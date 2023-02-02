using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cobid.Api.Migrations
{
    public partial class newdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuctionEvents",
                columns: table => new
                {
                    AuctionEventId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AuctionEventTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuctionEventDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuctionEventStartingBid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AuctionEventDateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuctionEventDateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductConditionId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HasStarted = table.Column<bool>(type: "bit", nullable: false),
                    HasEnded = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionEvents", x => x.AuctionEventId);
                });

            migrationBuilder.CreateTable(
                name: "CommunityPosts",
                columns: table => new
                {
                    CommunityPostId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThreadStaterUserId = table.Column<int>(type: "int", nullable: false),
                    CommunityPostTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommunityPostType = table.Column<long>(type: "bigint", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityPosts", x => x.CommunityPostId);
                });

            migrationBuilder.CreateTable(
                name: "CommunityPostTypes",
                columns: table => new
                {
                    CommunityPostTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityPostTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityPostTypes", x => x.CommunityPostTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    ConversationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConversationTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.ConversationId);
                });

            migrationBuilder.CreateTable(
                name: "Dimensions",
                columns: table => new
                {
                    DimensionsModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DimensionsModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DimensionsModelShortName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensions", x => x.DimensionsModelId);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "GovernmentTypeIds",
                columns: table => new
                {
                    GovernmentIdentificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GovIdName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovIdShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernmentTypeIds", x => x.GovernmentIdentificationId);
                });

            migrationBuilder.CreateTable(
                name: "LiveSellings",
                columns: table => new
                {
                    LiveSellingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LiveSellingTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiveSellingPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiveSellingDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiveSellingLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiveSellingDateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LiveSellingDateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HasEnded = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveSellings", x => x.LiveSellingId);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.ProductCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ProductConditions",
                columns: table => new
                {
                    ProductConditionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductConditionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductConditions", x => x.ProductConditionId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductConditionId = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DimensionModelId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeightModelId = table.Column<int>(type: "int", nullable: false),
                    ProductRanking = table.Column<int>(type: "int", nullable: false),
                    ProductStatusId = table.Column<int>(type: "int", nullable: false),
                    ProductListedAs = table.Column<int>(type: "int", nullable: false),
                    ProductRating = table.Column<int>(type: "int", nullable: false),
                    ProductStockCount = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSale = table.Column<bool>(type: "bit", nullable: false),
                    SaleAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdminRemarks = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ProductsListedAs",
                columns: table => new
                {
                    ProductListedAsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductListedAsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsListedAs", x => x.ProductListedAsId);
                });

            migrationBuilder.CreateTable(
                name: "ProductStatuses",
                columns: table => new
                {
                    ProductStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatuses", x => x.ProductStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedTimeSpan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTimeSpan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipppingAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValidationId = table.Column<int>(type: "int", nullable: false),
                    CommunityId = table.Column<int>(type: "int", nullable: false),
                    UserProfilePic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Weights",
                columns: table => new
                {
                    WeightModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeightModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeightModelShortName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weights", x => x.WeightModelId);
                });

            migrationBuilder.CreateTable(
                name: "AuctionEventParticipants",
                columns: table => new
                {
                    AuctionEventParticipantId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionEventId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsBanned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionEventParticipants", x => x.AuctionEventParticipantId);
                    table.ForeignKey(
                        name: "FK_AuctionEventParticipants_AuctionEvents_AuctionEventId",
                        column: x => x.AuctionEventId,
                        principalTable: "AuctionEvents",
                        principalColumn: "AuctionEventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionMessages",
                columns: table => new
                {
                    AuctionMessageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionEventId = table.Column<long>(type: "bigint", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuctionBidAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsBidWinner = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsBanned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionMessages", x => x.AuctionMessageId);
                    table.ForeignKey(
                        name: "FK_AuctionMessages_AuctionEvents_AuctionEventId",
                        column: x => x.AuctionEventId,
                        principalTable: "AuctionEvents",
                        principalColumn: "AuctionEventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionProductImages",
                columns: table => new
                {
                    AuctionProductImageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionEventId = table.Column<long>(type: "bigint", nullable: false),
                    AuctionProductImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuctionProductImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuctionProductImageData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionProductImages", x => x.AuctionProductImageId);
                    table.ForeignKey(
                        name: "FK_AuctionProductImages_AuctionEvents_AuctionEventId",
                        column: x => x.AuctionEventId,
                        principalTable: "AuctionEvents",
                        principalColumn: "AuctionEventId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityMessages",
                columns: table => new
                {
                    CommunityMessageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityPostId = table.Column<long>(type: "bigint", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityMessages", x => x.CommunityMessageId);
                    table.ForeignKey(
                        name: "FK_CommunityMessages_CommunityPosts_CommunityPostId",
                        column: x => x.CommunityPostId,
                        principalTable: "CommunityPosts",
                        principalColumn: "CommunityPostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityPostsRatings",
                columns: table => new
                {
                    CommunityPostRatingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityPostId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommunityPostRatingLike = table.Column<long>(type: "bigint", nullable: false),
                    CommunityPostRatingDislike = table.Column<long>(type: "bigint", nullable: false),
                    CommunityPostRatingGrade = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityPostsRatings", x => x.CommunityPostRatingId);
                    table.ForeignKey(
                        name: "FK_CommunityPostsRatings_CommunityPosts_CommunityPostId",
                        column: x => x.CommunityPostId,
                        principalTable: "CommunityPosts",
                        principalColumn: "CommunityPostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConversationId = table.Column<long>(type: "bigint", nullable: false),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateSent = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "ConversationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LiveSellingImages",
                columns: table => new
                {
                    LiveSellingImageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LiveSellingId = table.Column<long>(type: "bigint", nullable: false),
                    LiveSellingImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiveSellingImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiveSellingDataImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveSellingImages", x => x.LiveSellingImageId);
                    table.ForeignKey(
                        name: "FK_LiveSellingImages_LiveSellings_LiveSellingId",
                        column: x => x.LiveSellingId,
                        principalTable: "LiveSellings",
                        principalColumn: "LiveSellingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    ProductImageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ProductImageLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDataImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductImageDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.ProductImageId);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductRatings",
                columns: table => new
                {
                    ProductRatingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ProductRatingDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductRatingGrade = table.Column<int>(type: "int", nullable: false),
                    ProductRatingComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRatings", x => x.ProductRatingId);
                    table.ForeignKey(
                        name: "FK_ProductRatings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserValidationImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageHttpLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GovernmentIdentificationId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsValidated = table.Column<bool>(type: "bit", nullable: false),
                    IsNew = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserValidationImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserValidationImages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityFileAttachments",
                columns: table => new
                {
                    CommunityFileAttachmentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityMessageId = table.Column<long>(type: "bigint", nullable: false),
                    CommunityFileAttachmentTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommunityFileAttachmentData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommunityFileAttachmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityFileAttachments", x => x.CommunityFileAttachmentId);
                    table.ForeignKey(
                        name: "FK_CommunityFileAttachments_CommunityMessages_CommunityMessageId",
                        column: x => x.CommunityMessageId,
                        principalTable: "CommunityMessages",
                        principalColumn: "CommunityMessageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunityImages",
                columns: table => new
                {
                    CommunityImageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityMessageId = table.Column<long>(type: "bigint", nullable: false),
                    CommunityImageLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommunityDataImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommunityImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommunityImageDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunityImages", x => x.CommunityImageId);
                    table.ForeignKey(
                        name: "FK_CommunityImages_CommunityMessages_CommunityMessageId",
                        column: x => x.CommunityMessageId,
                        principalTable: "CommunityMessages",
                        principalColumn: "CommunityMessageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductRatingImages",
                columns: table => new
                {
                    ProductRatingImageId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductRatingId = table.Column<long>(type: "bigint", nullable: false),
                    ProductRatingImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductRatingImageLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductRatingImageData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRatingImages", x => x.ProductRatingImageId);
                    table.ForeignKey(
                        name: "FK_ProductRatingImages_ProductRatings_ProductRatingId",
                        column: x => x.ProductRatingId,
                        principalTable: "ProductRatings",
                        principalColumn: "ProductRatingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AuctionEvents",
                columns: new[] { "AuctionEventId", "AuctionEventDateEnd", "AuctionEventDateStart", "AuctionEventDescription", "AuctionEventStartingBid", "AuctionEventTitle", "Deleted", "HasEnded", "HasStarted", "IsActive", "ProductConditionId", "UserId" },
                values: new object[] { 1L, new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7895), new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7894), "Maxsun B660M iCraft Wifi Motherboard - New", 8000.99m, "Maxsun B660M iCraft Wifi", false, false, false, true, 1, 1 });

            migrationBuilder.InsertData(
                table: "CommunityPostTypes",
                columns: new[] { "CommunityPostTypeId", "CommunityPostTypeName", "IsActive" },
                values: new object[,]
                {
                    { 1L, "Books", true },
                    { 2L, "Clothings", true },
                    { 3L, "Electronics", true },
                    { 4L, "Jewelries", true },
                    { 5L, "Paintings", true },
                    { 6L, "Tools", true },
                    { 7L, "Bags", true },
                    { 8L, "Others", true },
                    { 9L, "Help", true }
                });

            migrationBuilder.InsertData(
                table: "CommunityPosts",
                columns: new[] { "CommunityPostId", "CommunityPostTitle", "CommunityPostType", "IsActive", "IsRead", "ThreadStaterUserId" },
                values: new object[,]
                {
                    { 1L, "Cheapest Bags I could find (Steal)", 7L, true, false, 1 },
                    { 2L, "My Items refuse to go into cart help!", 9L, true, false, 2 }
                });

            migrationBuilder.InsertData(
                table: "Conversations",
                columns: new[] { "ConversationId", "ConversationTitle", "CreatedById", "DateCreated", "IsActive", "IsRead", "ProductId", "ReceiverId" },
                values: new object[] { 1L, "Intel ARC a380", 2, new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7751), true, false, 1L, 1 });

            migrationBuilder.InsertData(
                table: "Dimensions",
                columns: new[] { "DimensionsModelId", "DimensionsModelName", "DimensionsModelShortName" },
                values: new object[,]
                {
                    { 1, "inches", "in" },
                    { 2, "feet", "ft" },
                    { 3, "centimeters", "cm" },
                    { 4, "millimeters", "mm" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "GenderName" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "GovernmentTypeIds",
                columns: new[] { "GovernmentIdentificationId", "GovIdName", "GovIdShortName", "isActive" },
                values: new object[,]
                {
                    { 1, "Philippine Passport", "DFA", true },
                    { 2, "Social Security System", "SSS", true },
                    { 3, "Government Service Insurance System", "GSIS", true },
                    { 4, "Unified Multi-Purpose Identification", "UMID", true },
                    { 5, "Driver’s License", "LTO", true },
                    { 6, "Professional Regulatory Commission", "PRC", true },
                    { 7, "Professional Regulatory Commission", "Voter’s ID", true },
                    { 8, "School ID", "", true }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "ProductCategoryId", "IsActive", "ProductCategoryDescription", "ProductCategoryName" },
                values: new object[,]
                {
                    { 1, true, "Books", "Books" },
                    { 2, true, "Clothings", "Clothings" },
                    { 3, true, "Electronics", "Electronics" },
                    { 4, true, "Jewelries", "Jewelries" },
                    { 5, true, "Paintings", "Paintings" },
                    { 6, true, "Tools", "Tools" },
                    { 7, true, "Bags", "Bags" }
                });

            migrationBuilder.InsertData(
                table: "ProductConditions",
                columns: new[] { "ProductConditionId", "IsActive", "ProductConditionName" },
                values: new object[,]
                {
                    { 1, true, "New" },
                    { 2, true, "Used - Like New" },
                    { 3, true, "Used - Good" },
                    { 4, true, "Used - Fair" }
                });

            migrationBuilder.InsertData(
                table: "ProductStatuses",
                columns: new[] { "ProductStatusId", "IsActive", "ProductStatusName" },
                values: new object[,]
                {
                    { 1, true, "Active" },
                    { 2, true, "Sold" },
                    { 3, true, "Deleted" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "AdminRemarks", "DateCreated", "DimensionModelId", "Height", "IsActive", "IsSale", "Length", "ProductCategoryId", "ProductConditionId", "ProductDescription", "ProductListedAs", "ProductName", "ProductPrice", "ProductRanking", "ProductRating", "ProductStatusId", "ProductStockCount", "SaleAmt", "UserId", "Weight", "WeightModelId", "Width" },
                values: new object[,]
                {
                    { 1L, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 51m, true, false, 276m, 3, 1, "Intel Arc Alchemist A380 is Intel’s first desktop graphics card in the lineup", 0, "Intel ARC a380", 20000.99m, 1, 5, 1, 50, 0.0m, 1, 5.09m, 3, 131m },
                    { 2L, "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 51m, true, false, 276m, 2, 1, "Assorted Clothes", 0, "Assorted Clothing", 500.99m, 1, 5, 1, 10, 0.0m, 1, 5.09m, 3, 131m }
                });

            migrationBuilder.InsertData(
                table: "ProductsListedAs",
                columns: new[] { "ProductListedAsId", "IsActive", "ProductListedAsName" },
                values: new object[,]
                {
                    { 1, true, "Single Item" },
                    { 2, true, "In Stock" }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "TypeName" },
                values: new object[,]
                {
                    { 1, "Super Admin" },
                    { 2, "Admin" },
                    { 3, "Seller" },
                    { 4, "Buyer" }
                });

            migrationBuilder.InsertData(
                table: "Weights",
                columns: new[] { "WeightModelId", "WeightModelName", "WeightModelShortName" },
                values: new object[,]
                {
                    { 1, "kilogram", "kg" },
                    { 2, "milligram", "mg" },
                    { 3, "pounds", "lbs" }
                });

            migrationBuilder.InsertData(
                table: "AuctionEventParticipants",
                columns: new[] { "AuctionEventParticipantId", "AuctionEventId", "IsActive", "IsBanned", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, true, false, 1 },
                    { 2L, 1L, true, false, 2 }
                });

            migrationBuilder.InsertData(
                table: "AuctionMessages",
                columns: new[] { "AuctionMessageId", "AuctionBidAmt", "AuctionEventId", "DateSent", "IsActive", "IsBanned", "IsBidWinner", "IsRead", "MessageContent", "SenderId" },
                values: new object[,]
                {
                    { 1L, 1000.99m, 1L, new DateTime(2022, 12, 6, 8, 8, 21, 150, DateTimeKind.Local).AddTicks(7996), true, false, false, false, "I bid for", 1 },
                    { 2L, 1100.99m, 1L, new DateTime(2022, 12, 6, 8, 9, 21, 150, DateTimeKind.Local).AddTicks(8024), true, false, false, false, "This is my bid", 2 },
                    { 3L, 1500.99m, 1L, new DateTime(2022, 12, 6, 8, 10, 21, 150, DateTimeKind.Local).AddTicks(8036), true, false, false, false, "Upping it to", 1 }
                });

            migrationBuilder.InsertData(
                table: "AuctionProductImages",
                columns: new[] { "AuctionProductImageId", "AuctionEventId", "AuctionProductImageData", "AuctionProductImageTitle", "AuctionProductImageUrl", "IsActive" },
                values: new object[,]
                {
                    { 1L, 1L, "", "Maxsun B660M iCraft Wifi", "https://x0.ifengimg.com/res/2022/16FC76B2979CE52987FBC116504BC8B551B84A6A_size79_w640_h480.jpeg", true },
                    { 2L, 1L, "", "Maxsun B660M iCraft Wifi", "https://www.alitrade.com.my/image/alitrade/image/data/all_product_images/product-311/eCvSpxzh1661177257.jpg", true },
                    { 3L, 1L, "", "Maxsun B660M iCraft Wifi", "https://media.karousell.com/media/photos/products/2022/9/18/maxsun_ms_b660m_icraft_wifi_mo_1663474563_96b660d4.jpg", true }
                });

            migrationBuilder.InsertData(
                table: "CommunityMessages",
                columns: new[] { "CommunityMessageId", "CommunityPostId", "IsActive", "IsRead", "MessageContent", "SenderId" },
                values: new object[,]
                {
                    { 1L, 1L, true, false, "Found this really cool Jansport bag on the website and its cheap and still in really good shape link: www.Link.Jansport.com\r\n\r\n", 1 },
                    { 2L, 2L, true, false, "Good day everyone. I was just browsing on this lovely website until I saw This Item that really caught my attention. When I tried to add it to card it Wouldnt come through. Any help would be appreciated thanks!", 1 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "ConversationId", "DateSent", "ImageData", "IsActive", "IsRead", "MessageContent", "SenderId" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7816), "", true, false, "Hello", 2 },
                    { 2L, 1L, new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7835), "", true, false, "Yes?", 1 },
                    { 3L, 1L, new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7848), "", true, false, "Still available?", 2 },
                    { 4L, 1L, new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7860), "", true, false, "Yes, it is available", 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ProductImageId", "IsActive", "ProductDataImage", "ProductId", "ProductImageDescription", "ProductImageLocation", "ProductImageTitle" },
                values: new object[,]
                {
                    { 1L, true, "", 1L, "Intel ARC a380 new GPU", "https://i2.wp.com/img.phonandroid.com/2022/07/Intro.jpg?resize=780,470", "Intel ARC a380" },
                    { 2L, true, "", 1L, "Intel ARC a380 new GPU", "https://www.digitaltrends.com/wp-content/uploads/2022/06/GUNNINR-A380-2.jpg?p=1", "Intel ARC a380" },
                    { 3L, true, "", 2L, "Assorted Clothing", "https://phshirt.com/wp-content/uploads/2021/02/T-Shirts.jpg", "Assorted Clothing" },
                    { 4L, true, "", 2L, "Assorted Clothing", "https://assets.designhill.com/resize_img.php?atyp=st_page_file&pth=ft_bt_thlcirlblirirb_org||BT23240||two_heading_left_content_image_right_link_button_left_image_right_info_right_button_left_image_img&flp=1630672410-6836666936132161a1709e3-51899622.png", "Assorted Clothing 1" }
                });

            migrationBuilder.InsertData(
                table: "ProductRatings",
                columns: new[] { "ProductRatingId", "DateCreated", "ProductId", "ProductRatingComment", "ProductRatingDescription", "ProductRatingGrade", "UserId", "isActive" },
                values: new object[,]
                {
                    { 1L, new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7287), 1L, "Brand new. User is very kind and responds immediately. Thank you.", "", 5, 1, true },
                    { 2L, new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7368), 1L, "Brand new. Intel GPU.", "", 4, 1, true },
                    { 3L, new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7383), 1L, "Thank you.", "", 4, 1, true },
                    { 4L, new DateTime(2022, 12, 6, 8, 7, 21, 150, DateTimeKind.Local).AddTicks(7396), 2L, "Thank you. The clothes were clean and as good as new", "", 4, 2, true }
                });

            migrationBuilder.InsertData(
                table: "ProductRatingImages",
                columns: new[] { "ProductRatingImageId", "IsActive", "ProductRatingId", "ProductRatingImageData", "ProductRatingImageLocation", "ProductRatingImageName" },
                values: new object[,]
                {
                    { 1L, true, 1L, "", "https://i.ytimg.com/vi/5AzlmyXkKh8/maxresdefault.jpg", "rating image 1" },
                    { 2L, true, 1L, "", "https://i.ytimg.com/vi/UZ0oE4AVu8w/maxresdefault.jpg", "rating image 2" },
                    { 3L, true, 1L, "", "https://i.ytimg.com/vi/G_x3b7FHGuI/maxresdefault.jpg", "rating image 3" },
                    { 4L, true, 2L, "", "https://techviral.net/wp-content/uploads/2022/06/Intel-Arc-380-Graphics-Card-Specifications.jpg", "rating image 4" },
                    { 5L, true, 2L, "", "https://pc.watch.impress.co.jp/img/pcw/docs/1430/766/a01_l.jpg", "rating image 5" },
                    { 6L, true, 3L, "", "https://static.techspot.com/articles-info/2510/images/intel-arc-4.jpg", "rating image 6" },
                    { 7L, true, 4L, "", "https://ichef.bbci.co.uk/news/640/cpsprodpb/10B12/production/_126607386_infinitedfibersclothesexamples.jpg", "Clothes Images assorted" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionEventParticipants_AuctionEventId",
                table: "AuctionEventParticipants",
                column: "AuctionEventId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionMessages_AuctionEventId",
                table: "AuctionMessages",
                column: "AuctionEventId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionProductImages_AuctionEventId",
                table: "AuctionProductImages",
                column: "AuctionEventId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityFileAttachments_CommunityMessageId",
                table: "CommunityFileAttachments",
                column: "CommunityMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityImages_CommunityMessageId",
                table: "CommunityImages",
                column: "CommunityMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityMessages_CommunityPostId",
                table: "CommunityMessages",
                column: "CommunityPostId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunityPostsRatings_CommunityPostId",
                table: "CommunityPostsRatings",
                column: "CommunityPostId");

            migrationBuilder.CreateIndex(
                name: "IX_LiveSellingImages_LiveSellingId",
                table: "LiveSellingImages",
                column: "LiveSellingId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ConversationId",
                table: "Messages",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRatingImages_ProductRatingId",
                table: "ProductRatingImages",
                column: "ProductRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRatings_ProductId",
                table: "ProductRatings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserValidationImages_UserId",
                table: "UserValidationImages",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionEventParticipants");

            migrationBuilder.DropTable(
                name: "AuctionMessages");

            migrationBuilder.DropTable(
                name: "AuctionProductImages");

            migrationBuilder.DropTable(
                name: "CommunityFileAttachments");

            migrationBuilder.DropTable(
                name: "CommunityImages");

            migrationBuilder.DropTable(
                name: "CommunityPostsRatings");

            migrationBuilder.DropTable(
                name: "CommunityPostTypes");

            migrationBuilder.DropTable(
                name: "Dimensions");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "GovernmentTypeIds");

            migrationBuilder.DropTable(
                name: "LiveSellingImages");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductConditions");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductRatingImages");

            migrationBuilder.DropTable(
                name: "ProductsListedAs");

            migrationBuilder.DropTable(
                name: "ProductStatuses");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "UserValidationImages");

            migrationBuilder.DropTable(
                name: "Weights");

            migrationBuilder.DropTable(
                name: "AuctionEvents");

            migrationBuilder.DropTable(
                name: "CommunityMessages");

            migrationBuilder.DropTable(
                name: "LiveSellings");

            migrationBuilder.DropTable(
                name: "Conversations");

            migrationBuilder.DropTable(
                name: "ProductRatings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CommunityPosts");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
