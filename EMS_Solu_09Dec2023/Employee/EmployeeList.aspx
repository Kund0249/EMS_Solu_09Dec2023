<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="EmployeeList.aspx.cs"
    Inherits="EMS_Solu_09Dec2023.Employee.EmployeeList"
    MasterPageFile="~/AppLayout/_Layout.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContenHead">
    <style>
        .ProfileImage {
            height: 100px;
            width: 100px;
            border-radius: 50px;
        }
    </style>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="ContentPage">
    <div class="row">
        <div class="">
            <asp:GridView runat="server" ID="EmployeeGrid"
                AutoGenerateColumns="false"
                CssClass="table"
                DataKeyNames="EmployeeId"
                OnRowDeleting="EmployeeGrid_RowDeleting">
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
                    <asp:TemplateField HeaderText="Profile Photo">
                        <ItemTemplate>
                            <asp:Image runat="server"
                                AlternateText="Image not available"
                                CssClass="ProfileImage"
                                ImageUrl='<%# Eval("ProfileImage") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:CommandField HeaderText="Action" 
                                ShowDeleteButton="true"
                                ButtonType="Button"
                                ControlStyle-CssClass="btn btn-sm btn-danger"/>--%>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="btn-group btn-group-sm">
                                <asp:HyperLink runat="server"
                                    Text="Edit"
                                    CssClass="btn btn-sm btn-primary"
                                    NavigateUrl='<%# string.Format("~/Employee/EditEmployee.aspx?id={0}",Eval("EmployeeId")) %>'>
                                </asp:HyperLink>
                                <%-- <asp:Button runat="server"
                                            CommandName="select"
                                            Text="Edit"
                                            CssClass="btn btn-sm btn-primary" />--%>
                                <asp:Button runat="server"
                                    CommandName="delete"
                                    Text="Remove"
                                    CssClass="btn btn-sm btn-danger" />

                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

