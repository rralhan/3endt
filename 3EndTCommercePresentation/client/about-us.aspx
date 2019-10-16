<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Client.Master" AutoEventWireup="true" CodeBehind="about-us.aspx.cs" Inherits="_3EndTCommercePresentation.client.aboutus" %>

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
                <%--<asp:LoginStatus CssClass="btn btn-yellow" ID="MainLoginStatus" LogoutAction="Refresh" runat="server" LoginText="&nbsp;Login&nbsp;" LogoutText="&nbsp;Logout&nbsp;" />--%>
            </div>
            <div class="clearfix"></div>
        </div>
        <div class="page-content">
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel">
                        <div class="panel-body">
                            <div class="row mbxxl">
                                <div class="col-lg-12">
                                    <%--<iframe src="http://player.vimeo.com/video/22439234"
                                        style="width: 100%; height: 340px; border: 0"></iframe>--%>
                                </div>
                                <div class="col-lg-6">
                                    <h3>Your One Stop Shop for NDT</h3>
                                    <p>Founded in 1972, 3E has been a family business serving the needs of Non-destructive Testing (NDT) professionals in diverse industries around the world. We have prospered because we are customer focused, service oriented, , and maintain one of the largest stocks of NDT equipment, accessories and consumables. We have earned the trust of companies to be their premier supplier and partner.</p>
                                    <p>Our Sales Representatives are knowledgeable NDT professionals who will help you find the right product, application and solution for your tough inspection jobs. Our operations team is focused on efficient and accurate order fulfillment to eliminate downtime. We know you have many choices when it comes to your NDT needs and we will strive to earn and grow your business by consistently providing a world class experience.</p>
                                    <p>&nbsp;</p>
                                    <p>
                                        <strong>Why Choose 3E NDT?<br />
                                            <br />
                                        </strong>
                                    </p>
                                   <%-- <p>
                                        At vero eos et accusamus et iusto odio dignissimos ducimus
                                        qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et
                                        quas molestias excepturi sint occaecati cupiditate non provident, similique sunt
                                        in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et
                                        harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum
                                        soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime
                                        placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus.
                                        Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus
                                        saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae.
                                        Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis
                                        voluptatibus maiores alias consequatur aut perferendis doloribus asperiores
                                        repellat.
                                    </p>--%>
                                    <ol class="pll">
                                        <li>Knowledgeable, caring, professional people</li>
                                        <li>Efficient and accurate orders</li>
                                        <li>Large inventories in two locations</li>
                                        <li>Experienced service and calibration technicians</li>
                                        <li>ASNT Corporate Partner</li>
                                        <li>After Sale Support</li>
                                        <%--<li>Aenean sit amet erat nunc</li>
                                        <li>Eget porttitor lorem</li>--%>
                                    </ol>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


   <%-- <div class="allpage">
        <div class="top-upper row">
            <div class="col-xs-6"><a href="tel:2814702010"><span class="glyphicon glyphicon-earphone"></span>281-470-2010</a></div>
            <div class="col-xs-6">
                <a href="https://www.facebook.com/3endt"><span class="glyphicon fbook"></span></a>
                <a href="https://www.twitter.com/3endt"><span class="glyphicon tweeter"></span></a>
                <a href="https://www.linkedin.com/company/3endt"><span class="glyphicon linkin"></span></a>
            </div>
        </div>
        <div class="divContact">
            <h3>Your One Stop Shop for NDT</h3>
            <p>Founded in 1972, 3E has been a family business serving the needs of Non-destructive Testing (NDT) professionals in diverse industries around the world. We have prospered because we are customer focused, service oriented, , and maintain one of the largest stocks of NDT equipment, accessories and consumables. We have earned the trust of companies to be their premier supplier and partner.</p>
            <p>Our Sales Representatives are knowledgeable NDT professionals who will help you find the right product, application and solution for your tough inspection jobs. Our operations team is focused on efficient and accurate order fulfillment to eliminate downtime. We know you have many choices when it comes to your NDT needs and we will strive to earn and grow your business by consistently providing a world class experience.</p>
            <p>&nbsp;</p>
            <p>
                <strong>Why Choose 3E NDT?<br />
                    <br />
                </strong>
            </p>
            <ul class="about-ul">
                <li>Knowledgeable, caring, professional people</li>
                <li>Efficient and accurate orders</li>
                <li>Large inventories in two locations</li>
                <li>Experienced service and calibration technicians</li>
                <li>ASNT Corporate Partner</li>
                <li>After Sale Support</li>
            </ul>
        </div>
    </div>--%>
</asp:Content>
