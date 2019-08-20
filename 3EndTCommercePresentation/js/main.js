$(function () {
    $('.navbar-toggle').click(function () {
        $('.navbar-nav').toggleClass('slide-in');
        $('.side-body').toggleClass('body-slide-in');
        $('#search').removeClass('in').addClass('collapse').slideUp(200);

        /// uncomment code for absolute positioning tweek see top comment in css
        //$('.absolute-wrapper').toggleClass('slide-in');
        
    });
   
   // Remove menu for searching
   $('#search-trigger').click(function () {
        $('.navbar-nav').removeClass('slide-in');
        $('.side-body').removeClass('body-slide-in');

        /// uncomment code for absolute positioning tweek see top comment in css
        //$('.absolute-wrapper').removeClass('slide-in');

   });

   //$('.btncart').click(function () {
   //    var id = this.id;
   //    var dropdownId = id.replace('lnkCart', 'ddlPrimaryFilter');
   //    var dropdwoncntrl = $('#' + dropdownId);
   //    if (dropdwoncntrl != undefined) {
   //        var drpdownval = dropdwoncntrl.val();
   //        if (drpdownval == "0") {
   //            alert('Please select a value from the dropdowns');
   //            return false;
   //        }
   //        else
   //        {

   //        }
   //    }
   //});
   jsProducts.init();
    

    //// For sidebar menu

   var last_tab = sessionStorage.getItem('lastTab');
   if( last_tab !=" " || last_tab != undefined)
   {
       $('.side-menu-container a').each(function(){
           var tabtext = $(this).text();
           
           if(last_tab === tabtext)
           {
               if ($(this).closest(".panel-body").length > 0) {
                   $(this).addClass("active");
                   $(this).closest("li").css("background-color", "rgb(62, 158, 153)");
                   $(this).closest(".panel-collapse").removeClass("collapse");
               } else {
                   $(this).addClass("active");
                   $(this).closest("li").css("background-color", "rgb(62, 158, 153)");
               }
               
           }
       });
   }

   $('.side-menu-container a').on("click", function () {
       var last_tab = $(this).text();
       sessionStorage.setItem("lastTab", last_tab);
   });
    

    $('select').each(function () {
        var id = $(this)[0].id;
        jsProducts.setUpDropdown(id);
    });
    
});