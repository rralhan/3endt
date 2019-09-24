<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ManageProductItemPrice.aspx.cs" Inherits="_3EndTCommercePresentation.admin.ManageProductItemPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="form-layouts" class="row">

        <div class="col-lg-12">
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-blue">
                        <div class="panel-heading">
                            Manage Product Prices

                            <button id="btn_BulkUpload" data-target="#modal-default" data-toggle="modal"
                                class="btn btn-primary right" style="float: right;" onclick="return OpenModel();">
                                <i class='fa fa-plus-square-o'></i>&nbsp; &nbsp;Bulk Update</button>
                            <%-- <asp:Button ID="btn_BulkUpload" runat="server" Text="Bulk Update" CssClass="btn btn-primary right" style="float: right;" />--%>
                        </div>

                        <div class="panel-body pan">
                            <%--   <form action="#" class="form-horizontal form-bordered">--%>
                            <div class="form-body">
                                <div class="form-group">
                                    <div class="col-md-3">
                                        <label for="inputFirstName"
                                            class="control-label" style="float: right;">
                                            Tier <span class='require'>*</span></label>
                                    </div>
                                    <div class="col-md-9">
                                        <asp:DropDownList ID="ddlTiers" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTiers_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                <br />





                            </div>
                            <div class="form-actions ">
                                <div class="form-group">
                                    <div class="col-md-4">
                                    </div>
                                    <div class="col-md-4">

                                        <%--<asp:Button ID="Dummy" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="Dummy_Click1" />--%>
                                    </div>
                                    <div class="col-md-4">
                                    </div>

                                </div>
                                <%--<button type="submit" class="btn btn-primary">Submit</button>--%>
                                &nbsp;
                                                       
                                            <%--<button type="button" class="btn btn-green">Cancel</button>--%>
                            </div>
                            <%-- </form>--%>
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </div>
    <div>
        <div class="row">
            <div class="col-lg-12">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-blue">
                            <div class="panel-heading">
                                Manage Product Prices
                            </div>
                            <div class="panel-body pan">
                                <div class="form-body">

                                    <table class="table table-hover">
                                        <thead>
                                            <tr>
                                                <td style="border: thin solid #800000; font-style: italic; font-weight: bold; width: 500px;">&nbsp;</td>
                                                <td class="tdproductitemheader">Regular Tier Prices</td>
                                                <td class="tdproductitemheader">
                                                    <asp:Label ID="lblTierHeader" runat="server"></asp:Label></td>
                                            </tr>
                                        </thead>


                                        <asp:ListView ID="lvProductItems" runat="server" OnItemDataBound="lvProductItems_ItemDataBound">
                                            <LayoutTemplate>
                                                <tr id="itemPlaceholder" runat="server">
                                                </tr>
                                            </LayoutTemplate>
                                            <ItemTemplate>
                                                <tr id="rowProduct" runat="server">
                                                    <td>
                                                        <b>
                                                            <asp:Label ID="lblProduct" runat="server" Text='<%#Eval("ProductName") %>'></asp:Label></b></td>
                                                    <td colspan="2">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:HiddenField ID="hdnProductItemId" runat="server" Value='<%#Eval("ItemId") %>' />
                                                        <asp:Label ID="lblProductItemName" runat="server" Text='<%#Eval("ProductSKU") %>'></asp:Label></td>
                                                    <td style="text-align: center; vertical-align: text-top">
                                                        <asp:Label ID="lblRegularTierPrices" runat="server"></asp:Label></td>
                                                    <td style="text-align: center; vertical-align: text-top">$
                                    <asp:TextBox ID="txtTierPrices" runat="server" Width="50px"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="regexTierPrices" runat="server" CssClass="imp-msg" ControlToValidate="txtTierPrices" ValidationExpression="^[0-9,]+(\.\d{1,2})?|(rfq)$" ErrorMessage="Only decimals OR the work 'rfq' are accepted" ValidationGroup="vgTierPrice"></asp:RegularExpressionValidator>
                                                    </td>

                                                </tr>
                                            </ItemTemplate>
                                        </asp:ListView>
                                        <tr>
                                            <td colspan="3" runat="server" style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000; margin: auto;">
                                                <asp:DataPager ID="dpProductItems" runat="server" PagedControlID="lvProductItems" PageSize="50" OnPreRender="dpProductItems_PreRender">
                                                    <Fields>
                                                        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                        <asp:NumericPagerField ButtonType="Link" />
                                                        <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                    </Fields>
                                                </asp:DataPager>
                                            </td>
                                        </tr>
                                    </table>
                                    <center>
                                    <asp:Button ID="btnSave" CssClass="btn btn-primary"  runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="vgTierPrice"  style="margin-bottom:15px;"/>
                                        </center>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--<table class="toptable">--%>
    <%--<tr>
            <td class="tdfirst">Tier:</td>
            <td class="tdsecond"></td>
        </tr>
        <tr>

            <td></td>
            <td></td>
        </tr>--%>
    <%--    <tr>
            <td colspan="2">


               
            </td>

        </tr>
    </table>--%>



    <div id="modal-default" tabindex="-1" role="dialog" aria-labelledby="modal-default-label"
        aria-hidden="true" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
<%--                    <button type="button" data-dismiss="modal" aria-hidden="true"
                        class="btn btn-primary"style="float:right;" runat="server" onclick="">
                        Dawonload Filles</button>--%>
                    <asp:Button ID="btn_DownloadExcel" runat="server" class="btn btn-primary" style="float:right;" Text="Download Files"  OnClick="btn_DownloadExcel_Click"/>


                    <h4 id="modal-default-label" class="modal-title">Manage Product Prices</h4>
                </div>
                <div class="modal-body">
                    <asp:FileUpload ID="fu_excel" runat="server" CssClass="form-control" />

                    
                </div>
                <div class="modal-footer">
                    <button type="button" data-dismiss="modal" class="btn btn-default">Close</button>
                    <asp:Button ID="btn_SaveAndUpdate" runat="server" CssClass="btn btn-primary" OnClick="btn_SaveAndUpdate_Click" Text="Save Changes" />
                    <%--<button type="button" class="btn btn-primary">Save changes</button>--%>
                </div>
            </div>
        </div>
    </div>


    <script type="text/javascript">
        function OpenModel() {
            return false;
        }
    </script>

</asp:Content>
