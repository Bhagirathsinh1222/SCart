using SCart.Data;
using SCart.Method;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;


namespace SCart
{
    public partial class Product : System.Web.UI.Page
    {
        SCartEntities db;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoryBind();
                SubCategoryBind();
                ProductGridView();

            }
        }

        public void CategoryBind()
        {
            Common objc = new Common();
            DataTable dt = new DataTable();
            dt = objc.BindCategory();

            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();

        }
        public void SubCategoryBind()
        {

            Common objc = new Common();
            DataTable dt = new DataTable();
            dt = objc.BindsubCategory(Convert.ToInt32(ddlCategory.SelectedValue));

            if (dt != null && dt.Rows.Count > 0)
            {
                ddlsubcategory.DataSource = dt;
                ddlsubcategory.DataTextField = "SubCategoryName";
                ddlsubcategory.DataValueField = "SubCategoryId";

                ddlsubcategory.DataBind();
                ddlsubcategory.Items.Insert(0, new ListItem("----Select SubCategory----", "0"));



            }
            else
            {
                ddlsubcategory.DataSource = null;
                ddlsubcategory.DataBind();
                ddlsubcategory.Items.Clear();
                ddlsubcategory.Items.Insert(0, new ListItem("------Select SubCategory---", "0"));
            }

        }
        public void ProductGridView()
        {
            Common objc = new Common();
            DataTable dt = new DataTable();
            DataTable dr = new DataTable();

            dt = objc.GridViewProduct();

            GridProduct.DataSource = dt;
            GridProduct.DataBind();

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            AddPanel.Visible = true;
            ListPanel.Visible = false;

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            UploadImage();
        }
        public void UploadImage()
        {
            try
            {
                string filename = "", newfile = "";
                string[] validFileTypes = { "jpeg", "png", "jpg", "bmp", "gif" };

                if (!FileUploadImage.HasFile)
                {
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select a file.');", true);
                    FileUploadImage.Focus();
                }


                string ext = System.IO.Path.GetExtension(FileUploadImage.PostedFile.FileName).ToLower();
                bool isValidFile = false;
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isValidFile = true;
                        break;
                    }
                }
                if (isValidFile == true)
                {

                    if (FileUploadImage.HasFile)
                    {

                        filename = Server.MapPath(FileUploadImage.FileName);
                        newfile = FileUploadImage.PostedFile.FileName;

                        FileInfo fi = new FileInfo(newfile);

                        // check folder exist or not
                        if (!System.IO.Directory.Exists(@"~\ProductPhoto"))
                        {
                            try
                            {

                                string Imgname = txtProductName.Text;

                                string path = Server.MapPath(@"~\ProductPhoto\");

                                System.IO.Directory.CreateDirectory(path);
                                FileUploadImage.SaveAs(path + @"\" + txtProductName.Text + ext);

                                ImageProfileImage.ImageUrl = @"~\ProductPhoto\" + txtProductName.Text + ext;
                                ImageProfileImage.Visible = true;

                                lblFilePath.Text = Imgname + ext;


                            }
                            catch (Exception ex)
                            {
                                lblFilePath.Text = "Not able to create new directory";
                            }

                        }
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(GetType(), "ShowAlert", "alert('Please select valid file.');", true);
                }
            }
            catch (Exception ex)
            {

            }

        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            int result = 0;
            Common objc = new Common();
            result = objc.addProduct(Convert.ToInt32(ProductID), Convert.ToInt32(ddlCategory.SelectedItem.Value), Convert.ToInt32(ddlsubcategory.SelectedItem.Value), txttitle.Text, txtProductName.Text, Convert.ToDecimal(txtProductPrice.Text), Convert.ToInt32(txtQuantity.Text), lblFilePath.Text, txtShortDiscription.Text, txtLongDiscription.Text);


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

        protected void GridProduct_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Common objc = new Common();
            int ProductID = 0;


            ProductID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "ProductDelete")
            {
                //int Result = 0;

                //Result=objc.DeleteProduct(ProductId);
                //ProductGridView();
                db = new SCartEntities();
                ProductMaster Objp = new ProductMaster();

                var res1 = (from PM in db.ProductMasters
                            where PM.ProductId == ProductID

                            select PM).FirstOrDefault();
                
                    res1.IsActive = false;
               
                db.SaveChanges();

                ProductGridView();



            }
 

            //if (e.CommandName == "ProductEdit")
            //{
            //    ProductID = ProductId;
            //    AddPanel.Visible = true;
            //    ListPanel.Visible = false;
            //    DataTable dt = objc.GetSelectProduct(ProductId.ToString());

            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        txtProductName.Text = dt.Rows[0]["ProductName"].ToString();
            //        txtProductPrice.Text = dt.Rows[0]["ProductPrice"].ToString();

            //    }
            //}


        }


        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubCategoryBind();
        }

    }

    
}
