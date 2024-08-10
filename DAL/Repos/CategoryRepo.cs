using DAL.Database;
using DAL.Database.Models;
using DAL.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class CategoryRepo
    {
        #region Get All Categories
        public static List<Category> getAll()
        {
            try
            {
                var db = new DatabaseContext();
                var data = db.Categories.ToList();
               if(data != null )
               {
                    return data;
               }
               else
               {
                    return null;
               }
            }
            catch (Exception ex) {
                Print_in_Red(ex.Message);
                return null;
            }
        }
        #endregion Get All Categories

        #region Create a Category
        public static bool Create_Category(Category cat)
        {
            try
            {
                var db = new DatabaseContext();
                // Doesn't need to send the PrimaryKey here
                var data = db.Categories.Add(cat);
                return db.SaveChanges() > 0;
            }catch(Exception ex)
            {
                Print_in_Red(ex.Message);
                return false;
            }
        }
        #endregion Create a Category

        #region Update a Category
        public static bool Update_Category(Category new_cat)
        {
            try
            {
                var db = new DatabaseContext();
                var old_cat = db.Categories.Find(new_cat.Category_ID);

                if (old_cat != null)
                {
                    if (old_cat.Category_ID >= 0) { old_cat.Category_ID = new_cat.Category_ID; }
                    if (old_cat.Name != null) { old_cat.Name = new_cat.Name; }

                    return db.SaveChanges() > 0;

                }
                else
                {
                    Print_in_Green("Data Not Found");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Print_in_Red(ex.Message);
                return false;
            }
        }
        #endregion Update a Category

        #region Delete a Category
        public static bool Delete_Category(int id)
        {
            try
            {
                var db = new DatabaseContext();
                var category = db.Categories.Find(id);

                if (category != null)
                {
                    db.Categories.Remove(category);
                    return db.SaveChanges() > 0;

                }
                else
                {
                    Print_in_Green("Data Not Found");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Print_in_Red(ex.Message);
                return false;
            }
        }
        #endregion Delete a Category

        #region Text Color Configuration in CONSOLE
        public static void Print_in_Red(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void Print_in_Green(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        #endregion Text Color Configuration in CONSOLE

        #region Demo
        /*
        public static bool Function_Name()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Print_in_Red(ex.Message);
                return false;
            }
        }
        */
        #endregion Demo

    }
}
