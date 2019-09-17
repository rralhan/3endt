<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_3EndTCommercePresentation.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>3ENDT</title>
    <link rel="stylesheet" href="css/bootstrap.css" />
     <link rel="stylesheet" href="css/main.css" />
    <link rel="stylesheet" href="css/fonts.css" />
   <%-- <link rel="stylesheet" href="css/bootstrap.css" />--%>
    <link rel="stylesheet" href="//ajax.googleapis.com/ajax/libs/jqueryui/1.10.4/themes/smoothness/jquery-ui.css" />
    <link rel="stylesheet" href="css/custom.css?ver=9" />
    <link rel="author" href="humans.txt" />

</head>
<body>

    <div id="wrapper">
        <div class="whitepart pull-left">
            <section class="container">
                <div class="row">
                    <div class="card loginform pull-center">
                        <div class="logo pull-left">
                            <h1 class="pull-left">
                                <img src="images/logo.jpg" alt="" /></h1>
                            <h3 class="pull-right">Login</h3>
                        </div>
                        <form class="card-body form-horizontal pull-left" role="form" id="form1" runat="server">
                            <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" OnLoggedIn="Login1_LoggedIn">
                                <LayoutTemplate>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-md-3 control-label">Username</label>
                                        <div class="col-md-9">
                                            <asp:TextBox ID="UserName" CssClass="form-control" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputPassword3" class="col-md-3 control-label">Password</label>
                                        <div class="col-md-9" style="padding-bottom: 5%;">

                                            <asp:TextBox  ID="Password" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>

                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-12"  id="validation_dialog_login">
                                            <asp:ValidationSummary ID="valSummaryLogin" runat="server" ValidationGroup="Login1" CssClass="imp-msg" DisplayMode="BulletList"/>
                                        </div>
                                    </div>
                                    <div class="form-group last">
                                        <div class="col-md-12">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Sign in" ValidationGroup="Login1"  CssClass="btn btn-default" />
                                        </div>
                                    </div>
                                </LayoutTemplate>
                            </asp:Login>
                        </form>
                        

                        <div class="forgetpassword col-md-12"><a href="/client/contact-us.aspx?urlrefer=1">Forgot Password ? Click Here</a></div>
                        <div class="signup col-md-12">Want to join our service, Please <a href="/client/contact-us.aspx?urlrefer=2">Sign up</a> first.</div>

                    </div>
                </div>
            </section>
        </div>
    </div>
    <script type='text/javascript' src='js/jquery.min.js'></script>
    <script type='text/javascript' src="js/custom.js"></script>
    <script src="//ajax.googleapis.com/ajax/libs/jqueryui/1.10.4/jquery-ui.min.js"></script>
    <script>
            function WebForm_OnSubmit() {
                if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                    $("#validation_dialog_login").dialog({
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


</body>
</html>
