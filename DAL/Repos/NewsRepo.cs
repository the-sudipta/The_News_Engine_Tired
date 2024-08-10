using DAL.Database;
using DAL.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class NewsRepo
    {
        #region Get All News
        public static List<News> getAll()
        {
            try
            {
                var db = new DatabaseContext();
                var data = db.Newses.ToList();
                //This is Called Tarnary If-Else. Don't use if you can't explain
                return (data.Count > 0) ? data : null;

            }catch (Exception ex)
            {
                Print_in_Red(ex.Message);
                return null;
            }
        }
        #endregion Get All News

        #region Create a News
        public static bool Create_News(News news)
        {
            try
            {
                var db = new DatabaseContext();
                // Doesn't need to send the PrimaryKey here
                var data = db.Newses.Add(news);
                return db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                Print_in_Red(ex.Message);
                return false;
            }
        }
        #endregion Create a News

        #region Update a News
        public static bool Update_News(News new_news)
        {
            try
            {
                var db = new DatabaseContext();
                var old_news= db.Newses.Find(new_news.News_ID);

                if (old_news != null)
                {
                    if (old_news.News_ID >= 1) { old_news.News_ID = new_news.News_ID; }
                    if (old_news.Title != null) { old_news.Title = new_news.Title; }
                    if (old_news.Description != null) { old_news.Description = new_news.Description; }
                    if (old_news.Date != null) { old_news.Date = new_news.Date; }
                    if (old_news.Category_ID >= 1) { old_news.Category_ID = new_news.Category_ID; }


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
        #endregion Update a News

        #region Delete a News
        public static bool Delete_News(int id)
        {
            try
            {
                var db = new DatabaseContext();
                var news = db.Newses.Find(id);

                if (news != null)
                {
                    db.Newses.Remove(news);
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
        #endregion Delete a News

        

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
