using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Xml;
using WebDAVSharp.Server.Adapters;
using WebDAVSharp.Server.Exceptions;
using WebDAVSharp.Server.Stores;

namespace WebDAVSharp.Server.MethodHandlers
{
    /// <summary>
    /// This class implements the <c>PROPFIND</c> HTTP method for WebDAV#.
    /// </summary>
    internal class WebDavHeadMethodHandler : WebDavMethodHandlerBase
    {

        #region Properties
        /// <summary>
        /// Gets the collection of the names of the HTTP methods handled by this instance.
        /// </summary>
        /// <value>
        /// The names.
        /// </value>
        public override IEnumerable<string> Names
        {
            get
            {
                return new[]
                {
                    "HEAD"
                };
            }
        }

        #endregion

        #region Functions

        /// <summary>
        /// Processes the request.
        /// </summary>
        /// <param name="server">The <see cref="WebDavServer" /> through which the request came in from the client.</param>
        /// <param name="context">The 
        /// <see cref="IHttpListenerContext" /> object containing both the request and response
        /// objects to use.</param>
        /// <param name="store">The <see cref="IWebDavStore" /> that the <see cref="WebDavServer" /> is hosting.</param>
        /// <exception cref="WebDavNotFoundException"><para>
        ///   <paramref name="context" /> specifies a request for a store item that does not exist.</para>
        /// <para>- or -</para>
        /// <para>
        ///   <paramref name="context" /> specifies a request for a store item that is not a document.</para></exception>
        /// <exception cref="WebDavConflictException"><paramref name="context" /> specifies a request for a store item using a collection path that does not exist.</exception>
        /// <param name="response"></param>
        /// <param name="request"></param>
        protected override void OnProcessRequest(
           WebDavServer server,
           IHttpListenerContext context,
           IWebDavStore store,
           XmlDocument request,
           XmlDocument response)
        {
            // Get the parent collection of the item

            IWebDavStoreCollection collection;
            IWebDavStoreItem item = null;
            //PATCH: Cyberduck and some windows ask HEAD of the root, and it was not supported.
            var uri = context.Request.Url;
            if (uri.Segments.Length == 1)
            {
                collection = store.Root;
                item = store.Root;
            }
            else
            {
                collection = GetParentCollection(server, store, uri);
                // Get the item from the collection
                item = GetItemFromCollection(collection, context.Request.Url);
            }
           
            /***************************************************************************************************
            * Send the response
            ***************************************************************************************************/
            
            // HttpStatusCode doesn't contain WebDav status codes, but HttpWorkerRequest can handle these WebDav status codes
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.StatusDescription = HttpWorkerRequest.GetStatusDescription((int)HttpStatusCode.OK);

            // set the headers of the response
            context.Response.ContentLength64 = 0;
            context.Response.AppendHeader("Content-Type", "text/html");
            context.Response.AppendHeader("Last-Modified", item.ModificationDate.ToUniversalTime().ToString("R"));

            context.Response.Close();
        }

        #endregion

    }
}