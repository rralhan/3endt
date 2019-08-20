<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ManageCustomerTierProductPrice.aspx.cs" Inherits="_3EndTCommercePresentation.admin.ManageCustomerTierProductPrice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script>
         function clickTier(specialCustomer) {
             __doPostBack(specialCustomer);
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </div>
    <div style="float: left; width: 79%">
         <div>

                            Special Customer Name:
                            <asp:Label ID="lblSpecialCustomer" runat="server" />
                        </div>
        <asp:GridView ID="gvSpecialCustomerPrice" AutoGenerateColumns="False"   runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                         <table>
                    <tr>

                        <td>
 <asp:Image ID="imgItemImage" runat="server" ImageUrl='<%# Eval("ImageUrl")%>' 
                        Width="40px" />

                        </td>
                        <td>
 <asp:Label ID="lblProductName" runat="server"  Text='<%#Eval("ProductTitle") %>'></asp:Label>

                        </td>
                      
                    </tr>
                    <tr>

                        <td>
 <asp:Label ID="lblTierProdutId" runat="server" Visible="false" Text='<%#Eval("TierProductId") %>'></asp:Label>

                        </td>
                         
                    </tr>
                </table>
               
               
               

                    </ItemTemplate>

                </asp:TemplateField>
                <asp:TemplateField HeaderText="Retail Price">
                   
                    <ItemTemplate>
                       <asp:TextBox ID="txtRetailPrice" Text='<%# Eval("RetailPrice") %>' runat="server"></asp:TextBox>
                    </ItemTemplate>
          </asp:TemplateField>
            </Columns>
        </asp:GridView>
       
        <div>
            <table>
            <tr>

                        <td>
 
<asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="Save" />
                        </td>
                          <td>
<asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" Text="Reset" />
                        </td>
                    </tr>
                </table>
               
        </div>
            </div>
            <div style="float: right; border: 1px solid black; width: 19%">
                <asp:DataGrid ID="dgvCustomers" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Horizontal">
                    <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundColumn DataField='CustomerId' Visible="False"></asp:BoundColumn>
                        <asp:TemplateColumn HeaderText="Special Customer">
                            <ItemTemplate>
                               <div id="divTier" runat="server" onclick='<%# GetFormattedString( Eval("FirstName"), Eval("LastName"), Eval("CustomerId"))%>' style="cursor: pointer">
                                        <%# Eval("FirstName")+"  &nbsp;"+Eval("LastName") %>
                                    </div>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                    <EditItemStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />

                </asp:DataGrid>
            </div>
</asp:Content>
