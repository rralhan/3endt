<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Client.Master" AutoEventWireup="true" CodeBehind="order-confirmation.aspx.cs" Inherits="_3EndTCommercePresentation.client.order_confirmation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CoreContentHolder" runat="server">
    <link href="vendors/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/js1/jquery-1.10.2.min.js"></script>
    <script src="vendors/bootstrap/js/bootstrap.min.js"></script>
    <div id="page-wrapper">
        <!--BEGIN TITLE & BREADCRUMB PAGE-->
        <div id="title-breadcrumb-option-demo" class="page-title-breadcrumb">
            <div class="page-header pull-left">
                <div class="page-title"></div>
            </div>
            <div class="page-header pull-right">
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
                            <p>
                                Thank you for placing an order with <strong>3Endt LLC</strong>. Your new purchase order: <strong><%=PurchaseOrderNumber %></strong> has been submitted successfully on <strong><%=DateTime.Now.ToString("G", System.Globalization.CultureInfo.CreateSpecificCulture("en-us"))%></strong>.        
                            </p>
                            <p>Your order confirmation number is <strong><%=ConfirmationNumber %></strong>.</p>
                            <p>An order confirmation email has been sent to the email address on file.</p>
                            <p>
                                <small>* Please note that any order placed after 2:30 pm CST will be processed the following business day.</small>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
