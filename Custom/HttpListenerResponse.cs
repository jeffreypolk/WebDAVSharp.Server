using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDAVSharp.Server.Custom
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpListenerResponse
    {
        private System.Web.HttpResponseBase _res;
        /// <summary>
        /// 
        /// </summary>
        public HttpListenerResponse(System.Web.HttpResponseBase res)
        {
            _res = res;
        }

        /// <summary>
        /// 
        /// </summary>
        public long ContentLength64
        {
            get
            {
                throw new NotImplementedException();
            }
            internal set
            {
                //ignore
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string ContentType
        {
            get
            {
                return _res.ContentType;
            }
            internal set
            {
                _res.ContentType = value;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public System.Collections.Specialized.NameValueCollection Headers
        {
            get
            {
                return _res.Headers;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int StatusCode
        {
            get
            {
                return _res.StatusCode;
            }
            internal set
            {
                _res.StatusCode = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string StatusDescription
        {
            get
            {
                return _res.StatusDescription;
            }
            internal set
            {
                _res.StatusDescription = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Stream OutputStream
        {
            get
            {
                return _res.OutputStream;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Encoding ContentEncoding
        {
            get
            {
                return _res.ContentEncoding;
            }
            internal set
            {
                _res.ContentEncoding = value;
            }
        }

        internal void Close()
        {
            // do nothing
        }

        internal void AppendHeader(string name, string value)
        {
            Headers.Add(name, value);
        }
    }
}
