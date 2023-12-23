using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace EMS_Solu_09Dec2023.Employee
{
    public partial class EditEmployee : System.Web.UI.Page
    {
        string CS = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            CS = ConfigurationManager.ConnectionStrings["DBCom"].ConnectionString;
            if (!IsPostBack)
            {

                if (Request.QueryString["id"] != null)
                {
                    if (int.TryParse(Request.QueryString["id"], out int EmpId))
                    {
                        GetDepartment();
                        GetEmployee(EmpId);
                    }
                    else
                    {
                        Response.Redirect("EmployeeList.aspx");
                    }
                }
                else
                {
                    Response.Redirect("EmployeeList.aspx");
                }
            }
        }

        private void GetEmployee(int EmpId)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployeeById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpId", EmpId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {
                        hdfEmpId.Value = table.Rows[0]["EmployeeId"].ToString();
                        txtFullName.Text = table.Rows[0]["Name"].ToString();
                        txtemail.Text = table.Rows[0]["EmailAddress"].ToString();
                        txtContact.Text = table.Rows[0]["ContactNo"].ToString();
                        txtSalary.Text = table.Rows[0]["Salary"].ToString();
                        txtSalaryAccNo.Text = table.Rows[0]["BankAccountNo"].ToString();
                        rdbGender.SelectedValue = table.Rows[0]["Gender"].ToString();
                        ddlDepartment.SelectedValue = table.Rows[0]["DepartmentId"].ToString();
                        txtDoj.Text = Convert.ToDateTime(table.Rows[0]["DOJ"]).ToString("yyyy-MM-dd");
                        //txtDoj.Text = string.Format("{0}:mm/dd/yyyy", table.Rows[0]["DOJ"].ToString());
                    }
                }
            }
        }

        private void GetDepartment()
        {
            SqlConnection con = new SqlConnection(CS);
            SqlCommand cmd = new SqlCommand("spGetAllDepartments", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            ddlDepartment.DataSource = reader;
            ddlDepartment.DataBind();
            con.Close();

            ddlDepartment.Items.Insert(0, new ListItem()
            {
                Text = "Select Department",
                Value = "-1"
            });
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Update the records;

            string ProfileImageFileName = null;
            if (ProfileImage.HasFile)
            {
                string guidId = Guid.NewGuid().ToString();
                ProfileImageFileName = guidId + "_" + ProfileImage.FileName;
                ProfileImage.SaveAs(Server.MapPath("~/ProfileImages/" + ProfileImageFileName));
            }

            string fullName = txtFullName.Text;
            string Gender = rdbGender.SelectedValue;
            string Department = ddlDepartment.SelectedValue;
            string DOJ = txtDoj.Text;
            string email = txtemail.Text;
            string Mob = txtContact.Text;
            string salaeyacc = txtSalaryAccNo.Text;
            string salary = txtSalary.Text;

            SqlConnection con = new SqlConnection(CS);

            SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter("@Name", fullName);
            SqlParameter parameter2 = new SqlParameter("@departmentId", Department);
            cmd.Parameters.Add(parameter1);
            cmd.Parameters.Add(parameter2);

            cmd.Parameters.AddWithValue("@EmpId", hdfEmpId.Value);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@ContactNo", Mob);
            cmd.Parameters.AddWithValue("@DOJ", DOJ);
            cmd.Parameters.AddWithValue("@EmailAddress", email);
            cmd.Parameters.AddWithValue("@Salary", salary);
            cmd.Parameters.AddWithValue("@BankAccount", salaeyacc);
            cmd.Parameters.AddWithValue("@ProfileImage", ProfileImageFileName);

            //Step-3 : Open the connection, Execute Command and Close the connection.
            con.Open();
            int Rows = cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("EmployeeList.aspx");
        }
    }
}