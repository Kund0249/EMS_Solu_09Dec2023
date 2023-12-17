using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace EMS_Solu_09Dec2023.Employee
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        string CS = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            CS = ConfigurationManager.ConnectionStrings["DBCom"].ConnectionString;
            if (!IsPostBack)
            {
                GetEmployees();
            }
        }

        private void GetEmployees()
        {
            using(SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    EmployeeGrid.DataSource = reader;
                    EmployeeGrid.DataBind();
                }
                con.Close();
            }
        }
    }
}