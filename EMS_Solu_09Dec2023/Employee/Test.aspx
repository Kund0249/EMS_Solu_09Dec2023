<%@ Page Title="" Language="C#" MasterPageFile="~/AppLayout/_Layout.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="EMS_Solu_09Dec2023.Employee.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPage" runat="server">
    <h3>This is my content page</h3>
    <asp:HiddenField runat="server" ID="hiddenValue" />
    <asp:TextBox runat="server" ID="txtCounter"></asp:TextBox>
    <asp:Button runat="server" ID="btnIncrement" Text="Count+"
        OnClick="btnIncrement_Click"/>
</asp:Content>
