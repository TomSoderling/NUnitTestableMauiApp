using System;
using NUnit.Framework;
using System.Collections.Generic;
using MauiAppToTest.Models;

namespace UnitTests.ReferenceUnitTests
{
    [TestFixture]
    public class TestCaseSource
    {
        // Purpose:
        //  Reference for how to use the NUnit TestCaseSource attribute with non-trival objects
        // Why is this needed:
        //  This is useful for supplying an object as input for a unit test,
        //  or a good way to reuse test case data for a collection of similar tests.


        // What if you want to supply an object as input for a test case?
        //[TestCase(new Waypoint { GeoCoordinate = new GeoCoordinate(44, -92) })] // my house
        //[TestCase(new Waypoint { GeoCoordinate = new GeoCoordinate(44, -83) })] // the office
        //[TestCase(new Waypoint { GeoCoordinate = new GeoCoordinate(44, -74) })] // garage
        //public void UnitUnderTest_ForGivenWaypoint_ExpectedResult(Waypoint waypointTestCase)
        //{
        //    // ...
        //
        //    // Assert
        //    Assert.AreEqual(waypointTestCase.GeoCoordinate.Latitude, 44);
        //}

        // Can't do this. "An attribute argument must be a constant expression..."
        // So instead you can do this:

        [TestCaseSource(nameof(WaypointTestCases))]
        public void UnitUnderTest_ForGivenWaypoint_ExpectedResult(Waypoint waypointTestCase)
        {
            // ...

            // Assert
            Assert.AreEqual(44, waypointTestCase.GeoCoordinate.Latitude);
        }

        // This will cause the above test to be executed 3 times, using each set of TestCaseData defined as the input: "my house", "the office", and "garage"
        private static IEnumerable<TestCaseData> WaypointTestCases => new List<TestCaseData>
        {
            new TestCaseData(new Waypoint { GeoCoordinate = new GeoCoordinate(44, -92) }).SetArgDisplayNames("my house"),
            new TestCaseData(new Waypoint { GeoCoordinate = new GeoCoordinate(44, -83) }).SetArgDisplayNames("the office"),
            new TestCaseData(new Waypoint { GeoCoordinate = new GeoCoordinate(44, -74) }).SetArgDisplayNames("garage")

            // If you want to supply multiple objects:
            //new TestCaseData(new object1(), new object2() ).SetArgDisplayNames("my house, my cabin"),
        };
    }
}

