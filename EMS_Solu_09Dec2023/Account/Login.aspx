<%@ Page Title="" Language="C#" MasterPageFile="~/AppLayout/_Layout.Master"
    AutoEventWireup="true" CodeBehind="Login.aspx.cs"
    Inherits="EMS_Solu_09Dec2023.Account.Login"
    %>
 <%-- ErrorPage="~/ErrorPages/Error.aspx"--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPage" runat="server">
     <div class="row">
        <div class="col-md-4 offset-3">
            <table class="table">
                <tr>
                    <th>UserId</th>
                    <td>
                        <asp:TextBox  ID="txtuserId" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>Password</th>
                    <td>
                        <asp:TextBox ID="txtPswd" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>Remember Me</th>
                    <td>
                        <asp:CheckBox runat="server" ID="rdbRemember" />
                    </td>
                </tr>
                <tr>
                   <td colspan="2">
                        <asp:Button runat="server" ID="btnSubmit" Text="Login"
                        OnClick="btnSubmit_Click"/>
                   </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
