using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class AddUspOrderPagging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var up = File.ReadAllText(@"Migrations\SqlFiles\20230324022900_up_add_usps.sql");
            migrationBuilder.Sql(up);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dn = File.ReadAllText(@"Migrations\SqlFiles\20230324022900_dn_add_usps.sql");
            migrationBuilder.Sql(dn);
        }
    }
}
