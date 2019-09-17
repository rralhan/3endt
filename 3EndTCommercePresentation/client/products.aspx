<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Client.Master" AutoEventWireup="true"
    CodeBehind="products.aspx.cs" Inherits="_3EndTCommercePresentation.Client.Products" EnableEventValidation="false"%>

<%@ Register Src="UserControls/ShoppingCart.ascx" TagName="ShoppingCart" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CoreContentHolder" runat="server">

    <script>
        resetNavigation();
    </script>
    <div class="products_page">
        <div>
            <uc1:ShoppingCart ID="ShoppingCart1" runat="server" />
        </div>

        <div class="clear"></div>

        <div class="main_product_container">
            <asp:ListView ID="lvProducts" runat="server" OnItemDataBound="lvProducts_ItemDataBound" OnItemCommand="lvProducts_ItemCommand" OnPreRender="lvProducts_PreRender">
                <LayoutTemplate>
                    <div id="itemPlaceholder" runat="server"></div>
                    <div class="clear"></div>
                </LayoutTemplate>

                <ItemTemplate>
                    <div class="card product-details-me col-lg-3 col-md-4 col-sm-6" <%--style=" width:18rem;"--%>>
                        <div class="product-margin">
                            <div class="img-container product-padding">
                                <img id="imgProduct" runat="server" class="img-dimension card-img-top" src="#" alt="" />
                            </div>
                            <div class="product-separator"></div>

                            <div class="product-padding">
                                <div class="product-name">
                                    <a href='<%#GetProductLink(Eval("Type"),Eval("Id")) %>'>
                                        <asp:Label ID="lblItemTitle" runat="server" Text='<%#Eval("Title")%>' /></a>
                                    
                                </div>
                                <div class="hidden_inputs">
                                    <asp:HiddenField ID="hdnItemId" runat="server" Value='<%#Eval("Id") %>' />
                                    <asp:HiddenField ID="hdnItemType" runat="server" Value='<%#Convert.ToInt16(Eval("Type")) %>' />
                                    <!--                                    <asp:Label CssClass="pdetails" ID="lblDescription" runat="server" Text='<%#GetProductDetails(Eval("Description"))%>' />-->
                                </div>
                            </div>

                            <div class="price_and_button_container ">
                                <asp:LoginView ID="lvItemPrice" runat="server">
                                    <LoggedInTemplate>
                                        <div id="divProductItemPrice" runat="server">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <%--<small id="lblSKU" runat="server" visible="false"></small>--%>
                                                </div>
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
                                                        <span style="display:none;"><asp:Label ID="lblProductUnit" runat="server"></asp:Label></span>
                                                    </div>
                                                </div>
                                                <asp:LinkButton ID="lnkCart" runat="server" CssClass="btncart" CommandName="AddToCart" data-name="lnkCart">Add To Cart</asp:LinkButton>
                                                <%--<a id="lnkCart" href="#" runat="server" class="btncart" data-name="lnkCart">Add To Cart</a>--%>
                                                <a id="lnkRFQ" href="#" runat="server" class="btncart" target="_blank" data-name="lnkRFQ">Request for Quote</a>
                                               <%-- <asp:LinkButton ID="lnkRFQ" runat="server" CssClass="btncart" PostBackUrl="~/client/contact-us.aspx" OnClientClick="aspnetForm.target ='_blank';">Request for Quote</asp:LinkButton>                                             --%>
                                            </div>
                                            <input type="hidden" id="hdnProductItems" runat="server" data-name="hdnProductItems"/>
                                        </div>

                                    </LoggedInTemplate>
                                </asp:LoginView>

                            </div>
                            <div id="divFurtherCategory" runat="server" class="price_div">
                                <a id="lnkCategory" class="btn btncart" href='<%#GetProductLink(Eval("Type"),Eval("Id")) %>'>Select Product</a>
                            </div>
                        </div>
                    </div>
                    
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>
