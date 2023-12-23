<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="EMS_Solu_09Dec2023.Employee.EditEmployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../StaticFiles/css/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="container-fluid">
            <div class="row">
                <asp:HiddenField runat="server" ID="hdfEmpId" />
                <div class="col-6 offset-3">
                    <table class="table">
                        <tr>
                            <th>Upload Profile Image</th>
                            <td>
                                <asp:FileUpload runat="server" ID="ProfileImage"
                                    CssClass="form-control" />
                            </td>
                        </tr>

                        <tr>
                            <th>Employee Full Name</th>
                            <td>
                                <%-- TextMode="MultiLine"
                                    Rows="3"
                                    Columns="50"--%>
                                <asp:TextBox
                                    runat="server" ID="txtFullName"
                                    CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="txtFullName"
                                    ErrorMessage="Please enter name."
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator runat="server"
                                    ControlToValidate="txtFullName"
                                    ErrorMessage="Only alphabets are allowed"
                                    ForeColor="Red"
                                    ValidationExpression="[a-zA-Z\s]*"
                                    Display="Dynamic">
                                </asp:RegularExpressionValidator>
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
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="rdbGender"
                                    ErrorMessage="Please select gender."
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <th>Email Address</th>
                            <td>
                                <asp:TextBox runat="server" ID="txtemail" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="txtemail"
                                    ErrorMessage="Please enter email."
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                <%--  <asp:RegularExpressionValidator runat="server"
                                    ControlToValidate="txtemail"
                                    ErrorMessage="Please enter valid email."
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ValidationExpression="[a-zA-Z0-1]*[@]{1}[a-zA-Z]*[.]{1}[a-zA-Z]{2,3}">
                                </asp:RegularExpressionValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <th>Contact No.</th>
                            <td>
                                <asp:TextBox runat="server" ID="txtContact" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="txtContact"
                                    ErrorMessage="Please enter contact number."
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator runat="server"
                                    ControlToValidate="txtContact"
                                    ErrorMessage="Please enter valid contact number."
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ValidationExpression="[6-9]{1}[0-9]{9}">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th>Date Of Joining</th>
                            <td>
                                <asp:TextBox runat="server" ID="txtDoj" TextMode="Date" CssClass="form-control"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <th>Department</th>
                            <td>
                                <asp:DropDownList runat="server" ID="ddlDepartment"
                                    DataValueField="DepartmentId" DataTextField="DepartmentName"
                                    CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="ddlDepartment"
                                    ErrorMessage="Please select department."
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    InitialValue="-1">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <th>Salary</th>
                            <td>
                                <asp:TextBox runat="server" ID="txtSalary" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="txtSalary"
                                    ErrorMessage="Please enter salary."
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                <asp:RangeValidator runat="server"
                                    ControlToValidate="txtSalary"
                                    ErrorMessage="Please enter salary between 10000 and 500000."
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    Type="Integer"
                                    MinimumValue="10000"
                                    MaximumValue="500000">
                                </asp:RangeValidator>
                            </td>
                        </tr>

                        <tr>
                            <th>Salary Account</th>
                            <td>
                                <asp:TextBox runat="server" ID="txtSalaryAccNo" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="txtSalaryAccNo"
                                    ErrorMessage="Please enter salary Account No."
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <th>Confirm Account</th>
                            <td>
                                <asp:TextBox runat="server" ID="txtSalaryReAccNo"
                                    TextMode="Password" CssClass="form-control"></asp:TextBox>
                                 <asp:RequiredFieldValidator runat="server"
                                    ControlToValidate="txtSalaryReAccNo"
                                    ErrorMessage="Please enter salary Account No."
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                 <asp:CompareValidator runat="server"
                                    ControlToValidate="txtSalaryReAccNo"
                                     ControlToCompare="txtSalaryAccNo"
                                    ErrorMessage="Account No. not matches"
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:CompareValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <asp:Button runat="server" ID="btnSubmit" 
                                    Text="Save"
                                    OnClick="btnSubmit_Click"
                                    CssClass="btn btn-primary" />
                            </td>
                            <td>
                                <asp:Button runat="server" ID="btnReset" Text="Re-Set"
                                   
                                    CssClass="btn btn-danger"
                                    CausesValidation="false"/>
                            </td>
                        </tr>

                    </table>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
