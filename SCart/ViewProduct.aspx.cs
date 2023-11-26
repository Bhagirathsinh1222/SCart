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
    public partial class ViewProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblProductId.Text = Request.QueryString["ProductID"];
            Bindproduct();
        }

        public void Bindproduct()
        {
            Common objc= new Common();  
            DataTable dt = new DataTable();
            dt = objc.Getproduct(Convert.ToInt32(lblProductId.Text));

            ImageProduct.ImageUrl = "~/ProductPhoto/" + dt.Rows[0]["ProductImage"].ToString();
            lblProductName.Text= dt.Rows[0]["ProductName"].ToString();
            lblSD.Text = dt.Rows[0]["ShortDiscription"].ToString();
            lblPrice.Text= dt.Rows[0]["ProductPrice"].ToString();
            lblQuantity.Text= dt.Rows[0]["ProductQuentity"].ToString();
            lblLD.Text= dt.Rows[0]["LongDiscription"].ToString();


        }
    }
}