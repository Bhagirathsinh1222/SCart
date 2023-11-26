using SCart.Data;
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
    public partial class ProductList : System.Web.UI.Page
    {
        SCartEntities db;

        protected void Page_Load(object sender, EventArgs e)
        {
            //PProductList();
            productlistEntity();
        }

        public void PProductList()
        {
            Common objc = new Common();
            DataTable dt = new DataTable();

            dt = objc.datalistProduct();

            DataListProduct.DataSource = dt;
            DataListProduct.DataBind();

        }

        public void productlistEntity()
        {
            db = new SCartEntities();

            var rej = (from P in db.ProductMasters where P.IsActive == true select P ).ToList();

            DataListProduct.DataSource= rej;
            DataListProduct.DataBind();
        }

        private long ProductID
        {
            get
            {
                if (ViewState["ProductId"] != null)
                {
                    return (long)ViewState["ProductId"];
                }
                return 0;

            }
            set
            {
                ViewState["ProductId"] = value;
            }

        }


        protected void LinkViewProduct_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "ProductView")
            {
                ProductID = Convert.ToInt32(e.CommandArgument);

                Response.Redirect("ViewProduct.aspx?ProductId=" + ProductID + "");


            }
        }
    }
}