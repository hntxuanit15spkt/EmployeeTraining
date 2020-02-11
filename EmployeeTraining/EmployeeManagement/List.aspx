<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="EmployeeTraining.EmployeeManagement.List" %>

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
    <asp:Button runat="server" ID="BtnCreate" Text="Create new employee" CssClass="insert" />
    <asp:GridView ID="EmployeeGrid" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="FullName" HeaderText="FullName"></asp:BoundField>
            <asp:BoundField DataField="DOB" HeaderText="DOB"></asp:BoundField>
            <asp:TemplateField HeaderText="Addresses">
                <ItemTemplate>
                    <asp:Repeater ID="Repeater1" runat="server" DataSource='<%# Eval("Addresses") %>'>
                        <ItemTemplate>
                            <%# (Container.ItemIndex+1)+"." %>
                            <asp:HyperLink ID="HyperLink1" runat="server" Text='<%#(Container.DataItem as EmployeeAddressObject).Text %>'>  
                            </asp:HyperLink>
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
