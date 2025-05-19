<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="false" CodeFile="WebsiteHits.aspx.vb" Inherits="Admin_WebsiteHits" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C1" Runat="Server">
<div class="form-horizontal" >

  <div class="panel panel-default">
                            
                <div class="panel-heading"><h6 class="panel-title">Website Hits</h6></div>
                <div class="table-responsive">
              
                        <asp:GridView ID="DataDisplay" class="table table-bordered table-check" AllowPaging="true" PageSize="50" AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" >
                                <ItemTemplate>
                                    <%#Container.DataItemIndex + 1%>
                                </ItemTemplate>  
                            </asp:TemplateField>
                            <asp:BoundField DataField="WebsitePage" HeaderText="Website Page"></asp:BoundField>
                            <asp:BoundField DataField="IPAddress" HeaderText="IP Address"></asp:BoundField>
                            <asp:BoundField DataField="Location" HeaderText="Location"></asp:BoundField>
                            <asp:BoundField DataField="Dated" HeaderText="Dated"></asp:BoundField>
                         </Columns>
                        </asp:GridView>
                        </div></div>
</div>
</asp:Content>

