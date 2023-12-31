using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace EMS_Solu_09Dec2023.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    HttpCookie cookie = Request.Cookies["LoginInfo"];
            //    if (cookie != null)
            //    {
            //        string UserId = cookie["userid"].ToString();
            //        string Password = cookie["password"].ToString();
            //        if (ValidateUser(UserId, Password))
            //        {
            //            FormsAuthentication.SetAuthCookie(UserId, false);
            //            Response.Redirect("~/Employee/EmployeeList.aspx");
            //        }
            //    }
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           // throw new Exception("There is some problem");
            try
            {
                if (ValidateUser(txtuserId.Text, txtPswd.Text, out DataTable dt))
                {
                    if (rdbRemember.Checked)
                    {
                        HttpCookie cookie = new HttpCookie("LoginInfo");
                        cookie["userid"] = txtuserId.Text;
                        cookie["password"] = txtPswd.Text;

                        cookie.Expires = DateTime.Now.AddDays(10);
                        Response.Cookies.Add(cookie);
                    }
                    Session["UserDetails"] = dt;
                    //throw new Exception("There is some problem");

                    //FormsAuthentication.RedirectFromLoginPage(txtuserId.Text, false);

                    //FormsAuthentication.SetAuthCookie(txtuserId.Text, false);

                    FormsAuthenticationTicket ticket =
                        new FormsAuthenticationTicket(1, txtuserId.Text, DateTime.Now,
                        DateTime.Now.AddMinutes(30), false, "");

                    string SecureTicket = FormsAuthentication.Encrypt(ticket);

                    HttpCookie AuthCookie = new HttpCookie(FormsAuthentication.FormsCookieName, SecureTicket);

                    Response.Cookies.Add(AuthCookie);
                   
                    Response.Redirect("~/Employee/AddnewEmployee.aspx");

                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(),
                     "S001", "toastr['error']('incorrect userid or password,', 'Error')", true);
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(),
            "S001", "toastr['error']('"+ex.Message+"', 'Error')", true);
               
            }
        }

        private bool ValidateUser(string UseId, string Password,out DataTable dtUser)
        {
            using (SqlConnection con =
                new SqlConnection(ConfigurationManager.
                ConnectionStrings["DBCom"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetUserDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", UseId);
                cmd.Parameters.AddWithValue("@Password", Password);

                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                dtUser = dt;
                if(dt != null)
                {
                    if (dt.Rows.Count > 0)
                        return true;
                }
            }
            //if (UseId == "admin" && Password == "123456")
            //{
            //    return true;
            //}
            return false;
        }
    }
}