using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace EMS_Solu_09Dec2023.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               HttpCookie cookie =  Request.Cookies["LoginInfo"];
                if(cookie != null)
                {
                    string UserId = cookie["userid"].ToString();
                    string Password = cookie["password"].ToString();
                    if (ValidateUser(UserId, Password))
                    {
                        FormsAuthentication.SetAuthCookie(UserId, false);
                        Response.Redirect("~/Employee/EmployeeList.aspx");
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if(ValidateUser(txtuserId.Text,txtPswd.Text))
            {
                if (rdbRemember.Checked)
                {
                    HttpCookie cookie = new HttpCookie("LoginInfo");
                    cookie["userid"] = txtuserId.Text;
                    cookie["password"] = txtPswd.Text;

                    cookie.Expires = DateTime.Now.AddDays(10);
                    Response.Cookies.Add(cookie);
                }
                FormsAuthentication.RedirectFromLoginPage(txtuserId.Text, false);
            }
        }

        private bool ValidateUser(string UseId,string Password)
        {
            if (UseId == "admin" && Password == "123456")
            {
                return true;
            }
            return false;
        }
    }
}