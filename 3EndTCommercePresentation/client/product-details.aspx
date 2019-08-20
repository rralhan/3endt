<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Client.Master" AutoEventWireup="true" CodeBehind="product-details.aspx.cs" Inherits="_3EndTCommercePresentation.Client.product_details" %>

<%@ Register Src="UserControls/ShoppingCart.ascx" TagName="ShoppingCart" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CoreContentHolder" runat="server">
    <div>

        <div class="single_product_title">
            <uc1:ShoppingCart ID="ShoppingCart1" runat="server" />
        </div>
        <div class="single_product_details">
            <div class="col-md-12">
            <div class="col-md-12 single_product_details_inner">
            <div class="product-name">
                <asp:Label ID="lblProductName" runat="server"></asp:Label>
            </div>
            <div class="col-sm-3 product_image">
                <img src="../images/product-image-small.jpg" alt="" id="imgProduct" runat="server" class="product-image-me"/>
            </div>
                <div class="col-sm-9">
            <div class="product-desc">
                <asp:Label ID="lblProductDesc" runat="server"></asp:Label>
            </div>
                    
                    
                    <!--
                    <div class="row first-input">
                        <div class="col-md-8">
                            <div class="row" >
                            <div class="col-md-5">
                             <strong>   <asp:Label ID="lblPrimaryFilterType" runat="server"></asp:Label></strong>
                            </div>
                            <div class="col-md-7">
                                <asp:DropDownList ID="ddlPrimaryFilter" runat="server" CssClass="entries  form-control"></asp:DropDownList>
                            </div>
                                </div>
                        </div>
                    </div>
<div class="row second-input">
                        <div class="col-md-8">
                            <div class="row" >
                            <div class="col-md-5"><strong> <asp:Label ID="lblSecondaryFilterType" runat="server"></asp:Label> </strong></div>
                            <div class="col-md-7">
                                <asp:DropDownList ID="ddlSecondaryFilter" runat="server" CssClass="entries form-control"></asp:DropDownList>
                            </div>
                        </div></div>
                      
                    </div>
-->
                    
            <asp:LoginView ID="lvItemPrice" runat="server">
                <LoggedInTemplate>

                    <table>
                        <tr class="first-input">
                            <td><strong><asp:Label ID="lblIdentifier" runat="server">SKU: </asp:Label></strong></td>
                             <td><asp:Label ID="lblSKU" runat="server"></asp:Label></td>
                        </tr>
                        <tr class="first-input">
                            <td><strong><asp:Label ID="lblPrimaryFilterType" runat="server"></asp:Label></strong></td>
                            <td><asp:DropDownList ID="ddlPrimaryFilter" runat="server" CssClass="entries  form-control"></asp:DropDownList></td>
                        </tr>
                        <tr class="second-input">
                            <td><strong><asp:Label ID="lblSecondaryFilterType" runat="server"></asp:Label> </strong></td>
                            <td><asp:DropDownList ID="ddlSecondaryFilter" runat="server" CssClass="entries form-control"></asp:DropDownList></td>
                        </tr>
                    </table>
                    
                    <div class="row">
                        <div class="col-md-6 col-md-offset-6 price-button">
                            <div class="row">
                                <div class="col-md-12 text-right price_div">
                                    <table style="float: right; margin: 0px;">
                                        <tr>
                                            <td><asp:Label ID="lblProductItemPrice" runat="server" CssClass="price product-price"></asp:Label></td>
                                            <td><asp:Label ID="lblProductUnit" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                    
                                    
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12 text-right">
                                    <asp:LinkButton ID="lnkCart" runat="server" CssClass="btncart" OnClick="lnkCart_Click">Add To Cart</asp:LinkButton>
                                    <a id="lnkRFQ" runat="server" class="btncart" target="_blank">Request for Quote</a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:HiddenField ID="hdnProductItems" runat="server" />

                </LoggedInTemplate>
            </asp:LoginView>
                    </div>
        </div></div></div>
    </div>
</asp:Content>
