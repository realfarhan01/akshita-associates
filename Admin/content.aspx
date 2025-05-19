<%@ Page Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="false" CodeFile="content.aspx.vb" Inherits="content" title="ADD Content" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="C1" Runat="Server">

<script type="text/javascript" src="tinymce/tinymce.min.js"></script>
<script type="text/javascript">
    tinymce.init({
        selector: "textarea",
        extended_valid_elements: 'span',
        theme: "modern",
        plugins: [
        "advlist autolink lists link image charmap print preview hr anchor pagebreak",
        "searchreplace wordcount visualblocks visualchars code fullscreen",
        "insertdatetime media nonbreaking save table contextmenu directionality",
        "emoticons template paste textcolor colorpicker textpattern imagetools"
    ],
        toolbar1: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image",
        toolbar2: "print preview media | forecolor backcolor emoticons",
        image_advtab: true,
        templates: [
        { title: 'Test template 1', content: 'Test 1' },
        { title: 'Test template 2', content: 'Test 2' }
    ]
    });
</script>
<div class="form-horizontal" >
    <div class="panel panel-default">
        <div class="panel-heading"><h6 class="panel-title">Content Manager</h6> </div>
        <div class="panel-body">
            <asp:Label ID="lblmsg" runat="server" Font-Bold="true" ForeColor="Coral"></asp:Label>
            <div class="form-group">
                <div class="col-sm-2"><h2>Website Page</h2></div>
                <div class="col-sm-6">
                    <asp:DropDownList ID="ddlContent" class="form-control" runat="server" Width="100%" AutoPostBack="True">
                    </asp:DropDownList>
                    <%--<asp:CheckBox ID="chkshow" runat="server" Text="Yes I  want to Show this on home Page" />--%>
                </div>
                <div class="col-sm-4">
                    <asp:Button ID="btnsave" runat="server" Text="SAVE" CssClass="btn btn-primary" Width="200px" ValidationGroup="CreateUser" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-2"><h2>Page URL</h2></div>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtPageURL" ReadOnly="true" Width="100%"  class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-12">
                    <h1>Page Title</h1>
                    <asp:TextBox ID="txtPageTitle" CssClass="span6" TextMode="SingleLine" MaxLength="60"  Height="50px" Width="100%" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-12">
                    <h1>Meta Description</h1>
                    <asp:TextBox ID="txtMetaDescription" CssClass="span6" TextMode="SingleLine" MaxLength="160"  Height="50px" Width="100%" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-12">
                    <h1>Meta Keywords</h1>
                    <asp:TextBox ID="txtMetaKeywords" CssClass="span6" TextMode="SingleLine"  Height="50px" Width="100%" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-12">
                    <h1>Other Meta Tags</h1>
                    <asp:TextBox ID="txtMetaTag" CssClass="span6" TextMode="SingleLine"  Height="50px" Width="100%" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-12">
                    <h1>Page Content</h1>
                    <asp:TextBox ID="txtcontent" CssClass="span6" TextMode="multiLine" Columns="60" Rows="30" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
</div>
</asp:Content>

