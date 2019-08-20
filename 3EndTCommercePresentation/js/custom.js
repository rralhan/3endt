var jsProducts = {
    userCart : [],
    displaySecondDropdown: function (hdnCntrlId) {
        var ddlprimaryid = hdnCntrlId.replace('hdnProductItems', 'ddlPrimaryFilter');
        var ddlsecondaryid = hdnCntrlId.replace('hdnProductItems', 'ddlSecondaryFilter');

        var hdncntrl = $('#' + hdnCntrlId);
        var ddlprimary = $('#' + ddlprimaryid);
        var ddlsecondary = $('#' + ddlsecondaryid);        

        var itemstr = hdncntrl.val();
        if (itemstr != "" || itemstr != "undefined") {
            var items = $.parseJSON(itemstr);
            var selprimary = ddlprimary.val();      
            var selitems = $.grep(items, function (item, index) {
                return (item.PrimaryFilterId == selprimary)
            });
            ddlsecondary.empty();
            ddlsecondary.append($("<option></option>").attr("value", '0').text('Select an option'));
            $.each(selitems, function (index, item) {
                ddlsecondary.append($("<option></option>")
                    .attr("value", item.SecondaryFilterId).text(item.SecondaryFilterValue));
                ddlsecondary.removeAttr('selected');
            });
          

            //if (ddlsecondary.children('option').length <= 0) {
            //    ddlsecondary.append($("<option></option>")
            //       .attr("value", '0').text('Select an option'));
            //}
            //Set the first option as selected
            ddlsecondary.val($("#" + ddlsecondaryid + " option:first").val());
            $('#' + ddlsecondaryid + ' option:first').attr('selected', 'selected');

            jsProducts.setUpDropdown(ddlsecondaryid);  
        }
    },
    displayPrice: function (hdnCntrlId) {
        var ddlprimaryid = hdnCntrlId.replace('hdnProductItems', 'ddlPrimaryFilter');
        var ddlsecondaryid = hdnCntrlId.replace('hdnProductItems', 'ddlSecondaryFilter');
        var lblproditempriceid = hdnCntrlId.replace('hdnProductItems', 'lblProductItemPrice');
        var lnkcartid = hdnCntrlId.replace('hdnProductItems', 'lnkCart');
        var lnkRFQid = hdnCntrlId.replace('hdnProductItems', 'lnkRFQ');
        var lblproductunitid = hdnCntrlId.replace('hdnProductItems', 'lblProductUnit');
               

        var hdncntrl = $('#' + hdnCntrlId);
        var ddlprimary = $('#' + ddlprimaryid);
        var ddlsecondary = $('#' + ddlsecondaryid);
        var lblprice = $('#' + lblproditempriceid);
        var lnkcart = $('#' + lnkcartid);
        var lnkRFQ = $('#' + lnkRFQid);
        var lblProductUnit = $('#' + lblproductunitid);


        var itemstr = hdncntrl.val();
        if (itemstr != "" || itemstr != "undefined") {
            var items = $.parseJSON(itemstr);
            var selprimaryid = ddlprimary.val();
            var selsecondaryid = ddlsecondary.val();

            var selitem;
            $.each(items, function (index, item) {
                if (selsecondaryid == null || selsecondaryid === undefined) {
                    if (item.PrimaryFilterId == selprimaryid) {
                        selitem = item;
                        return false;
                    }
                }
                else {
                    if (item.PrimaryFilterId == selprimaryid && item.SecondaryFilterId == selsecondaryid) {
                        selitem = item;
                        return false;
                    }
                }
            });


            if (selitem != null && selitem != undefined) {
                var price = selitem.Price;

                //display rfq
                if (parseFloat(price) <= 0) {
                    lnkcart.hide();
                    lnkRFQ.show();
                    lnkRFQ.attr("href", "/client/contact-us.aspx?urlrefer=3&sku=" + sku);
                    lblprice.hide();
                }
                else if (selprimaryid == '0') {
                    lblprice.hide();
                    lblProductUnit.hide();
                }
                else {
                    lnkcart.show();
                    lnkRFQ.hide();
                    lblprice.show();
                    lblprice.text("$ " + parseFloat(price).toFixed(2));
                    lblProductUnit.show();
                }
            }
            else {
                lblprice.hide();
                lblProductUnit.hide();
            }
        }
    },
    setUpDropdown : function(id)
    {
        // Cache the number of options
        var self = $('#'+id);    

        numberOfOptions = self.children('option').length;

        //reset
        var parentDiv = self.parent();
        if (parentDiv != undefined) {
            parentDiv.find('.styledSelect').remove();
            parentDiv.find('.options').remove();
            if (parentDiv.attr('class') == 'select')
                self.unwrap();
        }

        // Hides the select element
        self.addClass('s-hidden');

        // Wrap the select element in a div
        self.wrap('<div class="select"></div>');           

        // Insert a styled div to sit over the top of the hidden select element
        self.after('<div class="styledSelect"></div>');

        // Cache the styled div
        var $styledSelect = self.next('div.styledSelect');

        // Show the first select option in the styled div
        $styledSelect.text(self.children('option').eq(0).text());

        if(self.children('option').eq(0).text().length === 0){
            self.parent().remove();
        }
    
        // Insert an unordered list after the styled div and also cache the list
        var $list = $('<ul />', {
            'class': 'options'
        }).insertAfter($styledSelect);

        // Insert a list item into the unordered list for each select option
        for (var i = 0; i < numberOfOptions; i++) {
            $('<li />', {
                text: self.children('option').eq(i).text(),
                rel: self.children('option').eq(i).val()
            }).appendTo($list);
        }
        // Cache the list items
        var $listItems = $list.children('li');

        // Show the unordered list when the styled div is clicked (also hides it if the div is clicked again)
        $styledSelect.click(function (e) {            
            e.stopPropagation();
            $('div.styledSelect.active').each(function () {
                $(this).removeClass('active').next('ul.options').hide();
            });
            $(this).toggleClass('active').next('ul.options').toggle();
        });

        // Hides the unordered list when a list item is clicked and updates the styled div to show the selected list item
        // Updates the select element to have the value of the equivalent option
        $listItems.click(function (e) {       
            e.stopPropagation();
            $styledSelect.text($(this).text()).removeClass('active');
            $(this).val($(this).attr('rel'));
            $list.hide();       
            self.val($(this).val());
            self.trigger("change");
            /* alert(self.val()); Uncomment this for demonstration! */
        });

        // Hides the unordered list when clicking outside of it
        $(document).click(function () {
            $styledSelect.removeClass('active');
            $list.hide();
        });

    },
    addToCartClick: function (lnk) {
        var ddlprimaryid = lnk.id.replace('lnkCart', 'ddlPrimaryFilter');
        var ddlsecondaryid = lnk.id.replace('lnkCart', 'ddlSecondaryFilter');
        var hdnproductitemsid = lnk.id.replace('lnkCart', 'hdnProductItems');
        var hdnsecondaryproductitemchoiceid = lnk.id.replace('lnkCart', 'hdnSecondaryProductItemChoice');

        var selprimary = $('#' + ddlprimaryid).val();
        var selsecondary = $('#' + ddlsecondaryid).val();
        var productitemsstr = $('#' + hdnproductitemsid).val();

        var hdnsecondaryproductitemchoice = $('#' + hdnsecondaryproductitemchoiceid);

        if (selprimary != undefined && selprimary == '0') {
            alert('Please select a valid value from the first dropdown.')
            return false;
        }
        else if (selsecondary != undefined && selsecondary == '0') {
            alert('Please select a valid value from the second dropdown.')
            return false;
        }
        else {
            hdnsecondaryproductitemchoice.val(selsecondary);
        }
        //else if ((selprimary == null || selprimary == undefined) && (selsecondary == null || selsecondary == undefined)) {
        //    if (productitemsstr != "" || itemstr != "productitemsstr") {
        //        var items = $.parseJSON(productitemsstr);
        //        var selitem = $.grep(items, function (item, index) {
        //            return (item.PrimaryFilterId == 1 && item.SecondaryFilterId == 1)
        //        });
        //        if (selitem != null && selitem != undefined) {
        //            jsProducts.addSelectedItemToUserCart(selitem);
        //        }
        //    }
        //}
        //else {            
        //    if (productitemsstr != "" || itemstr != "productitemsstr") {
        //        var items = $.parseJSON(productitemsstr);
        //        //filters down by primaryfilterId
        //        var selitem = $.grep(items, function (item, index) {
        //            return (item.PrimaryFilterId == selprimary)
        //        });
        //        if (selsecondary != null && selsecondary != undefined) {
        //            selitem = $.grep(selitem, function (item, index) {
        //                return (item.SecondaryFilterId == selsecondary)
        //            });
        //        }
        //        if (selitem != null && selitem != undefined) {
        //            jsProducts.addSelectedItemToUserCart(selitem);                    
        //        }
        //    }
        //}
        //var abc = jsProducts.userCart;
    },
    addSelectedItemToUserCart: function (selItem) {
        if (selItem.length > 0) {
            selItem = selItem[0];
        }
        var obj = {};
        var totalQuantity = 0;
        if (jsProducts.userCart.length > 0) {
            var existingItem = $.grep(jsProducts.userCart, function (item, index) {
                return (item.ItemId == selItem.ItemId)
            });

            if (existingItem != null && existingItem.length > 0) {
                existingItem[0].Quantity = existingItem[0].Quantity + 1;
            }
            else {
                obj.ItemId = selItem.ItemId;
                obj.Quantity = 1;
                obj.ProductId = selItem.ProductId;
                obj.TierId = selItem.TierId;
                jsProducts.userCart.push(obj);
            }
        }
        else {
            obj.ItemId = selItem.ItemId;
            obj.Quantity = 1;
            obj.ProductId = selItem.ProductId;
            obj.TierId = selItem.TierId;
            jsProducts.userCart.push(obj);
        }
        $.each(jsProducts.userCart, function (index, e) {
            totalQuantity = totalQuantity + e.Quantity;
        });

        var hdnShoppingCart = $("input[data-name='hdnShoppingCart']");
        if (hdnShoppingCart != null && hdnShoppingCart != undefined)
            hdnShoppingCart.val(JSON.stringify(jsProducts.userCart));
        
        var divDisplayCart = $("div[data-name='divDisplayCart']");
        divDisplayCart.show();

        var spnCartQuantity = $("span[data-name='cartQuantity']");
        spnCartQuantity.text(totalQuantity);

    },
    init: function () {
        $("a[data-name='lnkCart']").click(function () {
            return jsProducts.addToCartClick(this);
        });
    }
};

