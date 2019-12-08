<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Client.Master" AutoEventWireup="true" CodeBehind="contact-us.aspx.cs" Inherits="_3EndTCommercePresentation.client.contact_us" %>

<%--<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CoreContentHolder" runat="server">
    <%-- <style>
        .h4FontSize
        {
            font-size:19px;
        }
    </style>--%>
    <link href="vendors/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="/js1/jquery-1.10.2.min.js"></script>
    <script src="vendors/bootstrap/js/bootstrap.min.js"></script>

    <div id="page-wrapper">
        <!--BEGIN TITLE & BREADCRUMB PAGE-->
        <div id="title-breadcrumb-option-demo" class="page-title-breadcrumb">
            <div class="page-header pull-left">
                <div class="page-title"></div>
            </div>
            <div class="page-header pull-left">
                <div class="page-title">Contact Us</div>
                <%--<asp:LoginStatus CssClass="btn btn-yellow" ID="MainLoginStatus" LogoutAction="Refresh" runat="server" LoginText="&nbsp;Login&nbsp;" LogoutText="&nbsp;Logout&nbsp;" />--%>
            </div>
            <div class="clearfix"></div>
        </div>

        <div class="page-content">
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel">
                        <div class="panel-body">

                            <div class="row">
                                <div class="col-lg-4">
                                    <h3>Texas Branch</h3>
                                    <hr />
                                    <h4>Address</h4>
                                    <address>
                                        <strong>3E NDT LLC.</strong><br />
                                        321 N.8th Street, La Porte, TX 77571<br />
                                        <abbr
                                            title="Phone">
                                            Ph: &nbsp;</abbr>(281) 470-2010      
                                        <br />
                                        <abbr
                                            title="FAX">
                                            Fax: &nbsp;</abbr>(281) 470-2024
                                    </address>
                                </div>
                                <div class="col-lg-4">
                                    <h3>California Branch</h3>
                                    <hr />
                                    <h4>Address</h4>
                                    <address>
                                        <strong>3E NDT LLC.</strong><br />
                                        14320 Wicks Blvd. San Leandro, CA 94577<br />
                                        <abbr
                                            title="Phone">
                                            Ph# &nbsp;</abbr>(510) 352-6767   
                                        <br />
                                        <abbr
                                            title="FAX">
                                            Fax# &nbsp;</abbr>(510) 352-6772
                                    </address>
                                </div>
                                <div class="col-lg-4">
                                    <h3>Italy Branch</h3>
                                    <hr />
                                    <h4>Address</h4>
                                    <address>
                                        <strong>3E NDT, LLC</strong><br />
                                        Via Roganti 16 23020 Prosto di Piuro SO ITALY<br />
                                        <abbr
                                            title="Phone">
                                            Ph# &nbsp;</abbr>+39 0343 37445     
                                        <br />
                                        <abbr
                                            title="FAX">
                                            Fax# &nbsp;</abbr>+39 0343 30974
                                        <br />
                                        <abbr
                                            title="MOobile">
                                            Mob # &nbsp;</abbr>+39 3351805557
                                    </address>
                                </div>




                            </div>
                            <div class="col-lg-12">
                                <h3>To: sales@3endt.com</h3>


                                <hr />
                                <%--<form action="#">--%>
                                <div class="form-group">
                                    <label>Name (required):</label>
                                    <asp:TextBox ID="txtName" runat="server" placeholder="Subject" class="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="refName" runat="server" ErrorMessage="Name is a required field" Text="*" CssClass="form-control" ControlToValidate="txtName" ValidationGroup="valContactUs"></asp:RequiredFieldValidator>

                                    <%-- <div class="input-icon">
                                            <i class="fa fa-check"></i>
                                            <input type="text"
                                                placeholder="Subject"
                                                class="form-control" />
                                        </div>--%>
                                </div>
                                <div class="form-group">
                                    <label>Email (required):</label>
                                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="refEmail" runat="server" ErrorMessage="Email is a required field" Text="*" ControlToValidate="txtEmail" CssClass="form-control" ValidationGroup="valContactUs"></asp:RequiredFieldValidator>

                                    <%--<div class="input-icon">
                                        <i class="fa fa-user"></i>
                                        <input type="text"
                                            placeholder="Name"
                                            class="form-control" />
                                    </div>--%>
                                </div>
                                <div class="form-group">
                                    <label>Company Name:</label>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<div class="input-icon">
                                        <i class="fa fa-envelope"></i>
                                        <input
                                            type="password" placeholder="Email" class="form-control" />
                                    </div>--%>
                                </div>
                                <div class="form-group">
                                    <label>Address:</label>
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
                                    <%--<textarea rows="3" placeholder="Content"
                                        class="form-control"></textarea>--%>
                                </div>
                                <div class="form-group">
                                    <label>Phone Number:</label>
                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ErrorMessage="Phone is a required field" Text="*" ControlToValidate="txtPhone" ValidationGroup="valContactUs" CssClass="form-control" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Text="*" runat="server" ErrorMessage="Phone Number is not valid" ValidationGroup="valContactUs" ControlToValidate="txtPhone" CssClass="form-control" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
                                </div>
                                <div class="form-group">
                                    <label>Subject:</label>
                                    <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <asp:Panel ID="pnlUserId" runat="server" Visible="false">
                                    <label>UserId (required):</label>
                                    <div>
                                        <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </asp:Panel>
                                <div class="form-group">
                                    <label>Your Message:</label>
                                    <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Height="150px" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div id="validation_dialog">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="valContactUs" CssClass="imp-msg validation_summary" DisplayMode="BulletList" />
                                </div>

                                <div class="send_btn">
                                    <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="btn btn-yellow" OnClick="btnSend_Click" ValidationGroup="valContactUs" />
                                </div>
                                <%--<button type="submit" class="btn btn-success">Submit</button>--%>
                                <%--</form>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>








    <%--    <div class="top-upper row">
        <div class="col-xs-6">
            <a href="tel:2814702010"><span class="glyphicon glyphicon-earphone"></span>281-470-2010</a>
        </div>
        <div class="col-xs-6">
            <a href="https://www.facebook.com/3endt"><span class="glyphicon fbook"></span></a>
            <a href="https://www.twitter.com/3endt"><span class="glyphicon tweeter"></span></a>
            <a href="https://www.linkedin.com/company/3endt"><span class="glyphicon linkin"></span></a>
        </div>
    </div>--%>
    <%-- <div class="divContact_add" style="padding: 5px;">
        <div class="row">
            <div class="col-sm-12">
                <h2 class="contact-head">Contact Us</h2>
            </div>
        </div>
        <div class="row ">
            <div class="col-sm-12">
                <div class="row branch_add_all" style="padding: 10px;">
                    <div class="col-sm-4">
                        <div class="branch_add">
                            <h4 class="h4FontSize">Texas Branch</h4>
                            <p>
                                3E NDT LLC.
                       
                                <br />
                                321 N.8th Street, La Porte, TX 77571
                       
                                <br />
                                <strong>Ph: (281) 470-2010</strong>
                                <br />
                                <strong>Fax: (281) 470-2024</strong>
                            </p>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="branch_add">
                            <h4 class="h4FontSize">California Branch</h4>
                            <p>
                                3E NDT LLC. 
                           
                                <br />
                                14320 Wicks Blvd. San Leandro, CA 94577 
                           
                                <br />
                                <strong>Ph # (510) 352-6767</strong>
                                <br />
                                <strong>Fax # (510) 352-6772</strong>
                            </p>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class="branch_add">
                            <h4 class="h4FontSize">Italy Branch</h4>
                            <p>
                                3E NDT, LLC 
                           
                                <br />
                                Via Roganti 16 23020 Prosto di Piuro SO ITALY
                           
                                <br />
                                <strong>Ph # +39 0343 37445</strong>
                                <br />
                                <strong>Fax # +39 0343 30974</strong>
                                <br />
                                <strong>Mob # +39 3351805557</strong>
                            </p>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>--%>
   <%-- <div class="divContact">
        <div class="divContact_to">
            To: sales@3endt.com
       
        </div>
        <label>Name (required):</label>
        <div>
        </div>
        <label>Email (required):</label>
        <div>
        </div>
        <label>Company Name:</label>
        <div>
        </div>
        <label>Address:</label>
        <div>
        </div>
        <label>
            Phone Number:
       
        </label>
        <div>
        </div>
        <label>Subject:</label>
        <div>
        </div>

        <label>
            Your Message:
       
        </label>
        <div>
        </div>


    </div>--%>
    <%--    <div style="margin: 0 auto; max-width: 640px; text-align: center">
        <a style="color:#333" href="careers.aspx">Careers with us</a>
    </div>--%>
    <script>
        function WebForm_OnSubmit() {
            if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                $("#validation_dialog").dialog({
                    title: "Validation Error!",
                    modal: true,
                    resizable: false,
                    buttons: {
                        Close: function () {
                            $(this).dialog('close');
                        }
                    }
                });
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
