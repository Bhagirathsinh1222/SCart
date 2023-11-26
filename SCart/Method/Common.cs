using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using static SCart.Method.Common;

namespace SCart.Method
{
    public class Common
    {
        private string CategoryID;

        public DataTable GridviewC()
        {
            General objg = new General();
            DataTable dt = new DataTable();
            string str = string.Empty;

            str = "select * from CategoryMaster where IsActive=1";

            dt = objg.GetDatasetByCommand(str);

            return dt;


        }
        
        public DataTable BindCategory()
        {
            General objg = new General();
            DataTable dt = new DataTable();
            string str = string.Empty;
            str = "Select * From CategoryMaster";
            dt = objg.GetDatasetByCommand(str);
            return dt;


        }



        public DataTable BindsubCategory(int CategoryId)
        {
            General objg = new General();
            DataTable dt = new DataTable();
            string str = string.Empty;
            str = " Select * From  SubCategoryMaster Where CategoryId= '" + CategoryId + "'";
            dt = objg.GetDatasetByCommand(str);
            return dt;

        } 
        public DataTable subCategory()
        {
            General objg = new General();
            DataTable dt = new DataTable();
            string str = string.Empty;
            str = " Select * From  SubCategoryMaster";
            dt = objg.GetDatasetByCommand(str);
            return dt;

        }

        public int addProduct(int ProductId, int CategoryId, int SubCategoryId, string ProductTitle, string ProductName, decimal ProductPrice, int ProductQuentity, string ProductImage, string ShortDiscription, string LongDiscription)
        {
            int Result = 0;
            General objg = new General();
            string str = string.Empty;

            if (ProductId == 0)
            {
                str = "insert into ProductMaster ( [CategoryId], [SubCategoryId], [ProductTitle], [ProductName], [ProductPrice], [ProductQuentity], [ProductImage], [ShortDiscription], [LongDiscription], [IsActive]) Values('" + CategoryId + "','" + SubCategoryId + "','" + ProductTitle + "','" + ProductName + "','" + ProductPrice + "','" + ProductQuentity + "','" + ProductImage + "','" + ShortDiscription + "','" + LongDiscription + "',1) ";
            }
            if (ProductId > 0)
            {
                str = "Update ProductMaster set ProductName = '" + ProductName + "',ProductPrice = '" + ProductPrice + "', ProductQuentity = '" + ProductQuentity + "', ProductImage = '" + ProductImage + "', ShortDiscription = '" + ShortDiscription + "', LongDiscription = '" + LongDiscription + "' where ProductId = '" + ProductId + "'";

            }

            Result = objg.GetExecuteNonQueryByCommand(str);
            return Result;

        }
        public DataTable Login(string UserName, string Password)
        {
            General objg = new General();
            DataTable dt = new DataTable();
            string str = string.Empty;

            str = "select * from LoginMaster where UserName='" + UserName + "' and Password='" + Password + "'";

            dt = objg.GetDatasetByCommand(str);
            return dt;

        }

        public DataTable GridViewProduct()
        {
            General objg = new General();
            DataTable dt = new DataTable();
            string str = string.Empty;

            str = "select * from ProductMaster  inner join CategoryMaster on ProductMaster.CategoryId=CategoryMaster.CategoryId inner join SubCategoryMaster on SubCategoryMaster.SubCategoryId=ProductMaster.SubCategoryId where ProductMaster.IsActive=1";

            dt = objg.GetDatasetByCommand(str);

            return dt;

        }

        public int DeleteProduct(int ProductId)
        {
            General objG = new General();
            int IsResult = 0;
            string str = string.Empty;

            str = "Update ProductMaster set IsActive=0 where ProductId='" + ProductId + "'";
            IsResult = objG.GetExecuteNonQueryByCommand(str);
            return IsResult;



        }

        public int DeleteCategory(int CategoryId)
        {
            General objG = new General();
            int IsResult = 0;
            string str = string.Empty;

            str = "Update CategoryMaster set IsActive=0 where CategoryId='" + CategoryId + "'";
            IsResult = objG.GetExecuteNonQueryByCommand(str);
            return IsResult;
        }

        public int DeleteSubcategory(int SubcategoryId)
        {
            General objG = new General();
            int IsResult = 0;
            string str = string.Empty;
            str = "Update SubCategoryMaster Set IsActive=0 Where SubCategoryId='" + SubcategoryId + "'";
            IsResult = objG.GetExecuteNonQueryByCommand(str);
            return IsResult;



        }

        public DataTable GetSelectProduct(string productid)
        {
            string str = string.Empty;
            str = "Select * from ProductMaster where ProductId='" + productid + "'";
            General objg = new General();
            DataTable dt = objg.GetDatasetByCommand(str);
            return dt;
        }