function mineheight() {
	var minheight = $(window).height();
	$('.whitepart').css('min-height', minheight + 'px');
}

function navigation(){
    $('li.first-level').on('click','a',function(event) {
        /* Act on the event */
        if ($(this).next('ul.second-level').hasClass('open')) {
            removeOpenClass($(this).next('ul.second-level'));
            removeOpenClass($(this).parent('li.first-level'));
        }
        else {
            addOpenClass(jQuery(this).parent('li.first-level'));
            addOpenClass(jQuery(this).next('ul.second-level'));                 
        }
	});

	$('li.second-level').on('click','a',function(event) {
	    /* Act on the event */
	    $('li.second-level').removeClass("open")
	    $('ul.third-level').removeClass("open")
			
	    if ($(this).next().find('ul.third-level').hasClass('open')) {
	        removeOpenClass($(this).next('ul.third-level'));
	        removeOpenClass($(this).parent('li.second-level'));		   
		}
	    else {
	        addOpenClass($(this).next('ul.third-level'));
	        addOpenClass($(this).parent('li.second-level'));	     
		}
	});

	$(document).on('click','div.showonmobile',function(event) {
		/* Act on the event */	
		if($(this).next('ul.first-level').hasClass('open')){
			$(this).next('ul.first-level').removeClass('open');
			$(this).parent().removeClass('open');
		}
		else{
			$(this).next('ul.first-level').addClass('open');
			$(this).parent().addClass('open');
		}
	});
    
}

