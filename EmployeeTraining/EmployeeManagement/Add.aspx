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
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Address"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
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
        <asp:Button ID="btnAddRow" runat="server" Text="Add Rows" OnClick="btnAddRow_Click" />

    </div>
    <asp:GridView ID="gvContacts" runat="server" AutoGenerateColumns="false" CellPadding="5">
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
            <asp:TemplateField HeaderText="CountryCode">
                <ItemTemplate>
                    <asp:TextBox ID="txtCountryCode" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div style="padding: 10px 0px;">
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            &nbsp;<asp:Label ID="lblMsg" runat="server"></asp:Label>
        </asp:Panel>
    </div>
    <%--<div>
        <b>Database Records</b>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CellPadding="5">
                <Columns>
                    <asp:TemplateField HeaderText="SL No.">
                        <ItemTemplate>
                            <%#Eval("ID") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="First Name">
                        <ItemTemplate>
                            <%#Eval("FirstName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Name">
                        <ItemTemplate>
                            <%#Eval("LastName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contact No">
                        <ItemTemplate>
                            <%#Eval("ContactNo") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>--%>
</asp:Content>
