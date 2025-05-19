<%@ Page Title="" Language="VB" MasterPageFile="~/Admin/AdminMaster.master" AutoEventWireup="false" ValidateRequest="false" CodeFile="productmaster.aspx.vb" Inherits="Admin_productmaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="C1" Runat="Server">
<!-- Form components -->
            <div class="form-horizontal" >



                <!-- Basic inputs -->
                <div class="panel panel-default">
                    <div class="panel-heading"><h6 class="panel-title">Product List</h6> </div>
                    <div class="panel-body">
                        <asp:HiddenField ID="hfId" runat="server" />
                       <%-- <div class="alert alert-info fade in widget-inner">
                            <button type="button" class="close" data-dismiss="alert">×</button>
                            Default form components, including bootstrap additions and tags
                        </div>--%>
                        <asp:Literal ID="litmsg" runat="server"></asp:Literal>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Product Category </label>
                            <div class="col-sm-10">
                                <asp:dropdownlist id="ddlCategory" class="form-control" AppendDataBoundItems="true"  runat="server">
                                    <asp:ListItem Value="">Select Category</asp:ListItem>
                                </asp:dropdownlist>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Product Name </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtProductName" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Image </label>
                            <div class="col-sm-10">
                                <asp:FileUpload ID="FileUpload" CssClass="form-control" runat="server" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Short Description </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtShortDesc" class="form-control" Height="100px" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label">Product Description </label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtProductDesc" class="form-control" Height="200px" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </div>
                        </div>
                         <div class="form-group">
                            <label class="col-sm-2 control-label">Status </label>
                            <div class="col-sm-10">
                                <asp:DropDownList ID="ddlStatus" class="select-full" runat="server">
                                 <asp:ListItem Value="0">Active</asp:ListItem>
                                <asp:ListItem Value="1">Deactive</asp:ListItem>
                                </asp:DropDownList>
                                 
                            </div>
                        </div>

                         <div class="form-actions text-right">
                                <asp:Button ID="btnSubmit" runat="server" ValidationGroup="UserRegistration" class="btn btn-primary" Text="Submit" />
                       
                        </div>
                        </div></div></div>

                         <div class="panel panel-default">
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                <div class="panel-heading"><h6 class="panel-title">Product Category List</h6></div>
                <div class="table-responsive">
                
                        <asp:GridView ID="DataDisplay" class="table table-bordered table-check" AutoGenerateColumns="false" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" >
                            <ItemTemplate>
                                <%#Container.DataItemIndex + 1%>
                            </ItemTemplate>
                                                          
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="200px">
                                 <HeaderTemplate>Product Name</HeaderTemplate>
                                 <ItemTemplate>
                                     <%#Eval("ProductName") %>                                                        
                                 </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField ItemStyle-Width="200px">
                                 <HeaderTemplate>Product Category</HeaderTemplate>
                                 <ItemTemplate>
                                     <%#Eval("ProductCategory") %>                                                        
                                 </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                 <ItemTemplate>
                                     <a href='../img/products/<%#Eval("ImageName") %>' target="_blank" >
                                    <img style="width:150px" alt="" src='../img/products/thumbnail/<%#Eval("ImageName") %>'></img></a>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:BoundField DataField="ShortDesc" HeaderText="Description"></asp:BoundField>
                             <asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
                         
                   

                         <asp:TemplateField>
                         <ItemTemplate>
                             <asp:LinkButton ID="LinkButton3" CommandArgument='<%#Eval("Cnt") %>' CommandName="Deactivate1" runat="server">Edit</asp:LinkButton>
                         </ItemTemplate>
                         
                         </asp:TemplateField>
                         
                         <asp:TemplateField>
                         <ItemTemplate>
                             <asp:LinkButton ID="LinkButton2" CommandArgument='<%#Eval("Cnt") %>' CommandName="Delete1" runat="server">Delete</asp:LinkButton>
                         </ItemTemplate>
                         
                         </asp:TemplateField>
                         </Columns>
                        </asp:GridView>
                        </div></div>

</asp:Content>

