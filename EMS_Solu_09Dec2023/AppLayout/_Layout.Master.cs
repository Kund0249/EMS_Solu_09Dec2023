using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace EMS_Solu_09Dec2023.AppLayout
{
    public partial class _Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCom"].ConnectionString)) 
                {
                    SqlCommand cmd = new SqlCommand("spGetNavURL", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    NavList.DataSource = cmd.ExecuteReader();
                    NavList.DataBind();
                    con.Close();
                }
            }
        }
    }
}