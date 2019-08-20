<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ManageProductItemPrice.aspx.cs" Inherits="_3EndTCommercePresentation.admin.ManageProductItemPrice" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="toptable">
        <tr>
            <td class="tdfirst">Tier:</td>
            <td class="tdsecond">
                <asp:DropDownList ID="ddlTiers" runat="server" CssClass="entries" AutoPostBack="true"  OnSelectedIndexChanged="ddlTiers_SelectedIndexChanged" >                 
                </asp:DropDownList>                                  
               
            </td>
        </tr>
        <tr>

            <td></td>
            <td><asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vgTierPrice"/></td>
        </tr>
        <tr>
            <td colspan="2">


                 <table class="tblProductItemPrice">
                     <thead>
                         <tr>
                             <td style="border: thin solid #800000; font-style: italic; font-weight: bold; width:500px;">&nbsp;</td>
                             <td class="tdproductitemheader">Regular Tier Prices</td>
                             <td class="tdproductitemheader"><asp:Label ID="lblTierHeader" runat="server"></asp:Label></td>
                         </tr>
                     </thead>


                     <asp:ListView ID="lvProductItems" runat="server" OnItemDataBound="lvProductItems_ItemDataBound"  >
                         <LayoutTemplate>
                             <tr id="itemPlaceholder" runat="server">
                             </tr>
                             
                             
                         </LayoutTemplate>
                         <ItemTemplate>
                             <tr id="rowProduct" runat="server" >
                                 <td>
                                     <b>
                                     <asp:Label ID="lblProduct" runat="server" Text='<%#Eval("ProductName") %>'></asp:Label></b></td>
                                 <td colspan="2">&nbsp;</td>
                             </tr>
                             <tr>
                                 <td>
                                     <asp:HiddenField ID="hdnProductItemId" runat="server" Value='<%#Eval("ItemId") %>' />
                                     <asp:Label ID="lblProductItemName" runat="server" Text='<%#Eval("ProductSKU") %>'></asp:Label></td>
                                 <td style="text-align:center; vertical-align:text-top">
                                     <asp:Label ID="lblRegularTierPrices" runat="server"></asp:Label></td>
                                 <td style="text-align:center;vertical-align:text-top">
                                     $ <asp:TextBox ID="txtTierPrices" runat="server" Width="50px"></asp:TextBox>
                                      <asp:RegularExpressionValidator ID="regexTierPrices" runat="server" CssClass="imp-msg" ControlToValidate="txtTierPrices" ValidationExpression="^[0-9,]+(\.\d{1,2})?|(rfq)$" ErrorMessage="Only decimals OR the work 'rfq' are accepted" ValidationGroup="vgTierPrice"></asp:RegularExpressionValidator>
                                 </td>

                             </tr>
                         </ItemTemplate>
                     </asp:ListView>
                     <tr>
                         <td colspan="3" runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000; margin:auto;">
                             <asp:DataPager ID="dpProductItems" runat="server" PagedControlID="lvProductItems" PageSize="50" OnPreRender="dpProductItems_PreRender">
                                 <Fields>
                                     <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                     <asp:NumericPagerField ButtonType="Link" />
                                     <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                 </Fields>
                             </asp:DataPager>
                         </td>
                     </tr>
                 </table>
            </td>

        </tr>
    </table>
</asp:Content>
