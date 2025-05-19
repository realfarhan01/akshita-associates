
Partial Class Admin_AddEvent
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
            BLL.AddEvent(hfId.Value, txttitle.Text, txtEvent.Text, txtLocation.Text, txtDate.Text, txtEvent.Text, ddlStatus.SelectedValue, System.Configuration.ConfigurationManager.AppSettings("UserName"))
            hfId.Value = 0
            showdata()
            litmsg.Text = Notifications.SuccessMessage("Added Successfully.")
        Catch ex As Exception
            litmsg.Text = Notifications.ErrorMessage("Sorry For Inconvenience.Please Try Again Later")
        End Try

    End Sub
    Protected Sub DataDisplay_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles DataDisplay.RowCommand
        If e.CommandName = "edit1" Then
            Dim dr As SqlDataReader = BLL.ExecDataReader("select *,convert(varchar,ondate,103) ondate1 from tbl_Events where cnt=@cnt and UserName=@UserName", "@cnt", e.CommandArgument, "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
            If dr.Read() Then
                txtEvent.Text = dr("EventDetail")
                txttitle.Text = dr("Title")
                txtDate.Text = dr("ondate1")
                txtLocation.Text = dr("Location")
                txtTime.Text = dr("EventTime")
                ddlStatus.SelectedValue = dr("Deactivated")
                hfId.Value = e.CommandArgument
            End If
        ElseIf e.CommandName = "Delete1" Then
            BLL.ExecNonQuery("Update tbl_Events Set Deleted=1,Deactivated=1 Where cnt=@cnt and UserName=@UserName", "@cnt", e.CommandArgument, "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
            showdata()
        End If
    End Sub
    Sub showdata()
        DataDisplay.DataSource = BLL.ExecDataTable("select *,case when Deactivated=0 then 'Active' else 'Deactive' End Status from tbl_Events Where Deleted=0 and UserName=@UserName", "@UserName", System.Configuration.ConfigurationManager.AppSettings("UserName"))
        DataDisplay.DataBind()
    End Sub

End Class
