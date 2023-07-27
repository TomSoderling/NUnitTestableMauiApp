using MauiAppToTest.Models;
using NUnit.Framework;

namespace UnitTests;

[TestFixture]
public class AddressTests
{
    // This empty test is to show the test naming pattern and the AAA pattern for structuring the code inside the test method
    [Test]
    public void UnitUnderTest_StateUnderTest_ExpectedResult()
    {
        // Arrange

        // Act

        // Assert
    }

    [Test]
    public void Clone_WithNonNullValues_ReturnsDifferentInstanceThanOriginal()
    {
        // Arrange
        var original = new Address();

        // Act
        var cloned = original.Clone();

        // Assert
        Assert.That(cloned, Is.Not.SameAs(original));
    }

    [Test]
    public void Clone_WithNonNullValues_ReturnsIdenticalClone()
    {
        // Arrange
        var original = new Address
        {
            Street = "Test Street",
            City = "Test City",
            State = "Test State",
            PostalCode = "Test Postal Code",
            County = "Test County",
            Country = "Test Country"
        };

        // Act
        var cloned = original.Clone();

        // Assert
        Assert.That(cloned.Street, Is.EqualTo(original.Street), nameof(original.Street));
        Assert.That(cloned.City, Is.EqualTo(original.City), nameof(original.City));
        Assert.That(cloned.State, Is.EqualTo(original.State), nameof(original.State));
        Assert.That(cloned.PostalCode, Is.EqualTo(original.PostalCode), nameof(original.PostalCode));
        Assert.That(cloned.County, Is.EqualTo(original.County), nameof(original.County));
        Assert.That(cloned.Country, Is.EqualTo(original.Country), nameof(original.Country));
    }

    [Test]
    public void Clone_WithNullCity_DoesNotThrowException()
    {
        // Arrange
        var original = new Address
        {
            City = null
        };

        // Act
        TestDelegate methodUnderTest = () => original.Clone();

        // Assert
        Assert.DoesNotThrow(methodUnderTest);
    }
}