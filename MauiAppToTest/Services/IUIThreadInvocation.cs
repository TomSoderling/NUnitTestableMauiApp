namespace MauiAppToTest.Services
{
    public interface IUIThreadInvocation
    {
        void BeginInvoke(Action action);

        Task InvokeOnMainThreadAsync(Action action);

        Task InvokeOnMainThreadAsync(Func<Task> func);

        Task<T> InvokeOnMainThreadAsync<T>(Func<T> func);

        Task<T> InvokeOnMainThreadAsync<T>(Func<Task<T>> func);
    }

    public class UIThreadInvocation : IUIThreadInvocation
    {
        public void BeginInvoke(Action action)
        {
            MainThread.BeginInvokeOnMainThread(action);
        }

        public Task InvokeOnMainThreadAsync(Action action)
        {
            return MainThread.InvokeOnMainThreadAsync(action);
        }

        public Task InvokeOnMainThreadAsync(Func<Task> func)
        {
            return MainThread.InvokeOnMainThreadAsync(func);
        }

        public Task<T> InvokeOnMainThreadAsync<T>(Func<T> func)
        {
            return MainThread.InvokeOnMainThreadAsync(func);
        }

        public Task<T> InvokeOnMainThreadAsync<T>(Func<Task<T>> func)
        {
            return MainThread.InvokeOnMainThreadAsync(func);
        }
    }
}