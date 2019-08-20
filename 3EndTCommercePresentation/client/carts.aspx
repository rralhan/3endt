<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Client.Master" AutoEventWireup="true"
    CodeBehind="carts.aspx.cs" Inherits="_3EndTCommercePresentation.client.carts" %>

<%@ Import Namespace="_3EndTBusinessLayer" %>
<%@ Import Namespace="System.Data" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CoreContentHolder" runat="server">
    <div class="allpage col-xs-12 pull-left">
        <div class="common-title pull-left">
            Products &raquo; <span class="category">Cart Information</span>
        </div>
        <asp:UpdatePanel ID="upnlCartItems" runat="server">
            <ContentTemplate>
                <div class="otheritems col-xs-12 pull-left">
                    <asp:DataList ID="dlCartItems" runat="server" CssClass="halfdiv" OnItemDataBound="dlCartItems_ItemDataBound">
                        <ItemTemplate>
                            <div class="col-xs-6 pull-left others">
                                <div class="common-block pull-left">
                                    <div class="product-image-sm pull-left">
                                        <img src="../images/product-image-small.jpg" alt="" />
                                        <a href="#" class="delete">Delete</a>
                                    </div>
                                    <div class="product-details-sm">
                                        <span class="product-name"><a href="#"><%#Eval("ProductTitle")%></a> </span><span
                                            class="itemselection"><span class="col-xs-12 pull-left">
                                                <label for="itemscount">
                                                    Units Needed:</label>
                                                <asp:DropDownList ID="ddlItemQuantity" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlItemQuantity_SelectionChanged">
                                                    <asp:ListItem Text="1" Value="1" Selected="True" />
                                                    <asp:ListItem Text="2" Value="2" />
                                                    <asp:ListItem Text="3" Value="3" />
                                                    <asp:ListItem Text="4" Value="4" />
                                                    <asp:ListItem Text="5" Value="5" />
                                                </asp:DropDownList>
                                            </span>
                                            <div id="divFilters" runat="server">
                                                <asp:HiddenField ID="hdProductId" runat="server" Value='<%#Eval("ProductId")%>' />
                                                <asp:HiddenField ID="hdProductItemId" runat="server" Value='<%#Eval("ProductItemId")%>' />
                                                <asp:HiddenField ID="hdOriginalProductItemId" runat="server" Value='<%#Eval("ProductItemId")%>' />
                                                <div id="divType" runat="server">
                                                    <span class="col-xs-12 pull-left">

                                                        <label for="itemstype" style="text-align: right; float: none">
                                                            Type:</label>
                                                        <asp:DropDownList ID="ddlProductType" AutoPostBack="true" OnSelectedIndexChanged="ddlProductType_SelectedIndexChanged" CssClass="itemstype" runat="server" />

                                                    </span>
                                                </div>
                                                <div id="divDimension" runat="server">
                                                    <span class="col-xs-12 pull-left">

                                                        <label for="itemstype" style="text-align: right; float: none">
                                                            Dimension:</label>
                                                        <asp:DropDownList ID="ddlDimension" AutoPostBack="true" CssClass="itemstype" OnSelectedIndexChanged="ddlDimension_SelectedIndexChanged" runat="server" />
                                                    </span>
                                                </div>
                                                <div id="divThickness" runat="server">
                                                    <span class="col-xs-12 pull-left">
                                                        <label for="itemstype" style="text-align: right; float: none">
                                                            Thickness:</label>
                                                        <asp:DropDownList ID="ddlThickness" AutoPostBack="true" CssClass="itemstype" OnSelectedIndexChanged="ddlThickness_SelectedIndexChanged" runat="server" />
                                                    </span>
                                                </div>
                                            </div>
                                        </span>

                                        </span>


                                </span><span class="price">Total Price:<span> $
                                    <asp:Label ID="lblItemPrice" runat="server" Visible="false" Text='<%#Eval("UnitPrice")%>' />
                                    <asp:Label ID="lblItemPriceTotal" runat="server" Visible="true" Text='<%#Eval("TotalPrice")%>' />
                                </span></span></span>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                    <div class="col-xs-12 pull-left controls">
                        <div class="col-xs-6 pull-left">
                            <asp:LinkButton ID="btnUpdateCart" CssClass="update" Text="Update Cart" runat="server" OnClick="btnUpdateCart_Click" />
                            <%--<a href="#" class="update">Update cart</a>--%>
                        </div>
                        <div class="col-xs-6 pull-right">
                            <asp:LinkButton ID="lnkNextStep" CssClass="nextstep" Text="Next Step" runat="server" PostBackUrl="~/client/purchase-order.aspx" />
                            <%--<a href="#" class="nextstep">Next Step &raquo;</a>--%>
                        </div>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </div>
</asp:Content>
