<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ManageCompanyShippingAddress.aspx.cs" Inherits="_3EndTCommercePresentation.Admin.ManageCompanyShippingAddress" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table class="toptable">
            <tr>
                <td colspan="3" class="tdcenter heading">Manage Company Shipping Address:
                </td>

            </tr>
            <tr>
                <td class="tdfirst">Company Name:*</td>
                <td>
                    <asp:DropDownList ID="ddlCompanyName" runat="server" CssClass="entries" AutoPostBack="true" OnSelectedIndexChanged="ddlCompanyName_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator CssClass="imp-msg" ID="rfvCompany" ControlToValidate="ddlCompanyName" InitialValue="-1" runat="server" ErrorMessage="Select Company Name"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <asp:Panel ID="pnlShipping" runat="server">
                <tr>
                    <td class="tdfirst">Shipping Address:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlShippingAddress" runat="server" CssClass="entries" AutoPostBack="true" OnSelectedIndexChanged="ddlShippingAddress_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator CssClass="imp-msg" ID="rfeShippingAddress" ControlToValidate="ddlShippingAddress" InitialValue="-1" runat="server" ErrorMessage="Select Shipping Address"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </asp:Panel>
            <asp:Panel ID="pnlShippingInfo" runat="server" Visible="false">
                <tr>
                    <td class="tdfirst">Same as Billing Address?
                    </td>
                    <td>
                        <asp:CheckBox ID="chkSameAsBilling" runat="server" AutoPostBack="true" OnCheckedChanged="chkSameAsBilling_CheckedChanged" />
                    </td>
                </tr>
                <tr>
                    <td class="tdfirst" colspan="3"><b>Shipping Information:</b></td>
                </tr>
                <tr>
                    <td>Shipping Name:
                    </td>
                    <td>
                        <asp:TextBox ID="txtShippingName" runat="server" CssClass="entries"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator CssClass="imp-msg" ID="rfvShippingName" runat="server" ControlToValidate="txtShippingName" ErrorMessage="Please enter a value for Shipping Name" ValidationGroup="ValidateShipping"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdfirst">Address Line 1:
                    </td>
                    <td style="margin-bottom: 10px;">
                        <asp:TextBox ID="txtShippingAddress1" runat="server" CssClass="entries"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator CssClass="imp-msg" ID="rfvShippingAddress1" runat="server" ControlToValidate="txtShippingAddress1" ErrorMessage="Please enter a value for Shipping Address" ValidationGroup="ValidateShipping"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdfirst">Address Line 2:
                    </td>
                    <td style="margin-bottom: 10px;">
                        <asp:TextBox ID="txtShippingAddress2" runat="server" CssClass="entries"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="tdfirst">City:
                    </td>
                    <td style="margin-bottom: 10px;">
                        <asp:TextBox ID="txtShippingCity" runat="server" CssClass="entries"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator CssClass="imp-msg" ID="rfvShippingCity" runat="server" ControlToValidate="txtShippingCity" ErrorMessage="Please enter a value for City" ValidationGroup="ValidateShipping"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="tdfirst">State:
                    </td>
                    <td style="margin-bottom: 10px;">
                        <asp:DropDownList ID="ddlShippingState" runat="server" CssClass="entries"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator CssClass="imp-msg" ID="rfvState" runat="server" ControlToValidate="ddlShippingState" ErrorMessage="Please select a valid State" ValidationGroup="ValidateShipping"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="tdfirst">Zip:
                    </td>
                    <td style="margin-bottom: 10px;">
                        <asp:TextBox ID="txtZipCode" runat="server" Style="width: 100px;"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator CssClass="imp-msg" ID="rfvZipCode" runat="server" ControlToValidate="txtZipCode" ErrorMessage="Please enter a valid zipcode" ValidationGroup="ValidateShipping"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td></td>
                    <td class="tdbuttonpad">
                        <asp:CheckBox ID="chkIsPrimary" Text="Is Primary" Checked="true" runat="server" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="chkIsActive" Text="Is Active" Checked="true" runat="server" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </asp:Panel>
            <tr>
                <td>&nbsp;
                </td>
                <td class="tdbuttonpad">
                    <asp:Button ID="btnSave" ValidationGroup="ValidateShipping" runat="server" Text="Save" OnClick="btnSave_Click" />
                    &nbsp;&nbsp;&nbsp;
               <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" class="tdcenter">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="imp-msg"></asp:Label></td>
            </tr>
        </table>
    </div>
    <div>

        <asp:GridView ID="gvShippingAddress" runat="server" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%"
            AllowPaging="true">
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
                        <asp:Label ID="lblProductHeader" runat="server" Text="Company"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProduct" runat="server" Text='<%# Eval("CompanyName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="lblAddrNameHeader" runat="server" Text="Shipping Address Name"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblAddrNameValue" runat="server" Text='<%# Eval("AddressName")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="lblAddrHeader" runat="server" Text="Shipping Address"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblProductSku" runat="server" Text='<%# Eval("Address1").ToString()
                        + " " + Eval("City").ToString() + " "
                        + Eval("State").ToString() +" "+ Eval("ZipCode").ToString()      %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
