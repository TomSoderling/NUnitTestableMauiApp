using System;
using FakeItEasy;
using NUnit.Framework;

namespace UnitTests.ReferenceUnitTests
{
    [TestFixture]
    public class ThrowException
    {
        // Purpose:
        //  Reference unit test to illustrate using FakeItEasy.Throws<T>() to force a method to throw an exception.
        // Why is this needed:
        //  This is useful for testing how your method responds to exceptional circumstances.

        [Test]
        public void DoStuff_ImportantServiceThrowsException_HandlesExceptionCase()
        {
            // Arrange
            var fakeMyImportantService = A.Fake<IMyImportantService>();
            A.CallTo(() => fakeMyImportantService.DoImportantStuff()).Throws<NullReferenceException>(); // Force the service method to throw an exception

            var vm = new SomeViewModel(fakeMyImportantService);

            // Act & Assert
            Assert.DoesNotThrow(() => vm.DoStuff()); // Assert that the method under test doesn't throw an exception, meaning it handles it correcty
        }
    }



    public interface IMyImportantService
    {
        public int DoImportantStuff();
    }

    public class MyImportantService : IMyImportantService
    {
        public int DoImportantStuff()
        {
            return 31 + 10 + 1;
        }
    }

    public class SomeViewModel
    {
        private readonly IMyImportantService myImportantService;

        public SomeViewModel(IMyImportantService myImportantService)
        {
            this.myImportantService = myImportantService;
        }

        public void DoStuff()
        {
            try // comment out these try/catch lines to see the test fail
            {
                var result = myImportantService.DoImportantStuff();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"{ex}");

                // Don't
                // 1.) swallow the exception (typically) - if it's a fire & forget or you absolutely must, at least add a comment as to why

                // Be Careful
                // 1.) re-throwing exception
                ///    if you must: throw;  Include inner exception
                ///    bad option: throw ex or throw new Exception(ex) messes up stack trace

                // What to consider when handling an exception:
                // 1.) Who needs to know? Does the user need to know?
                // 2.) Should this be logged to Raygun?
                // 3.) Can I recover from this execption? Engage DDX
                // 4.) Should I let this exception bubble up? Should it be a specfic/custom exception type?
                // More reading: https://docs.microsoft.com/en-us/dotnet/standard/exceptions/best-practices-for-exceptions
            }

            // Do something with result here...
        }
    }
}

