using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

            string Skills = "";

            //ListItemCollection items = chkSkills.Items;
            foreach (ListItem item in chkSkills.Items)
            {
                if (item.Selected)
                    Skills += item.Text + ",";
            }

            Skills = Skills.Remove(Skills.LastIndexOf(','));
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtFullName.Text = string.Empty;
            txtDoj.Text = string.Empty;
            txtContact.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtSalaryAccNo.Text = string.Empty;
            txtSalaryReAccNo.Text = string.Empty;

            rdbGender.ClearSelection();
            chkSkills.ClearSelection();
            ddlDepartment.ClearSelection();
        }
    }
}