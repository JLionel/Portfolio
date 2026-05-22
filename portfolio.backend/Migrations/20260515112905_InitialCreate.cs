using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace portfolio.backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "revenue",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    month = table.Column<string>(type: "text", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_revenue", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoices", x => x.id);
                    table.ForeignKey(
                        name: "FK_invoices_customers_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "id", "email", "image_url", "name" },
                values: new object[,]
                {
                    { new Guid("13d07535-c59e-4157-a011-f8d2ef4e0cbb"), "balazs@orban.com", "/customers/balazs-orban.png", "Balazs Orban" },
                    { new Guid("3958dc9e-712f-4377-85e9-fec4b6a6442a"), "delba@oliveira.com", "/customers/delba-de-oliveira.png", "Delba de Oliveira" },
                    { new Guid("3958dc9e-742f-4377-85e9-fec4b6a6442a"), "lee@robinson.com", "/customers/lee-robinson.png", "Lee Robinson" },
                    { new Guid("76d65c26-f784-44a2-ac19-586678f7c2f2"), "michael@novotny.com", "/customers/michael-novotny.png", "Michael Novotny" },
                    { new Guid("cc27c14a-0acf-4f4a-a6c9-d45682c144b9"), "amy@burns.com", "/customers/amy-burns.png", "Amy Burns" },
                    { new Guid("d6e15727-9fe1-4961-8c5b-ea44a9bd81aa"), "evil@rabbit.com", "/customers/evil-rabbit.png", "Evil Rabbit" }
                });

            migrationBuilder.InsertData(
                table: "revenue",
                columns: new[] { "id", "amount", "month" },
                values: new object[,]
                {
                    { new Guid("07e5316f-ffa6-4909-aa4a-ca1f08abbda0"), 2000, "Jan" },
                    { new Guid("20a93528-428f-4d34-8475-3648861ead65"), 1800, "Feb" },
                    { new Guid("243a9c6b-4384-47c3-a7d3-ad2c2a89b19a"), 2200, "Mar" },
                    { new Guid("3278655e-2fd2-4b47-8e42-7fab47030641"), 2500, "Apr" },
                    { new Guid("4a7f7eb3-ca78-4cdf-ac9f-15cd89db2837"), 2300, "May" },
                    { new Guid("57344439-19ac-4268-8a69-0f9299dddb5c"), 3200, "Jun" },
                    { new Guid("63aa12b2-9ed9-4b84-82c1-a77e570bbbeb"), 3500, "Jul" },
                    { new Guid("6467ea0e-e110-4c9c-8f7b-ce30f7e9c058"), 3700, "Aug" },
                    { new Guid("7721265f-1be2-4a21-9bd3-ae592a06849a"), 2500, "Sep" },
                    { new Guid("a79ee355-d4bf-4644-9006-ebacb059606a"), 2800, "Oct" },
                    { new Guid("b51fb53c-cd45-42e9-b7f7-17641b3c78c2"), 3000, "Nov" },
                    { new Guid("e756d367-0747-4701-99d1-b7c54fd4cca7"), 4800, "Dec" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "email", "name", "password" },
                values: new object[] { new Guid("b3436992-ad18-4873-aa2c-29ed8892a5aa"), "user@nextmail.com", "User", "$2a$11$psaSIr9t4MHIGMSgdGswZONTn72xOQVt/TGnJMZPvrnx/BeEEX5t2" });

            migrationBuilder.InsertData(
                table: "invoices",
                columns: new[] { "id", "amount", "customer_id", "date", "status" },
                values: new object[,]
                {
                    { new Guid("2c2a4e4e-8b3b-4320-b5b5-3954545aad7d"), 15795, new Guid("d6e15727-9fe1-4961-8c5b-ea44a9bd81aa"), new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "pending" },
                    { new Guid("2d4b3bfa-4e60-4163-acbc-79edd4d9e69e"), 20348, new Guid("3958dc9e-712f-4377-85e9-fec4b6a6442a"), new DateTime(2022, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "pending" },
                    { new Guid("39f5ae23-f425-4042-9bb9-860cc3f7231f"), 3040, new Guid("cc27c14a-0acf-4f4a-a6c9-d45682c144b9"), new DateTime(2022, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "paid" },
                    { new Guid("3b5f714b-0221-4222-92bc-b3245eabfe22"), 44800, new Guid("76d65c26-f784-44a2-ac19-586678f7c2f2"), new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "paid" },
                    { new Guid("3dd0584b-4405-4f23-a715-470381f2e073"), 34577, new Guid("13d07535-c59e-4157-a011-f8d2ef4e0cbb"), new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "pending" },
                    { new Guid("659eb7d0-6656-4221-8863-b706bc8cd9e1"), 54246, new Guid("3958dc9e-742f-4377-85e9-fec4b6a6442a"), new DateTime(2023, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "pending" },
                    { new Guid("6ce7d909-58fa-40db-8a66-313de4e1c995"), 666, new Guid("d6e15727-9fe1-4961-8c5b-ea44a9bd81aa"), new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "pending" },
                    { new Guid("7d311dbc-3547-4b13-884c-9c47620e6878"), 32545, new Guid("76d65c26-f784-44a2-ac19-586678f7c2f2"), new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "paid" },
                    { new Guid("887c63ea-a013-437e-993d-0321e7839db1"), 1250, new Guid("cc27c14a-0acf-4f4a-a6c9-d45682c144b9"), new DateTime(2023, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "paid" },
                    { new Guid("94ac86bb-033a-400c-a570-9d9383ae92df"), 8546, new Guid("13d07535-c59e-4157-a011-f8d2ef4e0cbb"), new DateTime(2023, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "paid" },
                    { new Guid("a89bae68-7ac8-4b4e-af7b-ed4d3e65b78d"), 500, new Guid("3958dc9e-712f-4377-85e9-fec4b6a6442a"), new DateTime(2023, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "paid" },
                    { new Guid("b3c388a0-141f-49fa-bcab-a3d05d97a167"), 8945, new Guid("13d07535-c59e-4157-a011-f8d2ef4e0cbb"), new DateTime(2023, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "paid" },
                    { new Guid("f51ff7fd-f1af-4fbc-84ff-fd197ddf322d"), 1000, new Guid("3958dc9e-742f-4377-85e9-fec4b6a6442a"), new DateTime(2022, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "paid" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_invoices_customer_id",
                table: "invoices",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_revenue_month",
                table: "revenue",
                column: "month",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "revenue");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
