<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Client.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_3EndTCommercePresentation.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server"></asp:Content>

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
                <asp:LoginStatus CssClass="btn btn-primary" ID="MainLoginStatus" LogoutAction="Refresh" runat="server" LoginText="&nbsp;Login&nbsp;" LogoutText="&nbsp;Logout&nbsp;" />
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
                            <div id="demo" class="carousel slide" data-ride="carousel">
                                <div class="carousel-inner" role="listbox">

                                    <div class="item active">
                                        <img src="images/1st.png" alt="firstImg" style="width: 820px; height: 508px;">
                                        <div class="carousel-caption">
                                            <h1>YOUR ONE STOP SHOP FOR NDT</h1>
                                            <p>
                                                World Class Customer Service, Competitive Cost, and Lowest Lead Time                       
                                            </p>
                                        </div>
                                    </div>

                                    <div class="item">
                                        <img src="images/2nd.png" alt="Chania" style="width: 820px; height: 508px;">
                                        <div class="carousel-caption">
                                            <h1>YOUR ONE STOP SHOP FOR NDT</h1>
                                            <p>
                                                World Class Customer Service, Competitive Cost, and Lowest Lead Time                       
                                            </p>
                                        </div>
                                    </div>

                                    <div class="item">
                                        <img src="images/3rd.png" alt="Flower" style="width: 820px; height: 508px;">
                                        <div class="carousel-caption">
                                            <h1>YOUR ONE STOP SHOP FOR NDT</h1>
                                            <p>
                                                World Class Customer Service, Competitive Cost, and Lowest Lead Time                       
                                            </p>
                                        </div>
                                    </div>

                                </div>

                                <!-- Left and right controls -->
                                <a class="left carousel-control" href="#demo" role="button" data-slide="prev">
                                    <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                                    <span class="sr-only">Previous</span>
                                </a>
                                <a class="right carousel-control" href="#demo" role="button" data-slide="next">
                                    <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                                    <span class="sr-only">Next</span>
                                </a>
                            </div>
                            <%-- <strong>
                            <asp:LoginName ID="lnHeaderBtn" class="header-welcome" runat="server" FormatString="Welcome, {0} !&nbsp;&nbsp;" />
                        </strong>
                        <asp:LoginStatus CssClass="header-btn btn" ID="MainLoginStatus" LogoutAction="Refresh" runat="server" LoginText="&nbsp;Login&nbsp;" LogoutText="&nbsp;Logout&nbsp;" />
                            --%>
                            <br />
                            <p id="info">
                                <strong>3E NDT, LLC</strong> is a leader in wholesale/distribution of NDT equipment, accessories and consumables. <strong>3E</strong> is a company driven by customer satisfaction and continuous improvement.  We provide deliveries, including weekends, and can be contacted <strong>24/7</strong> in the event of an emergency. In the ever-demanding world of Non-Destructive Testing, we ensure that customer demands are met. We are dedicated to providing support for all products and have an established in-house service center with a large inventory of spare parts. Trained professionals have the skills  to service equipment from multiple manufacturers both in-house and in the field.
   
                            </p>
                        </div>



                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--END CONTENT-->

</asp:Content>
