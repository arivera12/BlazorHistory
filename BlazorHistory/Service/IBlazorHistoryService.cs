using System.Threading.Tasks;

namespace BlazorHistory
{
    public interface IBlazorHistoryService
    {
        /// <summary>
        /// This asynchronous method goes to the previous page in session history.
        /// </summary>
        /// <returns></returns>
        ValueTask Back();
        /// <summary>
        /// This asynchronous method goes to the next page in session history.
        /// </summary>
        /// <returns></returns>
        ValueTask Forward();
        /// <summary>
        /// Asynchronously loads a page from the session history, identified by its relative location to the current page.
        /// </summary>
        /// <param name="index">The index to move back or forward</param>
        /// <returns></returns>
        ValueTask Go(int index);
        /// <summary>
        /// Pushes the given data onto the session history stack.
        /// </summary>
        /// <typeparam name="T">The type of the state data</typeparam>
        /// <param name="stateData">The state of the data</param>
        /// <param name="pageTitle">The page title</param>
        /// <param name="url">The url to navigate</param>
        /// <returns></returns>
        ValueTask PushState<T>(T stateData, string pageTitle, string url);
        /// <summary>
        /// Updates the most recent entry on the history stack.
        /// </summary>
        /// <typeparam name="T">The type of the state data</typeparam>
        /// <param name="stateData">The state of the data</param>
        /// <param name="pageTitle">The page title</param>
        /// <param name="url">The url to navigate</param>
        /// <returns></returns>
        ValueTask ReplaceState<T>(T stateData, string pageTitle, string url);
        /// <summary>
        /// Returns an Integer representing the number of elements in the session history, including the currently loaded page.
        /// </summary>
        /// <returns></returns>
        ValueTask<int> Length();
        /// <summary>
        /// Allows web applications to explicitly set default scroll restoration behavior on history navigation. This property can be either auto or manual.
        /// </summary>
        /// <param name="scrollRestorationType"></param>
        /// <returns></returns>
        ValueTask ScrollRestoration(ScrollRestorationType scrollRestorationType);
        /// <summary>
        /// Allows web applications to explicitly get default scroll restoration behavior on history navigation. This property can be either auto or manual.
        /// </summary>
        /// <param name="scrollRestorationType">The scroll restoration type value</param>
        /// <returns></returns>
        ValueTask<ScrollRestorationType> ScrollRestoration();
        /// <summary>
        /// Returns an <typeparamref name="T"/> type representing the state at the top of the history stack.
        /// </summary>
        /// <typeparam name="T">The type of the state data</typeparam>
        /// <returns></returns>
        ValueTask<T> State<T>();
    }
}