using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FitnessApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Features = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    IsAdmin = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "Description", "Features", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Başlangıç için ideal.", "Haftada 2 Gün Kullanım,Antrenman Programı,Beslenme Programı,7/24 WhatsApp Desteği", "https://images.unsplash.com/photo-1534438327276-14e5300c3a48", "Basic Paket", 500m },
                    { 2, "Düzenli spor yapanlar için.", "Haftada 4 Gün Kullanım,Antrenman Programı,Beslenme Programı,Supplement Çekilişi Hakkı", "https://images.unsplash.com/photo-1517836357463-d25dfeac3438", "Pro Paket", 1000m },
                    { 3, "Tam kapsamlı profesyonel destek.", "Birebir Yüz Yüze Ders,Grup Dersleri,Beslenme & Antrenman Programı,7/24 WhatsApp Desteği,Supplement ve Üyelik Çekilişleri", "https://images.unsplash.com/photo-1599058945522-28d584b6f0ff", "Elite Paket", 2000m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsAdmin", "Password", "Username" },
                values: new object[] { 1, true, "123", "barkin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
