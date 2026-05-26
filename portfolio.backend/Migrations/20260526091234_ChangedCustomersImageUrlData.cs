using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace portfolio.backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangedCustomersImageUrlData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("13d07535-c59e-4157-a011-f8d2ef4e0cbb"),
                column: "image_url",
                value: "/next-tuto/customers/balazs-orban.png");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("3958dc9e-712f-4377-85e9-fec4b6a6442a"),
                column: "image_url",
                value: "/next-tuto/customers/delba-de-oliveira.png");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("3958dc9e-742f-4377-85e9-fec4b6a6442a"),
                column: "image_url",
                value: "/next-tuto/customers/lee-robinson.png");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("76d65c26-f784-44a2-ac19-586678f7c2f2"),
                column: "image_url",
                value: "/next-tuto/customers/michael-novotny.png");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("cc27c14a-0acf-4f4a-a6c9-d45682c144b9"),
                column: "image_url",
                value: "/next-tuto/customers/amy-burns.png");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("d6e15727-9fe1-4961-8c5b-ea44a9bd81aa"),
                column: "image_url",
                value: "/next-tuto/customers/evil-rabbit.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("13d07535-c59e-4157-a011-f8d2ef4e0cbb"),
                column: "image_url",
                value: "/customers/balazs-orban.png");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("3958dc9e-712f-4377-85e9-fec4b6a6442a"),
                column: "image_url",
                value: "/customers/delba-de-oliveira.png");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("3958dc9e-742f-4377-85e9-fec4b6a6442a"),
                column: "image_url",
                value: "/customers/lee-robinson.png");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("76d65c26-f784-44a2-ac19-586678f7c2f2"),
                column: "image_url",
                value: "/customers/michael-novotny.png");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("cc27c14a-0acf-4f4a-a6c9-d45682c144b9"),
                column: "image_url",
                value: "/customers/amy-burns.png");

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "id",
                keyValue: new Guid("d6e15727-9fe1-4961-8c5b-ea44a9bd81aa"),
                column: "image_url",
                value: "/customers/evil-rabbit.png");
        }
    }
}
