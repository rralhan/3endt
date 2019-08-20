<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ManageCustomer.aspx.cs" Inherits="_3EndTCommercePresentation.Admin.ManageCustomer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table class="toptable">
             <tr>
                <td colspan="3" class="tdcenter heading">Manage Customer</td>
            </tr>
             <tr>
                <td class="tdfirst">
                    Company:</td>
                <td class="tdsecond">
                    <asp:DropDownList ID="ddlCompany" runat="server" CssClass="entries">
                    </asp:DropDownList>
                   
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfeCompany" ValidationGroup="ValidateCustomer" ControlToValidate="ddlCompany" Display="None"  runat="server" InitialValue="-1" ErrorMessage="Please select a Company"></asp:RequiredFieldValidator>

                    </td>
            </tr>
             
             <tr>
                <td class="tdfirst">
                    UserName:</td>
                <td class="tdsecond">
                    <asp:TextBox ID="txtUserName" runat="server"  CssClass="entries"></asp:TextBox>
                   
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfeUserName" ValidationGroup="ValidateCustomer" ControlToValidate="txtUserName" Display="None"  runat="server" ErrorMessage="Please enter a value for username."></asp:RequiredFieldValidator>

                    </td>
            </tr>
             
             <tr>
                <td class="tdfirst">
                    Password:</td>
                <td class="tdsecond">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="entries"></asp:TextBox>
                   
                 </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfePassword" ValidationGroup="ValidateCustomer" ControlToValidate="txtPassword" Display="None"  runat="server" ErrorMessage="Please enter a value for Password"></asp:RequiredFieldValidator>

                    </td>
            </tr>
             
            <tr>
                <td class="tdfirst">First Name:</td>
                <td class="tdsecond">
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="entries"></asp:TextBox>
                </td>
                
                <td class="auto-style6">
                   
                    &nbsp;</td>
                
            </tr>
            <tr>
                <td class="tdfirst">Last Name:</td>
                <td class="tdsecond">
                    <asp:TextBox ID="txtLastName" runat="server"  CssClass="entries"></asp:TextBox>
                </td>
                
                <td class="auto-style6">
                   
                    &nbsp;</td>
                
            </tr>
             
            <tr>
                <td class="auto-style2"></td>
                <td >
                    <asp:CheckBox ID="chkIsActive" Text="Is Active" Checked="true" runat="server" />
                </td>
                <td><asp:Label ID="lblMessage" runat="server" Text="" CssClass="imp-msg"></asp:Label></td>
            </tr>

            <tr>
                <td>
                    
                </td>
                <td class="tdbuttonpad">
                    <asp:Button ID="btnSave" runat="server" ValidationGroup="ValidateCustomer" Text="Save" OnClick="btnSave_Click" CausesValidation="true" CssClass="btnsubmit" />&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel"  OnClick="btnCancel_Click" CssClass="btnsubmit" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    <div>
  
<asp:GridView ID="grdCustomer" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" 
            AllowPaging="True" onpageindexchanging="grdCustomer_PageIndexChanging" 
            onrowcommand="grdCustomer_RowCommand" OnRowDataBound="grdCustomer_RowDataBound">
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
                         <asp:HiddenField ID="hdnCompanyId" runat="server" Value='<%#Eval("CompanyId") %>'/>
                         <asp:HiddenField ID="hdnCustomerId" runat="server" Value='<%#Eval("CustomerId") %>' />
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField>
                     <HeaderStyle HorizontalAlign="left" />
                     <ItemStyle HorizontalAlign="left" />
                     <HeaderTemplate>
                         <asp:Label ID="lblhdrUserName" runat="server" Text="UserName"></asp:Label>
                     </HeaderTemplate>
                     <ItemTemplate>
                         <asp:Label ID="lblUserName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField>
                     <HeaderStyle HorizontalAlign="left" />
                     <ItemStyle HorizontalAlign="left" />
                     <HeaderTemplate>
                         <asp:Label ID="lblhdrCompany" runat="server" Text="Company"></asp:Label>
                     </HeaderTemplate>
                     <ItemTemplate>
                         <asp:Label ID="lblCompany" runat="server" ></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField>
                     <HeaderStyle HorizontalAlign="left" />
                     <ItemStyle HorizontalAlign="left" />
                     <HeaderTemplate>
                         <asp:Label ID="lblhdrActive" runat="server" Text="Is Active"></asp:Label>
                     </HeaderTemplate>
                     <ItemTemplate>
                         <asp:Label ID="lblIsActive" runat="server" Text='<%#Eval("IsActive") %>'></asp:Label>
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Edit/Delete Customer">
                     <HeaderStyle HorizontalAlign="left" />
                     <ItemStyle HorizontalAlign="left" />
                     <ItemTemplate>
                         <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/Images/edit.gif" ToolTip="Edit" CausesValidation="false"  CommandName="cmdedit" />
                         <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/Images/delete.png" ToolTip="Delete" CausesValidation="false" CommandName="cmddelete" />                         
                     </ItemTemplate>
                 </asp:TemplateField>
               </Columns>
        </asp:GridView>

    </div>
</asp:Content>
