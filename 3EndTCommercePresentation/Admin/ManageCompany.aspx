<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ManageCompany.aspx.cs" Inherits="_3EndTCommercePresentation.Admin.ManageCompany" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><strong style="color: #0000FF">Manage Company</strong></div>

    <asp:MultiView ID="mvManageCompany" runat="server" ActiveViewIndex="0" OnActiveViewChanged="mvManageCompany_ActiveViewChanged">
        <asp:View ID="viewQuestion" runat="server">
            <table class="toptable">
                <tr>
                    <td colspan="2" id="tdQuestion" class="tdcenter heading">
                        <span id="spnQuestion">Is this</span> a Parent Company?
                    </td>

                </tr>
                <tr>
                    <td class="tdright">
                        <asp:Button ID="btnQuestionYes" runat="server" Text="Yes" OnClick="btnQuestionYes_Click" />
                    </td>
                    <td class="tdleft">
                        <asp:Button ID="btnQuestionNo" runat="server" Text="No" OnClick="btnQuestionNo_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;</td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewParentCompany" runat="server">
            <table class="toptable">
                <tr>
                    <td class="tdfirst">Parent Company Name:*</td>
                    <td>
                        <asp:TextBox ID="txtParentCompany" runat="server" CssClass="entries"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvParent" ValidationGroup="ValidateParent" runat="server" ControlToValidate="txtParentCompany" ErrorMessage="Please enter a value for Parent Company."></asp:RequiredFieldValidator>

                    </td>

                </tr>

                <tr>
                    <td class="tdfirst">Federal Id:</td>
                    <td class="tdsecond">
                        <asp:TextBox ID="txtParentFederal" runat="server" CssClass="entries"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lblParentConfirmation" runat="server" CssClass="imp-msg"></asp:Label></td>
                </tr>

                <tr>
                    <td></td>
                    <td class="tdbuttonpad">
                        <asp:Button ID="btnParentSave" runat="server" CssClass="btnsubmit" ValidationGroup="ValidateParent" Text="Save and Next" OnClick="btnParentSave_Click" Width="150px" />
                        &nbsp;&nbsp;&nbsp;
                             <asp:Button ID="btnParentCancel" runat="server" Text="Cancel" CssClass="btnsubmit" CausesValidation="false" OnClick="btnCancel_Click" CommandName="parentcancel" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;</td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="viewCompany" runat="server">
            <table class="toptable">
                <tr>
                    <td class="tdfirst">Company Name:*</td>
                    <td>
                        <asp:TextBox ID="txtCompanyName" runat="server" CssClass="entries"></asp:TextBox>

                    </td>
                    <td>

                        <asp:RequiredFieldValidator ID="rfvCompany" ControlToValidate="txtCompanyName" ValidationGroup="ValidateCompany" CssClass="imp-msg" runat="server" ErrorMessage="Please enter a value for Company."></asp:RequiredFieldValidator>
                    </td>

                </tr>

                <tr>
                    <td class="tdfirst">Parent Company Name:*</td>
                    <td>
                        <asp:DropDownList ID="ddlParentCompany" runat="server" CssClass="entries">
                        </asp:DropDownList>
                    </td>
                    <td>

                        <asp:RequiredFieldValidator ID="rfvParentSel" ControlToValidate="ddlParentCompany" ValidationGroup="ValidateCompany" Display="None" runat="server" InitialValue="-1" ErrorMessage="Please select a value for Parent-Company."></asp:RequiredFieldValidator>

                    </td>

                </tr>
                <tr>
                    <td>Tier:*
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTiers" runat="server" CssClass="entries">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvTiers" ControlToValidate="ddlTiers" ValidationGroup="ValidateCompany" runat="server" InitialValue="-1" CssClass="imp-msg" ErrorMessage="Please select a value for Tiers."></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>FederalId:</td>
                    <td>
                        <asp:TextBox ID="txtFederalId" runat="server" CssClass="entries"></asp:TextBox></td>
                    <td></td>

                </tr>
                <tr>
                    <td colspan="3"><b>Billing Address:</b></td>

                </tr>
                <tr>
                    <td class="tdfirst">Address Line 1:*</td>
                    <td>
                        <asp:TextBox ID="txtBillingAddressLine1" runat="server" CssClass="entries"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvBillingAddress1" runat="server" ControlToValidate="txtBillingAddressLine1" ErrorMessage="Please enter a value for Billing Address" CssClass="imp-msg" ValidationGroup="ValidateCompany"></asp:RequiredFieldValidator>

                    </td>

                </tr>
                <tr>
                    <td class="tdfirst">Address Line 2:</td>
                    <td>
                        <asp:TextBox ID="txtBillingAddressLine2" runat="server" CssClass="entries"></asp:TextBox>
                    </td>


                </tr>
                <tr>
                    <td>City:*
                    </td>
                    <td>
                        <asp:TextBox ID="txtBillingCity" runat="server" CssClass="entries"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvBillingAddress2" runat="server" ControlToValidate="txtBillingCity" ErrorMessage="Please enter a value for City" CssClass="imp-msg" ValidationGroup="ValidateCompany"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td class="tdfirst">State:*
                    </td>
                    <td style="margin-bottom: 10px;">
                        <asp:DropDownList ID="ddlBillingState" runat="server" CssClass="entries"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlBillingState" ErrorMessage="Please select a valid State" ValidationGroup="ValidateCompany" CssClass="imp-msg"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="tdfirst">Zip:*
                    </td>
                    <td style="margin-bottom: 10px;">
                        <asp:TextBox ID="txtBillingZipCode" runat="server" Style="width: 100px;"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ControlToValidate="txtBillingZipCode" ErrorMessage="Please enter a valid zipcode" ValidationGroup="ValidateCompany" CssClass="imp-msg"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td>Phone:*</td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="entries"></asp:TextBox></td>
                    <td>
                        <asp:RegularExpressionValidator ID="regPhone" ControlToValidate="txtPhone" CssClass="imp-msg" runat="server" ValidationExpression="^(?:\([2-9]\d{2}\)\ ?|[2-9]\d{2}(?:\-?|\ ?))[2-9]\d{2}[- ]?\d{4}$" ErrorMessage="Please enter a valid phone number in the format <br/> (xxx) xxx-xxxx"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvPhone" ControlToValidate="txtPhone" ValidationGroup="ValidateCompany" CssClass="imp-msg" runat="server" ErrorMessage="Please enter a value for phone no."></asp:RequiredFieldValidator>

                    </td>

                </tr>

                <tr>
                    <td>Fax Number:</td>
                    <td>
                        <asp:TextBox ID="txtFaxNumber" runat="server" CssClass="entries"></asp:TextBox></td>
                    <td>&nbsp;</td>

                </tr>

                <tr>
                    <td>Email ID:</td>
                    <td>
                        <asp:TextBox ID="txtEmailId" runat="server" CssClass="entries"></asp:TextBox></td>
                    <td>
                        <asp:RegularExpressionValidator ID="regEmailId" runat="server" ErrorMessage="<b>Enter Valid Email Address.</b>" ControlToValidate="txtEmailId" CssClass="imp-msg" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>


                    </td>

                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:CheckBox ID="chkIsActive" Text="Is Active" Checked="true" runat="server" />
                    </td>
                    <td>
                        <asp:Label ID="lblMessage" runat="server" CssClass="imp-msg"></asp:Label>
                    </td>
                </tr>


                <tr>
                    <td></td>
                    <td class="tdbuttonpad">
                        <asp:Button ID="btnCompanySave" runat="server" ValidationGroup="ValidateCompany" Text="Save" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                               <asp:Button ID="btnCompanyCancel" runat="server" CausesValidation="false" Text="Cancel" CommandName="compcancel" OnClick="btnCancel_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>










    <div>
        <asp:GridView ID="grdCompany" runat="server" AutoGenerateColumns="False"
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%"
            AllowPaging="True" OnPageIndexChanging="grdCompany_PageIndexChanging" PageSize="10"
            OnRowCommand="grdCompany_RowCommand" OnRowDataBound="grdCompany_RowDataBound">
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
                        <asp:HiddenField ID="hdnCompanyId" runat="server" Value='<%# Eval("CompanyId") %>' />
                        <asp:HiddenField ID="hdnParentCompanyId" runat="server" Value='<%# Eval("ParentCompanyId") %>' />
                        <asp:HiddenField ID="hdnTierId" runat="server" Value='<%# Eval("TierId") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="lblCname" runat="server" Text="Company Name"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCompanyName" runat="server" Text='<%#Eval("CompanyName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="lblParent" runat="server" Text="Parent Company Name"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblParentCompany" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="lblTier" runat="server" Text="Tier"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblTierName" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="lblBilling" runat="server" Text="Billing Address"></asp:Label>
                    </HeaderTemplate>
                    <%--                    <ItemTemplate>
                        <asp:Label ID="lblBillingAddress" runat="server" Text='<%#Eval("BillingAddress").ToString().Replace("^"," ")%>'></asp:Label>
                    </ItemTemplate>--%>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="lblContact" runat="server" Text="Contact No."></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblContactNumber" runat="server" Text='<%#Eval("PhoneNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="lblEmail" runat="server" Text="Email Id"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEmailId" runat="server" Text='<%#Eval("EmailId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="lblIsActive" runat="server" Text="Is Active"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkIsActive" runat="server" Enabled="false" Checked='<%# Eval("IsActive") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Edit/Delete Company">
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/Images/edit.gif" ToolTip="Edit" CausesValidation="false" CommandArgument='<%# Eval("CompanyId") %>' CommandName="cmdedit" />
                        <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/Images/delete.png" ToolTip="Delete" CausesValidation="false" CommandArgument='<%# Eval("CompanyId") %>' CommandName="cmddelete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </div>

</asp:Content>
