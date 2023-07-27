using FakeItEasy;
using MauiAppToTest.Services;
using Microsoft.Maui.ApplicationModel;
using NUnit.Framework;

namespace UnitTests.ReferenceUnitTests
{
    [TestFixture]
    public class Device_BeginInvokeOnMainThread
    {
        // Purpose:
        //  Reference for how to unit test code in a method that has a Device.BeginInvokeOnMainThread() or InvokeOnMainThreadAsync() code block in it.
        //  In .NET MAUI these methods are now in the MainThread static class.

        // Why is this needed:
        //  The MainThread class comes from the Maui.ApplicationModel namespace and creates a difficult dependency for the unit test project.
        //  Since these unit tests don't run on a mobile device, they can't execute MainThread.BeginInvokeOnMainThread() code blocks or move
        //  past them. You get the following error message on test execution:
        //  "Microsoft.Maui.ApplicationModel.NotImplementedInReferenceAssemblyException : This functionality is not implemented in the portable
        //  version of this assembly. You should reference the NuGet package from your main application project in order to reference the
        //  platform-specific implementation."

        //  Trying to Initialize MAUI is a whole lot of overhead for a unit test, so the better approach is to remove this difficult dependency
        //  on Maui.ApplicationModel by using the IUIThreadInvocation interface instead. That allows you to provide a fake instance of
        //  IUIThreadInvocation in the unit test code for your ViewModel/Service.

        // This testing approach requires some changes to the code:
        // 1.) Inject IUIThreadInvocation into your ViewModel or Service constructor
        // 2.) Replace usage of MainThread.BeginInvokeOnMainThread() with uIThreadInvocation.BeginInvoke() instead


        // ViewModel class for illustration of problem
        private class MyViewModel
        {
            public MyViewModel()
            {
            }

            public int ImportantCodeToUnitTest()
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    // does something on main thread
                });

                // Important code to unit test down here
                return 1 + 2 + 39;
            }
        }

        // Uncomment this unit test method to see the test fail.
        //[Test]
        //public void ImportantCodeToUnitTest_UsesBeginInvokeOnMainThread_ShouldExecuteImportantCode()
        //{
        //    // Arrange
        //    var viewModel = new MyViewModel();

        //    // Act
        //    var actual = viewModel.ImportantCodeToUnitTest();

        //    // Assert - we'll never get here because a NotImplementedInReferenceAssemblyException is thrown by the line above.
        //    Assert.AreEqual(42, actual);
        //}



        // ViewModel class for illustration of solution
        private class MyBetterViewModel
        {
            private readonly IUIThreadInvocation uIThreadInvocation;

            // 1.) Inject IUIThreadInvocation into constructor
            public MyBetterViewModel(IUIThreadInvocation uIThreadInvocation)
            {
                this.uIThreadInvocation = uIThreadInvocation;
            }

            public int ImportantCodeToUnitTest()
            {
                // 2.) Replace usage of Device.BeginInvokeOnMainThread() with uIThreadInvocation.BeginInvoke() instead
                uIThreadInvocation.BeginInvoke(() =>
                {
                    // does something on main thread
                });

                // Important code to unit test down here
                return 1 + 2 + 39;
            }
        }

        [Test]
        public void ImportantCodeToUnitTest_UsesUIThreadInvocation_ShouldExecuteImportantCode()
        {
            // Arrange
            var fakeUIThreadInvocation = A.Fake<IUIThreadInvocation>();    // fake an instance of IUIThreadInvocation
            var viewModel = new MyBetterViewModel(fakeUIThreadInvocation); // pass it in for use in your ViewModel

            // Act
            var actual = viewModel.ImportantCodeToUnitTest();

            // Assert
            Assert.AreEqual(42, actual);
        }
    }
}

