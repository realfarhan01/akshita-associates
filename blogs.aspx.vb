
Partial Class blogs
    Inherits System.Web.UI.Page
    Dim BLL As New BusinessLogicLayer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim rptData As DataTable = BLL.ExecDataTableProc("Prc_GetBlogs", "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
            dtlData.DataSource = rptData
            dtlData.DataBind()


        End If
    End Sub

End Class
