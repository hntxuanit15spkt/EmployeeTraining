<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="EmployeeTraining.EmployeeManagement.List" 
    UICulture="vi"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server" PageSize="10" AllowPaging="true" AllowSorting="true">
    <style type="text/css">
        .insert {
            border: 1px solid #563d7c;
            border-radius: 5px;
            color: white;
            padding: 5px 10px 5px 25px;
            /*background: url(https://i.stack.imgur.com/jDCI4.png) left 3px top 5px no-repeat #563d7c;*/
            background: left 3px top 5px no-repeat #563d7c;
        }
    </style>
    <asp:Label runat="server" ID="lblHelloWorld" Text="Hello, world!" meta:resourcekey="lblHelloWorld" />
    <asp:Button runat="server" ID="BtnCreate" Text="Create new employee" CssClass="insert" OnClick="RedirectToCreate_Click" />
    <br />
    <br />
    <asp:Label runat="server" Text="Date:" />
    <asp:TextBox ID="txtDate" runat="server" TextMode="Date"></asp:TextBox>
    <asp:Label runat="server" Text="fromDOB:" />
    <asp:TextBox ID="txtFromDate" runat="server" TextMode="Date"></asp:TextBox>
    <asp:Label runat="server" Text="toDOB:" />
    <asp:TextBox ID="txtToDate" runat="server" TextMode="Date"></asp:TextBox>
    <asp:Label runat="server" Text="Name:" />
    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"/>
    
    <br />
    <asp:Label ID="lblMsg" ForeColor="Red" runat="server"></asp:Label>
    <br />
    <asp:GridView ID="EmployeeGrid" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="20" OnPageIndexChanging="EmployeeGrid_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="FullName" HeaderText="FullName"></asp:BoundField>
            <asp:BoundField DataField="DOB" HeaderText="DOB" DataFormatString="{0:MM/dd/yyyy}"></asp:BoundField>
            <asp:TemplateField HeaderText="Addresses (Line 1)">
                <ItemTemplate>
                    <asp:Repeater ID="Repeater1" runat="server" DataSource='<%# Eval("Addresses") %>'>
                        <ItemTemplate>
                            <%# (Container.ItemIndex+1)+"." %>
                            <asp:Label ID="HyperLinkAddress" runat="server" Text='<%#(Container.DataItem as EmployeeTraining.Code.AddressModel).Line1 %>'>  
                            </asp:Label>
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkUpdate" runat="server" CommandArgument='<%# Eval("EmployeeId") %>' OnClick="lnk_OnUpdate">Update</asp:LinkButton>
                    <asp:LinkButton ID="DeleteButton" runat="server" CommandArgument='<%# Eval("EmployeeId") %>' CommandName="Delete" OnCommand="CommandBtn_Click" OnClientClick='<%# string.Format("javascript:return ConfirmOnDelete(\"{0}\")", Eval("FullName")) %>' AlternateText="Delete">Delete</asp:LinkButton>
                    <%--<asp:LinkButton ID="DeleteButton" runat="server" CommandArgument='<%# Eval("EmployeeId") %>' CommandName="Delete" OnCommand="CommandBtn_Click" OnClientClick='return confirmCheckIn(this);' AlternateText="Delete">Delete</asp:LinkButton>--%>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.2/jquery-confirm.min.css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-confirm/3.3.2/jquery-confirm.min.js"></script>--%>
    <script type="text/javascript">
        //function confirmCheckIn(button) {
        //    var _confirm = false;
        //    if (_confirm == false) {
        //        jQuery('<div>')
        //            .html("<p>Do you want to check in?</p>")
        //            .dialog({
        //                autoOpen: true,
        //                modal: true,
        //                title: "Check in?",
        //                buttons: {
        //                    "No": function () {
        //                        jQuery(this).dialog("close");
        //                    },
        //                    "Yes": function () {
        //                        jQuery(this).dialog("close");
        //                        _confirm = true;
        //                        button.click();
        //                    }
        //                },
        //                close: function () {
        //                    jQuery(this).remove();
        //                }
        //            });
        //    }
        //    return _confirm;
        //}
        function ConfirmOnDelete(fullName) {
            if (confirm(`Do you really want to delete ${fullName}?`) == true)
                return true;
            else
                return false;
            //$.confirm({
            //    title: 'confirm!',
            //    content: 'simple confirm!',
            //    buttons: {
            //        confirm: function () {
            //            $.alert('confirmed!');
            //            return true;
            //        },
            //        cancel: function () {
            //            $.alert('canceled!');
            //            return false;
            //        },
            //        somethingelse: {
            //            text: 'something else',
            //            btnclass: 'btn-blue',
            //            keys: ['enter', 'shift'],
            //            action: function () {
            //                $.alert('something else?');
            //            }
            //        }
            //    }
            //});
            //return false;
        }
    </script>
</asp:Content>
