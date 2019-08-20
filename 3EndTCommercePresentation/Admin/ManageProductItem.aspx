<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true"
    CodeBehind="ManageProductItem.aspx.cs" Inherits="_3EndTCommercePresentation.ManageProductItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var jsProductItem = {
            displaySecondFilter: function () {
                var seconddiv = $('#<%=trSecondFilter.ClientID%>');
                var display = $('#<%=chkSecondFilter.ClientID%>').is(':checked');
                if (display) {
                    seconddiv.show();
                }
                else {
                    seconddiv.hide();
                }
            },

            toggleProductFilterValue: function () {
                var ddltext = $('#<%=ddlProductFilterVal.ClientID %> option:selected').text();
                var divpfv = $('#divProductFilterVal');
                var ddltext2 = $('#<%=ddlProductFilter2Val.ClientID %> option:selected').text();
                var divpfv2 = $('#divProductFilter2Val');
                if (ddltext.trim().toLowerCase().indexOf("add") > 0) {
                    divpfv.show();
                }
                else {
                    divpfv.hide();
                }
                if (ddltext2.trim().toLowerCase().indexOf("add") > 0) {
                    divpfv2.show();
                }
                else {
                    divpfv2.hide();
                }
            },

            validateEntries: function () {
                var isvalid = true;
                var lblpfvmsg = $('#lblProductFilter');
                var lblpfvmsg2 = $('#lblProductFilter2');
                if ($('#divProductFilterVal').is(':visible')) {
                    var txtpfv = $('#<%=txtProductFilterVal.ClientID%>').val();
                    if (txtpfv.trim() == '') {
                        lblpfvmsg.show();
                        isvalid = false;
                    }
                }
                else {
                    var ddlpfv = $('#<%=ddlProductFilterVal.ClientID %>');
                    if (ddlpfv.val() < 0 && ddlpfv.is(':enabled')) {
                        lblpfvmsg.show();
                        isvalid = false;
                    }
                }

                if ($('#<%=chkSecondFilter.ClientID%>').is(':checked')) {
                    if ($('#<%=ddlProductFilter2.ClientID %> option:selected').val() < 0) {
                        lblpfvmsg2.text('Please select a product filter');
                        lblpfvmsg2.show();
                        isvalid = false;
                    }

                    if ($('#divProductFilter2Val').is(':visible')) {
                        var txtpfv = $('#<%=txtProductFilter2Val.ClientID%>').val();
                        if (txtpfv.trim() == '') {
                            lblpfvmsg2.show();
                            isvalid = false;
                        }
                    }
                    else {
                        if ($('#<%=ddlProductFilter2Val.ClientID %> option:selected').val() < 0) {
                            lblpfvmsg2.show();
                            isvalid = false;
                        }
                    }
                }
                if (isvalid) {
                    lblpfvmsg.hide();
                    lblpfvmsg.hide();
                }
                return isvalid;
            },

            hideMsg:function(ddlproduct)
            {
                var msg = $('#<%=lblMessage.ClientID %>');
                if($(ddlproduct).val() > 0)
                {
                    msg.hide();
                }
            },


            toggleProductFilters: function () {
                var displayfilters = $('#<%=chkNoFilter.ClientID%>').is(':checked');
                var ddlfilter = $('#<%=ddlProductFilter.ClientID%>');
                var ddlfilterval = $('#<%=ddlProductFilterVal.ClientID%>');
                var chk2filter = $('#<%=chkSecondFilter.ClientID%>');
                if (displayfilters) {
                    ddlfilter.attr('disabled', true);
                    ddlfilterval.attr('disabled', true);
                    chk2filter.attr('disabled', true);
                }
                else {
                    ddlfilter.attr('disabled', false);
                    ddlfilterval.attr('disabled', false);
                    chk2filter.attr('disabled', false);
                }
            }

        }

    </script>
    <style type="text/css">
        .auto-style1 {
            height: 61px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table class="toptable">
        <tr>
            <td class="tdfirst">Product  :
            </td>
            <td class="tdsecond">
                <asp:DropDownList ID="ddlProduct" runat="server" CssClass="entries" onchange="jsProductItem.hideMsg(this);" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="-1"> -- Select Product --</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="refProduct" ControlToValidate="ddlProduct" ValidationGroup="ValidateProductItem"
                    InitialValue="-1" runat="server" ErrorMessage="Please select a Product" CssClass="imp-msg"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td>Product SKU:</td>
            <td>
                <asp:TextBox ID="txtProductSKU" CssClass="entries" runat="server"></asp:TextBox>
            </td>
            <td colspan="2">
                <asp:Label ID="lblUniqueSKU" runat="server" CssClass="imp-msg" Visible="false">Please enter a valid Product SKU</asp:Label>
                <asp:RequiredFieldValidator ID="rfeProductSKU" runat="server" ValidationGroup="ValidateProductItem"
                    ErrorMessage="Please enter a Product SKU" CssClass="imp-msg" ControlToValidate="txtProductSKU"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>No Product Filter?</td>
            <td>

                <asp:CheckBox ID="chkNoFilter" runat="server" onchange="jsProductItem.toggleProductFilters()" />
                (Item same as Product)
            </td>
        </tr>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <tr>
                    <td>Product Filter:</td>
                    <td>
                        <%--OnSelectedIndexChanged="ddlProductFilter_SelectedIndexChanged" AutoPostBack="true"--%>
                        <asp:DropDownList ID="ddlProductFilter" runat="server" CssClass="entries" OnSelectedIndexChanged="ddlProductFilter_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblMessage" runat="server" CssClass="imp-msg"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Product Filter Value:</td>
                    <td class="auto-style1">
                        <div style="margin-bottom: 5px;">
                            <asp:DropDownList ID="ddlProductFilterVal" runat="server" CssClass="entries" onchange="jsProductItem.toggleProductFilterValue();">
                                <asp:ListItem Text=" -- Select a Product Filter Value --" Value="-1"></asp:ListItem>
                                <asp:ListItem Text=" -- Add a new Product Filter Value --" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div style="margin-top: 5px;" id="divProductFilterVal">
                            <asp:TextBox ID="txtProductFilterVal" runat="server" CssClass="entries"></asp:TextBox>
                        </div>
                    </td>

                    <td class="auto-style1">
                        <label id="lblProductFilter" class="imp-msg" style="display: none;">Please enter a Product Filter Value</label>
                    </td>
                </tr>
                <tr>
                    <td class="tdfirst">Is there a second filter?</td>
                    <td>
                        <asp:CheckBox ID="chkSecondFilter" runat="server" onclick="jsProductItem.displaySecondFilter();" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr id="trSecondFilter" runat="server" style="display: none;">
                    <td colspan="2">
                        <table style="border-spacing: 0; border-collapse: collapse">
                            <tr>

                                <td class="tdfirst">Second Product Filter :
                                </td>
                                <td class="tdsecond">
                                    <asp:DropDownList ID="ddlProductFilter2" runat="server" OnSelectedIndexChanged="ddlProductFilter2_SelectedIndexChanged" CssClass="entries" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td></td>
                            </tr>
                            <tr>
                                <td class="tdfirst">Second Product Filter Value :
                                </td>
                                <td>
                                    <div style="margin-bottom: 5px;">
                                        <asp:DropDownList ID="ddlProductFilter2Val" runat="server" CssClass="entries" onchange="jsProductItem.toggleProductFilterValue();">
                                            <asp:ListItem Text=" -- Select a Product Filter Value --" Value="-1"></asp:ListItem>
                                            <asp:ListItem Text=" -- Add a new Product Filter Value --" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div style="margin-top: 5px;" id="divProductFilter2Val">
                                        <asp:TextBox ID="txtProductFilter2Val" runat="server" CssClass="entries"></asp:TextBox>
                                    </div>


                                </td>
                                <td style="vertical-align: top">
                                    <label id="lblProductFilter2" class="imp-msg" style="display: none;">Please enter a Product Filter Value</label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </ContentTemplate>
        </asp:UpdatePanel>

        <tr>
            <td>&nbsp;        
                <asp:HiddenField Id="hdnProductItemId" runat="server" />
            </td>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btnsubmit" Visible="false" OnClick="btnDelete_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="ValidateProductItem"
                                Text="Save" OnClientClick="return jsProductItem.validateEntries();"
                                CausesValidation="true" CssClass="btnsubmit" OnClick="btnSave_Click" />
                        </td>
                        <td>
                            <asp:Button ID="btnCancel" runat="server" CausesValidation="false" Text="Cancel"
                                CssClass="btnsubmit" OnClick="btnCancel_Click" />
                        </td>
                    </tr>
                </table>           

               
            </td>
            <td colspan="2">&nbsp;
                
            </td>
        </tr>

    </table>




    <div>


        <div>
            <asp:GridView ID="grdProductItem" runat="server" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" PageSize="20" OnPageIndexChanging="grdProductItem_PageIndexChanging"
                AllowPaging="true" OnRowCommand="grdProductItem_RowCommand">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <PagerSettings LastPageText="Last" Mode="NumericFirstLast" FirstPageText="First" />
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
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="left" />
                        <ItemStyle HorizontalAlign="left" />
                        <HeaderTemplate>
                            <asp:Label ID="lblProductHeader" runat="server" Text="Product"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblProduct" runat="server" Text='<%# Eval("ProductName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="left" />
                        <ItemStyle HorizontalAlign="left" />
                        <HeaderTemplate>
                            <asp:Label ID="lblProductSKUHeader" runat="server" Text="Product SKU"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblProductSku" runat="server" Text='<%# Eval("ProductSKU")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="left" />
                        <ItemStyle HorizontalAlign="left" />
                        <HeaderTemplate>
                            <asp:Label ID="lblPrimaryFilterHeader" runat="server" Text="Primary Filter"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPrimaryFilter" runat="server" Text='<%# Eval("PrimaryFilterType")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="left" />
                        <ItemStyle HorizontalAlign="left" />
                        <HeaderTemplate>
                            <asp:Label ID="lblPrimaryFilterValueHeader" runat="server" Text="Primary Filter Value"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPrimaryFilterValue" runat="server" Text='<%# Eval("PrimaryFilterValue")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="left" />
                        <ItemStyle HorizontalAlign="left" />
                        <HeaderTemplate>
                            <asp:Label ID="lblSecondaryFilterHeader" runat="server" Text="Secondary Filter"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSecondaryFilter" runat="server" Text='<%# Eval("SecondaryFilterType")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderStyle HorizontalAlign="left" />
                        <ItemStyle HorizontalAlign="left" />
                        <HeaderTemplate>
                            <asp:Label ID="lblSecondaryFilterValueHeader" runat="server" Text="Secondary Filter Value"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblSecondaryFilterValue" runat="server" Text='<%# Eval("SecondaryFilterValue")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Edit Product Item">
                        <HeaderStyle HorizontalAlign="left" />
                        <ItemStyle HorizontalAlign="center" />
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/Images/edit.gif" ToolTip="Edit" CausesValidation="false" CommandArgument='<%# Eval("ItemId") %>' CommandName="cmdedit" />
                            <%--<asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/Images/delete.png" ToolTip="Delete" CausesValidation="false" CommandArgument='<%# Eval("CategoryId") %>' CommandName="cmddelete" />--%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <script>
            $(document).ready(function () {
                jsProductItem.displaySecondFilter();
                jsProductItem.toggleProductFilterValue();
            });
        </script>
    </div>



</asp:Content>
