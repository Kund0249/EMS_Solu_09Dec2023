using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Security;

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


                if(Application["TotalUser"] != null)
                {
                    lblTotalUserCount.Text = Application["TotalUser"].ToString();
                }

                if(Session["UserDetails"] != null)
                {
                    DataTable dt = (DataTable)Session["UserDetails"];
                    if(dt != null)
                    {
                        if(dt.Rows.Count > 0)
                        {
                            lblMob.Text = dt.Rows[0]["ContactNo"].ToString();
                            lblEmail.Text = dt.Rows[0]["EmailAddress"].ToString();
                            lblDepartment.Text = dt.Rows[0]["DepartmentName"].ToString();
                        }
                    }
                }
                //else
                //{
                //    Session.Abandon();
                //    Session.Clear();
                //    FormsAuthentication.SignOut();
                //}
            }
        }
    }
}