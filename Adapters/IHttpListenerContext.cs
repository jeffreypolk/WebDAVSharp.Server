using System.Net;

namespace WebDAVSharp.Server.Adapters
{
    /// <summary>
    /// This is an interface-version of the parts of 
    /// <see cref="HttpListenerContext" /> that
    /// the 
    /// <see cref="WebDavServer" /> requires to operator.
    /// </summary>
    /// <remarks>
    /// The main purpose of this interface is to facilitate unit-testing.
    /// </remarks>
    public interface IHttpListenerContext : IAdapter<HttpListenerContext>
    {
        /// <summary>
        /// Gets the <see cref="IHttpListenerRequest" /> request adapter.
        /// </summary>
        /// <value>
        /// The request.
        /// </value>
        IHttpListenerRequest Request
        {
            get;
        }

        /// <summary>
        /// Gets the <see cref="IHttpListenerResponse" /> response adapter.
        /// </summary>
        /// <value>
        /// The response.
        /// </value>
        IHttpListenerResponse Response
        {
            get;
        }

        /// <summary>
        /// Retrieve a context data set with <see cref="SetContextData(string, object)"/> method.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        object GetContextData(string key);

        /// <summary>
        /// Allow storing data for the current context.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        void SetContextData(string key, object data);
    }
}