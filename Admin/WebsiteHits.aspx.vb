Imports System.Data.OleDb
Imports System.IO
Partial Class Admin_WebsiteHits
    Inherits BasePage
    Dim BLL As New BusinessLogicLayer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'BindClass()
            bind()
        End If
    End Sub
    Sub bind()
        DataDisplay.DataSource = BLL.ExecDataTableProc("Prc_GetWebsiteHits", "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
        DataDisplay.DataBind()
    End Sub

    Protected Sub DataDisplay_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles DataDisplay.PageIndexChanging
        DataDisplay.PageIndex = e.NewPageIndex
        bind()
    End Sub

End Class
