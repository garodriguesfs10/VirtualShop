using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductAPI.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO PRODUCTS(Name,Price,Description, Stock, ImageUrl,CategoryId) " +
                   "values ('Caderno',7.55,'Caderno Capa dura',10,'caderno.jpg',1)");

            mb.Sql("INSERT INTO PRODUCTS(Name,Price,Description, Stock, ImageUrl,CategoryId) " +
                  "values ('Lapis',2.35,'Lapis',5,'lapis.jpg',1)");

            mb.Sql("INSERT INTO PRODUCTS(Name,Price,Description, Stock, ImageUrl,CategoryId) " +
                  "values ('Clips',0.50,'Clips',3,'clips.jpg',2)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from products");
        }
    }
}
