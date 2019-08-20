<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Client.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="_3EndTCommercePresentation.Client.Home_Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CoreContentHolder" runat="server">
    <div class="slider pull-left">
        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <!--  <ol class="carousel-indicators">
    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
</ol> -->

            <!-- Wrapper for slides -->
            <div class="carousel-inner">
                <div class="item active">
                    <img src="../images/carousel.jpg" alt="...">
                    <div class="carousel-caption">
                    </div>
                </div>

                <div class="item">
                    <img src="../images/carousel.jpg" alt="...">
                    <div class="carousel-caption">
                    </div>
                </div>


                <div class="item">
                    <img src="../images/carousel.jpg" alt="...">
                    <div class="carousel-caption">
                    </div>
                </div>



            </div>

            <!-- Controls -->
            <a class="left carousel-control" href="#carousel-example-generic" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left"></span>
            </a>
            <a class="right carousel-control" href="#carousel-example-generic" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right"></span>
            </a>
        </div>
    </div>


    <%--<div class="featured col-xs-12 pull-left">
        <div class="common-title pull-left">Featured &raquo;</div>
        <div class="common-block pull-left">
            <div class="featured-block first pull-left">
                <div class="product-image-me pull-left">
                    <img src="../images/product-image-medium.jpg" alt="" />
                </div>
                <div class="product-details-me pull-left">
                    <span class="product-name">
                        <a href="#">Lorem ipsum dolor sit amet</a>
                    </span>
                    <span class="pdetails">consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut </span>
                    <span class="price">Price: $ 25.90</span>
                    <span class="add-to-cart"><a href="carts.html">Add to cart</a></span>
                    <span class="view-details"><a href="products-details.html">View details</a></span>
                </div>
            </div>

            <div class="featured-block pull-left">
                <div class="product-image-me pull-left">
                    <img src="../images/product-image-medium.jpg" alt="" />
                </div>
                <div class="product-details-me pull-left">
                    <span class="product-name">
                        <a href="#">Lorem ipsum dolor sit amet</a>
                    </span>
                    <span class="pdetails">consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut </span>
                    <span class="price">Price: $ 25.90</span>
                    <span class="add-to-cart"><a href="carts.html">Add to cart</a></span>
                    <span class="view-details"><a href="products-details.html">View details</a></span>
                </div>
            </div>

            <div class="featured-block pull-left">
                <div class="product-image-me pull-left">
                    <img src="../images/product-image-medium.jpg" alt="" />
                </div>
                <div class="product-details-me pull-left">
                    <span class="product-name">
                        <a href="#">Lorem ipsum dolor sit amet</a>
                    </span>
                    <span class="pdetails">consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut </span>
                    <span class="price">Price: $ 25.90</span>
                    <span class="add-to-cart"><a href="carts.html">Add to cart</a></span>
                    <span class="view-details"><a href="products-details.html">View details</a></span>
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>
