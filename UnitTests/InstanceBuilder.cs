using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FakeItEasy.Sdk;

namespace UnitTests;

public class InstanceBuilder<TObject>
{
    public static InstanceBuilder<TObject> CreateBuilder() => new InstanceBuilder<TObject>();

    protected Type ObjectType { get; }

    protected ConstructorInfo ConstructorInfo { get; }

    protected Dictionary<Type, ParameterInfo> ConstructorParameterInfos { get; }

    protected Dictionary<Type, object> Overrides { get; } = new Dictionary<Type, object>();

    private InstanceBuilder()
    {
        // Get the constructor with the most parameter.
        ObjectType = typeof(TObject);
        ConstructorInfo = ObjectType.GetConstructors().OrderByDescending(c => c.GetParameters().Count()).FirstOrDefault();
        ConstructorParameterInfos = ConstructorInfo.GetParameters().ToDictionary(key => key.ParameterType, val => val);
    }

    public InstanceBuilder<TObject> WithOverride<TOverride>(TOverride overrideInstance)
    {
        return WithOverride(typeof(TOverride), overrideInstance);
    }

    public InstanceBuilder<TObject> WithOverride(Type overrideType, object overrideInstance)
    {
        ValidateOverrideType(overrideType);

        var overrideInstanceType = overrideInstance.GetType();
        if (!overrideType.IsAssignableFrom(overrideInstanceType))
        {
            throw new InvalidOperationException($"Cannot use override {overrideInstanceType.Name} for {overrideType.Name}");
        }

        Overrides[overrideType] = overrideInstance;

        return this;
    }

    public InstanceBuilder<TObject> WithNullInstanceOverride(Type overrideType)
    {
        ValidateOverrideType(overrideType);

        Overrides[overrideType] = null;

        return this;
    }

    public TObject Build()
    {
        var parameterInstances = new List<object>();

        foreach (var paramInfo in ConstructorParameterInfos.Values)
        {
            var paramType = paramInfo.ParameterType;
            if (Overrides?.ContainsKey(paramType) == true)
            {
                parameterInstances.Add(Overrides[paramType]);
            }
            else
            {
                // Creates a fake instance if none is provided.
                parameterInstances.Add(Create.Fake(paramInfo.ParameterType));
            }
        }
        return (TObject)ConstructorInfo.Invoke(parameterInstances.ToArray());
    }

    private void ValidateOverrideType(Type type)
    {
        if (!ConstructorParameterInfos.ContainsKey(type))
        {
            throw new InvalidOperationException($"No constructor parameter of type {type.Name} exists for {typeof(TObject).Name}");
        }
    }
}
