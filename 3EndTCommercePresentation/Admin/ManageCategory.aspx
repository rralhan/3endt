<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ManageCategory.aspx.cs" Inherits="_3EndTCommercePresentation.Admin.ManageCategory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
        .auto-style1

        {
            width: 100%;
        }
        .auto-style2
        {
            width: 128px;
        }
        .auto-style3
        {
            width: 246px;
        }
        .auto-style4
        {
            width: 128px;
            height: 26px;
        }
        .auto-style5
        {
            width: 246px;
            height: 26px;
        }
        .auto-style6
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div><strong style="color: #0000FF">Manage Category:</strong></div>
      <div>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

    </div>
    <div>


        <table class="auto-style1">
           
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">Category Name:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtCategoryName" runat="server" Height="16px" Width="208px"></asp:TextBox>
                </td>
                <td class="auto-style6">
                   
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="ValidateCategory" runat="server" ControlToValidate="txtCategoryName" Display="None" ErrorMessage="<b>Category is empty</b><br/>Please enter a value for category."></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator1" runat="server"></asp:ValidatorCalloutExtender>
                </td>
                
            </tr>
             
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style3">
                    <asp:CheckBox ID="chkIsActive" Text="Is Active" Checked="true" runat="server" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="btnSave" ValidationGroup="ValidateCategory" runat="server" Text="Save" Width="73px" OnClick="btnSave_Click" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" Width="73px" OnClick="btnCancel_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>


    </div>
    <div>
  <asp:Panel ID="delPanel" runat="server">
                <asp:Label ID="lblMessageDispaly" runat="server" Font-Bold="True" Font-Size="Large" 
                    ForeColor="#0033CC" 
                    Text="Are You Sure You want to Delete the Selected Product Details Permanently?" BackColor="#FFFF66" />
        <br />
                <asp:Button ID="btnYes" runat="server" onclick="btnYes_Click" CausesValidation="false" 
                    style="text-align: right" Text="Yes" Width="63px" />
                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnNo" runat="server" onclick="btnNo_Click" CausesValidation="false" Text="No" 
                    Width="63px" />
        <br />
                <asp:Label ID="lbldisplay" runat="server" Font-Bold="True" Font-Size="X-Large" 
                    ForeColor="#0033CC" />
            </asp:Panel>

        </div>
    <div>
<asp:GridView ID="grdCategory" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" 
            AllowPaging="True" onpageindexchanging="grdCategory_PageIndexChanging" 
            onrowcommand="grdCategory_RowCommand">
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
                 <asp:Label ID="Label1" runat="server" Text="Is Active"></asp:Label>
             </HeaderTemplate>
             <ItemTemplate>
                  <asp:CheckBox ID="chkIsActive" runat="server" Enabled="false" Checked='<%# Eval("IsActive") %>' />
                
             </ItemTemplate>
             </asp:TemplateField>
             
               <asp:TemplateField HeaderText="Edit/Delete Category">
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <ItemTemplate>
                          <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/Images/edit.gif" ToolTip="Edit" CausesValidation="false" CommandArgument='<%# Eval("CategoryId") %>' CommandName="cmdedit" />
                        <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/Images/delete.png" ToolTip="Delete" CausesValidation="false" CommandArgument='<%# Eval("CategoryId") %>' CommandName="cmddelete" />
                 

                    </ItemTemplate>
                    </asp:TemplateField>
               </Columns>
        </asp:GridView>

    </div>
</asp:Content>
