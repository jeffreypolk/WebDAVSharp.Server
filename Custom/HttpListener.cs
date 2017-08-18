using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebDAVSharp.Server.Custom
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpListener
    {
        private System.Net.HttpListener _listener = new System.Net.HttpListener();

        internal readonly bool IsListening;
        internal HttpListenerPrefixCollection Prefixes
        {
            get
            {
                return _listener.Prefixes;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public System.Net.AuthenticationSchemes AuthenticationSchemes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool UnsafeConnectionNtlmAuthentication { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AuthenticationSchemeSelector AuthenticationSchemeSelectorDelegate { get; internal set; }

        internal void Close()
        {
            throw new NotImplementedException();
        }

        internal IAsyncResult BeginGetContext(object p1, object p2)
        {
            throw new NotImplementedException();
        }

        internal Custom.HttpListenerContext EndGetContext(IAsyncResult ar)
        {
            throw new NotImplementedException();
        }

        internal void Start()
        {
            throw new NotImplementedException();
        }

        internal void Stop()
        {
            throw new NotImplementedException();
        }
        
    }
}
