<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ManageTierProduct.aspx.cs" Inherits="_3EndTCommercePresentation.Admin.ManageTierProduct" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script>
        function clickTier(tierName) {
            //_currentTier
            var arr = tierName.split(":");
            __doPostBack(tierName);
        }
        function handlesaveclickevent() {
            var products = '_savetierproduct*';
            $("#targetdiv ul li input:hidden").each(function (index) {
                products = products + parseInt($(this).attr("value")) + '$';
            });
            __doPostBack(products);



        }
    </script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.10.3/themes/smoothness/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.9.1.js"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js"></script>
    <link rel="stylesheet" href="http://jqueryui.com/resources/demos/style.css" />
    <style>
        #gallery
        {
            float: left;
            width: 65%;
            min-height: 12em;
        }

        .gallery.custom-state-active
        {
            background: #eee;
        }

        .gallery li
        {
            float: left;
            width: 96px;
            padding: 0.4em;
            margin: 0 0.4em 0.4em 0;
            text-align: center;
        }

            .gallery li h5
            {
                margin: 0 0 0.4em;
                cursor: move;
            }

            .gallery li a
            {
                float: right;
            }

                .gallery li a.ui-icon-zoomin
                {
                    float: left;
                }

            .gallery li img
            {
                width: 100%;
                cursor: move;
            }

        #trash
        {
            float: right;
            width: 32%;
            min-height: 18em;
            padding: 1%;
        }

            #trash h4
            {
                line-height: 16px;
                margin: 0 0 0.4em;
            }

                #trash h4 .ui-icon
                {
                    float: left;
                }

            #trash .gallery h5
            {
                display: none;
            }
    </style>
    <script>
        $(function () {
            // there's the gallery and the trash
            var $gallery = $("#gallery"),
              $trash = $("#trash");
            debugger;
            // let the gallery items be draggable
            $("li", $gallery).draggable({
                cancel: "a.ui-icon", // clicking an icon won't initiate dragging
                revert: "invalid", // when not dropped, the item will revert back to its initial position
                containment: "document",
                helper: "clone",
                cursor: "move"
            });

            // let the trash be droppable, accepting the gallery items
            $trash.droppable({
                accept: "#gallery > li",
                activeClass: "ui-state-highlight",
                drop: function (event, ui) {
                    deleteImage(ui.draggable);
                }
            });

            // let the gallery be droppable as well, accepting items from the trash
            $gallery.droppable({
                accept: "#trash li",
                activeClass: "custom-state-active",
                drop: function (event, ui) {
                    recycleImage(ui.draggable);
                }
            });

            // image deletion function
            var recycle_icon = "<a href='link/to/recycle/script/when/we/have/js/off' title='Recycle this image' class='ui-icon ui-icon-refresh'>Recycle image</a>";
            function deleteImage($item) {
                $item.fadeOut(function () {
                    var $list = $("ul", $trash).length ?
                      $("ul", $trash) :
                      $("<ul class='gallery ui-helper-reset'/>").appendTo($trash);

                    $item.find("a.ui-icon-trash").remove();
                    $item.append(recycle_icon).appendTo($list).fadeIn(function () {
                        $item
                          .animate({ width: "48px" })
                          .find("img")
                            .animate({ height: "36px" });
                    });
                });
            }

            // image recycle function
            var trash_icon = "<a href='link/to/trash/script/when/we/have/js/off' title='Delete this image' class='ui-icon ui-icon-trash'>Delete image</a>";
            function recycleImage($item) {
                $item.fadeOut(function () {
                    $item
                      .find("a.ui-icon-refresh")
                       .remove()
                      .end()
                      .css("width", "96px")
                      .append(trash_icon)
                      .find("img")
                        .css("height", "72px")
                      .end()
                      .appendTo($gallery)
                      .fadeIn();
                });
            }

            // image preview function, demonstrating the ui.dialog used as a modal window
            function viewLargerImage($link) {
                var src = $link.attr("href"),
                  title = $link.siblings("img").attr("alt"),
                  $modal = $("img[src$='" + src + "']");

                if ($modal.length) {
                    $modal.dialog("open");
                } else {
                    var img = $("<img alt='" + title + "' width='384' height='288' style='display: none; padding: 8px;' />")
                      .attr("src", src).appendTo("body");
                    setTimeout(function () {
                        img.dialog({
                            title: title,
                            width: 400,
                            modal: true
                        });
                    }, 1);
                }
            }

            // resolve the icons behavior with event delegation
            $("ul.gallery > li").click(function (event) {
                var $item = $(this),
                  $target = $(event.target);

                if ($target.is("a.ui-icon-trash")) {
                    deleteImage($item);
                } else if ($target.is("a.ui-icon-zoomin")) {
                    viewLargerImage($target);
                } else if ($target.is("a.ui-icon-refresh")) {
                    recycleImage($item);
                }

                return false;
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="uPnlTierProduct" runat="server">
        <ContentTemplate>
            <div>

                <div style="float: left; width: 79%">
                    <div style="border: 1px solid red;">
                        <div style="text-align: center">
                            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green" />
                        </div>
                        <div>
                            <asp:Label ID="lblCategoryCaption" runat="server" Text="Category" Width="110px" /><asp:DropDownList ID="ddlCategory"  AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectionChanged" runat="server" Width="300px" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  InitialValue="-1" runat="server" ControlToValidate="ddlCategory" Display="None" ErrorMessage="<b>Category not selected</b><br/>Please select a category." ValidationGroup="LoadProduct"></asp:RequiredFieldValidator>
                            <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator1" runat="server"></asp:ValidatorCalloutExtender>

                        </div>
                        <div>
                            <asp:Label ID="lblSubCategoryCaption" runat="server" Text="Sub - Category" Width="110px" /><asp:DropDownList ID="ddlSubcategory" AutoPostBack="true" runat="server" Width="300px" />
                        </div>
                        <div>
                            <asp:Button ID="btnLoadProdcts" ValidationGroup="LoadProduct" runat="server" OnClick="btnLoadProdcts_Click" Text="Load Products" />
                        </div>
                    </div>
                    <div>
                        <div>
                            Tier Name:
                            <asp:Label ID="lblCurrentTier" runat="server" />
                        </div>

                    </div>
                    <asp:Label ID="lblSaveStatus" runat="server" Text="" />

                    <div class="ui-widget ui-helper-clearfix">
                        <div>
                            <div id="sourcediv">
                                <asp:Literal ID="ltSourceDiv" runat="server" />

                                <%--<ul id="gallery" class="gallery ui-helper-reset ui-helper-clearfix">
                                    <li class="ui-widget-content ui-corner-tr">
                                        <h5 class="ui-widget-header">High Tatras 1</h5>
                                        <input type="hidden" id="productId" value="1" />
                                        <img src="../UploadFile/ProductImage/img_logo.gif" alt="The peaks of High Tatras" width="100">
                                        <a href="images/high_tatras.jpg" title="View larger image" class="ui-icon ui-icon-zoomin">View larger</a>
                                        <a href="link/to/trash/script/when/we/have/js/off" title="Delete this image" class="ui-icon ui-icon-trash">Delete image</a>
                                    </li>
                                    <li class="ui-widget-content ui-corner-tr">
                                        <h5 class="ui-widget-header">High Tatras 2</h5>
                                        <input type="hidden" id="productId" value="1" />
                                        <img src="../UploadFile/ProductImage/img_logo.gif" alt="The chalet at the Green mountain lake" width="100">
                                        <a href="images/high_tatras2.jpg" title="View larger image" class="ui-icon ui-icon-zoomin">View larger</a>
                                        <a href="link/to/trash/script/when/we/have/js/off" title="Delete this image" class="ui-icon ui-icon-trash">Delete image</a>
                                    </li>                                    
                                </ul>--%>
                            </div>

                        </div>
                        <div>
                            <div id="targetdiv">
                                <div id="trash" class="ui-widget-content ui-state-default">
                                    <h4 class="ui-widget-header"><span class="ui-icon ui-icon-trash">Trash</span> Trash</h4>
                                    <asp:LinkButton ID="ltDestination" runat="server" />
                                    <%--<ul class="gallery ui-helper-reset">
                                    <li class="ui-widget-content ui-corner-tr ui-draggable" style="display: list-item; width: 48px;">
                                        <h5 class="ui-widget-header">Blue Jeans</h5>
                                        <img src="../UploadFile/ProductImage/img_logo.gif" alt="The peaks of High Tatras" width="100" style="display: inline-block; height: 36px;">
                                        <a href="images/high_tatras.jpg" title="View larger image" class="ui-icon ui-icon-zoomin">View larger</a>
                                        <a href="link/to/recycle/script/when/we/have/js/off" title="Recycle this image" class="ui-icon ui-icon-refresh">Recycle image</a>
                                    </li>
                                    <li class="ui-widget-content ui-corner-tr ui-draggable" style="display: list-item; width: 48px;">
                                        <h5 class="ui-widget-header">Blazer</h5>
                                        <img src="../UploadFile/ProductImage/img_logo.gif" alt="The peaks of High Tatras" width="100" style="display: inline-block; height: 36px;">
                                        <a href="images/high_tatras.jpg" title="View larger image" class="ui-icon ui-icon-zoomin">View larger</a>
                                        <a href="link/to/recycle/script/when/we/have/js/off" title="Recycle this image" class="ui-icon ui-icon-refresh">Recycle image</a>
                                    </li>
                                </ul>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div>
                        <asp:Button ID="btnSave" Text="Save" runat="server" OnClientClick="handlesaveclickevent()" />
                    </div>
                </div>
                <div style="float: right; border: 1px solid black; width: 19%">
                    <asp:DataGrid ID="dgvTiers" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="Horizontal">
                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundColumn DataField='TierId' Visible="False"></asp:BoundColumn>
                            <asp:TemplateColumn HeaderText="Tire">
                                <ItemTemplate>
                                    <div id="divTier" runat="server" onclick='<%#string.Format("clickTier(\"_invoketier_event:{0}:{1}\")", Eval("TierName"), Eval("TierId")) %>' style="cursor: pointer">
                                        <%# Eval("TierName") %>
                                    </div>

                                </ItemTemplate>
                            </asp:TemplateColumn>
                        </Columns>
                        <EditItemStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />

                    </asp:DataGrid>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
