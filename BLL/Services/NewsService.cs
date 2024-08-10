using AutoMapper;
using BLL.DTO;
using DAL.Database.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NewsService
    {
        #region Get All News
        public static List<NewsDTO> getAll()
        {
            var data = NewsRepo.getAll();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<News, NewsDTO>();
            });

            var mapper = new Mapper(config);
            var converted = mapper.Map<List<NewsDTO>>(data);

            return converted;
        }
        #endregion region Get All Categories

        #region Get Single News
        public static NewsDTO Get_Single_News(int id)
        {
            var data = NewsRepo.getAll();

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<News, NewsDTO>(); });
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<NewsDTO>>(data);

            var category = converted.FirstOrDefault(c => c.News_ID.Equals(id));

            return category;
        }
        #endregion Get Single News

        #region Create a News
        public static bool Create_News(NewsDTO news)
        {

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewsDTO, News>(); });
            var mapper = new Mapper(config);
            var converted = mapper.Map<News>(news);

            var decision = NewsRepo.Create_News(converted);

            return decision? true:false;

        }
        #endregion Create a Category

        #region Update a News
        public static bool Update_News(NewsDTO new_news)
        {

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<NewsDTO, News>(); });
            var mapper = new Mapper(config);
            var converted = mapper.Map<News>(new_news);

            var decision = NewsRepo.Update_News(converted);

            return decision? true:false;

        }
        #endregion Update a News

        #region Delete a News
        public static bool Delete_News(int id)
        {
            // Here i have used Ternary If-Else. Do Not use if you don't know it
            return NewsRepo.Delete_News(id) ? true : false;
        }
        #endregion Delete a News


        #region Get News by Date
        public static List<NewsDTO> Get_News_by_Date(DateTime date)
        {
            var data = (from n in NewsRepo.getAll()
                        where n.Date == date
                        select n).ToList();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsDTO>();
             });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<NewsDTO>>(data);
            return cnvrt;
        }
        #endregion Get News by Date

        #region Get News by Category Name
        public static List<NewsDTO> Get_News_by_Name(string name)
        {
            var data = (from n in NewsRepo.getAll()
                        where n.Category.Name.ToLower().Contains(name.ToLower())
                        select n).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<NewsDTO>>(data);
            return cnvrt;
        }
        #endregion Get News by Category Name

        #region Get News by Date and Category Name
        public static List<NewsDTO> Get_News_by_News_Date_and_Category_Name(string cat, DateTime date)
        {
            var data = (from n in NewsRepo.getAll()
                        where n.Category.Name.ToLower().Contains(cat.ToLower())
                        && n.Date == date
                        select n).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<News, NewsDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<NewsDTO>>(data);
            return cnvrt;
        }
        #endregion Get News by Date and Category Name


        // 3 Special Method Needed


    }
}