        public int LoginAndUser(String FullName, String Email, string Password)
        {
            int Result = 0;
            General objg = new General();
            string str = string.Empty;
            str = "exec UserMaster @FullName='" + FullName + "' ,@Email='" + Email + "',@Password ='" + Password + "'";

            Result = objg.GetExecuteNonQueryByCommand(str);
            return Result;
        }
        public int AddCategory(int CategoryId, string CategoryName, string Details, string CategoryImage)
        {
            int Result = 0;
            General objg = new General();
            string str = string.Empty;

            if (CategoryId == 0)
            {
                str = "insert into CategoryMaster( [CategoryName], [Details], [CategoryImage], [IsActive]) values('" + CategoryName + "','" + Details + "','" + CategoryImage + "',1)";
            }
            if (CategoryId > 0)
            {
                str = "Update CategoryMaster set [CategoryName] = '" + CategoryName + "', [Details] = '" + Details + "' where CategoryId = '"+ CategoryId +"'";
            }

            Result = objg.GetExecuteNonQueryByCommand(str);

            return Result;
        }

        public DataTable GetSelectedCategory(int CategoryId)
        {
            General gen = new General();
            string str = string.Empty;

            str = "Select * from CategoryMaster where CategoryId = '" + CategoryId + "'";

            DataTable dt = gen.GetDatasetByCommand(str);

            return dt;
        }

        public DataTable GetSelectSubCategory(int SubCategoryid)
        { 
            string str = string.Empty;
            General gen = new General();
            str = "Select * From SubCategoryMaster Where SubCategoryId='" + SubCategoryid + "'";

            DataTable dt =gen.GetDatasetByCommand(str);
            return dt;
        }
        public int AddSubCategory(int SubCategoryId, int CategoryId, string SubCategoryName, string Datails)
        {
            int Result = 0;
            General objg = new General();
            string str = string.Empty;

            if (SubCategoryId == 0)
            {
                str = " insert into SubCategoryMaster  ( [CategoryId], [SubCategoryName], [Datails], [IsActive])   Values ( '" + CategoryId + "','" + SubCategoryName + "','" + Datails + "',1)";
            }

            if(SubCategoryId >0)
            {
                str = "update SubCategoryMaster set   [SubCategoryName]='" + SubCategoryName + "', [Datails]='" + Datails + "' Where SubCategoryId='" + SubCategoryId + "' ";

            }
                Result = objg.GetExecuteNonQueryByCommand(str);
            return Result;


        }
        public DataTable GridSUbC()
        {
            DataTable dt = new DataTable();
            string str = string.Empty;
            General objg = new General();

            str = "select * from SubCategoryMaster inner join CategoryMaster on SubCategoryMaster.CategoryId=CategoryMaster.CategoryId   where SubCategoryMaster.IsActive=1";

            dt = objg.GetDatasetByCommand(str);

            return dt;


        }
        public DataTable datalistProduct()
        {
            General objg = new General();
            string str = string.Empty;
            DataTable dt = new DataTable();

            str = "select * from ProductMaster where IsActive=1";

            dt = objg.GetDatasetByCommand(str);
            return dt;
        }
        public DataTable Getproduct(int ProductId)
        {
            General objg = new General();
            string str = string.Empty;
            DataTable dt = new DataTable();

            str = "select * from ProductMaster where ProductId='" + ProductId + "'";

            dt = objg.GetDatasetByCommand(str);

            return dt;


        }

        
        internal int DeleteSubcategory(object subCategoryID)
        {
            throw new NotImplementedException();
        }


        public int InsertCategory(string CategoryName, string Details, string CategoryImage)
        {
            int result = 0;
            General objg = new General();
            string str = string.Empty;
            DataTable dt = new DataTable();

            str = "insert into CategoryMaster ( [CategoryName], [Details], [CategoryImage], [IsActive])" +
                " Values ('" + CategoryName + "','" + Details + "','" + CategoryImage + "',1)";
            result = objg.GetExecuteNonQueryByCommand(str);

            return result;


        }
    }
   
    public class Categorylist
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        //public string MobileNo { get; set; }
        //public string EMailId { get; set; }
        //public string Address { get; set; }

    }



    public class checkCategoryinsert
    {
        
        public bool status { get; set; }
        public string message { get; set; }
        public int CategoryId { get; internal set; }
    }



    public class checkCategorylist
    {
        public List<Categorylist> Data { get; set; }
        public bool status { get; set; }
        public string message { get; set; }
        public int CategoryId { get; internal set; }
    }
    public class SubCategorylist
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        //public string MobileNo { get; set; }
        //public string EMailId { get; set; }
        //public string Address { get; set; }

    }
    public class checkSubCategorylist
    {
        public List<SubCategorylist> Data { get; set; }
        public bool status { get; set; }
        public string message { get; set; }

    }
    public class Productlist
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Decimal ProductPrice { get; set; }
        //public string EMailId { get; set; }
        //public string Address { get; set; }

    }
    public class checkProductlist
    {
        public List<Productlist> Data { get; set; }
        public bool status { get; set; }
        public string message { get; set; }

    }

}