using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebDAVSharp.Server.Custom
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpListenerRequest
    {

        private System.Web.HttpRequestBase _req;
        /// <summary>
        /// 
        /// </summary>
        public HttpListenerRequest(System.Web.HttpRequestBase req)
        {
            _req = req;
        }

        /// <summary>
        /// 
        /// </summary>
        public Encoding ContentEncoding
        {
            get
            {
                return _req.ContentEncoding;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public long ContentLength64
        {
            get
            {
                return _req.ContentLength;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public NameValueCollection Headers
        {
            get
            {
                return _req.Headers;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string HttpMethod
        {
            get
            {
                return _req.HttpMethod;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Stream InputStream
        {
            get
            {
                return _req.InputStream;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IPEndPoint RemoteEndPoint
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Uri Url
        {
            get
            {
                return _req.Url;
            }
        }
    }
}
