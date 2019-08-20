<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ManageDocuments.aspx.cs" Inherits="_3EndTCommercePresentation.admin.ManageDocuments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="toptable">
        <tr>
            <td colspan="3" class="tdcenter heading">Manage Documents</td>
        </tr>
        <tr>
            <td class="tdfirst">Name:</td>
            <td>
                <asp:TextBox ID="txtDocumentName" runat="server" CssClass="entries"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="refCategory" CssClass="imp-msg" ValidationGroup="ValidateCategory" ControlToValidate="txtDocumentName" ValidateRequestMode="Enabled" runat="server" ErrorMessage="Please enter a value for Document Name" />
            </td>
        </tr>
        <tr>
            <td class="tdfirst">Document:</td>
            <td>
                <asp:FileUpload ID="fuDocument" runat="server" Width="300px" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="tdfirst"></td>
            <td>
                <asp:Button ID="btnSave" runat="server" ValidationGroup="ValidateCategory" Text="Save" CssClass="btnsubmit" CausesValidation="true" OnClick="btnSave_Click" />
            </td>
            <td><asp:Label ID="lblError" runat="server" CssClass="imp-msg"></asp:Label></td>
        </tr>
    </table>
    <div>
        <asp:GridView ID="grdDocumentLinks" runat="server" AutoGenerateColumns="False" PageSize="20"
            CellPadding="4" ForeColor="#333333" GridLines="Vertical" Width="100%"
            AllowPaging="True">
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
                        <asp:Label ID="lblDocumentName" runat="server" Text="Document Name"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcategoryname" runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                                   <asp:TemplateField>
                    <HeaderStyle HorizontalAlign="left" />
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderTemplate>
                        <asp:Label ID="lblDocumentName" runat="server" Text="Document Link"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblcategoryname" runat="server" Text='<%#Eval("Url") %>'></asp:Label>
                   </ItemTemplate>
                </asp:TemplateField>
                 </Columns>
        </asp:GridView>
    </div>
</asp:Content>
