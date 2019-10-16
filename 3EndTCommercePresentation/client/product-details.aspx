<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Client.Master" AutoEventWireup="true" CodeBehind="product-details.aspx.cs" Inherits="_3EndTCommercePresentation.Client.product_details" %>

<%@ Register Src="UserControls/ShoppingCart.ascx" TagName="ShoppingCart" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CoreContentHolder" runat="server">
    <link href="../vendors/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../js1/jquery-1.10.2.min.js"></script>
    <script src="../vendors/bootstrap/js/bootstrap.min.js"></script>
    <div id="page-wrapper">
        <!--BEGIN TITLE & BREADCRUMB PAGE-->
        <div id="title-breadcrumb-option-demo" class="page-title-breadcrumb">
            <div class="page-header">
                <uc1:ShoppingCart ID="ShoppingCart1" runat="server" style="font-size: xx-large" />
            </div>
            <div class="clearfix"></div>
        </div>
        <!--END TITLE & BREADCRUMB PAGE-->
        <!--BEGIN CONTENT-->
        <div class="page-content">
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel">
                        <div class="panel-body">
                            <div class="col-md-12">
                                <div class="col-md-12">
                                    <div class="product-name">
                                        <asp:Label ID="lblProductName" runat="server" style="font-size:22px"></asp:Label>
                                    </div>
                                    <hr />
                                    <div class="col-sm-3">
                                        <img src="../images/product-image-small.jpg" alt="" id="imgProduct" runat="server" class="product-image-me" />
                                    </div>
                                    <div class="col-sm-9">
                                        <div class="product-desc">
                                            <asp:Label ID="lblProductDesc" runat="server"></asp:Label>
                                        </div>
                                        <asp:LoginView ID="lvItemPrice" runat="server">
                                            <LoggedInTemplate>
                                                <table>
                                                    <tr class="first-input">
                                                        <td><strong>
                                                            <asp:Label ID="lblIdentifier" runat="server">SKU: </asp:Label></strong></td>
                                                        <td>
                                                            <asp:Label ID="lblSKU" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr class="first-input">
                                                        <td><strong>
                                                            <asp:Label ID="lblPrimaryFilterType" runat="server"></asp:Label></strong></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlPrimaryFilter" runat="server" CssClass="entries  form-control"></asp:DropDownList></td>
                                                    </tr>
                                                    <tr class="second-input">
                                                        <td><strong>
                                                            <asp:Label ID="lblSecondaryFilterType" runat="server"></asp:Label>
                                                        </strong></td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlSecondaryFilter" runat="server" CssClass="entries form-control"></asp:DropDownList></td>
                                                    </tr>
                                                </table>
                                                <div class="row">
                                                    <div class="col-md-6 col-md-offset-6 price-button">
                                                        <div class="row">
                                                            <div class="col-md-12 text-right price_div">
                                                                <table style="float: right; margin: 0px;">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblProductItemPrice" runat="server" CssClass="price product-price"></asp:Label></td>
                                                                        <td>
                                                                            <asp:Label ID="lblProductUnit" runat="server"></asp:Label></td>
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
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
