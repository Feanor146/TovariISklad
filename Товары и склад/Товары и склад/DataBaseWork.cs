using System;
using System.Collections.Generic;
using System.IO;
using SQLite;
using Xamarin.Forms;
namespace Товары_и_склад
{
    internal abstract class DataBaseWork
    {
        public static List<User> users { get
            {
                return Connection.Table<User>().ToList();
            } 
        }
        public static List<Product> products { get
            {
                return Connection.Table<Product>().ToList();
            }
        }
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string filename = "DataBase.db";        
        public static SQLiteConnection Connection = new SQLiteConnection(path+filename);
        public static void CreateifNotExistDataBase()
        {
            Connection.CreateTable<User>();
            Connection.CreateTable<Product>();
        }
    }
    [Table ("User")]
    class User
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        [Unique]
        public string Login { get; set; }
        public string Password { get; set; }
    }
    [Table("Product")]
    public class Product
    {
        [AutoIncrement, PrimaryKey]
        public int ID { get; set; }
        public string ProductName { get; set; }
        public long QuantityStock { get; set; }
        public decimal Cost { get; set; }
        public byte[] Photo { get; set; }
        public ImageSource source { get
            {
                return ImageSource.FromStream(() => new MemoryStream(Photo));
            } 
        }
        public string CostText 
        { 
            get
            {
                return "Цена за еденицу:" + Convert.ToString(Cost) + "₽";
            } 
        }
        public string QuantityText
        {
            get
            {
                return "Количество:" + Convert.ToString(QuantityStock) + "шт.";
            }
        }
    }
}
