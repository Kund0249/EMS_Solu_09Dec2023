<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="AddEmployee.aspx.cs"
    Inherits="EMS_Solu_09Dec2023.Employee.AddEmployee" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <link href="../StaticFiles/css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row">
                <div class="col-6 offset-3">
                    <table class="table">
                        <tr>
                            <th>Employee Full Name</th>
                            <td>
                                <asp:TextBox 
                                    runat="server" ID="txtFullName"
                                    CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>Gender</th>
                            <td>
                                <%--  <asp:RadioButton runat="server" ID="rdbGenderMale" GroupName="Gender" />
                        Male
                       <asp:RadioButton runat="server" ID="rdbGenderFemale" GroupName="Gender"/>
                        Female--%>

                                <asp:RadioButtonList runat="server" ID="rdbGender" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="M">Male</asp:ListItem>
                                    <asp:ListItem Value="F">Female</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>

                        <tr>
                            <th>Email Address</th>
                            <td>
                                <asp:TextBox runat="server" ID="txtemail"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>Contact No.</th>
                            <td>
                                <asp:TextBox runat="server" ID="txtContact"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>Date Of Joining</th>
                            <td>
                                <asp:TextBox runat="server" ID="txtDoj" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <th>Department</th>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlDepartment">
                                    <asp:ListItem Value="-1">Select Department</asp:ListItem>
                                    <asp:ListItem Value="1">Admin</asp:ListItem>
                                    <asp:ListItem Value="2">Pay Roll</asp:ListItem>
                                    <asp:ListItem Value="3">Department Manager</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <th>Primary Skills</th>
                            <td>
                                <%-- <asp:CheckBox runat="server" ID="chkDotNet" Text=".Net Framework"/>--%>
                                <asp:CheckBoxList runat="server" ID="chkSkills"
                                    RepeatDirection="Horizontal"
                                    RepeatColumns="3">
                                    <asp:ListItem>.Net Framework</asp:ListItem>
                                    <asp:ListItem>.Net Core</asp:ListItem>
                                    <asp:ListItem>Java</asp:ListItem>
                                    <asp:ListItem>Python</asp:ListItem>
                                    <asp:ListItem>SQL Server</asp:ListItem>
                                    <asp:ListItem>Oracle</asp:ListItem>
                                </asp:CheckBoxList>
                            </td>
                        </tr>

                        <tr>
                            <th>Salary Account</th>
                            <td>
                                <asp:TextBox runat="server" ID="txtSalaryAccNo"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <th>Confirm Account</th>
                            <td>
                                <asp:TextBox runat="server" ID="txtSalaryReAccNo"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Button runat="server" ID="btnSubmit" Text="Save" OnClick="btnSubmit_Click"
                                    CssClass="btn btn-primary"/>
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnReset" Text="Re-Set"
                                    OnClick="btnReset_Click" 
                                     CssClass="btn btn-danger"/>
                            </td>
                        </tr>

                    </table>
                </div>

            </div>

        </div>
    </form>
</body>
</html>
