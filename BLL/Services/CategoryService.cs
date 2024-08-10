using AutoMapper;
using BLL.DTO;
using DAL.Database.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService
    {
        //var config = new MapperConfiguration(cfg => { cfg.CreateMap<Source, Destination>(); });
        //mapper.Map<Destination>(Data);

        #region Get All Categories
        public static List<CategoryDTO> getAll()
        {
            var data =  CategoryRepo.getAll();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDTO>();
            });

            var mapper = new Mapper(config);
            var converted = mapper.Map<List<CategoryDTO>>(data);

            return converted;
        }
        #endregion region Get All Categories

        #region Get Single Category
        public static CategoryDTO Get_Single_Category(int id)
        {
            var data = CategoryRepo.getAll();

            var config = new MapperConfiguration(cfg =>{cfg.CreateMap<Category, CategoryDTO>();});
            var mapper = new Mapper(config);
            var converted = mapper.Map<List<CategoryDTO>>(data);

            var category = converted.FirstOrDefault(c => c.Category_ID.Equals(id));

            return category;
        }
        #endregion Get Single Category

        #region Create a Category
        public static bool Create_Category(CategoryDTO cat)
        {

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CategoryDTO, Category>(); });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Category>(cat);

            var decision = CategoryRepo.Create_Category(converted);

            if (decision)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }
        #endregion Create a Category

        #region Update a Category
        public static bool Update_Category(CategoryDTO cat)
        {

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CategoryDTO, Category>(); });
            var mapper = new Mapper(config);
            var converted = mapper.Map<Category>(cat);

            var decision = CategoryRepo.Update_Category(converted);

            if (decision)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion Update a Category

        #region Delete a Category
        public static bool Delete_Category(int id)
        {
            // Here i have used Ternary If-Else. Do Not use if you don't know it
            return CategoryRepo.Delete_Category(id) ? true : false;
        }
        #endregion Delete a Category
    }
}
