using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupCapstone.Data.Migrations
{
    public partial class addPrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "302d25db-f92e-4b7e-8c3e-143f1e395eab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3965988e-dd5a-4577-ac96-2b18fe678c8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4972a75a-24ef-4354-b296-836fbcb4bb71");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c9415ec0-c559-4d46-9844-18b3bed05d26", "9ec99975-aac3-4582-98dd-023fe384f242", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d52b4752-e318-466c-af8d-9f7e09c4eb61", "e1ed23f2-474c-47d6-8bcb-7a6eddae6b9e", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5bf81e13-1560-4730-9e14-491c96fab335", "5fbd1303-74fa-4e96-8e31-137a2af9cd25", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5bf81e13-1560-4730-9e14-491c96fab335");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9415ec0-c559-4d46-9844-18b3bed05d26");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d52b4752-e318-466c-af8d-9f7e09c4eb61");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "302d25db-f92e-4b7e-8c3e-143f1e395eab", "2e801a79-0e40-4e27-af18-65c582df5237", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3965988e-dd5a-4577-ac96-2b18fe678c8e", "82b2dad0-d6bf-454b-a057-d434b5807bd8", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4972a75a-24ef-4354-b296-836fbcb4bb71", "405884a4-f71c-4ec5-859e-ce8bab05a50b", "Customer", "CUSTOMER" });
        }
    }
}
