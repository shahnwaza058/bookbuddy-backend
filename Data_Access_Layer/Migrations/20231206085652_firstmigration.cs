using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$wdi4zs3R9gXIPSN7Z6Kr8.E39zRToix1TcHsAkpvzrMTLBAm9KkAS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$X2oXkzIfEP83O84IWV/Fee7j4PXv3.8mmU6OY.SUgXX3K12FxZjqK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$dSx/4tFu4FX344P1qm82GOQq0ZgmfjrMuiEWG2mQ5U.PS55NJl.re");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$AYnOsr/9Rn6YRtcTQBFtTeLtwmz43/MUoVwuwDcR/5rTzR9BAem0e");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$ulnTdWEef3Hdf0QR1WU3qerKH/VtL5XCmM52U4c72rNBz.IttQqya");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$cYgBptrI2eWeVC7hdXm9aeFaNIy2s2/v9QR3Zv4UHW78ltKn0pRN2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$z3SZMuYl0bcD1zgmDN8ZUeboLvGZhK1Xv3BSS7VU0.1pcXUfAPtSy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$F1enRAU/8PZexeuK/b9Aveh2/stF2Q2JKN7ktIqHprZqZiC/MWnoe");
        }
    }
}
