using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Data.Entity;
using System.Web.Http.Results;
using BLL.Services;
using BLL.DTO;

namespace The_News_Engine.Controllers
{
    public class NewsController : ApiController
    {
        #region Get All News

        [HttpGet]
        [Route("api/news/all")]
        public HttpResponseMessage Get_All_News()
        {
            try
            {
                var data = NewsService.getAll();
                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "News Table is Empty");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        #endregion Get All News

        #region Get Single Category

        [HttpGet]
        [Route("api/news/search/{id}")]
        public HttpResponseMessage Get_Single_News(int id)
        {
            var data = NewsService.Get_Single_News(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "News not Found");
            }
        }

        #endregion Get Single Category

        #region Create a Category

        [HttpPost]
        [Route("api/news/create")]
        public HttpResponseMessage Add_News(NewsDTO news)
        {

            if (news != null)
            {
                var decision = NewsService.Create_News(news);
                if (decision)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "News Created Successfully");
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

        #region Update a News

        [HttpPost]
        [Route("api/news/edit")]
        public HttpResponseMessage Update_News(NewsDTO new_news)
        {
            try
            {
                if (new_news != null)
                {
                    var decision = NewsService.Update_News(new_news);
                    if (decision)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, "News Updated Successfully");
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
            }catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #endregion Update a Category

        #region Delete a Category

        [HttpPost]
        [Route("api/news/delete/{id}")]
        public HttpResponseMessage Delete_News(int id)
        {
            if (id > 0)
            {
                var decision = NewsService.Delete_News(id);
                if (decision)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "News Deleted Successfully");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please Check Console to Find out the issue");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "You must give ID (Greater that 0) in JSON format");
            }


        }

        #endregion Delete a Category

        // Special Methods

        #region Get News by Date
        [HttpGet]
        [Route("api/news/date/{date}")]
        public HttpResponseMessage GetNewsByDate(DateTime date)
        {
            if(date != null)
            {
                try
                {
                    var data = NewsService.Get_News_by_Date(date);
                    if (data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, data);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "No Data Found");
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please Enter a Date");
            }
        }
        #endregion Get News by Date

        #region Get News by Category Name
        [HttpGet]
        [Route("api/news/category/{name}")]
        public HttpResponseMessage GetNewsByCategoryName(string name)
        {
            if (name != null)
            {
                try
                {
                    var data = NewsService.Get_News_by_Name(name);
                    if (data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, data);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "No Data Found");
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please Enter a Category Name");
            }
        }
        #endregion Get News by Category Name

        #region Get News by Date and Category Name
        [HttpGet]
        [Route("api/news/category/{cat}/date/{date}")]
        public HttpResponseMessage Get_News_by_News_Date_and_Category_Name(string cat, DateTime Date)
        {
            if (cat != null && Date != null)
            {
                try
                {
                    var data = NewsService.Get_News_by_News_Date_and_Category_Name(cat, Date);
                    if (data != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, data);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, "No Data Found");
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            else if(cat != null && Date == null)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please Enter Date");
            }
            else if(cat == null && Date != null)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please Enter Category Name");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please Check Console to get further info");
            }
        }
        #endregion Get News by Date and Category Name



    }
}
