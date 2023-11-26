using SCart.Data;
using SCart.Method;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Caching;
using System.Web.Services.Protocols;
using static SCart.Method.Common;

namespace SCart
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ShoppingService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ShoppingService.svc or ShoppingService.svc.cs at the Solution Explorer and start debugging.
    public class ShoppingService : IShoppingService
    {
        SCartEntities db;
        public void DoWork()
        {
        }

        #region CoutryList
        public checkCategorylist GetCategoryList()
        {
            checkCategorylist ObjCheck = new checkCategorylist();
            try
            {
                Common objc = new Common();
                DataTable dt = new DataTable();
                Categorylist objcl = new Categorylist();
                dt = objc.BindCategory();


                if (dt != null)
                {

                    var lstmployee = new List<Categorylist>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Categorylist objE = new Categorylist();

                        objE.CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]);
                        objE.CategoryName = dt.Rows[i]["CategoryName"].ToString();
                        lstmployee.Add(objE);
                    }

                    ObjCheck.Data = lstmployee;
                    ObjCheck.status = true;
                    ObjCheck.message = "Success";
                }
                else
                {
                    ObjCheck.Data = null;
                    ObjCheck.status = false;
                    ObjCheck.message = "Failure";
                }

            }
            catch (Exception ex)
            {

                ObjCheck.Data = null;
                ObjCheck.status = false;
                ObjCheck.message = ex.Message;


            }

            return ObjCheck;
        }

        #endregion

        #region Add Category


        //public checkCategoryinsert AddCategory(int CategoryId, string CategoryName, string Detail, string CategoryImage)
        //{

        //    checkCategoryinsert objCheck = new checkCategoryinsert();
        //    try
        //    {
        //        int Result = 0;
        //        Common objc = new Common();
        //        Result = objc.InsertCategory(CategoryName, Detail, CategoryImage);

        //        if (Result > 0)
        //        {
        //            objCheck.CategoryId = Result;
        //            objCheck.status = true;
        //            objCheck.message = "Success";
        //        }
        //        else
        //        {

        //            objCheck.CategoryId = CategoryId;
        //            objCheck.status = false;
        //            objCheck.message = "Fail";

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        objCheck.CategoryId = 0;

        //        objCheck.status = false;
        //        objCheck.message = ex.Message;
        //    }
        //    return objCheck;
        //}

        public checkCategoryinsert AddCategory(int CategoryId,string CategoryName, string Details, string CategoryImage)
        {
            checkCategoryinsert objCheck = new checkCategoryinsert();

            try
            {

                int Result = 0;
                Common objc = new Common();
                Result = objc.InsertCategory(CategoryName,Details,CategoryImage);

                if(Result>0)
                {
                    objCheck.CategoryId = Result;
                    objCheck.status = true;
                    objCheck.message = "success";

                }
                else
                {
                    objCheck.CategoryId = CategoryId;
                    objCheck.status = false;
                    objCheck.message= "error";

                }


            }
            catch (Exception ex) 
            {

                objCheck.CategoryId =0;
                objCheck.status = false;
                objCheck.message = ex.Message;
            
            }
            return objCheck;
        }


        #endregion




        #region sub CoutryList
        public checkSubCategorylist GetSubCategorylist()
        {
            checkSubCategorylist ObjCheck = new checkSubCategorylist();
            try
            {
                Common objc = new Common();
                DataTable dt = new DataTable();
                Categorylist objcl = new Categorylist();
                dt = objc.subCategory();


                if (dt != null)
                {

                    var lstmployee = new List<SubCategorylist>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        SubCategorylist objE = new SubCategorylist();

                        objE.SubCategoryId = Convert.ToInt32(dt.Rows[i]["SubCategoryId"]);
                        objE.SubCategoryName = dt.Rows[i]["SubCategoryName"].ToString();
                        lstmployee.Add(objE);
                    }

                    ObjCheck.Data = lstmployee;
                    ObjCheck.status = true;
                    ObjCheck.message = "Success";
                }
                else
                {
                    ObjCheck.Data = null;
                    ObjCheck.status = false;
                    ObjCheck.message = "Failure";
                }

            }
            catch (Exception ex)
            {

                ObjCheck.Data = null;
                ObjCheck.status = false;
                ObjCheck.message = ex.Message;


            }

            return ObjCheck;
        }

        #endregion
        #region productList
        public checkProductlist GridViewProduct()
        {
            checkProductlist ObjCheck = new checkProductlist();
            try
            {
                Common objc = new Common();
                DataTable dt = new DataTable();

                dt = objc.GridViewProduct();


                if (dt != null)
                {

                    var lstProduct = new List<Productlist>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Productlist objpl = new Productlist();

                        objpl.ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]);
                        objpl.ProductName = dt.Rows[i]["ProductName"].ToString();
                        objpl.ProductPrice = Convert.ToDecimal(dt.Rows[i]["ProductPrice"]);
                        lstProduct.Add(objpl);
                    }

                    ObjCheck.Data = lstProduct;
                    ObjCheck.status = true;
                    ObjCheck.message = "Success";
                }
                else
                {
                    ObjCheck.Data = null;
                    ObjCheck.status = false;
                    ObjCheck.message = "Failure";
                }

            }
            catch (Exception ex)
            {

                ObjCheck.Data = null;
                ObjCheck.status = false;
                ObjCheck.message = ex.Message;


            }

            return ObjCheck;
        }
        #endregion

        #region productList
        public checkProductlist GetProductByModel()
        {
            checkProductlist ObjCheck = new checkProductlist();
            List<Categorylist> list = new List<Categorylist>();

            Categorylist objC = null;
            db = new SCartEntities();


            try
            {

                var res = (from C in db.CategoryMasters
                           orderby C.CategoryId ascending
                           where C.IsActive == true
                           select C).ToList();






            }
            catch (Exception ex)
            {

                ObjCheck.Data = null;
                ObjCheck.status = false;
                ObjCheck.message = ex.Message;


            }

            return ObjCheck;
        }

   

        #endregion
    }
}

