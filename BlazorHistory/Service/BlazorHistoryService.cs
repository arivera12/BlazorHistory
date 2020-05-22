using Microsoft.JSInterop;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlazorHistory
{
    internal class BlazorHistoryService : IBlazorHistoryService
    {
        /// <summary>
        /// The jsruntime
        /// </summary>
        private readonly IJSRuntime JsRuntime;
        /// <summary>
        /// Constructor with the jsruntime
        /// </summary>
        /// <param name="jSRuntime"></param>
        public BlazorHistoryService(IJSRuntime jSRuntime)
        {
            JsRuntime = jSRuntime;
        }
        /// <summary>
        /// This asynchronous method goes to the previous page in session history.
        /// </summary>
        /// <returns></returns>
        public ValueTask Back() => JsRuntime.InvokeVoidAsync("window.history.back");
        /// <summary>
        /// This asynchronous method goes to the next page in session history.
        /// </summary>
        /// <returns></returns>
        public ValueTask Forward() => JsRuntime.InvokeVoidAsync("window.history.forward");
        /// <summary>
        /// Asynchronously loads a page from the session history, identified by its relative location to the current page.
        /// </summary>
        /// <param name="index">The index to move back or forward</param>
        /// <returns></returns>
        public ValueTask Go(int index) => JsRuntime.InvokeVoidAsync("window.history.go", index);
        /// <summary>
        /// Pushes the given data onto the session history stack.
        /// </summary>
        /// <typeparam name="T">The type of the state data</typeparam>
        /// <param name="stateData">The state of the data</param>
        /// <param name="pageTitle">The page title</param>
        /// <param name="url">The url to navigate</param>
        /// <returns></returns>
        public ValueTask PushState<T>(T data, string page, string url)
        {
            return JsRuntime.InvokeVoidAsync("window.history.pushState", JsonConvert.SerializeObject(data), page, url);
        }
        /// <summary>
        /// Updates the most recent entry on the history stack.
        /// </summary>
        /// <typeparam name="T">The type of the state data</typeparam>
        /// <param name="stateData">The state of the data</param>
        /// <param name="pageTitle">The page title</param>
        /// <param name="url">The url to navigate</param>
        /// <returns></returns>
        public ValueTask ReplaceState<T>(T data, string page, string url)
        {
            return JsRuntime.InvokeVoidAsync("window.history.replaceState", JsonConvert.SerializeObject(data), page, url);
        }
        /// <summary>
        /// Returns an Integer representing the number of elements in the session history, including the currently loaded page
        /// </summary>
        /// <returns></returns>
        public ValueTask<int> Length() => JsRuntime.InvokeAsync<int>("eval", "window.history.length");
        /// <summary>
        /// Returns an <typeparamref name="T"/> type representing the state at the top of the history stack.
        /// </summary>
        /// <typeparam name="T">The type of the state data</typeparam>
        /// <returns></returns>
        public async ValueTask<T> State<T>() => JsonConvert.DeserializeObject<T>(await JsRuntime.InvokeAsync<string>("eval", "window.history.state"));
        /// <summary>
        /// Allows web applications to explicitly set default scroll restoration behavior on history navigation. This property can be either auto or manual.
        /// </summary>
        /// <param name="scrollRestorationType"></param>
        /// <returns></returns>
        public ValueTask ScrollRestoration(ScrollRestorationType scrollRestorationType)
        {
            return JsRuntime.InvokeVoidAsync("eval", $"window.history.scrollRestoration = '{scrollRestorationType}'");
        }
        /// <summary>
        /// Allows web applications to explicitly get default scroll restoration behavior on history navigation. This property can be either auto or manual.
        /// </summary>
        /// <param name="scrollRestorationType"></param>
        /// <returns></returns>
        public async ValueTask<ScrollRestorationType> ScrollRestoration()
        {
            return ScrollRestorationType.FromString(await JsRuntime.InvokeAsync<string>("eval", $"window.history.scrollRestoration"));
        }
    }
}
