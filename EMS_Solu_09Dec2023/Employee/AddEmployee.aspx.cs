using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace EMS_Solu_09Dec2023.Employee
{
    public partial class AddEmployee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string Gender = string.Empty;

            //if (rdbGenderMale.Checked)
            //    Gender = "M";
            //else if (rdbGenderFemale.Checked)
            //    Gender = "F";

            // Gender = rdbGender.SelectedValue;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
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
            string cs = "Data Source=.;DataBase=Assignement10112023;trusted_connection=true";
            SqlConnection con = new SqlConnection(cs);

            //Step-1 : Prepare Sql Command
            string Query = string.Format("INSERT INTO TEMPLOYEE " +
                "Values('{0}',{1},'{2}','{3}','{4}','{5}',{6},'{7}')",
                fullName, Department, Gender, Mob, DOJ, email,salary, salaeyacc);
            SqlCommand cmd = new SqlCommand(Query, con);

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