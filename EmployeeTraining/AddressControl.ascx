<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddressControl.ascx.cs" Inherits="EmployeeTraining.AddressControl" %>
<%--<script runat="server">
    public int MinValue = 0;
</script>--%>
<%--123--%>
<table>
    <tr>
        <td>
            <asp:HiddenField ID="txtAddressId" runat="server" Value='<%#Eval("AddressId")%>' />
        </td>
        <td>
            <asp:Label ID="lblLine1" runat="server"
                Text="Line1"></asp:Label></td>
        <td>
            <asp:TextBox ID="txtLine1"
                runat="server"></asp:TextBox></td>
        <td>
            <asp:Label ID="lblLine2" runat="server"
                Text="Line2"></asp:Label></td>
        <td>
            <asp:TextBox ID="txtLine2"
                runat="server"></asp:TextBox></td>
        <td>
            <asp:Label ID="lblTownCity" runat="server"
                Text="TownCity"></asp:Label></td>
        <td>
            <asp:TextBox ID="txtTownCity"
                runat="server"></asp:TextBox></td>
        <td>
            <asp:Label ID="lblStateOrProvince" runat="server"
                Text="StateOrProvince"></asp:Label></td>
        <td>
            <asp:TextBox ID="txtStateOrProvince"
                runat="server"></asp:TextBox></td>
        <td>
            <asp:Label ID="lblPostCod" runat="server"
                Text="PostCod"></asp:Label></td>
        <td>
            <asp:TextBox ID="txtPostCod"
                runat="server"></asp:TextBox></td>
        <td>
            <asp:Label ID="lblCountryCode" runat="server" Visible="false" Text="Country" />
        </td>
        <td>
            <asp:DropDownList ID="ddlCountries" runat="server" DataTextField="Name" DataValueField="CountryCode"></asp:DropDownList>
        </td>
    </tr>
    <%--<tr>
        <td>
            <asp:Label ID="label2" runat="server"
                Text="Last Name"></asp:Label></td>
        <td>
            <asp:TextBox ID="txtLastName"
                runat="server"></asp:TextBox></td>
    </tr>--%>
    <%--<tr>
        <td>
            <asp:Label ID="lblCountryCode" runat="server" Visible="false" />
        </td>
        <td>
            <asp:DropDownList ID="ddlCountries" runat="server" DataTextField="Name" DataValueField="CountryCode"></asp:DropDownList>
        </td>

    </tr>--%>
    <%--<tr>
        <td><asp:Button ID="btnPost"  runat="server"
            Text="Send Info" OnClick="btnPost_Click" />
        </td>
    </tr>--%>
</table>
