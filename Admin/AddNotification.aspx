<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="false" CodeFile="AddNotification.aspx.vb" Inherits="Admin_AddNotification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C1" Runat="Server">
<div class="form-horizontal" >



                <!-- Basic inputs -->
                <div class="panel panel-default">
                    <div class="panel-heading"><h6 class="panel-title">Add Notification </h6></div>
                    <div class="panel-body">
                   
                       <%-- <div class="alert alert-info fade in widget-inner">
                            <button type="button" class="close" data-dismiss="alert">×</button>
                            Default form components, including bootstrap additions and tags
                        </div>--%>
                        <asp:Literal ID="litmsg" runat="server"></asp:Literal>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Notification For </label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlnoti" class="select-search" AutoPostBack="true" AppendDataBoundItems="true" runat="server">
                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                  <asp:ListItem Value="Student">Student</asp:ListItem>
                                    <asp:ListItem Value="Parent">Parent</asp:ListItem>
                                      <asp:ListItem Value="Employee">Employee</asp:ListItem>
                                </asp:DropDownList>
                            
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" InitialValue="0" ControlToValidate="ddlnoti"
                ErrorMessage="*" ValidationGroup="UserRegistration">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">Notification </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtnotification" class="form-control" runat="server"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtnotification"
                ErrorMessage="*" ValidationGroup="UserRegistration">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Class Name</label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlnewclass" class="select-search" AppendDataBoundItems="true" runat="server">
                               
                                <asp:ListItem Value="0">--ALL Classes--</asp:ListItem>
                                </asp:DropDownList>
                             
                                  
                            </div>
                        </div>
                    
                        
                            <div class="form-actions text-right">
                                <asp:Button ID="btnsubmit" runat="server" ValidationGroup="UserRegistration" class="btn btn-primary" Text="Submit" />
                       
                        </div>
                     
                        </div>
                        </div></div>

</asp:Content>

