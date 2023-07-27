using FakeItEasy;
using MauiAppToTest.Services;
using MauiAppToTest.ViewModels;
using NUnit.Framework;

namespace UnitTests.ViewModels
{
    [TestFixture]
	public class ExampleViewModelTests
	{
        [Test]
        public void DoSomeWork_StateUnderTest_ExpectedResult()
        {
            // Arrange
            const int Expected = 42;

            // You could create an instance of the ViewModel this way by injecting a faked instance of the interface(s) the constructor requires.
            // BUT when this ViewModel changes and we add more interfaces to be injected, or change the order of the constructor parameters,
            // every single test in this class will need to be updated. Major pain.
            var fakeUIThreadInvocation = A.Fake<IUIThreadInvocation>();
            var vm = new ExampleViewModel(fakeUIThreadInvocation);

            // Instead, use the InstanceBuilder class and let it create the test instance for you. You only need to supply the faked interfaces you
            // care about for your test method and InstanceBuilder will supply fakes for any of the other required interface constructor parameters.
            // This is the preferred way to create instances of any classes that use constructor dependency injection (ViewModels, Services, etc.)
            vm = InstanceBuilder<ExampleViewModel>.CreateBuilder()
                .WithOverride(fakeUIThreadInvocation)
                .Build();

            // Act
            var actual = vm.DoSomeWork();

            // Assert
            Assert.AreEqual(Expected, actual);
        }
    }
}

