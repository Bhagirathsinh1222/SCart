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
    
    public partial class SubCategory : System.Web.UI.Page
    {

        Common objc = new Common();
        string str = string.Empty;
        private int SubCategoryID;
        SCartEntities db;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoryBind();
                //GridSSubCategory();
                GridSubCategorybyEntity();
                Edit();
            }
        }
        public void CategoryBind()
        {
            DataTable dt = new DataTable();
            dt = objc.BindCategory();
            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();


        }
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            AddPanel.Visible = true;
            ListPanel.Visible = false;
        }
        public void InsertSubCategory()
        {
            Common objc = new Common();
            int Result = 0;
            Result = objc.AddSubCategory(Convert.ToInt32(EditSubCategoryID), Convert.ToInt32(ddlCategory.SelectedItem.Value), txtSubCategory.Text, txtDetails.Text);


        }
        public void GridSSubCategory()
        {
            Common objc = new Common();
            DataTable dt = new DataTable();
            dt = objc.GridSUbC();

            GridSubCategory.DataSource = dt;
            GridSubCategory.DataBind();


        }

        public void GridSubCategorybyEntity()
        {
            db = new SCartEntities();

            var res = (from SC in db.SubCategoryMasters join C in db.CategoryMasters on SC.CategoryId equals C.CategoryId where SC.IsActive==true select new { SC.SubCategoryName, C.CategoryName,SC.Datails,SC.SubCategoryId }).ToList();

            GridSubCategory.DataSource= res;
            GridSubCategory.DataBind() ;

        } 

        private long EditSubCategoryID
        {
            get
            {
                if (ViewState["SubCategoryid"] != null)
                {
                    return (long)ViewState["SubCategoryid"];

                }
                return 0;
            }
            set
            {
                ViewState["SubCategoryid"] = value;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            InsertSubCategory();
        }

        protected void GridSubCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Common objc = new Common();
            int SubCategoryid = 0;

            SubCategoryid = Convert.ToInt32(e.CommandArgument);
          
            if (e.CommandName == "EmployeeDelete")
            {
                //int Result = 0;

                //Result = objc.DeleteSubcategory(SubCategoryID);
                db = new SCartEntities();
                SubCategory objS= new SubCategory();

                var rej=(from SS in db.SubCategoryMasters 
                         where SS.SubCategoryId==SubCategoryid
                         select SS).FirstOrDefault();

                rej.IsActive = false;
                db.SaveChanges();

                GridSubCategorybyEntity();

                 
            }
            if(e.CommandName == "EmployeeEdit")
            {
                //EditSubCategoryID = SubCategoryid;
                //AddPanel.Visible = true;
                //ListPanel.Visible = false;

                //DataTable dt = objc.GetSelectSubCategory(SubCategoryID);

                //if(dt !=null && dt.Rows.Count>0 )
                //{
                //    txtSubCategory.Text = dt.Rows[0]["SubCategoryName"].ToString();
                //    txtDetails.Text = dt.Rows[0]["Datails"].ToString();

                //}

                AddPanel.Visible = false;
                ListPanel.Visible = false;
                
                
            }
            
        }
        public void Edit()
        {

            int SubCategoryID = 0;

           

            var rej = (from SC in db.SubCategoryMasters
                       where SC.SubCategoryId == 9
                       select new
                       {
                           SC
            .SubCategoryName
                       }).FirstOrDefault();

            if (rej != null)
            {

                txtSubCategory.Text = rej.SubCategoryName;
            }

        }
    }
}