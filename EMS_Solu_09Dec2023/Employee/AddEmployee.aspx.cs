using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace EMS_Solu_09Dec2023.Employee
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        // string cs = "Data Source=.;DataBase=Assignement10112023;trusted_connection=true";
        string cs = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            cs = ConfigurationManager.ConnectionStrings["DBCom"].ConnectionString;

            if (!IsPostBack)
            {
                GetDepartment();
            }
        }

        private void GetDepartment()
        {
            SqlConnection con = new SqlConnection(cs);
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
            string ProfileImageFileName = null;
            if (ProfileImage.HasFile)
            {
                //foreach (var item in ProfileImage.PostedFiles)
                //{

                //}
                //1024 bytes = 1KB
                //long length = ProfileImage.FileContent.Length;
                //int kb = legth/1024;
                //1024 KB = 1 MB
                //int MB = KB/1024
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
            //string Skills = "";
            ////ListItemCollection items = chkSkills.Items;
            //foreach (ListItem item in chkSkills.Items)
            //{
            //    if (item.Selected)
            //        Skills += item.Text + ",";
            //}
            //Skills = Skills.Remove(Skills.LastIndexOf(','));

            //DB Code

            //Step-1 : Establish the Connection with DB
            //-> Connection String : [Data Source] + [DataBase] + [Credentials]
            SqlConnection con = new SqlConnection(cs);

            //Step-1 : Prepare Sql Command
            //string Query = string.Format("INSERT INTO TEMPLOYEE " +
            //    "Values('{0}',{1},'{2}','{3}','{4}','{5}',{6},'{7}')",
            //    fullName, Department, Gender, Mob, DOJ, email,salary, salaeyacc);
            //SqlCommand cmd = new SqlCommand(Query, con);
            //cmd.CommandType = System.Data.CommandType.Text;

            SqlCommand cmd = new SqlCommand("spAddEmployee", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter1 = new SqlParameter("@Name", fullName);
            SqlParameter parameter2 = new SqlParameter("@departmentId", Department);
            cmd.Parameters.Add(parameter1);
            cmd.Parameters.Add(parameter2);

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


            if (Rows > 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(),
              "S001", "toastr['success']('Record Inserted Successfully!', 'Sucess')", true);
                ClearFormControls();
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(),
            "S001", "toastr['error']('System not able to process this request!', 'Error')", true);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearFormControls();
        }

        private void ClearFormControls()
        {
            txtFullName.Text = string.Empty;
            txtDoj.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtSalaryAccNo.Text = string.Empty;
            txtSalaryReAccNo.Text = string.Empty;
            txtSalary.Text = string.Empty;

            rdbGender.ClearSelection();
            //chkSkills.ClearSelection();
            ddlDepartment.ClearSelection();
        }
    }
}