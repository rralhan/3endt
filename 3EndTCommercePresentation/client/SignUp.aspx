<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="_3EndTCommercePresentation.SignUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Admin/bootstrap/css/bootstrap-responsive.css" rel="stylesheet" type="text/css" />
    <link href="../Admin/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="../Admin/bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../Admin/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Admin/bootstrap/js/bootstrap.min.js"></script>
    <script src="../Admin/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../Admin/bootstrap/js/bootstrap.js" type="text/javascript"></script>
    <script src="../Admin/bootstrap/js/jquery-1.8.3.js" type="text/javascript"></script>
    

</head>
<body>
    <form id="form1" runat="server">
 
    <div><strong style="color: #0000FF">Create An Account.</strong></div>
    <asp:UpdatePanel ID="upnlTop" runat="server">
    <ContentTemplate>
   
    <div style="width: 49%; float: left; border: 1px solid red;">
   


        <table class="auto-style1">

            <tr>
                <td class="style1" colspan="3">&nbsp; 
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
                </td>
                <td class="style1">&nbsp; 
                    <asp:Label ID="lblPassword" runat="server" Visible="false" ForeColor="Red" Text=""></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="style1">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td class="style1">First Name:</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtFirstName" runat="server" Width="175px"></asp:TextBox>

                </td>
                <td class="auto-style6">

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" 
                        ControlToValidate="txtFirstName" ValidationGroup="ValidateSignUp" 
                        Display="None" runat="server" 
                        ErrorMessage="<b>First Name is empty</b><br/>Please enter a value for First Name."></asp:RequiredFieldValidator>

                </td>

            </tr>

            <tr>
                <td class="style1">Last Name:</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtLastName" runat="server" Width="175px"></asp:TextBox>

                </td>
                <td class="auto-style6">

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" 
                        ControlToValidate="txtLastName" ValidationGroup="ValidateSignUp" 
                        Display="None" runat="server" 
                        
                        ErrorMessage="<b>Last Name is empty</b><br/>Please enter a value for Last Name."></asp:RequiredFieldValidator>

                </td>

            </tr>

            <tr>
                <td class="style1">Company Name:</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtCompanyName" runat="server" Width="175px"></asp:TextBox>

                </td>
                <td class="auto-style6">

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtCompanyName" ValidationGroup="ValidateSignUp" Display="None" runat="server" ErrorMessage="<b>Company is empty</b><br/>Please enter a value for Company."></asp:RequiredFieldValidator>

                </td>

            </tr>

            <tr>
                <td class="style1">Parent Company Name:</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtParentCompanyName" runat="server" Width="175px"></asp:TextBox>

                </td>
                <td class="auto-style6">

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtParentCompanyName" ValidationGroup="ValidateSignUp" Display="None" runat="server" ErrorMessage="<b>Parent-Company is empty</b><br/>Please enter a value for Parent-Company."></asp:RequiredFieldValidator>

                </td>

            </tr>

            <tr>
                <td class="style1">Company Billing Address:</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtBillingAddress" runat="server" Width="175px"></asp:TextBox>

                </td>
                <td class="auto-style6">

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtBillingAddress" ValidationGroup="ValidateSignUp" Display="None" runat="server" ErrorMessage="<b>Billing Address is empty</b><br/>Please enter a value for billing address."></asp:RequiredFieldValidator>

                </td>

            </tr>

            <tr>
                <td class="style1">FederalId:</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtFederalId" runat="server" Width="175px"></asp:TextBox></td>
                <td class="auto-style6">

                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtFederalId" ValidationGroup="ValidateCompany" Display="None" runat="server" ErrorMessage="<b>FederalId is empty</b><br/>Please enter a value for FederalId."></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender" TargetControlID="RequiredFieldValidator7" runat="server">
                    </asp:ValidatorCalloutExtender>--%>
                </td>

            </tr>

            <tr>
                <td class="style1">Contact:</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtContact" runat="server" Width="175px"></asp:TextBox></td>
                <td class="auto-style6">

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtContact"  ValidationGroup="ValidateSignUp" Display="None" runat="server" ErrorMessage="<b>Contact is empty</b><br/>Please enter a value for contact no."></asp:RequiredFieldValidator>

                </td>

            </tr>

            <tr>
                <td class="style1">Fax Number:</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtFaxNumber" runat="server" Width="175px"></asp:TextBox></td>
                <td class="auto-style6">

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtFaxNumber" ValidationGroup="ValidateSignUp" Display="None" runat="server" ErrorMessage="<b>Fax No.is empty</b><br/>Please enter a value for fax no."></asp:RequiredFieldValidator>

                </td>

            </tr>

            <tr>
                <td class="style1">Email ID:</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtEmailId" runat="server" Width="175px"></asp:TextBox></td>
                <td class="auto-style6">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="None"   ErrorMessage="<b>Enter Valid Eamil Address.</b>" ControlToValidate="txtEmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtEmailId" ValidationGroup="ValidateSignUp" Display="None" runat="server" ErrorMessage="<b>Eamil Address is empty</b><br/>Please enter a value for email address."></asp:RequiredFieldValidator>

                </td>

            </tr>

            <tr>
                <td class="style1">User ID</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtUserId" runat="server" Width="175px"></asp:TextBox>
                </td>
                <td class="auto-style6">

                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" 
                        ControlToValidate="txtUserId" ValidationGroup="ValidateSignUp" 
                        Display="None" runat="server" 
                        ErrorMessage="<b>User ID is empty</b><br/>Please enter a value for User Id"></asp:RequiredFieldValidator>


                </td>
            </tr>
            <tr>
                <td class="style1">
                    <asp:Button ID="btnSave" runat="server" ValidationGroup="ValidateSignUp" Text="Sign Up" Width="73px" OnClick="btnSave_Click" />
                </td>
                <td class="auto-style7">
                    <asp:Button ID="btnCancel" runat="server" CausesValidation="false" OnClick="btnCancel_Click" Text="Cancel" Width="73px" />
                </td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
        </table>


    </div>
     </ContentTemplate>
    </asp:UpdatePanel> 
     <script type="text/javascript" src="Admin/bootstrap/js/bootstrap.js"></script>
    
    
    <asp:UpdatePanel ID="upCrudGrid" runat="server">

        <ContentTemplate>
            <div style="width: 50%; border: 1px solid black; float: right;">
                <div>
                    Shipping Address
            
                </div>


                <div>

                    <asp:Button ID="btnAddNewShippingAddress" runat="server" Text="Add New"
                        CausesValidation="false" OnClick="btnAddNewShippingAddress_Click" />

                </div>
                <div>
                    <asp:Label ID="lblDispaly" ForeColor="Red" runat="server" Text=""></asp:Label>

                </div>
                <div>
                    <asp:UpdatePanel ID="upnlShipping" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvShippingAddress" runat="server" AutoGenerateColumns="False"
                                CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%"
                                AllowPaging="True" OnPageIndexChanging="gvShippingAddress_PageIndexChanging"
                                OnRowCommand="gvShippingAddress_RowCommand">
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
                                   <%--  <asp:TemplateField>
                                        <HeaderStyle HorizontalAlign="left" />
                                        <ItemStyle HorizontalAlign="left" />
                                        <HeaderTemplate>
                                            <asp:Label ID="lblPrimary" runat="server" Text="Not Primary "></asp:Label>
                                        </HeaderTemplate>
                                        <ItemTemplate>

                                           <asp:RadioButton ID="rdoIsPrimary" Checked='<%# Eval("IsPrimary")%>' Text="Set As Primary" GroupName="Primary" AutoPostBack="true" runat="server" />
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                   <%-- <asp:TemplateField HeaderText="Edit/Delete Shipping Address">
                                        <HeaderStyle HorizontalAlign="left" />
                                        <ItemStyle HorizontalAlign="left" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/Images/edit.gif" ToolTip="Edit" CausesValidation="false" CommandArgument='<%# Eval("ShippingAddressId") %>' CommandName="cmdedit" />
                                            <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/Images/delete.png" ToolTip="Delete" CausesValidation="false" CommandArgument='<%# Eval("ShippingAddressId") %>' CommandName="cmddelete" />


                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>

            </div>
        </ContentTemplate>
        <Triggers></Triggers>
    </asp:UpdatePanel>
    
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <br />
            <img src="" alt="Loading.. Please wait!" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div id="addModal" class="modal hide fade" tabindex="-1" role="dialog"
        aria-labelledby="addModalLabel" aria-hidden="true">

        <div class="modal-header">

            <button type="button" class="close" data-dismiss="modal"
                aria-hidden="true">
                ×</button>

            <h3 id="addModalLabel">Add Shipping Address</h3>

        </div>

        <asp:UpdatePanel ID="upAdd" runat="server">

            <ContentTemplate>

                <div class="modal-body">

                    <table class="table table-bordered table-hover">

                        <tr>

                            <td>Shipping Address Name :

   <asp:TextBox ID="txtShippingAddressName" runat="server">

   </asp:TextBox>

                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtShippingAddressName" ValidationGroup="Shipping" ForeColor="Red" runat="server" ErrorMessage="Enter Shipping Address"></asp:RequiredFieldValidator>
                                <%--<asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" TargetControlID="RequiredFieldValidator1" runat="server">
                    </asp:ValidatorCalloutExtender>--%>

                            </td>

                        </tr>
                        <tr>
                        <td>
                            <asp:RadioButton ID="rdoIsPrimary" Text="Set As Primary" GroupName="Primary" AutoPostBack="true" runat="server" />
                            <asp:RadioButton ID="rdoNotPrimary" Text="Not Primary" GroupName="Primary" AutoPostBack="true" runat="server" />
                        </td>
                        </tr>


                    </table>

                </div>

                <div class="modal-footer">

                    <asp:Button ID="btnAddRecord" runat="server" ValidationGroup="Shipping" OnClick="btnAddRecord_Click" Text="Add"
                        CssClass="btn btn-info" />

                    <button class="btn btn-info" data-dismiss="modal"
                        aria-hidden="true">
                        Close</button>

                </div>

            </ContentTemplate>

            <%--<Triggers>

  <asp:AsyncPostBackTrigger ControlID="btnAddRecord" EventName="Click" />

  </Triggers>--%>
        </asp:UpdatePanel>

    </div>
    
   
    </form>
</body>
</html>
