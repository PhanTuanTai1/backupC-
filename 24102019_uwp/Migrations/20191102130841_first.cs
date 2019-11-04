using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _24102019_uwp.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CusID = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CusID);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    TypeID = table.Column<int>(nullable: false),
                    TypeName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Salt = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    RentalID = table.Column<int>(nullable: false),
                    CusID = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    StartRentDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.RentalID);
                    table.ForeignKey(
                        name: "FK_Rentals_Customers_CusID",
                        column: x => x.CusID,
                        principalTable: "Customers",
                        principalColumn: "CusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    TitleID = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    RentCharge = table.Column<decimal>(type: "money", nullable: false),
                    RentPeriod = table.Column<short>(nullable: false),
                    TypeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.TitleID);
                    table.ForeignKey(
                        name: "FK_Titles_Types_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Types",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disks",
                columns: table => new
                {
                    DiskID = table.Column<int>(nullable: false),
                    ChkOutStatus = table.Column<short>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    TitleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disks", x => x.DiskID);
                    table.ForeignKey(
                        name: "FK_Disks_Titles_TitleID",
                        column: x => x.TitleID,
                        principalTable: "Titles",
                        principalColumn: "TitleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ResID = table.Column<int>(nullable: false),
                    CusID = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false),
                    Status = table.Column<short>(nullable: false),
                    TitleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ResID);
                    table.ForeignKey(
                        name: "FK_Reservations_Customers_CusID",
                        column: x => x.CusID,
                        principalTable: "Customers",
                        principalColumn: "CusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Titles_TitleID",
                        column: x => x.TitleID,
                        principalTable: "Titles",
                        principalColumn: "TitleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentail_Detail",
                columns: table => new
                {
                    RentalID = table.Column<int>(nullable: false),
                    DiskID = table.Column<int>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: true),
                    OwnedMoney = table.Column<decimal>(type: "money", nullable: true),
                    ReturnDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentail_Detail", x => new { x.RentalID, x.DiskID });
                    table.ForeignKey(
                        name: "FK_Rentail_Detail_Disks_DiskID",
                        column: x => x.DiskID,
                        principalTable: "Disks",
                        principalColumn: "DiskID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentail_Detail_Rentals_RentalID",
                        column: x => x.RentalID,
                        principalTable: "Rentals",
                        principalColumn: "RentalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disks_TitleID",
                table: "Disks",
                column: "TitleID");

            migrationBuilder.CreateIndex(
                name: "IX_Rentail_Detail_DiskID",
                table: "Rentail_Detail",
                column: "DiskID");

            migrationBuilder.CreateIndex(
                name: "IX_Rentail_Detail_RentalID",
                table: "Rentail_Detail",
                column: "RentalID");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CusID",
                table: "Rentals",
                column: "CusID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CusID",
                table: "Reservations",
                column: "CusID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TitleID",
                table: "Reservations",
                column: "TitleID");

            migrationBuilder.CreateIndex(
                name: "IX_Titles_TypeID",
                table: "Titles",
                column: "TypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentail_Detail");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Disks");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Titles");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
