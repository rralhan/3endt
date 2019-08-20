<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ManageProductCategory.aspx.cs" Inherits="_3EndTCommercePresentation.Admin.ManageProductCategory" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function ToggleParent() {
            var parentdiv = $('#<%=trParentCat.ClientID%>');
            var isservicechk = $('#tdIsService');
            var display = $('#<%=rdbtnSubCatYes.ClientID%>').is(':checked');
            if (display) {
                parentdiv.show();
                isservicechk.hide();
            }
            else {
                parentdiv.hide();
                isservicechk.show();
            }
        }
        function ValidateParentSelection() {
            if ($('#<%=rdbtnSubCatYes.ClientID%>').is(':checked')) {
                var selval = $('#<%=ddlCategoryName.ClientID%>').val();
                if (selval == -1) {
                    alert('Please select an appropriate Parent Category');
                    return false;
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="toptable">
          <tr>
                <td colspan="3" class="tdcenter heading">Manage Categories</td>
            </tr>
        <tr>
            <td class="tdfirst">Category / SubCategory Name:</td>
            <td>
                <asp:TextBox ID="txtCategoryName" runat="server" CssClass="entries"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="refCategory" ValidationGroup="ValidateCategory" ControlToValidate="txtCategoryName" ValidateRequestMode="Enabled" runat="server" Text="*" ErrorMessage="Please enter a value for Category / SubCategory."></asp:RequiredFieldValidator>

            </td>
        </tr>
        <tr>
            <td class="tdfirst">Is it a SubCategory?</td>
            <td>
                <input id="rdbtnSubCatNo" type="radio" value="0" checked="true" name="rdbtnSubCat" runat="server" onclick="ToggleParent();" />
                No 
                <input id="rdbtnSubCatYes" type="radio" value="1" name="rdbtnSubCat" runat="server" onclick="ToggleParent();" />
                Yes
            </td>
            <td></td>
        </tr>
        <tr id="trParentCat" runat="server">
            <td >Parent Category Name:</td>
            <td class="auto-style4">
                <asp:DropDownList ID="ddlCategoryName" runat="server" CssClass="entries">
                </asp:DropDownList></td>
            <%--<td class="auto-style4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="ValidateCategory" ControlToValidate="ddlCategoryName" Display="None" InitialValue="-1" ValidateRequestMode="Enabled" runat="server" ErrorMessage="<b>Category is empty</b><br/>Please enter a value for category."></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" TargetControlID="RequiredFieldValidator5" runat="server">
                </asp:ValidatorCalloutExtender>
            </td>--%>
            <td></td>
        </tr>
        <tr>
            <td class="tdfirst">Category Image</td>
            <td>
                <asp:FileUpload ID="fuCatImage" runat="server" Width="300px" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="tdfirst"></td>
            <td>
                <table>
                    <tr>
                        <td>
                             <asp:CheckBox ID="chkIsActive" Text="Is Active" Checked="true" runat="server" />
                        </td>
                        <td id="tdIsService">
                             <asp:CheckBox ID="chkIsService" Text="Is a Service" Checked="false" runat="server" />
                        </td>
                    </tr>
                </table>               
            </td>
            <td> <asp:Label ID="lblConfirmation" runat="server" CssClass="imp-msg">
                <asp:ValidationSummary ID="vsSummary" runat="server" CssClass="imp-msg" ShowValidationErrors="true" EnableClientScript="true" DisplayMode="BulletList" ValidationGroup="ValidateCategory"/>
                 </asp:Label></td>
        </tr>
       
        <tr>
            <td class="tdfirst"></td>
            <td class="tdbuttonpad">
                <asp:Button ID="btnSave" runat="server" ValidationGroup="ValidateCategory" Text="Save" OnClientClick="return ValidateParentSelection();" CssClass="btnsubmit" OnClick="btnSave_Click" CausesValidation="true"/>
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btnsubmit" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>

    <div>
        <asp:GridView ID="grdCategory" runat="server" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%"
            AllowPaging="True" OnPageIndexChanging="grdCategory_PageIndexChanging" PageSize="30"
            OnRowCommand="grdCategory_RowCommand" OnRowDataBound="grdCategory_RowDataBound">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
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
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCategoryId" runat="server" Visible="false" Text='<%#Eval("CategoryId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Category Name"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcategoryname" runat="server" Text='<%#Eval("CategoryName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Parent Category Name"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblparentcategoryname" runat="server" Text='<%# GetCategoryName(Eval("ParentCategoryId")) %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Category Level"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcategorylevel" runat="server" Text='<%# Eval("CategoryLevel") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="Label1" runat="server" Text="Is Active"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkIsActive" runat="server" Enabled="false" Checked='<%# Eval("IsActive") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Edit Category">
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="center" />
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/Images/edit.gif" ToolTip="Edit" CausesValidation="false" CommandArgument='<%# Eval("CategoryId") %>' CommandName="cmdedit" />
                        <%--<asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/Images/delete.png" ToolTip="Delete" CausesValidation="false" CommandArgument='<%# Eval("CategoryId") %>' CommandName="cmddelete" />--%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>
    <script>
        $(document).ready(function () {
            ToggleParent();
        });
    </script>
</asp:Content>
