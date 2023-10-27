using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiNet5.Migrations
{
    public partial class AddDonHangSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    MaDh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getutcdate()"),
                    NgayGiao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TinhTrangDonHang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiNhan = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DiaChiGiao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.MaDh);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHang",
                columns: table => new
                {
                    MaHh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaDh = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "float", nullable: false),
                    GiamGia = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietDonHang", x => new { x.MaHh, x.MaDh });
                    table.ForeignKey(
                        name: "FK_DonHangCT_DonHang",
                        column: x => x.MaDh,
                        principalTable: "DonHang",
                        principalColumn: "MaDh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHangCT_HangHoa",
                        column: x => x.MaHh,
                        principalTable: "HangHoa",
                        principalColumn: "MaHh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_MaDh",
                table: "ChiTietDonHang",
                column: "MaDh");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "DonHang");
        }
    }
}
