using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cobid.Api.Migrations
{
    public partial class addeddatecreatedcommunity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "CommunityPostsRatings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "CommunityPosts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateSent",
                table: "CommunityMessages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "CommunityImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "CommunityFileAttachments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AuctionEvents",
                keyColumn: "AuctionEventId",
                keyValue: 1L,
                columns: new[] { "AuctionEventDateEnd", "AuctionEventDateStart" },
                values: new object[] { new DateTime(2022, 12, 6, 8, 26, 15, 514, DateTimeKind.Local).AddTicks(1185), new DateTime(2022, 12, 6, 8, 26, 15, 514, DateTimeKind.Local).AddTicks(1184) });

            migrationBuilder.UpdateData(
                table: "AuctionMessages",
                keyColumn: "AuctionMessageId",
                keyValue: 1L,
                column: "DateSent",
                value: new DateTime(2022, 12, 6, 8, 27, 15, 514, DateTimeKind.Local).AddTicks(1283));

            migrationBuilder.UpdateData(
                table: "AuctionMessages",
                keyColumn: "AuctionMessageId",
                keyValue: 2L,
                column: "DateSent",
                value: new DateTime(2022, 12, 6, 8, 28, 15, 514, DateTimeKind.Local).AddTicks(1305));

            migrationBuilder.UpdateData(
                table: "AuctionMessages",
                keyColumn: "AuctionMessageId",
                keyValue: 3L,
                column: "DateSent",
                value: new DateTime(2022, 12, 6, 8, 29, 15, 514, DateTimeKind.Local).AddTicks(1318));

            migrationBuilder.UpdateData(
                table: "CommunityMessages",
                keyColumn: "CommunityMessageId",
                keyValue: 1L,
                column: "DateSent",
                value: new DateTime(2022, 12, 6, 8, 56, 15, 514, DateTimeKind.Local).AddTicks(1395));

            migrationBuilder.UpdateData(
                table: "CommunityMessages",
                keyColumn: "CommunityMessageId",
                keyValue: 2L,
                column: "DateSent",
                value: new DateTime(2022, 12, 6, 9, 1, 15, 514, DateTimeKind.Local).AddTicks(1413));

            migrationBuilder.UpdateData(
                table: "CommunityPosts",
                keyColumn: "CommunityPostId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2022, 12, 6, 8, 56, 15, 514, DateTimeKind.Local).AddTicks(1347));

            migrationBuilder.UpdateData(
                table: "CommunityPosts",
                keyColumn: "CommunityPostId",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2022, 12, 6, 9, 1, 15, 514, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "Conversations",
                keyColumn: "ConversationId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2022, 12, 6, 8, 26, 15, 514, DateTimeKind.Local).AddTicks(1042));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1L,
                column: "DateSent",
                value: new DateTime(2022, 12, 6, 8, 26, 15, 514, DateTimeKind.Local).AddTicks(1065));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2L,
                column: "DateSent",
                value: new DateTime(2022, 12, 6, 8, 26, 15, 514, DateTimeKind.Local).AddTicks(1083));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3L,
                column: "DateSent",
                value: new DateTime(2022, 12, 6, 8, 26, 15, 514, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 4L,
                column: "DateSent",
                value: new DateTime(2022, 12, 6, 8, 26, 15, 514, DateTimeKind.Local).AddTicks(1150));

            migrationBuilder.UpdateData(
                table: "ProductRatings",
                keyColumn: "ProductRatingId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2022, 12, 6, 8, 26, 15, 514, DateTimeKind.Local).AddTicks(571));

            migrationBuilder.UpdateData(
                table: "ProductRatings",
                keyColumn: "ProductRatingId",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2022, 12, 6, 8, 26, 15, 514, DateTimeKind.Local).AddTicks(594));

            migrationBuilder.UpdateData(
                table: "ProductRatings",
                keyColumn: "ProductRatingId",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2022, 12, 6, 8, 26, 15, 514, DateTimeKind.Local).AddTicks(608));

            migrationBuilder.UpdateData(
                table: "ProductRatings",
                keyColumn: "ProductRatingId",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2022, 12, 6, 8, 26, 15, 514, DateTimeKind.Local).AddTicks(663));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "CommunityPostsRatings");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "CommunityPosts");

            migrationBuilder.DropColumn(
                name: "DateSent",
                table: "CommunityMessages");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "CommunityImages");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "CommunityFileAttachments");

            migrationBuilder.UpdateData(
                table: "AuctionEvents",
                keyColumn: "AuctionEventId",
                keyValue: 1L,
                columns: new[] { "AuctionEventDateEnd", "AuctionEventDateStart" },
                values: new object[] { new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7895), new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7894) });

            migrationBuilder.UpdateData(
                table: "AuctionMessages",
                keyColumn: "AuctionMessageId",
                keyValue: 1L,
                column: "DateSent",
                value: new DateTime(2022, 12, 6, 8, 8, 21, 150, DateTimeKind.Local).AddTicks(7996));

            migrationBuilder.UpdateData(
                table: "AuctionMessages",
                keyColumn: "AuctionMessageId",
                keyValue: 2L,
                column: "DateSent",
                value: new DateTime(2022, 12, 6, 8, 9, 21, 150, DateTimeKind.Local).AddTicks(8024));

            migrationBuilder.UpdateData(
                table: "AuctionMessages",
                keyColumn: "AuctionMessageId",
                keyValue: 3L,
                column: "DateSent",
                value: new DateTime(2022, 12, 6, 8, 10, 21, 150, DateTimeKind.Local).AddTicks(8036));

            migrationBuilder.UpdateData(
                table: "Conversations",
                keyColumn: "ConversationId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1L,
                column: "DateSent",
                value: new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7816));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2L,
                column: "DateSent",
                value: new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3L,
                column: "DateSent",
                value: new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7848));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 4L,
                column: "DateSent",
                value: new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7860));

            migrationBuilder.UpdateData(
                table: "ProductRatings",
                keyColumn: "ProductRatingId",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "ProductRatings",
                keyColumn: "ProductRatingId",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7368));

            migrationBuilder.UpdateData(
                table: "ProductRatings",
                keyColumn: "ProductRatingId",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7383));

            migrationBuilder.UpdateData(
                table: "ProductRatings",
                keyColumn: "ProductRatingId",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7396));
        }
    }
}
