using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data_Access_Layer.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Users_LentByUserId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Book_BookId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Book",
                table: "Book");

            migrationBuilder.RenameTable(
                name: "Book",
                newName: "BookList");

            migrationBuilder.RenameIndex(
                name: "IX_Book_LentByUserId",
                table: "BookList",
                newName: "IX_BookList_LentByUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookList",
                table: "BookList",
                column: "BookId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BookList_Users_LentByUserId",
                table: "BookList",
                column: "LentByUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_BookList_BookId",
                table: "Ratings",
                column: "BookId",
                principalTable: "BookList",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookList_Users_LentByUserId",
                table: "BookList");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_BookList_BookId",
                table: "Ratings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookList",
                table: "BookList");

            migrationBuilder.RenameTable(
                name: "BookList",
                newName: "Book");

            migrationBuilder.RenameIndex(
                name: "IX_BookList_LentByUserId",
                table: "Book",
                newName: "IX_Book_LentByUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Book",
                table: "Book",
                column: "BookId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$mHEHeH2cq7MdXkeA.SIp6uft2mHLFBCgph4N57uc.4BtjssJcYzzO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$YY54dgrCQMSX1fPEDKAuq.lrzh1TrvgB2nJrmeWn4E0x0uTSSrD7e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$aMNOGvo9bn8oos6pVuQ7Su70AE1eXUKO05W5yF0rqYhfx5jypuu8y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$.rdnW9iIjJeGRKKaJuB7Ue7kOTK0jUdNZCPkicA.Y7PZkE51sNFNS");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Users_LentByUserId",
                table: "Book",
                column: "LentByUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Book_BookId",
                table: "Ratings",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
