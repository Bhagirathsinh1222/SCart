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

namespace SCart
{
    public partial class Category : System.Web.UI.Page
    {
        SCartEntities db;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GridViewCBind();
                GridCBindByEntity();

            }
        }

        public void GridViewCBind()
        {
            Common objc = new Common();
            DataTable dt = new DataTable();

            dt = objc.GridviewC();

            GridCategory.DataSource = dt;
            GridCategory.DataBind();



        }

        public void GridCBindByEntity()
        {

            db= new SCartEntities();

            var res = (from CM in db.CategoryMasters where CM.IsActive == true select CM).ToList();

            GridCategory.DataSource=res;
            GridCategory.DataBind();


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

                                string Imgname = txtName.Text;

                                string path = Server.MapPath(@"~\ProductPhoto\");

                                System.IO.Directory.CreateDirectory(path);
                                FileUploadImage.SaveAs(path + @"\" + txtName.Text + ext);

                                ImageProfileImage.ImageUrl = @"~\ProductPhoto\" + txtName.Text + ext;
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

        public void insertCategory()
        {
            Common objc = new Common();
            int Result = 0;
            db = new SCartEntities();
            if (CategoryID1 == 0)
            {
                var rej = new CategoryMaster
                {

                    CategoryName = txtName.Text,
                    CategoryImage = lblFilePath.Text,
                    Details = txtDetails.Text,
                    IsActive = true


                };
                db.CategoryMasters.Add(rej);
                Result = db.SaveChanges();

            }
            else if(CategoryID1>0)
            {
                var rej = (from CM in db.CategoryMasters
                           where CM.CategoryId == CategoryID1
                           select CM).FirstOrDefault();
                rej.CategoryName = txtName.Text;
                rej.Details= txtDetails.Text;
                db.SaveChanges();

                GridCBindByEntity();

                Response.Redirect("Category.aspx");

            }




            //Result = objc.AddCategory(Convert.ToInt32(CategoryID),txtName.Text, txtDetails.Text, lblFilePath.Text);


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

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            insertCategory();
        }

        private long CategoryID1
        {
            get
            {
                if (ViewState["CategoryId"] != null)
                {
                    return (long)ViewState["CategoryId"];
                }
                return 0;
            }
            set
            {
                ViewState["CategoryId"] = value;
            }
        }

       

        protected void GridCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Common objc = new Common();
            int CategoryID = 0;

            CategoryID = Convert.ToInt32(e.CommandArgument);
         
            if (e.CommandName == "CategoryDelete")
            {
                //int Result = 0;

                //Result = objc.DeleteCategory(CategoryId);

                db= new SCartEntities();
                CategoryMaster objC = new CategoryMaster();

                var rej = (from CM in db.CategoryMasters
                           where CM.CategoryId == CategoryID
                           select CM).FirstOrDefault();
                rej.IsActive = false;
                db.SaveChanges();

                GridCBindByEntity();
               

                //GridViewCBind();
            }

            
            if (e.CommandName == "CategoryEdit")
            {
                db=new SCartEntities();

                CategoryID1 = CategoryID;


                //CategoryID = CategoryId;
                //AddPanel.Visible = true;
                //ListPanel.Visible = false;

                //DataTable dt = objc.GetSelectedCategory(CategoryId);

                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    txtName.Text = dt.Rows[0]["CategoryName"].ToString();
                //    txtDetails.Text = dt.Rows[0]["Details"].ToString();
                //}

                

                //this code is show deta in textbox
                AddPanel.Visible=true;
                ListPanel.Visible = false;

                var rej=(from CM in db.CategoryMasters 
                         where CM.CategoryId==CategoryID 
                         select CM).FirstOrDefault();
                 
                if(rej != null) 
                {
                    txtName.Text = rej.CategoryName;
                    txtDetails.Text=rej.Details;

                } 
                GridCBindByEntity();
                    

            }
        }
    }
}