function addOpenClass(obj)
{
    if(obj != null && obj !== undefined)
    {
        obj.addClass("open");
        updateHdnNav(obj);
    }
}

function removeOpenClass(obj)
{
    if (obj != null && obj !== undefined) {
        obj.removeClass("open");
        updateHdnNav(obj);
    }
}

function updateHdnNav(obj) {
    var id = obj.attr('id');
    if (id !== undefined) {
        var hdnnav = $('#hdnNav');
        var arr = new Array();
        if (hdnnav.val() != '' && hdnnav.val() !== undefined) {
            var arr = JSON.parse(hdnnav.val());
            if ($.inArray(id, arr) < 0) {
                arr.push(id);
                hdnnav.val(JSON.stringify(arr));
            }
            arr = $.grep(arr, function (element, index) {
                if (element.indexOf(id.substring(0, 6)) > -1) {
                    return element == id;
                }
                else {
                    return element;
                }
            });

            hdnnav.val(JSON.stringify(arr));
        }
        else {
            if ($.inArray(id, arr) < 0) {
                arr.push(id);
                hdnnav.val(JSON.stringify(arr));
            }
        }
    }
}

function addToCookieNav() {
    var hdnnav = $('#hdnNav');
    if (hdnnav !== undefined && hdnnav.val() != "" && hdnnav.val() !== undefined) {
        $.cookie("nav", hdnnav.val());
    }
}

