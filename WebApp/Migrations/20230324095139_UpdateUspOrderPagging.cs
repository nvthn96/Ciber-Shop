using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class UpdateUspOrderPagging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var up = File.ReadAllText(@"Migrations\SqlFiles\20230324095500_up_update_usps.sql");
            migrationBuilder.Sql(up);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
