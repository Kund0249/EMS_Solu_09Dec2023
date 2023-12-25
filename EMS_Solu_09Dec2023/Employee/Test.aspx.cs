using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EMS_Solu_09Dec2023.Employee
{
    public partial class Test : System.Web.UI.Page
    {
        int C = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtCounter.Text = C.ToString();
            }
        }

        protected void btnIncrement_Click(object sender, EventArgs e)
        {
            //if((string.IsNullOrEmpty(hiddenValue.Value) || string.IsNullOrWhiteSpace(hiddenValue.Value)))
            //{
            //    C = C + 1;
            //    hiddenValue.Value = C.ToString();
            //}
            //else
            //{
            //    C = Convert.ToInt32(hiddenValue.Value) + 1;
            //    hiddenValue.Value = C.ToString();
            //}

            if (ViewState["CounterValue"] == null)
            {
                C = C + 1;
                ViewState["CounterValue"] = C.ToString();
            }
            else
            {
                C = Convert.ToInt32(ViewState["CounterValue"]) + 1;
                ViewState["CounterValue"] = C.ToString();
            }

            txtCounter.Text = C.ToString();
        }
    }
}