function resetNavigation(isdelete) {
    if (isdelete === undefined || isdelete == false) {
        var cookieval = $.cookie("nav");
        if (cookieval !== undefined && cookieval != '')
        { $('#hdnNav').val(cookieval); }

        //Now get it from hdnNav. Gotta change this code to not use hdnNav at all.
        var hdnnav = $('#hdnNav');
        if (hdnnav !== undefined && hdnnav.val() != "" && hdnnav.val() !== undefined) {
            var arr = JSON.parse(hdnnav.val());
            $.each(arr, function (index) {
                var obj = $('#' + this);
                obj.addClass("open");
            });
        }
    }
    else {
        $.removeCookie("nav");
    }
}

function changeblocks(){
	var newdiv = $('.top-sellers').html();
	$('.show-about-us-on-mobile').html(newdiv);	
}

$(document).ready(function() {
	/* Act on the event */
	mineheight();
	navigation();
    
	changeblocks();   
});

$(window).load(function() {
	/* Act on the event */
	mineheight();
    // navigation();
	if ($(window).width() <= 768) {
	    $('#footer').css("width", $(window).width());
	}
	else {
	    $('#footer').css("width", $(window).width() - 300);
	}
    
//    Heights
    var heights = $("div.product-name").map(function ()
    {
        return $(this).height();
    }).get(),

    maxHeight = Math.max.apply(null, heights);
    $("div.product-name").css("height",maxHeight);
    
});

$(window).resize(function() {
	/* Act on the event */
	mineheight();
	navigation();
    //changeblocks()
	if ($(window).width() <= 768) {
	    $('#footer').css("width", $(window).width());
	}
	else {
	    $('#footer').css("width", $(window).width() - 300);
	}
        
    //    Heights
    var heights = $("div.product-name").map(function ()
    {
        return $(this).height();
    }).get(),

    maxHeight = Math.max.apply(null, heights);
    $("div.product-name").css("height",maxHeight);
});

