<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true"
    CodeBehind="ManageProduct.aspx.cs" Inherits="_3EndTCommercePresentation.Admin.ManageProduct" ValidateRequest="false" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/jquery-te/jquery-te-1.4.0.css" rel="stylesheet" />
    <script type="text/javascript" src="../jquery-te/jquery-te-1.4.0.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".editor").jqte();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <table class="toptable">
        <tr>
            <td colspan="3" class="tdcenter heading">Manage Product</td>
        </tr>

        <tr>
            <td class="tdfirst">Category:</td>
            <td class="tdsecond">
                <asp:DropDownList ID="ddlCategoryName" runat="server" CssClass="entries">
                </asp:DropDownList>

            </td>
            <td>

                <asp:RequiredFieldValidator ID="rfeCategory" ControlToValidate="ddlCategoryName" InitialValue="-1" ValidationGroup="ValidateProduct" Display="None" runat="server" ErrorMessage="Please enter a value for Category."></asp:RequiredFieldValidator>

            </td>

        </tr>

        <tr>
            <td class="tdfirst">Product Name:</td>
            <td class="tdsecond">
                <asp:TextBox ID="txtProductTitle" runat="server" CssClass="entries"></asp:TextBox>
            </td>
            <td class="auto-style6">

                <asp:RequiredFieldValidator ID="rfeProductName" ControlToValidate="txtProductTitle" ValidationGroup="ValidateProduct" Display="None" runat="server" ErrorMessage="Please enter a value for product title."></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td class="tdfirst">Description:</td>
            <td class="tdsecond">
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="editor"></asp:TextBox>
            </td>
            <td></td>
        </tr>

        <tr>
            <td class="tdfirst">Product Unit:</td>
            <td class="tdsecond">
                <asp:TextBox ID="txtProductUnit" runat="server" CssClass="entries"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="reqProductUnit" runat="server" ControlToValidate="txtProductUnit"
                    ErrorMessage="Product Unit is required" ValidationGroup="ValidateProduct"></asp:RequiredFieldValidator></td>
        </tr>

        <tr>
            <td>Image:
            </td>
            <td class="tdsecond">
                <asp:FileUpload ID="fuProductImage" runat="server" CssClass="entries" Width="350px" />
            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:CheckBox ID="chkIsActive" Text="Is Active" Checked="true" runat="server" />
            </td>
            <td>
                <asp:Label ID="lblMessage" runat="server" CssClass="imp-msg"></asp:Label></td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnsubmit" Visible="false" OnClick="btnDelete_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="ValidateProduct" Text="Save" OnClick="btnSave_Click" CssClass="btnsubmit" CausesValidation="true" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" OnClick="btnCancel_Click" Text="Cancel" CssClass="btnsubmit" />
                        </td>
                    </tr>
                </table>   
                
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <div>
        <asp:GridView ID="grdProducts" runat="server" AutoGenerateColumns="False" PageSize="20"
            CellPadding="4" ForeColor="#333333" GridLines="Vertical" Width="100%"
            AllowPaging="True" OnPageIndexChanging="grdProducts_PageIndexChanging"
            OnRowCommand="grdProducts_RowCommand">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            <Columns>
                <asp:TemplateField HeaderText="S. No">
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <ItemTemplate>
                        <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="lblPtitle" runat="server" Text="Product Title"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProdcutTitle" runat="server" Text='<%#Eval("ProductTitle") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="center" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="lblDesc" runat="server" Text="Description"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDescription" runat="server" Text='<%# HttpUtility.HtmlDecode(Eval("Description").ToString()) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="lblPunit" runat="server" Text="Product Unit"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProductUnit" runat="server" Text='<%#Eval("Unit") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="lblContact" runat="server" Text="Product Image"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <img src='<%#Eval("ImageUrl")%>' width='100px' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="lblhdrIsActive" runat="server" Text="Is Active"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkIsActive" runat="server" Enabled="false" Checked='<%# Eval("IsActive") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit Product">
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/Images/edit.gif" ToolTip="Edit" CausesValidation="false" CommandArgument='<%# Eval("ProductId") %>' CommandName="cmdedit" />
                       <%-- <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/Images/delete.png" ToolTip="Delete" CausesValidation="false" CommandArgument='<%# Eval("ProductId") %>' CommandName="cmddelete" />--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
</asp:Content>
