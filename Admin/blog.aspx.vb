Imports System.Drawing
Imports System.Drawing.Drawing2D
Partial Class blog
    Inherits BasePage
    Dim BLL As New BusinessLogicLayer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Page.Title = "Advance MLM Softwares - Contact"
            'Page.MetaDescription = "Contact Advance MLM Softwares for Best MLM Software Development in India. Our support team will get back to you during standard business hours."
            'Page.MetaKeywords = "Contact Advance MLM Softwares, MLM Software Development Company, Multi Level Marketing, MLM Plan Demo, MLM Software Demo"

            'ddlContent.DataSource = BLL.ExecDataTable("select contentid,PageName from tblcontent Where UserName=@UserName and Deleted=0", "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
            'ddlContent.DataValueField = "contentid"
            'ddlContent.DataTextField = "PageName"
            'ddlContent.DataBind()
            hfId.Value = 0
            divAdd.Visible = False
            divData.Visible = True
            showdata()
        End If

    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Try
            Dim File As String = ""
            If FileUpload.HasFile Then
                File = txtPageURL.Text
                If Not BLL.isImage(FileUpload.FileContent) Then
                    Exit Sub
                End If
                If FileUpload.PostedFile.ContentType.Split("/")(0) = "image" Then
                    'File = FileUpload.FileName
                    File = File & System.IO.Path.GetExtension(FileUpload.PostedFile.FileName)
                    FileUpload.SaveAs(Server.MapPath("../images/blog/origional/") + File)
                    CreateThumbnail(800, Server.MapPath("../images/blog/origional/") + File, Server.MapPath("../images/blog/") + File)
                    CreateThumbnail(400, Server.MapPath("../images/blog/origional/") + File, Server.MapPath("../images/blog/") + "thumbnail/" + File)
                End If
            End If
            BLL.AddUpdate_Blog(hfId.Value, txtBlogTitle.Text, txtcontent.Text, System.Configuration.ConfigurationManager.AppSettings("UserName"), File, txtMetaTag.Text, txtPageURL.Text, txtPageTitle.Text, txtMetaDescription.Text, txtMetaKeywords.Text, ddlStatus.SelectedValue)

            divAdd.Visible = False
            divData.Visible = True
            showdata()
        Catch ex As Exception

        End Try
    End Sub
    Sub showdata()
        DataDisplay.DataSource = BLL.ExecDataTableProc("Prc_GetBlogs", "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
        DataDisplay.DataBind()
    End Sub
    Protected Sub DataDisplay_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles DataDisplay.RowCommand
        If e.CommandName = "edit1" Then
            Dim dr As SqlDataReader = BLL.ExecDataReader("select * from tblBlogs where BlogId=@BlogId and UserName=@UserName", "@BlogId", e.CommandArgument, "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
            If dr.Read() Then
                txtBlogTitle.Text = dr("BlogTitle")
                txtcontent.Text = dr("BlogContent")
                txtMetaTag.Text = dr("MetaTag")
                txtPageURL.Text = dr("PageURL")
                txtPageTitle.Text = dr("PageTitle")
                txtMetaDescription.Text = dr("MetaDescription")
                txtMetaKeywords.Text = dr("MetaKeywords")
                ddlStatus.SelectedValue = dr("Deactivated")
                hfId.Value = e.CommandArgument
                divAdd.Visible = True
                divData.Visible = False
            End If
        ElseIf e.CommandName = "Delete1" Then
            BLL.ExecNonQuery("Update tblBlogs Set Deleted=1,Deactivated=1 Where BlogId=@BlogId and UserName=@UserName", "@BlogId", e.CommandArgument, "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
            showdata()
        End If
    End Sub
    'Private Sub showData()

    '    Dim dr As SqlDataReader = BLL.ExecDataReader("select Content,Deactivated,PageURL,MetaTag,PageTitle,MetaDescription,MetaKeywords from tblcontent where contentid=@ContentId", "@ContentId", ddlContent.SelectedValue)
    '    While dr.Read
    '        txtcontent.Text = dr("Content")
    '        txtMetaTag.Text = dr("MetaTag")
    '        txtPageURL.Text = dr("PageURL")
    '        txtPageTitle.Text = dr("PageTitle")
    '        txtMetaDescription.Text = dr("MetaDescription")
    '        txtMetaKeywords.Text = dr("MetaKeywords")
    '        'chkshow.Checked = False
    '        'If dr("Content").ToString() = "1" Then
    '        '    chkshow.Checked = True
    '        'End If
    '    End While

    'End Sub

    'Protected Sub ddlContent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlContent.SelectedIndexChanged
    '    showData()
    'End Sub
    Sub CreateThumbnail(ByVal ThumbnailMax As Integer, ByVal OriginalImagePath As String, ByVal ThumbnailImagePath As String)
        ' Loads original image from file
        Dim imgOriginal As Image = Image.FromFile(OriginalImagePath)
        ' Finds height and width of original image
        Dim OriginalHeight As Single = imgOriginal.Height
        Dim OriginalWidth As Single = imgOriginal.Width
        ' Finds height and width of resized image
        Dim ThumbnailWidth As Integer
        Dim ThumbnailHeight As Integer
        If OriginalHeight > OriginalWidth Then
            ThumbnailHeight = ThumbnailMax
            ThumbnailWidth = (OriginalWidth / OriginalHeight) * ThumbnailMax
        Else
            ThumbnailWidth = ThumbnailMax
            ThumbnailHeight = (OriginalHeight / OriginalWidth) * ThumbnailMax
        End If
        ' Create new bitmap that will be used for thumbnail
        Dim ThumbnailBitmap As Bitmap = New Bitmap(ThumbnailWidth, ThumbnailHeight)
        Dim ResizedImage As Graphics = Graphics.FromImage(ThumbnailBitmap)
        ' Resized image will have best possible quality
        ResizedImage.InterpolationMode = InterpolationMode.HighQualityBicubic
        ResizedImage.CompositingQuality = CompositingQuality.HighQuality
        ResizedImage.SmoothingMode = SmoothingMode.HighQuality
        ' Draw resized image
        ResizedImage.DrawImage(imgOriginal, 0, 0, ThumbnailWidth, ThumbnailHeight)
        ' Save thumbnail to file
        ThumbnailBitmap.Save(ThumbnailImagePath)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        divAdd.Visible = True
        divData.Visible = False
    End Sub

    Private Sub txtBlogTitle_TextChanged(sender As Object, e As EventArgs) Handles txtBlogTitle.TextChanged
        txtPageTitle.Text = txtBlogTitle.Text
        Dim pageurl As String = ""
        pageurl = Replace(txtBlogTitle.Text, " ", "-").ToLower()
        pageurl = Replace(pageurl, "&", "")
        pageurl = Replace(pageurl, "/", "")
        pageurl = Replace(pageurl, "#", "")
        pageurl = Replace(pageurl, "!", "")
        pageurl = Replace(pageurl, "@", "")
        pageurl = Replace(pageurl, "#", "")
        pageurl = Replace(pageurl, "$", "")
        pageurl = Replace(pageurl, "%", "")
        pageurl = Replace(pageurl, "^", "")
        pageurl = Replace(pageurl, "*", "")
        pageurl = Replace(pageurl, "{", "")
        pageurl = Replace(pageurl, "}", "")
        pageurl = Replace(pageurl, ":", "")
        pageurl = Replace(pageurl, ";", "")
        pageurl = Replace(pageurl, """", "")
        pageurl = Replace(pageurl, "'", "")
        pageurl = Replace(pageurl, "|", "")
        pageurl = Replace(pageurl, "\", "")
        pageurl = Replace(pageurl, ">", "")
        pageurl = Replace(pageurl, ".", "")
        pageurl = Replace(pageurl, ",", "")
        pageurl = Replace(pageurl, "<", "")
        pageurl = Replace(pageurl, "~", "")
        pageurl = Replace(pageurl, "+", "")
        txtPageURL.Text = pageurl
    End Sub
End Class
