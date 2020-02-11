<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="EmployeeTraining.EmployeeManagement.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="FullName"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <%--<tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Mobile"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Adddress"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>--%>
        <tr>
            <td></td>
            <td colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2">
                <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
            </td>
            <tr>
                <td></td>
                <td colspan="2">
                    <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </tr>
    </table>
</asp:Content>