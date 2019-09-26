<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Client.Master" AutoEventWireup="true" CodeBehind="purchase-order.aspx.cs" Inherits="_3EndTCommercePresentation.client.purchase_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script type="text/javascript">
        jsPurchaseOrder = {
            updateTotalCost: function () {
                var priceLabels = $("span[data-name='price']");
                var totalcost = 0;
                priceLabels.each(function (i, e) {
                    totalcost = totalcost + parseFloat($(e).text().replace(/[^0-9\.-]+/g, ''));
                });
                $('#spnSumTotal').text("$ " + parseFloat(totalcost).toFixed(2));
            },
            displayShippingAddresses: function () {
                $("#dialog").dialog(
                    {
                        modal: true,
                        height: "auto",
                        width: 500,
                        position:{ my: "center", at: "top", of: window },
                        show: true
                    });
            },
            fixRadioButtons: function()
            {
                $('[name$="rbtnShippingAddress"]').attr("name", $('[name$="rbtnShippingAddress"]').attr("name"));

                $('[name$="rbtnShippingAddress"]').click(function () {
                    //set name for all to name of clicked 
                    $('[name$="rbtnShippingAddress"]').attr("name", $(this).attr("name"));                    
                });
            },
            setShippingAddressId:function()
            {
                $('[name$="rbtnShippingAddress"]').each(function () {
                    if ($(this).is(':checked')) {
                        var shipid = $(this).parent().attr('data-value');
                        $('#<%=hdnSelectedShipping.ClientID%>').val(shipid)

                    }
                })
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CoreContentHolder" runat="server">
    <div class="purchase_order_page_outer">
    <div class="allpage purchase_order_page">
        <div class="message_green">
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Text=""></asp:Label>
             <asp:HiddenField ID="hdnSelectedShipping" runat="server"  />
        </div>
        <div class="row">
        <div class="col-md-6 card">

            <div class="item-selected card-header">Items Selected &raquo;</div>
            <div class="common-block card-body">

                <asp:DataList ID="dlCartItems" runat="server" CssClass="threediv" CellSpacing="0" CellPadding="4">
                    <HeaderTemplate>

                        <div class="others theader">
                            <div>
                             
                                <div class="product-details-xsm">
                                    <div class="product-name">Product Name</div>
                                    <div class="itemselection">
                                            <label for="itemscount">Units</label>
                                    </div>
                                    <div class="price">Price ($)</div>
                                </div>
                            </div>
                        </div>
             
                               </HeaderTemplate>
                    <ItemTemplate>
                        <div class="others">
                            <div>                        
                                <div class="product-details-xsm">
                                     <asp:HiddenField ID="hdUnitPrice" runat="server" Value='<%#Eval("UnitPrice")%>' />
                                    <asp:HiddenField ID="hdProductItemId" runat="server" Value='<%#Eval("ProductItemId")%>' />
                                    <asp:HiddenField ID="hdProductId" runat="server" Value='<%#Eval("ProductId")%>' />
                                    <div class="product-name">
                                        <asp:Label ID="lblProductTitle" runat="server" Text='<%#Eval("ProductName")%>' /></div>
                                    <div class="itemselection">
                                            <label for="itemscount">
                                                <asp:Label ID="lblQuantity" runat="server" Text='<%#Eval("Quantity")%>' /></label>
                                    </div>
                                    <div class="price">
                                        <asp:Label ID="lblTotalPrice" data-name="price" runat="server" Text='<%#string.Format("$ {0:#,###0.00}", Eval("TotalPrice"))   %>' /></div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <asp:Label ID="lblConfirmation" runat="server" CssClass="conf-msg" Visible="false" Text="Thank you. Your order has been placed."></asp:Label>
            </div>
            
            <div class="col-xs-12 price_total_div card-footer">               
                <span class="col-xs-6">Total</span>
                <span id="spnSumTotal" class ="price col-xs-6">  </span>
            </div>
            </div>
            <div class="col-md-6 card">
            <div class="common-title card-header">Delivery Information &raquo;</div>
            <div class="delivery_info row card-body">
                <div class="col-xs-12 mar-top-10">
                    <h2>Billing Address</h2>
                    <div class="billaddress">
                        <div class="first_line">
                            <asp:Label ID="lblBillingAddressName" runat="server"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblBillingAddress" runat="server" />
                        </div>
                    </div>
                </div>
                <div class="col-xs-12 mar-top-10">
                    <h2>Shipping Address</h2>
                    <div class="billaddress">
                        <div class="first_line">
                            <asp:Label ID="lblShippingAddressName" runat="server"/>
                        </div>
                        <div>
                            <asp:Label ID="lblShippingAddress" runat="server" />
                        </div>
                    </div>
                    <div class="continue_btn">
                    <div id="divChangeShipping" runat="server">
                            <a href="#" id="lnkChangeShipping" class="billaddress" onclick="jsPurchaseOrder.displayShippingAddresses();">Change Shipping &raquo;</a>
                    </div>
                        </div>
                </div>
            </div>

            <div class="row order_number card-footer">
                <div class="col-sm-6">
                <h3 class="common-title">Order Number »</h3>
                    </div>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtPurchaseOrderNumber" runat="server" CssClass="form-control"/>
                </div>
                    
            </div>
            <div class="row controls">
            <div class="col-sm-12 error_confirmation">
                <asp:RequiredFieldValidator ID="reqPONumber" runat="server" ControlToValidate="txtPurchaseOrderNumber" ValidationGroup="PurchaseConfirmation"
                        CssClass="imp-msg " Text="*Please enter a Purchase Order Number" ErrorMessage="*Please enter a Purchase Order Number" Display="Static"></asp:RequiredFieldValidator>
            </div>
                </div>
            <div class="row controls">
                <div class="col-sm-6 continue_shopping">
                    <a href="/default.aspx" id="lnkContinueShopping">&nbsp;&nbsp;Continue Shopping &raquo;&nbsp;</a>
                </div>
                <div class="col-sm-2">&nbsp;</div>
                <div class="col-sm-4 text-right">
                    <asp:LinkButton ID="btnPlaceOrder" CssClass="btn btncart" runat="server" Text="Place Order &raquo;" OnClick="btnPlaceOrder_Click" ValidationGroup="PurchaseConfirmation" />
                </div>
            </div>
        </div>
    </div>
        </div>
        </div>
    <div id="dialog" class="change_addr_popup" title="Change Shipping Address">       
      
        <asp:ListView ID="lvShippingAddressSelection" runat="server" OnItemCommand="lvShippingAddressSelection_ItemCommand" OnItemDataBound="lvShippingAddressSelection_ItemDataBound">
            <LayoutTemplate>
                <div class="confirm_div">
                    <div id="itemPlaceholder" runat="server"></div>
                    <div class="confirm_inner">
                        <asp:LinkButton ID="lnkChangeShipping" runat="server" CssClass="btncart" OnClientClick="jsPurchaseOrder.setShippingAddressId()" CommandName ="ChangeShipping">Confirm</asp:LinkButton>
                    </div>
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="dialog_inner_addr">
                    <div class="ship_addr">
                        <asp:RadioButton  ID ="rbtnShippingAddress" runat="server" GroupName="rbtnShippingAddress" data-value='<%#Eval("AddressId") %>'/>
                        <asp:HiddenField ID="hdnShippingAddressId" runat="server" Value='' />
                    </div>
                    <div class="bill_addr">
                        <div class="billaddress"><%#Eval("AddressName") %></div>
                        <div></div>
                    </div>
                </div>
            </ItemTemplate>
            
        </asp:ListView>
       
    </div>


    <script type="text/javascript">
        $(function () {
            $("#dialog")[0].style.display = "none";
            jsPurchaseOrder.updateTotalCost();
            jsPurchaseOrder.fixRadioButtons();
        });
    </script>
</asp:Content>
