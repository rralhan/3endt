<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Client.Master" AutoEventWireup="true"
    CodeBehind="products.aspx.cs" Inherits="_3EndTCommercePresentation.Client.Products" EnableEventValidation="false" %>

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
                            <asp:ListView ID="lvProducts" runat="server" OnItemDataBound="lvProducts_ItemDataBound" OnItemCommand="lvProducts_ItemCommand" OnPreRender="lvProducts_PreRender">
                                <LayoutTemplate>
                                    <div id="itemPlaceholder" runat="server"></div>
                                    <div class="clear"></div>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <div class="col-lg-3">
                                        <div <%--class="product-margin"--%>>
                                            <div class="img" style="line-height: 200px; height: 240px; padding: 10px">
                                                <img id="imgProduct" runat="server" class="img-dimension card-img-top" src="#" alt="" style="width: 100%; max-width: 198px; max-height: 198px;" />
                                            </div>
                                            <hr />
                                            <div class="product-padding" style="padding: 10px; min-height: 25px;">
                                                <div class="product-name" style="text-align: center;">
                                                    <a href='<%#GetProductLink(Eval("Type"),Eval("Id")) %>' style="color: #337ab7">
                                                        <asp:Label ID="lblItemTitle" runat="server" Text='<%#Eval("Title")%>' Style="font-weight: bold;" /></a>
                                                </div>
                                                <div class="hidden_inputs">
                                                    <asp:HiddenField ID="hdnItemId" runat="server" Value='<%#Eval("Id") %>' />
                                                    <asp:HiddenField ID="hdnItemType" runat="server" Value='<%#Convert.ToInt16(Eval("Type")) %>' />
                                                </div>
                                            </div>
                                            <div class="price_and_button_container" style="min-height: 240px; position: relative;">
                                                <asp:LoginView ID="lvItemPrice" runat="server">
                                                    <LoggedInTemplate>
                                                        <div id="divProductItemPrice" runat="server">
                                                            <div class="row">
                                                                <div class="col-md-12 table_one">
                                                                    <div class="row row_min-height">
                                                                        <div class="col-md-4p text-left">
                                                                            <strong>
                                                                                <asp:Label ID="lblPrimaryFilterType" runat="server"></asp:Label></strong>
                                                                        </div>
                                                                        <div class="col-md-8">
                                                                            <asp:DropDownList ID="ddlPrimaryFilter" runat="server" CssClass="entries demoselect"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row row_min-height">
                                                                        <div class="col-md-4 text-left">
                                                                            <strong>
                                                                                <asp:Label ID="lblSecondaryFilterType" runat="server"></asp:Label></strong>
                                                                        </div>
                                                                        <div class="col-md-8">
                                                                            <asp:DropDownList ID="ddlSecondaryFilter" runat="server" CssClass="entries demoselect"></asp:DropDownList>
                                                                        </div>
                                                                        <asp:HiddenField ID="hdnSecondaryProductItemChoice" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div id="divAddToCart" runat="server" class="price_div">
                                                                <div class="price_div_top">
                                                                    <div>
                                                                        <asp:Label ID="lblProductItemPrice" runat="server" CssClass="price product-price"></asp:Label>
                                                                        <span style="display: none;">
                                                                            <asp:Label ID="lblProductUnit" runat="server"></asp:Label></span>
                                                                    </div>
                                                                </div>
                                                                <asp:LinkButton ID="lnkCart" runat="server" CssClass="btncart" CommandName="AddToCart" data-name="lnkCart">Add To Cart</asp:LinkButton>
                                                                <a id="lnkRFQ" href="#" runat="server" class="btncart" target="_blank" data-name="lnkRFQ">Request for Quote</a>
                                                            </div>
                                                            <input type="hidden" id="hdnProductItems" runat="server" data-name="hdnProductItems" />
                                                        </div>
                                                    </LoggedInTemplate>
                                                </asp:LoginView>
                                            </div>
                                            <div id="divFurtherCategory" runat="server" class="price_div" style="text-align: center; position: absolute; bottom: 0; width: 100%; min-height: 35px; margin-top: 15px; padding: 10px; background-color: #FFFFFF; padding-top: 0px;">
                                                <a id="lnkCategory" class="btn btn-yellow" href='<%#GetProductLink(Eval("Type"),Eval("Id")) %>'>Select Product</a>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            resetNavigation();
        });
    </script>
</asp:Content>
