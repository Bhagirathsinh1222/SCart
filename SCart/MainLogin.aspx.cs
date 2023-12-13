using SCart.Method;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SCart
{
    public partial class MainLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void LoginDetail()
        {
            Common objc = new Common();
            DataTable dt = new DataTable();
            DataTable dt2= new DataTable();
            dt = objc.Login(txtEmail.Text, txtPass.Text);
            int RoleId = 0;

            if (dt != null && dt.Rows.Count > 0)

            {
                RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"]);

                if (RoleId == 1)
                {
                    Response.Redirect("Category.aspx");
                }
                else if (RoleId == 2)
                {
                    Response.Redirect("ProductList.aspx");


                }
            }
            else
            {
                lblMessage.Text = "UserName & Password Are Incoreect";

            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            LoginDetail();
        }
    }
}