
Partial Class blog
    Inherits System.Web.UI.Page
    Dim BLL As New BusinessLogicLayer
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not Page.IsPostBack Then

    '        Dim rptData As DataTable = BLL.ExecDataTableProc("Prc_GetBlogs")
    '        dtlData.DataSource = rptData
    '        dtlData.DataBind()


    '    End If
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If Not Page.IsPostBack Then
                Dim PageName As String = ""
                If Not Request.QueryString("page") Is Nothing Then
                    PageName = Request.QueryString("page")
                    PageName = PageName.Replace("-blog", "")
                    Dim dr As SqlDataReader = BLL.ExecDataReaderProc("Prc_GetBlogs", "@Type", 2, "@PageURL", PageName, "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
                    While dr.Read
                        Page.Title = dr("PageTitle").ToString()
                        Page.MetaDescription = dr("MetaDescription").ToString()
                        Page.MetaKeywords = dr("MetaKeywords").ToString()
                        LitBlogTitle.Text = dr("BlogTitle").ToString()
                        LitBody.Text = dr("BlogContent").ToString()
                        LitHits.Text = Val(dr("Hits")) + 666
                        ImgBlog.ImageUrl = "images/blog/" & dr("ImageName").ToString()
                    End While
                    'LitHead.Text = bll.ExecScalar("Select MetaTag From tblContent Where UserName=@UserName and PageURL=@Page and Deactivated=0 and Deleted=0", "@Page", PageName, "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
                    'LitBody.Text = bll.ExecScalar("Select Content From tblContent Where UserName=@UserName and PageURL=@Page and Deactivated=0 and Deleted=0", "@Page", PageName, "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
                End If

                Dim website As String = System.Configuration.ConfigurationManager.AppSettings("url")
                Dim pageurl As String = PageName
                Dim username As String = System.Configuration.ConfigurationManager.AppSettings("UserName")
                Dim IPAddress As String = Request.ServerVariables("REMOTE_ADDR")
                If IPAddress <> "127.0.0.1" Then
                    Dim IPLocation As String = BLL.IPLocation()
                    Dim Location As String = geospilt(IPLocation, 4).ToString() & " - Latitude : " & geospilt(IPLocation, 8).ToString() & ", Longitude : " & geospilt(IPLocation, 9).ToString()
                    BLL.SaveWebsiteHit(website, pageurl, username, IPAddress, Location)
                End If
            End If
        Catch ex As Exception
            Response.Write(ex.ToString())
        End Try
    End Sub
    Public Function geospilt(ByVal IPLocation As String, ByVal Number As Integer) As String
        Dim location, ReturnData As String
        location = IPLocation
        Dim arr As Array
        arr = location.Split(";")
        ReturnData = arr(Number)
        Return ReturnData
    End Function

End Class
