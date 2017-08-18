using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDAVSharp.Server.Custom
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpListenerContext
    {
        /// <summary>
        /// 
        /// </summary>
        public HttpListenerRequest Request
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        public HttpListenerResponse Response
        {
            get; set;
        }

        /// <summary>
        /// 
        /// </summary>
        public System.Security.Principal.IPrincipal User {
            get
            {
                System.Security.Principal.WindowsIdentity current = System.Security.Principal.WindowsIdentity.GetCurrent();
                System.Security.Principal.IPrincipal principal = new System.Security.Principal.WindowsPrincipal(current);
                return principal;
            }
            internal set {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public HttpListenerContext (System.Web.HttpRequestBase req, System.Web.HttpResponseBase res)
        {
            Request = new HttpListenerRequest(req);
            Response = new HttpListenerResponse(res);
        }
    }
}
