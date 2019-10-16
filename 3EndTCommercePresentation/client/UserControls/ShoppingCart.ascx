<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.ascx.cs" Inherits="_3EndTCommercePresentation.client.UserControls.UC_ShoppingCart" %>
<script type="text/javascript" >
    var jsShoppingCart = {
        displayCart: function () {
            $("#dialog").dialog(
                {
                    modal: true,
                    height: "auto",
                    width: 750,
                    show: true
                });
            this.updatePrice();
        },
        updatePrice: function () {
            var wrapdivs = $('div.item__information');
            var totalcost = 0;
            var totalitems = 0;

            $.each(wrapdivs, function (i, e) {
                var quantcntrl = $(e).find("input[data-name='quantity']");
                var quantity = parseFloat(quantcntrl.val());
                if (quantity <= 0) {
                    quantcntrl.parents('.item__information').hide(800);
                }
                var unitprice = parseFloat($(e).find("#hdnUnitPrice").val().replace('$', ''));
                var cost = quantity * unitprice;
                var pricelabel = $(e).find("span[data-name='price']");
                pricelabel.text("$ " + parseFloat(cost).toFixed(2));
                totalcost += cost;
                totalitems += quantity;
            });
            $('#<%=spnCartQuantity.ClientID%>').text(totalitems);
            $('#spnSumTotal').text("$ " + parseFloat(totalcost).toFixed(2));
            this.updateCart();
            if(totalitems <= 0)
            {
                this.closeCart();              
                $('#<%=divDisplayCart.ClientID%>').hide();
            }
        },

        isNumber: function (evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        },
        deleteItem: function (btnClose, txtQuantity) {
            $('#' + txtQuantity).val(0);
            this.updatePrice();            
        },
        updateCart: function () {
            var wrapdivs = $('div.item__body');
            var jsonArr = [];
            wrapdivs.each(function (i, e) {
                var item = $(e).find("input[name$='hdnProductItemId']");
                var quantity = $(e).find("input[data-name='quantity']");
                jsonArr.push({
                    ItemId: item.val(),
                    Quantity: quantity.val()
                });
            });

            $('#<%=hdnShoppingCart.ClientID %>').val(JSON.stringify(jsonArr));
                this.AJAXUpdateShoppingCart();
        },
        AJAXUpdateShoppingCart: function () {
            var strtempcarts = $('#<%=hdnShoppingCart.ClientID %>').val();
            $.ajax({
                type: "POST",
                url: "products.aspx/UpdateShoppingCart",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ strTempCarts: strtempcarts }),
                dataType: "json"
            });
        },
        closeCart: function()
        {
            $("#dialog").dialog("close");
        }


    };
</script>

<style>
    .ui-draggable .ui-dialog-titlebar {
        background: #084A46;
    }
    .ui-dialog.ui-widget{
        padding: 0px;
        top: 60px !important;
        height: 80% !important;
        position: fixed !important;
        width: auto !important;
        max-width:750px;
        left: 0px !important;
        right: 0px !important;
        margin: 0 auto;

    }
    .ui-dialog .ui-dialog-title{
          color: #F9AD19;
    }
    .ui-dialog .ui-dialog-content {
          height: calc(100% - 50px) !important;
          padding: 0px;
          overflow:hidden;

    }
    .summary.js-summary{
        background-color: #F1F1F1;
        padding-bottom:10px;
        padding-left:2%;
    }
    
    .shopping_cart_without_button {
          height: calc(100% - 120px) !important;
          overflow-y: auto !important;
          padding: 5px 20px;
    }
    ul.checkout li {
          list-style:none;
          display: table;
          float: right;
        }
    div.product-image-sm.item__image img {
        width: 100%;
        height: auto;
    }
    li.item{
        border: none !important;
        padding: 0px !important;
    }
    div.item__information {
        padding:20px;
        border-bottom: 1px solid #ddd !important;
          display: block;
          width:100%;
    }
    div.product_info-sm{
        float:left;
        width: calc(100% - 150px);
        padding-left: 20px;
    }
    div.product-image-sm.item__image{
        float:left;
        width:150px;
    }
    div.product-choice div, div.price_box{
        margin-bottom:10px;
    }
    .pull-left{float:left!important}
</style>

<div style="font-size:xx-large;width: 98%; border-bottom: 0px solid #DDDDDD; margin-top: 0px" class="pull-left">
    <div class="common-title" style="width: 90%; float: left; border: none">
        <span><%=HeaderLabel %> &raquo;</span>
    </div>
    <input type="hidden" id="hdnShoppingCart" runat="server" data-name="hdnShoppingCart" />

    <asp:LoginStatus ID="MainLoginStatus" LogoutAction="Redirect" LogoutPageUrl="/Default.aspx" runat="server" LoginText="Login" LogoutText="Logout" OnLoggedOut="MainLoginStatus_LoggedOut" CssClass="btn btn-primary" />

    <div id="divDisplayCart" runat="server" data-name="divDisplayCart" style="width: 50%; text-align: right; float: right; display: none;">
        <%--<asp:LinkButton ID="lnkDisplayCart" runat="server" OnClick="lnkDisplayCart_Click"></asp:LinkButton>--%>
        <a href="#" onclick="jsShoppingCart.displayCart(); ">
            <span style="font-weight: bold; font-size: large">
                <img src="/Images/shopping-cart-2.png" />
            </span>
            <span id="spnCartQuantity" runat="server" class="cart-quantity" data-name="cartQuantity"></span>
        </a>
        <%-- <span style="font-weight: bold; font-size: large">
                <img src="/Images/shopping-cart-2.png" />
            </span>
            <span id="spnCartQuantity" runat="server" class="cart-quantity" data-name="cartQuantity"></span>--%>
    </div>
