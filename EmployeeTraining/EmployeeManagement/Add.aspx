<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="EmployeeTraining.EmployeeManagement.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h2>Insert new employee</h2>
    <br />
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="FullName"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="EmployeeCode" runat="server" Text="EmployeeCode"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtEmployeeCode" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="FirstName" runat="server" Text="FirstName"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="MiddlesName" runat="server" Text="MiddlesName"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtMiddlesName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LastName" runat="server" Text="LastName"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="DOB" runat="server" Text="DOB"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtDOB" runat="server" TextMode="Date"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Email" runat="server" Text="Email"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Bio" runat="server" Text="Bio"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtBio" runat="server"></asp:TextBox>
            </td>
        </tr>
        <%--<tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>--%>
        <%--<tr>
            <td></td>
            <td colspan="2">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </td>
        </tr>--%>
        <%--<tr>
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
        </tr>--%>
    </table>
    <br />
    <h2>Insert address for this employee</h2>
    <br />
    <div style="padding: 10px 0px">
        The number of records you want to insert : 
        <asp:TextBox ID="txtNoOfRecord" runat="server"></asp:TextBox>
        &nbsp;
        <asp:Button ID="btnAddRow" runat="server" Text="Set number of rows" OnClick="btnAddRow_Click" />

    </div>
    <asp:GridView ID="gvAddresses" runat="server" AutoGenerateColumns="false" CellPadding="5" OnRowDataBound="OnRowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="SL No.">
                <ItemTemplate>
                    <%#Container.DataItemIndex +1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Line1">
                <ItemTemplate>
                    <asp:TextBox ID="txtLine1" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Line2">
                <ItemTemplate>
                    <asp:TextBox ID="txtLine2" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="TownCity">
                <ItemTemplate>
                    <asp:TextBox ID="txtTownCity" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="StateOrProvince">
                <ItemTemplate>
                    <asp:TextBox ID="txtStateOrProvince" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="PostCod">
                <ItemTemplate>
                    <asp:TextBox ID="txtPostCod" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CountryCode">
                <ItemTemplate>
                    <asp:Label ID="lblCountryCode" runat="server" Visible = "false" />
                    <asp:DropDownList ID="ddlCountries" runat="server" DataTextField="Name" DataValueField="CountryCode"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div style="padding: 10px 0px;">
        <asp:Panel ID="PanelAdd" runat="server" Visible="false">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            &nbsp;<asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        </asp:Panel>
        <asp:Button ID="btnBack" runat="server" Text="Back to list" OnClick="btnBack_Click" />
    </div>
</asp:Content>
