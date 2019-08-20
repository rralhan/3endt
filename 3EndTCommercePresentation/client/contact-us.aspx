<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Client.Master" AutoEventWireup="true" CodeBehind="contact-us.aspx.cs" Inherits="_3EndTCommercePresentation.client.contact_us" %>

<%--<%@ Register TagPrefix="recaptcha" Namespace="Recaptcha" Assembly="Recaptcha" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CoreContentHolder" runat="server">

    <div class="top-upper row">
        <div class="col-xs-6">
            <a href="tel:2814702010"><span class="glyphicon glyphicon-earphone"></span>281-470-2010</a>
        </div>
        <div class="col-xs-6">
            <a href="https://www.facebook.com/3endt"><span class="glyphicon fbook"></span></a>
            <a href="https://www.twitter.com/3endt"><span class="glyphicon tweeter"></span></a>
            <a href="https://www.linkedin.com/company/3endt"><span class="glyphicon linkin"></span></a>
        </div>
    </div>
    <div class="divContact_add">
        <div class="row">
            <div class="col-sm-12">
                <h2 class="contact-head">Contact Us</h2>
            </div>
        </div>
        <div class="row ">
            <div class="col-sm-12">
                <div class="row branch_add_all">
                    <div class="col-sm-4">
                        <div class="branch_add">
                            <h4>Texas Branch</h4>
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
                            <h4>California Branch</h4>
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
                            <h4>Italy Branch</h4>
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
    </div>
    <div class="divContact">
        <div class="divContact_to">
            To: sales@3endt.com
        </div>
        <label>Name (required):</label>
        <div>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:RequiredFieldValidator ID="refName" runat="server" ErrorMessage="Name is a required field" Text="*" CssClass="imp-msg" ControlToValidate="txtName" ValidationGroup="valContactUs"></asp:RequiredFieldValidator>

        </div>
        <label>Email (required):</label>
        <div>
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="refEmail" runat="server" ErrorMessage="Email is a required field" Text="*" ControlToValidate="txtEmail" CssClass="imp-msg" ValidationGroup="valContactUs"></asp:RequiredFieldValidator>

        </div>
        <label>Company Name:</label>
        <div>
            <asp:TextBox runat="server" CssClass="form-control"></asp:TextBox>

        </div>
        <label>Address:</label>
        <div>
            <asp:TextBox runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <label>
            Phone Number:
        </label>
        <div>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPhoneNumber" runat="server" ErrorMessage="Phone is a required field" Text="*" ControlToValidate="txtPhone" ValidationGroup="valContactUs" CssClass="imp-msg" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Text="*" runat="server" ErrorMessage="Phone Number is not valid" ValidationGroup="valContactUs" ControlToValidate="txtPhone" CssClass="imp-msg" ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}">
            </asp:RegularExpressionValidator>
        </div>
        <label>Subject:</label>
        <div>
            <asp:TextBox ID="txtSubject" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Panel ID="pnlUserId" runat="server" Visible="false">
            <label>UserId (required):</label>
            <div>
                <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </asp:Panel>
        <label>
            Your Message:
        </label>
        <div>

            <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Height="150px" CssClass="form-control"></asp:TextBox>

        </div>

        <div id="validation_dialog">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="valContactUs" CssClass="imp-msg validation_summary" DisplayMode="BulletList" />
        </div>

        <div class="send_btn">
            <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="btncart btn btn-warning" OnClick="btnSend_Click" ValidationGroup="valContactUs" />
        </div>
    </div>
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