</div>
<div id="dialog" title="Shopping Cart">
    <div class="shopping_cart_without_button">
        <asp:ListView ID="lvShoppingCart" runat="server" OnItemDataBound="lvShoppingCart_ItemDataBound">
            <LayoutTemplate>
                <ul class="item-list">
                    <li id="itemPlaceholder" runat="server"></li>
                </ul>
            </LayoutTemplate>
            <ItemTemplate>
                <li class="item">
                    <div class="item__information" style="border: 1px solid #DDDDDD; position: relative;">
                        <div class="product-image-sm item__image">
                            <img src="<%#Eval("ImageUrl")%>" alt="" />
                        </div>
                        <div class="product_info-sm">
                            <div class="item__body" <%--class="product-details-sm"--%>>
                                <div class="product-name item__title">
                                    <label><%#Eval("ProductName")%></label>
                                </div>
                                <asp:HiddenField ID="hdnProductId" runat="server" Value='<%#Eval("ProductId")%>' />
                                <asp:HiddenField ID="hdnProductItemId" runat="server" Value='<%#Eval("ProductItemId")%>' />
                                <div class="product-choice">
                                    <div>
                                        <strong>
                                            <asp:Label ID="lblPrimaryFilterType" runat="server"></asp:Label></strong>
                                        <asp:Label ID="lblPrimaryFilterValue" runat="server"></asp:Label>
                                    </div>
                                    <div>
                                        <strong>
                                            <asp:Label ID="lblSecondaryFilterType" runat="server"></asp:Label></strong>
                                        <asp:Label ID="lblSecondaryFilterValue" runat="server"></asp:Label>
                                    </div>                               
                                </div>
                                <div class="price_box">
                                    <span style="width: 60%; display: inline-block;">
                                        <label>
                                            Quantity: &nbsp;&nbsp;</label>
                                        <asp:TextBox ID="txtQuantity" data-name="quantity" runat="server" Style="width: 40px;" onblur="jsShoppingCart.updatePrice();" Text='<%#Eval("Quantity")%>'> </asp:TextBox>
                                    </span>
                                    <div style="width: 38%; display: inline-block; font-size: 20px; font-weight: 600; color: #084A46; text-align: right;">
                                        <input type="hidden" id="hdnUnitPrice" value='<%#Eval("UnitPrice") %>' />
                                        <asp:Label ID="lblItemPriceTotal" data-name="price" runat="server" Text='<%#string.Format("$ {0:#,###0.00}",Eval("TotalPrice"))%>' />
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div style="position: absolute; top: 10px; right: 10px; cursor: pointer;">
                            <img src="/Images/close_button.png" alt="close" id="imgBtnClose" runat="server" />
                        </div>
                        <div style="clear: both"></div>
                    </div>
                </li>

            </ItemTemplate>


        </asp:ListView>
    </div>
    <div class="summary js-summary">
        <div style="width: 48%; display: inline-block; vertical-align: bottom;">
            <a href="#" id="lnkContinue" class="checkout btncart" style="float: left; width: 150px;" onclick="jsShoppingCart.closeCart();">Continue Shopping </a>

        </div>
        <div style="width: 48%; display: inline-block; vertical-align: bottom; text-align: center;">
            <ul class="checkout">
                <li style="width: 100%; float: left; font-size: 24px; font-weight: 600; padding: 15px 0;">
                    <span style="display: inline-block; width: 50%; float: left">Total:</span>
                    <span id="spnSumTotal" class="price sum" style="float: right;"></span>
                </li>
                <li style="float: right;">
                    <asp:LinkButton ID="lnkCheckout" runat="server" CssClass="checkout btncart" Text="Checkout" OnClick="lnkCheckout_Click" OnClientClick="jsShoppingCart.updateCart();"></asp:LinkButton>

                </li>
            </ul>
        </div>
    </div>
    <input type="hidden" id="hdnIsUserAuthenticated" value="<%=IsUserAuthenticated %>" />
</div>
<script type="text/javascript">
    $(function () {
        $("#dialog")[0].style.display = "none";
    });

    $(document).ready(function () {
        if ($("#hdnIsUserAuthenticated").attr('value') == 'False') {
            $('.price_and_button_container').css("display", "none");
        }
    });

    $(document).on("resize", function () {

        $('.main_product_container').each(function () {
            var highestBox = 0;
            $('.product-details-me > .product-margin', this).each(function () {

                if ($(this).height() > highestBox)
                    highestBox = $(this).height();
            });

            $('.product-details-me > .product-margin', this).height(highestBox);
        });
    }).resize();
</script>
