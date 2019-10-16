<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="_3EndTCommercePresentation.SignUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SignUp</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="expires" content="Thu, 19 Nov 1900 08:52:00 GMT" />
    <!--Loading bootstrap css-->
    <link type="text/css"
        href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,700italic,800italic,400,700,800" />
    <link type="text/css" rel="stylesheet" href="http://fonts.googleapis.com/css?family=Oswald:400,700,300" />
    <link type="text/css" rel="stylesheet"
        href="../vendors/jquery-ui-1.10.3.custom/css/ui-lightness/jquery-ui-1.10.3.custom.css" />
    <link type="text/css" rel="stylesheet" href="../vendors/font-awesome/css/font-awesome.min.css" />
    <link type="text/css" rel="stylesheet" href="../vendors/bootstrap/css/bootstrap.min.css" />
    <!--Loading style vendors-->
    <link type="text/css" rel="stylesheet" href="../vendors/animate.css/animate.css" />
    <link type="text/css" rel="stylesheet" href="../vendors/iCheck/skins/all.css" />
    <!--Loading style-->
    <link type="text/css" rel="stylesheet" href="../css1/themes/style1/pink-blue.css" class="default-style" />
    <link type="text/css" rel="stylesheet" href="../css1/themes/style1/pink-blue.css" id="theme_change"
        class="style-change color-change" />
    <link type="text/css" rel="stylesheet" href="../css1/style-responsive.css" />
    <link rel="shortcut icon" href="../images/favicon.ico" />
