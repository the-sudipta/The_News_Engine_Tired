using AutoMapper;
using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace The_News_Engine.Controllers
{
    public class CategoryController : ApiController
    {

        #region Get All Category

        [HttpGet]
        [Route("api/category/all")]
        public HttpResponseMessage Get_All_Category()
        {
            
            var data = CategoryService.getAll();
            if(data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No data available");
            }

        }

        #endregion Get All Category
        
        #region Get Single Category

        [HttpGet]
        [Route("api/category/{id}")]
        public HttpResponseMessage Get_Single_Category(int id)
        {
            var data = CategoryService.Get_Single_Category(id);
            if(data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Category not Found");
            }
        }

        #endregion Get Single Category

        #region Create a Category

        [HttpPost]
        [Route("api/category/create")]
        public HttpResponseMessage Add_Category(CategoryDTO category)
        {
           
            if(category != null)
            {
                var decision = CategoryService.Create_Category(category);
                if (decision)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Category Created Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please Check Console to Find out the issue");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "You must give data inside Body in JSON format");
            }


        }

        #endregion Create a Category

        #region Update a Category

        [HttpPost]
        [Route("api/category/edit")]
        public HttpResponseMessage Update_Category(CategoryDTO new_cat)
        {
            if (new_cat != null)
            {
                var decision = CategoryService.Update_Category(new_cat);
                if (decision)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Category Updated Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please Check Console to Find out the issue");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "You must give data inside Body (With Primary-Key) in JSON format");
            }
        }

        #endregion Update a Category

        #region Delete a Category

        [HttpPost]
        [Route("api/category/delete/{id}")]
        public HttpResponseMessage Delete_Category(int id)
        {
            if (id != null)
            {
                var decision = CategoryService.Delete_Category(id);
                if (decision)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Category Deleted Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please Check Console to Find out the issue");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "You must give ID in JSON format");
            }


        }

        #endregion Delete a Category

    }
}
