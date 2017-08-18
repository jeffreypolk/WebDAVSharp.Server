Imports System.Web.Mvc
Imports WebDAVSharp.Server
Imports WebDAVSharp.Server.Adapters
Imports WebDAVSharp.Server.Stores

Namespace Controllers
    Public Class WebDAVController
        Inherits Controller

        ' GET: WebDAV
        Function Index() As WebDavResult

            Dim Ret As New WebDavResult()

            'runtime variables
            Dim DocumentLocation As String = "C:\Development\Prototypes\WebDavSharp\docs"
            Dim WebDavRoot As String = "http://localhost:4303/WebDav/Index/a9e1e4ad-3691-436c-8680-d83be36d24c3/"


            'set up context with the MVC Request and Response objects
            Dim context As IHttpListenerContext = New HttpListenerContextAdapter(New Custom.HttpListenerContext(Request, Response))


            ' set up store and server
            Dim store As IWebDavStore = New DiskStore.WebDavDiskStore(DocumentLocation)
            Dim server As New WebDavServer(store, AuthType.Anonymous)
            server.SetUrlRoot(WebDavRoot)
            'set identity to the app pool user
            server.SetIdentity(context)


            'call the request handler
            Dim Handler As MethodHandlers.IWebDavMethodHandler = server.GetMethodHandler(Request.HttpMethod)
            Handler.ProcessRequest(server, context, store, New System.Xml.XmlDocument, New System.Xml.XmlDocument)


            'done
            Return Ret

        End Function

    End Class

End Namespace