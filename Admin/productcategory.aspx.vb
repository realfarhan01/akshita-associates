Imports System.Drawing
Imports System.Drawing.Drawing2D

Partial Class Admin_productcategory
    Inherits BasePage
    Dim BLL As New BusinessLogicLayer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            hfId.Value = 0
            showdata()
        End If
    End Sub

    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            Dim File As String = ""
            If FileUpload.HasFile Then
                If Not BLL.isImage(FileUpload.FileContent) Then
                    Exit Sub
                End If
                If FileUpload.PostedFile.ContentType.Split("/")(0) = "image" Then
                    'File = FileUpload.FileName
                    File = Guid.NewGuid().ToString & System.IO.Path.GetExtension(FileUpload.PostedFile.FileName)
                    FileUpload.SaveAs(Server.MapPath(System.Configuration.ConfigurationManager.AppSettings("productcategoryactualpath")) + File)
                    CreateThumbnail(400, Server.MapPath(System.Configuration.ConfigurationManager.AppSettings("productcategoryactualpath")) + File, Server.MapPath(System.Configuration.ConfigurationManager.AppSettings("productcategorypath")) + File)
                End If
            End If
            Dim user As String = System.Configuration.ConfigurationManager.AppSettings("UserName")
            BLL.ExecNonQueryProc("AddUpdate_ProductCategory", "@ProductCategoryId", hfId.Value, "@UserName", user, "@ProductCategory", txtProductCategory.Text, "@ProductCategoryImage", File, "@ShortDesc", txtShortDesc.Text, "@DeActivated", ddlStatus.SelectedValue)
            showdata()
            litmsg.Text = Notifications.SuccessMessage("Added Successfully.")
        Catch ex As Exception
            litmsg.Text = Notifications.ErrorMessage("Sorry For Inconvenience. Please Try Again Later")
        End Try

    End Sub
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
    Protected Sub DataDisplay_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles DataDisplay.RowCommand
        If e.CommandName = "Delete1" Then
            BLL.ExecNonQuery("Update tbl_ProductCategory Set Deactivated=2 Where ProductCategoryId=@cnt and UserName=@UserName", "@cnt", e.CommandArgument, "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
            showdata()
        ElseIf e.CommandName = "Deactivate1" Then
            hfId.Value = e.CommandArgument
            Dim dr As SqlDataReader = BLL.ExecDataReader("select * from tbl_ProductCategory where ProductCategoryId=@cnt and UserName=@UserName", "@cnt", e.CommandArgument, "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
            If dr.Read Then
                txtShortDesc.Text = dr("ShortDesc").ToString()
                txtProductCategory.Text = dr("ProductCategory").ToString()
            End If
            'BLL.ExecNonQuery("Update tbl_Gallary Set Deactivated=1 Where cnt=@cnt and UserName=@UserName", "@cnt", e.CommandArgument, "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
            showdata()
        End If
    End Sub
    Sub showdata()
        DataDisplay.DataSource = BLL.ExecDataTable("Select *,(Case when DeActivated=0 then 'Active' Else 'DeActive' End)Status from tbl_ProductCategory Where Deactivated<=1 and UserName=@UserName", "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
        DataDisplay.DataBind()
    End Sub

    'Protected Sub DataDisplay_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles DataDisplay.RowDataBound
    '    Dim img As Image
    '    Dim hf As HiddenField
    '    If e.Row.RowType = DataControlRowType.DataRow Then
    '        img = e.Row.FindControl("ImageURL")
    '        hf = e.Row.FindControl("hfimg")
    '        img.ImageUrl = "~/" & hf.Value.ToString

    '    End If
    'End Sub
End Class
