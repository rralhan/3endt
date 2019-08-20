<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ManageTier.aspx.cs" Inherits="_3EndTCommercePresentation.Admin.ManageTier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table class="toptable">
            <tr>
                <td colspan="3" class="tdcenter heading">Manage Tier</td>
            </tr>
            <tr>
                <td class="tdfirst">Tier Name:*</td>
                <td>
                    <asp:TextBox ID="txtTierName" runat="server" CssClass="entries"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ValidateTier" runat="server" ControlToValidate="txtTierName" Display="None" ErrorMessage="Please enter a value for Tier."></asp:RequiredFieldValidator>

                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:CheckBox ID="chkIsDefault" runat="server" TextAlign="Right" />
                    &nbsp;&nbsp;Mark Default
                </td>
                <td></td>
            </tr>
            <tr>
                <td></td>
                <td class="tdsecond">
                    <div>
                        <asp:CheckBox ID="chkIsActive" Checked="true" runat="server" />
                        &nbsp;&nbsp;Is Active
                    </div>
                </td>
                <td>
                    <asp:Label ID="lblConfirmation" runat="server" CssClass="imp-msg"></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td class="tdsecond">
                    <asp:Button ID="btnSave" runat="server" CssClass="btnsubmit" ValidationGroup="ValidateTier" Text="Save" OnClick="btnSave_Click" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btnsubmit" CausesValidation="false" OnClick="btnCancel_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">&nbsp;</td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="grdTier" runat="server" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%"
            AllowPaging="True" OnPageIndexChanging="grdTier_PageIndexChanging"
            OnRowCommand="grdTier_RowCommand">
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
                        <asp:Label ID="lblTier" runat="server" Text="Tier Name"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTierName" runat="server" Text='<%#Eval("TierName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="lblActive" runat="server" Text="Is Active"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkIsActive" runat="server" Enabled="false" Checked='<%# Eval("IsActive") %>' />

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="lblDefault" runat="server" Text="Is Default"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkIsDefault" runat="server" Enabled="false" Checked='<%# Eval("IsDefault") %>' />

                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Edit/Delete Tier">
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/Images/edit.gif" ToolTip="Edit" CausesValidation="false" CommandArgument='<%# Eval("TierId") %>' CommandName="cmdedit" />
                        <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/Images/delete.png" ToolTip="Delete" CausesValidation="false" CommandArgument='<%# Eval("TierId") %>' CommandName="cmddelete" />


                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

    </div>



</asp:Content>
