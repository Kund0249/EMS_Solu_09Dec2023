<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeList.aspx.cs" Inherits="EMS_Solu_09Dec2023.Employee.EmployeeList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../StaticFiles/css/bootstrap.css" rel="stylesheet" />
    <style>
        .ProfileImage{
            height :100px;
            width:100px;
            border-radius : 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-10 offset-1">
                    <asp:GridView runat="server" ID="EmployeeGrid"
                        AutoGenerateColumns="false"
                        CssClass="table">
                        <Columns>
                            <asp:BoundField HeaderText="Employee Name" DataField="Name" />
                            <asp:BoundField HeaderText="Gender" DataField="Gender" />
                            <asp:BoundField HeaderText="Employee Contact" DataField="ContactNo" />
                            <asp:BoundField HeaderText="DOJ" DataField="DOJ" />
                            <asp:BoundField HeaderText="Email" DataField="EmailAddress" />
                            <asp:BoundField HeaderText="Salary" DataField="Salary" />
                            <asp:BoundField HeaderText="Salary Acc" DataField="BankAccount" />
                            <asp:BoundField HeaderText="Department" DataField="Department" />
<%--                            <asp:BoundField HeaderText="Profile Photo" DataField="ProfileImage" />--%>
                            <asp:TemplateField  HeaderText="Profile Photo">
                                <ItemTemplate>
                                    <asp:Image runat="server" 
                                        AlternateText="Image not available"
                                        CssClass="ProfileImage"
                                        ImageUrl='<%# Eval("ProfileImage") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
