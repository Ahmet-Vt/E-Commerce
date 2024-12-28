using ecommercesite.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace wecommercesite.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>()
            {
                new Category(){Name="Ekran Kartı", Description="Ekran Kartı Ürünleri"},
                new Category(){Name="Laptop", Description="Laptop Ürünleri"},
                new Category(){Name="Fare", Description="Fare Ürünleri"},
                new Category(){Name="Klavye", Description="Klavye Ürünleri"},
                new Category(){Name="Kulaklık", Description="Kulaklık Ürünleri"},
                new Category(){Name="Telefon", Description="Telefon Ürünleri"}

            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();

            var urunler = new List<Product>()
            {
                new Product(){ Name="ASUS RTX 3060" ,Description= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", Price= 399, Stock= 31,IsHome = true, CategoryId= 1, Image="1.jpg"},
                new Product(){ Name="Asus laptop" ,Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", Price= 1199, Stock= 23,IsHome = true, CategoryId= 2, Image="2.jpg"},
                new Product(){ Name="Logitech Mouse" ,Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", Price= 99, Stock= 23,IsHome = true, CategoryId= 3, Image="3.jpg"},
                new Product(){ Name="Razer Blackwidow" ,Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", Price= 199, Stock= 155,IsHome = true, CategoryId= 4, Image="4.jpg"},
                new Product(){ Name="Steel Series Kulaklık" ,Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", Price= 299, Stock= 666,IsHome = true, CategoryId= 5, Image="5.jpg"},
                new Product(){ Name="Iphone 15" ,Description="Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book", Price= 799, Stock= 77,IsHome = false, CategoryId= 6, Image="6.jpg"}
            };

            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();


            base.Seed(context);
        }

    }
}