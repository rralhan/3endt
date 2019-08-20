<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Client.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_3EndTCommercePresentation.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="CoreContentHolder" runat="server">
	
	
    <script type="text/javascript">
        $(function () {
            resetNavigation(true);
        });
    </script>
    
    <div class="top-upper row">
        <div class="col-xs-6"><a href="tel:2814702010"><span class="glyphicon glyphicon-earphone"></span> 281-470-2010</a></div>
        <div class="col-xs-6">
            <a href="https://www.facebook.com/3endt"><span class="glyphicon fbook"></span></a>
            <a href="https://www.twitter.com/3endt"><span class="glyphicon tweeter"></span></a>
            <a href="https://www.linkedin.com/company/3endt"><span class="glyphicon linkin"></span></a>
        </div>
    </div>
    <div id="home-slider" class="carousel slide" data-ride="carousel">
        <div class="carousel-inner" role="listbox">
            <div class="item active">
                <div class="carousel-bg">
                    <div class="caption_bg">
                        <div class="carousel-img">
                            <img src="images/1st.png" alt="firstImg">
                        </div>
                    <div class="carousel-caption">
                        <h1>YOUR ONE STOP SHOP FOR NDT</h1>
                        <p>
                            World Class Customer Service, Competitive Cost, and Lowest Lead Time
                        </p>
                    </div>
                        </div>
                </div>
            </div>
            <div class="item">
                <div class="carousel-bg">
                    <div class="caption_bg">
                        <div class="carousel-img">
                            <img src="images/2nd.png" alt="firstImg">
                        </div>
                    <div class="carousel-caption">
                        <h1>YOUR ONE STOP SHOP FOR NDT</h1>
                        <p>
                            World Class Customer Service, Competitive Cost, and Lowest Lead Time
                        </p>
                    </div>
                        </div>
                </div>
            </div>
            <div class="item">
                <div class="carousel-bg">
                    <div class="caption_bg">
                        <div class="carousel-img">
                            <img src="images/3rd.png" alt="firstImg">
                        </div>
                    <div class="carousel-caption">
                        <h1>YOUR ONE STOP SHOP FOR NDT</h1>
                        <p>
                            World Class Customer Service, Competitive Cost, and Lowest Lead Time
                        </p>
                    </div>
                        </div>
                </div>
            </div>
        </div>
        
            <!-- Controls -->
      <a class="left carousel-control" href="#home-slider" role="button" data-slide="prev">
        <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
        <span class="sr-only">Previous</span>
      </a>
      <a class="right carousel-control" href="#home-slider" role="button" data-slide="next">
        <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
        <span class="sr-only">Next</span>
      </a>
    </div>
    
   
    <strong>
		<asp:LoginName ID="lnHeaderBtn" class="header-welcome" runat="server" FormatString="Welcome, {0} !&nbsp;&nbsp;" />
    </strong>
    
   
        <asp:LoginStatus CssClass="header-btn" ID="MainLoginStatus" LogoutAction="Refresh" runat="server" LoginText="&nbsp;Login&nbsp;" LogoutText="&nbsp;Logout&nbsp;" />
   
    
   
    <p id="info">
<!--
        <strong>3E NDT, LLC</strong> is involved in the wholesale/distribution of NDT equipment and accessories manufactured by various leading manufacturers from around the world.<br/><br/>

Our main lines of business in NDT are Radiography, Magnetic Particle Testing and Ultrasonic Testing equipment and accessories.<br/><br/> We pride ourselves as a company that is very customer driven. We make weekend deliveries and can be contacted 24/7 for emergencies. In the ever-demanding field of Non-Destructive Testing, we try very hard to make sure that customer demands are met on time. We are dedicated to provide support for all our products. We have an in-house service center where we have trained professionals servicing all kinds of equipments.
-->
        <strong>3E NDT, LLC</strong> is a leader in wholesale/distribution of NDT equipment, accessories and consumables. <strong>3E</strong> is a company driven by customer satisfaction and continuous improvement.  We provide deliveries, including weekends, and can be contacted <strong>24/7</strong> in the event of an emergency. In the ever-demanding world of Non-Destructive Testing, we ensure that customer demands are met. We are dedicated to providing support for all products and have an established in-house service center with a large inventory of spare parts. Trained professionals have the skills  to service equipment from multiple manufacturers both in-house and in the field.
    </p>


</asp:Content>
