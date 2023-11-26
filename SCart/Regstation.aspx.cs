using SCart.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SCart
{
    public partial class Regstation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void Registration()
        {
            Common objc = new Common();
            int Result = 0;
            Result = objc.LoginAndUser(txtFullName.Text,txtEmail.Text,txtPassword.Text);
             
        }

        

        

        protected void btnreg_Click1(object sender, EventArgs e)
        {
            Registration();
        }
    }
}