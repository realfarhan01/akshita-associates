
Partial Class content
    Inherits BasePage
    Dim BLL As New BusinessLogicLayer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Page.Title = "Advance MLM Softwares - Contact"
            'Page.MetaDescription = "Contact Advance MLM Softwares for Best MLM Software Development in India. Our support team will get back to you during standard business hours."
            'Page.MetaKeywords = "Contact Advance MLM Softwares, MLM Software Development Company, Multi Level Marketing, MLM Plan Demo, MLM Software Demo"

            ddlContent.DataSource = BLL.ExecDataTable("select contentid,PageName from tblcontent Where UserName=@UserName and Deleted=0", "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
            ddlContent.DataValueField = "contentid"
            ddlContent.DataTextField = "PageName"
            ddlContent.DataBind()

            showData()
        End If

    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        BLL.ExecNonQueryProc("Prc_UpdateContent", "@ContentId", ddlContent.SelectedValue, "@Content", txtcontent.Text, "@MetaTag", txtMetaTag.Text, "@PageTitle", txtPageTitle.Text, "@MetaDescription", txtMetaDescription.Text, "@MetaKeywords", txtMetaKeywords.Text, "@Deactivated", 0, "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
    End Sub
    Private Sub showData()

        Dim dr As SqlDataReader = BLL.ExecDataReader("select Content,Deactivated,PageURL,MetaTag,PageTitle,MetaDescription,MetaKeywords from tblcontent where contentid=@ContentId", "@ContentId", ddlContent.SelectedValue)
        While dr.Read
            txtcontent.Text = dr("Content")
            txtMetaTag.Text = dr("MetaTag")
            txtPageURL.Text = dr("PageURL")
            txtPageTitle.Text = dr("PageTitle")
            txtMetaDescription.Text = dr("MetaDescription")
            txtMetaKeywords.Text = dr("MetaKeywords")
            'chkshow.Checked = False
            'If dr("Content").ToString() = "1" Then
            '    chkshow.Checked = True
            'End If
        End While

    End Sub
   
    Protected Sub ddlContent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlContent.SelectedIndexChanged
        showData()
    End Sub
End Class
