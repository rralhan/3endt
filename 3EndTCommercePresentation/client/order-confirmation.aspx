<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Client.Master" AutoEventWireup="true" CodeBehind="order-confirmation.aspx.cs" Inherits="_3EndTCommercePresentation.client.order_confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CoreContentHolder" runat="server">
    <div class="order_confirmation_page">
        <div class="inner_div">
        <p class="common_p">
            Thank you for placing an order with <strong>3Endt LLC</strong>. Your new purchase order: <strong><%=PurchaseOrderNumber %></strong> has been submitted successfully on <strong><%=DateTime.Now.ToString("G", System.Globalization.CultureInfo.CreateSpecificCulture("en-us"))%></strong>. 
        </p>
            <p class="common_p">Your order confirmation number is <strong><%=ConfirmationNumber %></strong>.</p>
<p class="common_p">An order confirmation email has been sent to the email address on file.</p>
        <p class="forth_p">
           <small>* Please note that any order placed after 2:30 pm CST will be processed the following business day.</small>
        </p>
            </div>
    </div>
</asp:Content>
