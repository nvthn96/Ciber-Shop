using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("2173ea05-3b7a-4e02-b608-0438f656858e"), "Description 3", "Category 3" },
                    { new Guid("77be08dd-f601-4c09-9bc9-252c33eb0b0b"), "Description 2", "Category 2" },
                    { new Guid("adce9f03-ca12-4fa4-a554-d8651ae654c0"), "Description 1", "Category 1" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[,]
                {
                    { new Guid("945b7d58-304f-4dd1-abb8-94bbad2b1ed8"), "Address 3", "Customer 3" },
                    { new Guid("c768a61d-5622-4f61-86a2-c12f88feae7f"), "Address 2", "Customer 2" },
                    { new Guid("f0ad4c7c-ce3c-42b3-bb3c-72d4c21f43a4"), "Address 1", "Customer 1" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("68eab5bc-20c4-4498-b224-93e229cf4a00"), new Guid("2173ea05-3b7a-4e02-b608-0438f656858e"), "Description 3", "Product 3", 300f, 3 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("927f2f86-f224-47ed-b400-0ce34990d403"), new Guid("adce9f03-ca12-4fa4-a554-d8651ae654c0"), "Description 1", "Product 1", 100f, 5 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("affc3126-c329-4a82-9b2b-3f569b786041"), new Guid("77be08dd-f601-4c09-9bc9-252c33eb0b0b"), "Description 2", "Product 2", 200f, 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("945b7d58-304f-4dd1-abb8-94bbad2b1ed8"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c768a61d-5622-4f61-86a2-c12f88feae7f"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f0ad4c7c-ce3c-42b3-bb3c-72d4c21f43a4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("68eab5bc-20c4-4498-b224-93e229cf4a00"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("927f2f86-f224-47ed-b400-0ce34990d403"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("affc3126-c329-4a82-9b2b-3f569b786041"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2173ea05-3b7a-4e02-b608-0438f656858e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("77be08dd-f601-4c09-9bc9-252c33eb0b0b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("adce9f03-ca12-4fa4-a554-d8651ae654c0"));
        }
    }
}
