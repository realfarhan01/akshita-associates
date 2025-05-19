
Partial Class Admin_AddNotification
    Inherits BasePage
    Dim BLL As New BusinessLogicLayer
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'BindClassNew()
        End If
    End Sub

    Protected Sub btnsubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsubmit.Click
        Try
            Dim res As String = BLL.AddNotice(txtnotification.Text, ddlnoti.SelectedValue, Session("User"), ddlnewclass.SelectedValue)
            litmsg.Text = Notifications.SuccessMessage(res)
        Catch ex As Exception
            litmsg.Text = Notifications.ErrorMessage("Sorry For Inconvenience.Please Try Again Later")
        End Try
    End Sub
End Class
