using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder builder)
        {
            builder.Sql("INSERT INTO Products(Name, Price, Description, Stock, ImageURL, CategoryId)" +
                "VALUES('Caderno', 7.55, 'Caderno Espiral', 10, 'caderno1.jpg', 1)");

            builder.Sql("Insert Into Products(Name,Price,Description,Stock,ImageURL,CategoryId) " +
                "Values('Lápis',3.45,'Lápis Preto',20,'lapis1.jpg',1)");

            builder.Sql("Insert Into Products(Name,Price,Description,Stock,ImageURL,CategoryId)" +
                " Values('Clips',5.33,'Clips para papel',50,'clips1.jpg',2)");
        }

        protected override void Down(MigrationBuilder builder)
        {
            builder.Sql("DELETE FROM Products");
        }
    }
}
