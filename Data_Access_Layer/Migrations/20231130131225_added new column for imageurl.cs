using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    /// <inheritdoc />
    public partial class addednewcolumnforimageurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "BookList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "BookList");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$qXJ3T8aa9G6tSPLhMmOX4eGQQqQr2xZWjU.mLeVza0xe4.lHOK0cq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$aHj1WS87GVw5EJK6yLKC1.IOIM8VzdOOI2yTpPHGJ1u9w8ezhSKX2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$5pL1VUFbwsQiVoVHzf3gHOd2s5B.d8cCxhqAcN8wv3th8f2kmPHxG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$3/D5R45cl8LYN5kBPd9W9.Yop6icA9brlaxOfxjPRiVzf55z/gFyy");
        }
    }
}