</head>
<body id="signup-page">
    <div class="page-form">
        <form id="form1" runat="server">
            <div class="header-content">
                <h1>Create An Account.</h1>
            </div>
            <div class="body-content">

                <asp:ScriptManager ID="ScriptManager1" runat="server" />
                <asp:UpdatePanel ID="upnlTop" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
                            <asp:Label ID="lblPassword" runat="server" Visible="false" ForeColor="Red" Text=""></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="First Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="txtFirstName" ValidationGroup="ValidateSignUp" Display="None" runat="server" ErrorMessage="<b>First Name is empty</b><br/>Please enter a value for First Name."></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" placeholder="Last Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15"
                                ControlToValidate="txtLastName" ValidationGroup="ValidateSignUp"
                                Display="None" runat="server"
                                ErrorMessage="<b>Last Name is empty</b><br/>Please enter a value for Last Name."></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtCompanyName" runat="server" CssClass="form-control" placeholder="Company Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtCompanyName" ValidationGroup="ValidateSignUp" Display="None" runat="server" ErrorMessage="<b>Company is empty</b><br/>Please enter a value for Company."></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtParentCompanyName" runat="server" CssClass="form-control" placeholder="Parent Company Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtParentCompanyName" ValidationGroup="ValidateSignUp" Display="None" runat="server" ErrorMessage="<b>Parent-Company is empty</b><br/>Please enter a value for Parent-Company."></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtBillingAddress" runat="server" CssClass="form-control" placeholder="Company Billing Address"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtBillingAddress" ValidationGroup="ValidateSignUp" Display="None" runat="server" ErrorMessage="<b>Billing Address is empty</b><br/>Please enter a value for billing address."></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtFederalId" runat="server" CssClass="form-control" placeholder="FederalId"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" placeholder="Contact"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtContact" ValidationGroup="ValidateSignUp" Display="None" runat="server" ErrorMessage="<b>Contact is empty</b><br/>Please enter a value for contact no."></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtFaxNumber" runat="server" CssClass="form-control" placeholder="Fax Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtFaxNumber" ValidationGroup="ValidateSignUp" Display="None" runat="server" ErrorMessage="<b>Fax No.is empty</b><br/>Please enter a value for fax no."></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtEmailId" runat="server" CssClass="form-control" placeholder="Email ID"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None" ErrorMessage="<b>Enter Valid Eamil Address.</b>" ControlToValidate="txtEmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtEmailId" ValidationGroup="ValidateSignUp" Display="None" runat="server" ErrorMessage="<b>Eamil Address is empty</b><br/>Please enter a value for email address."></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control" placeholder="User ID"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="txtUserId" ValidationGroup="ValidateSignUp"
                                Display="None" runat="server"
                                ErrorMessage="<b>User ID is empty</b><br/>Please enter a value for User Id"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="ValidateSignUp" Text="Sign Up" CssClass="btn btn-info" />
                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel" CssClass="btn btn-warning" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="upCrudGrid" runat="server">
                    <ContentTemplate>
                        <div class="form-group">
                            Shipping Address
                        <button type="button" CausesValidation="false" class="btn btn-info" data-target="#addModal" data-toggle="modal">Add New</button>                            <asp:Label ID="lblDispaly" ForeColor="Red" runat="server" Text=""></asp:Label>
                        </div>
                    </ContentTemplate>
                    <Triggers></Triggers>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="upnlShipping" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvShippingAddress" runat="server" AutoGenerateColumns="False"
                            CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%"
                            AllowPaging="True">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            <Columns>
                                <asp:TemplateField HeaderText="S. No">
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShippingAddressId" runat="server" Text='<%#Eval("ShippingAddressId") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" />
                                    <HeaderTemplate>
                                        <asp:Label ID="Label1" runat="server" Text="Shipping Address "></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblShippingAddress" runat="server" Text='<%# Eval("ShippingAddressName")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderStyle HorizontalAlign="left" />
                                    <ItemStyle HorizontalAlign="left" />
                                    <HeaderTemplate>
                                        <asp:Label ID="lblPrimary" runat="server" Text=" Primary "></asp:Label>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:RadioButton ID="rdoIsPrimary" Checked='<%# Eval("IsPrimary")%>' Text="Set As Primary" GroupName="Primary" AutoPostBack="true" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <br />
                        <img src="#" alt="Loading.. Please wait!" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
            <div id="addModal" tabindex="-1" role="dialog" aria-labelledby="modal-wide-width-label" aria-hidden="true" class="modal fade">
                <div class="modal-dialog modal-wide-width">
                    <div class="modal-content">
                        <asp:UpdatePanel ID="upAdd" runat="server">
                            <ContentTemplate>
                                <div class="modal-header">
                                    <button type="button" data-dismiss="modal" aria-hidden="true" class="close">&times;</button>
                                    <h3 id="addModalLabel">Add Shipping Address</h3>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-md-3">
                                            Shipping Address Name :
                                        </div>
                                        <div class="col-md-6">
                                            <asp:TextBox ID="txtShippingAddressName" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtShippingAddressName" ValidationGroup="Shipping" ForeColor="Red" runat="server" ErrorMessage="Enter Shipping Address"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:RadioButton ID="rdoIsPrimary" Text="Set As Primary" GroupName="Primary" AutoPostBack="true" runat="server" />
                                            <asp:RadioButton ID="rdoNotPrimary" Text="Not Primary" GroupName="Primary" AutoPostBack="true" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnAddRecord" runat="server" ValidationGroup="Shipping" Text="Add" CssClass="btn btn-info" />
                                    <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </form>
    </div>
    <script type="text/javascript" src="../js1/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../js1/jquery-migrate-1.2.1.min.js"></script>
    <script type="text/javascript" src="../js1/jquery-ui.js"></script>
    <!--loading bootstrap js-->
    <script type="text/javascript" src="../vendors/bootstrap/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="../vendors/bootstrap-hover-dropdown/bootstrap-hover-dropdown.js"></script>
    <script type="text/javascript" src="../vendors/jquery-validate/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../js1/html5shiv.js"></script>
    <script type="text/javascript" src="../js1/respond.min.js"></script>
    <script type="text/javascript" src="../js1/extra-signup.js"></script>
    <script type="text/javascript" src="../vendors/iCheck/icheck.min.js"></script>
    <script type="text/javascript" src="../vendors/iCheck/custom.min.js"></script>
</body>
</html>
