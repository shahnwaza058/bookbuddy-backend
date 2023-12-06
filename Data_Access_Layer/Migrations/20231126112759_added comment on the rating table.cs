using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    /// <inheritdoc />
    public partial class addedcommentontheratingtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "comment",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "comment",
                table: "Ratings");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$KhjJz3eJV/ru.mKj8N42DOiSS3GXLvCZM7FVqqiM4isxdaVHuC6iq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$imNod9RjDumtteqDcgVVNOUduDyf4MZCu4LHWeQnsxwMNtRYKh.2u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$325LRc2XnvQcvwmm4o2Auub6MQ71LTDvnnk/n.BVnHAGq0ZWLwbL2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$IrNR7fOujt1.js42NTQieOJPfcts9FU3NvmCf6Vs2Cp9oke1afKZK");
        }
    }
}
