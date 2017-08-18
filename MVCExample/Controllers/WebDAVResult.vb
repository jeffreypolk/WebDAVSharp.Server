Public Class WebDavResult
    Inherits ActionResult

    Public Overrides Sub ExecuteResult(context As ControllerContext)
        'Do nothing.  The controller uses WebDAVServer to set everything in the Response
    End Sub
End Class
