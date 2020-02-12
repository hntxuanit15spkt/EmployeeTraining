﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="EmployeeTraining.EmployeeManagement.List" %>

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
    <asp:Button runat="server" ID="BtnCreate" Text="Create new employee" CssClass="insert" OnClick="RedirectToCreate_Click" />
    <br />
    <asp:Label ID="lblMsg" ForeColor="Red" runat="server"></asp:Label>
    <br />
    <asp:GridView ID="EmployeeGrid" runat="server" AutoGenerateColumns="False" AllowPaging="true" PageSize="20" OnPageIndexChanging="EmployeeGrid_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="FullName" HeaderText="FullName"></asp:BoundField>
            <asp:BoundField DataField="DOB" HeaderText="DOB"></asp:BoundField>
            <asp:TemplateField HeaderText="Addresses (Line 1)">
                <ItemTemplate>
                    <asp:Repeater ID="Repeater1" runat="server" DataSource='<%# Eval("Addresses") %>'>
                        <ItemTemplate>
                            <%# (Container.ItemIndex+1)+"." %>
                            <asp:HyperLink ID="HyperLinkAddress" runat="server" Text='<%#(Container.DataItem as EmployeeTraining.Code.AddressModel).Line1 %>'>  
                            </asp:HyperLink>
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkUpdate" runat="server" CommandArgument='<%# Eval("EmployeeId") %>' OnClick="lnk_OnUpdate">Update</asp:LinkButton>
                    <asp:LinkButton ID="DeleteButton" runat="server" CommandArgument='<%# Eval("EmployeeId") %>' CommandName="Delete" OnCommand="CommandBtn_Click" OnClientClick='<%# string.Format("javascript:return ConfirmOnDelete(\"{0}\")", Eval("FullName")) %>' AlternateText="Delete">Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <script type="text/javascript">    
        function ConfirmOnDelete(fullName) {
            if (confirm(`Do you really want to delete ${fullName}?`) == true)
                return true;
            else
                return false;
        }
    </script>
</asp:Content>
