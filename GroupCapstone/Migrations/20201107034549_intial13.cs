using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupCapstone.Migrations
{
    public partial class intial13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0da649e5-5575-4270-90a7-cfc49d93f17e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26adb92f-a4cd-4714-8b21-269248411074");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26c96242-d25e-44f4-90a8-e46638660f07");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "ShoppingCarts",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Products",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "31801656-7fef-4278-9952-95daa9792eb4", "e137f5cc-f700-4907-ae6f-60f6f95f74c2", "Admin", "ADMIN" },
                    { "1e26089a-15f8-46fe-954f-cf1855fd7586", "be8db9b4-c6ef-46e3-bef1-61ff7c46ece1", "Employee", "EMPLOYEE" },
                    { "50448970-58c7-410c-abcf-dee088d192f9", "aec37058-15fd-4981-89bd-f1abf3d74581", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e26089a-15f8-46fe-954f-cf1855fd7586");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31801656-7fef-4278-9952-95daa9792eb4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50448970-58c7-410c-abcf-dee088d192f9");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "ShoppingCarts",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26adb92f-a4cd-4714-8b21-269248411074", "2194eb8b-4c33-4a35-a70f-c96123a4c67a", "Admin", "ADMIN" },
                    { "0da649e5-5575-4270-90a7-cfc49d93f17e", "1dac394f-37ff-4c14-8769-a3f2280ab488", "Employee", "EMPLOYEE" },
                    { "26c96242-d25e-44f4-90a8-e46638660f07", "2dfdb08f-9c8e-4d75-941c-c505926679c1", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 2.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 20.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 9.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 5.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 3.0);
        }
    }
}
