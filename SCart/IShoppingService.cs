using SCart.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace SCart
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IShoppingService" in both code and config file together.
    [ServiceContract]
    public interface IShoppingService
    {
        [OperationContract]
        void DoWork();


        #region Coutry List
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetCategoryList", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        checkCategorylist GetCategoryList();
        #endregion

        #region Coutry List
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GetSubCategorylist", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        checkSubCategorylist GetSubCategorylist();
        #endregion


        #region Product List
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "GridViewProduct", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        checkProductlist GridViewProduct();
        #endregion

        #region Add Category
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddCategory", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        checkCategoryinsert AddCategory(int CategoryId, string CategoryName, string Detail, string CategoryImage);
        #endregion
    }

}
