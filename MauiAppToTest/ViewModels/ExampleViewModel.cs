using System;
using MauiAppToTest.Services;

namespace MauiAppToTest.ViewModels
{
    /// <summary>
    /// This is an example ViewModel to help illustrate unit testing best practices. See ExampleViewModelTests
    /// </summary>
    public class ExampleViewModel
    {
	private readonly IUIThreadInvocation uIThreadInvocation;

        public ExampleViewModel(IUIThreadInvocation uIThreadInvocation) // this service is being injected here just for illustration purposes
        {
	    this.uIThreadInvocation = uIThreadInvocation;
        }

	public string PageTitle { get; set; }

        public int DoSomeWork()
        {
            uIThreadInvocation.BeginInvoke(() =>
            {
                // does something on main thread
            });

            // Important code to unit test down here
            return 1 + 2 + 39;
        }
    }
}
