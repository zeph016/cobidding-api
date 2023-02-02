
using Cobid.Api.Entities.Community;

namespace Cobid.Api.Data
{
    public class CobidDbContext : DbContext
    {
        public CobidDbContext(DbContextOptions<CobidDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<LiveSelling>().HasKey(ls => new { ls.UserId });

            //modelBuilder.Entity<User>().HasData(new User()
            //{
            //    UserId = 1,
            //    FirstName = "test",
            //    MiddleName = "test",
            //    LastName = "test",
            //    NameExtension = string.Empty,
            //    DateOfBirth = Convert.ToDateTime("01/01/2000"),
            //    UserName = "JohnDoe",
            //    Email = "email@email.com",
            //    PasswordHash = "password1234",
            //    UserTypeId = 1,
            //    GenderId = 1,
            //    CreatedTimeSpan = DateTime.Now,
            //    UpdatedTimeSpan = DateTime.Now,
            //    Address = "Iloilo City",
            //    Phone = "033-3333",
            //    ShipppingAddress = "Iloilo City",
            //    ValidationId = 1,
            //    CommunityId = 1,
            //    UserProfilePic = "",
            //    IsActive = true
            //});

            //Gender model builder
            modelBuilder.Entity<Gender>().HasData(new Gender()
            {
                GenderId = 1,
                GenderName = "Male"
            });
            modelBuilder.Entity<Gender>().HasData(new Gender()
            {
                GenderId = 2,
                GenderName = "Female"
            });
            modelBuilder.Entity<Gender>().HasData(new Gender()
            {
                GenderId = 3,
                GenderName = "Other"
            });

            //Products model builder
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 1,
                UserId = 1,
                ProductName = "Intel ARC a380",
                ProductDescription = "Intel Arc Alchemist A380 is Intel’s first desktop graphics card in the lineup",
                ProductCategoryId = 3,
                ProductPrice = 20000.99M,
                ProductConditionId = 1,
                Length = 276,
                Width = 131,
                Height = 51,
                DimensionModelId = 4,
                Weight = 5.09m,
                WeightModelId = 3,
                ProductRanking = 1,
                ProductStatusId = 1,
                ProductRating = 5,
                ProductStockCount = 50,
                IsActive = true,
                IsSale = false,
                SaleAmt = 0.0M,
                AdminRemarks = string.Empty
            });
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                ProductId = 2,
                UserId = 1,
                ProductName = "Assorted Clothing",
                ProductDescription = "Assorted Clothes",
                ProductCategoryId = 2,
                ProductPrice = 500.99M,
                ProductConditionId = 1,
                Length = 276,
                Width = 131,
                Height = 51,
                DimensionModelId = 4,
                Weight = 5.09m,
                WeightModelId = 3,
                ProductRanking = 1,
                ProductStatusId = 1,
                ProductRating = 5,
                ProductStockCount = 10,
                IsActive = true,
                IsSale = false,
                SaleAmt = 0.0M,
                AdminRemarks = string.Empty
            });

            //Products Image model builder
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage()
            {
                ProductImageId = 1,
                ProductId = 1,
                ProductImageLocation = "https://i2.wp.com/img.phonandroid.com/2022/07/Intro.jpg?resize=780,470",
                ProductImageTitle = "Intel ARC a380",
                ProductImageDescription = "Intel ARC a380 new GPU",
                IsActive = true
            }); ;
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage()
            {
                ProductImageId = 2,
                ProductId = 1,
                ProductImageLocation = "https://www.digitaltrends.com/wp-content/uploads/2022/06/GUNNINR-A380-2.jpg?p=1",
                ProductImageTitle = "Intel ARC a380",
                ProductImageDescription = "Intel ARC a380 new GPU",
                IsActive = true
            });
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage()
            {
                ProductImageId = 3,
                ProductId = 2,
                ProductImageLocation = "https://phshirt.com/wp-content/uploads/2021/02/T-Shirts.jpg",
                ProductImageTitle = "Assorted Clothing",
                ProductImageDescription = "Assorted Clothing",
                IsActive = true
            }); ;
            modelBuilder.Entity<ProductImage>().HasData(new ProductImage()
            {
                ProductImageId = 4,
                ProductId = 2,
                ProductImageLocation = "https://assets.designhill.com/resize_img.php?atyp=st_page_file&pth=ft_bt_thlcirlblirirb_org||BT23240||two_heading_left_content_image_right_link_button_left_image_right_info_right_button_left_image_img&flp=1630672410-6836666936132161a1709e3-51899622.png",
                ProductImageTitle = "Assorted Clothing 1",
                ProductImageDescription = "Assorted Clothing",
                IsActive = true
            });

            //Product Condition model builder
            modelBuilder.Entity<ProductCondition>().HasData(new ProductCondition()
            {
                ProductConditionId = 1,
                ProductConditionName = "New",
                IsActive = true
            });
            modelBuilder.Entity<ProductCondition>().HasData(new ProductCondition()
            {
                ProductConditionId = 2,
                ProductConditionName = "Used - Like New",
                IsActive = true
            });
            modelBuilder.Entity<ProductCondition>().HasData(new ProductCondition()
            {
                ProductConditionId = 3,
                ProductConditionName = "Used - Good",
                IsActive = true
            });
            modelBuilder.Entity<ProductCondition>().HasData(new ProductCondition()
            {
                ProductConditionId = 4,
                ProductConditionName = "Used - Fair",
                IsActive = true
            });
            //Product Category model builder
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory()
            {
                ProductCategoryId = 1,
                ProductCategoryName = "Books",
                ProductCategoryDescription = "Books",
                IsActive = true
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory()
            {
                ProductCategoryId = 2,
                ProductCategoryName = "Clothings",
                ProductCategoryDescription = "Clothings",
                IsActive = true
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory()
            {
                ProductCategoryId = 3,
                ProductCategoryName = "Electronics",
                ProductCategoryDescription = "Electronics",
                IsActive = true
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory()
            {
                ProductCategoryId = 4,
                ProductCategoryName = "Jewelries",
                ProductCategoryDescription = "Jewelries",
                IsActive = true
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory()
            {
                ProductCategoryId = 5,
                ProductCategoryName = "Paintings",
                ProductCategoryDescription = "Paintings",
                IsActive = true
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory()
            {
                ProductCategoryId = 6,
                ProductCategoryName = "Tools",
                ProductCategoryDescription = "Tools",
                IsActive = true
            });
            modelBuilder.Entity<ProductCategory>().HasData(new ProductCategory()
            {
                ProductCategoryId = 7,
                ProductCategoryName = "Bags",
                ProductCategoryDescription = "Bags",
                IsActive = true
            });

            //Product listed as model builder
            modelBuilder.Entity<ProductListedAs>().HasData(new ProductListedAs()
            {
                ProductListedAsId = 1,
                ProductListedAsName = "Single Item",
                IsActive = true
            });
            modelBuilder.Entity<ProductListedAs>().HasData(new ProductListedAs()
            {
                ProductListedAsId = 2,
                ProductListedAsName = "In Stock",
                IsActive = true
            });

            //Product Statuses model builder
            modelBuilder.Entity<ProductStatus>().HasData(new ProductStatus()
            {
                ProductStatusId = 1,
                ProductStatusName = "Active",
                IsActive = true
            });
            modelBuilder.Entity<ProductStatus>().HasData(new ProductStatus()
            {
                ProductStatusId = 2,
                ProductStatusName = "Sold",
                IsActive = true
            });
            modelBuilder.Entity<ProductStatus>().HasData(new ProductStatus()
            {
                ProductStatusId = 3,
                ProductStatusName = "Deleted",
                IsActive = true
            });

            //Product Rating model builder
            modelBuilder.Entity<ProductRating>().HasData(new ProductRating()
            {
                ProductRatingId = 1,
                UserId = 1,
                ProductId = 1,
                ProductRatingDescription = string.Empty,
                ProductRatingGrade = 5,
                ProductRatingComment = "Brand new. User is very kind and responds immediately. Thank you.",
                DateCreated = DateTime.Now,
                isActive = true
            });
            modelBuilder.Entity<ProductRating>().HasData(new ProductRating()
            {
                ProductRatingId = 2,
                UserId = 1,
                ProductId = 1,
                ProductRatingDescription = string.Empty,
                ProductRatingGrade = 4,
                ProductRatingComment = "Brand new. Intel GPU.",
                DateCreated = DateTime.Now,
                isActive = true
            });
            modelBuilder.Entity<ProductRating>().HasData(new ProductRating()
            {
                ProductRatingId = 3,
                UserId = 1,
                ProductId = 1,
                ProductRatingDescription = string.Empty,
                ProductRatingGrade = 4,
                ProductRatingComment = "Thank you.",
                DateCreated = DateTime.Now,
                isActive = true
            });
            modelBuilder.Entity<ProductRating>().HasData(new ProductRating()
            {
                ProductRatingId = 4,
                UserId = 2,
                ProductId = 2,
                ProductRatingDescription = string.Empty,
                ProductRatingGrade = 4,
                ProductRatingComment = "Thank you. The clothes were clean and as good as new",
                DateCreated = DateTime.Now,
                isActive = true
            });

            //Product Rating Image model builder
            modelBuilder.Entity<ProductRatingImage>().HasData(new ProductRatingImage()
            {
                ProductRatingImageId = 1,
                ProductRatingId = 1,
                ProductRatingImageName = "rating image 1",
                ProductRatingImageLocation = "https://i.ytimg.com/vi/5AzlmyXkKh8/maxresdefault.jpg",
                ProductRatingImageData = "",
                IsActive = true
            });
            modelBuilder.Entity<ProductRatingImage>().HasData(new ProductRatingImage()
            {
                ProductRatingImageId = 2,
                ProductRatingId = 1,
                ProductRatingImageName = "rating image 2",
                ProductRatingImageLocation = "https://i.ytimg.com/vi/UZ0oE4AVu8w/maxresdefault.jpg",
                ProductRatingImageData = "",
                IsActive = true
            });
            modelBuilder.Entity<ProductRatingImage>().HasData(new ProductRatingImage()
            {
                ProductRatingImageId = 3,
                ProductRatingId = 1,
                ProductRatingImageName = "rating image 3",
                ProductRatingImageLocation = "https://i.ytimg.com/vi/G_x3b7FHGuI/maxresdefault.jpg",
                ProductRatingImageData = "",
                IsActive = true
            });
            modelBuilder.Entity<ProductRatingImage>().HasData(new ProductRatingImage()
            {
                ProductRatingImageId = 4,
                ProductRatingId = 2,
                ProductRatingImageName = "rating image 4",
                ProductRatingImageLocation = "https://techviral.net/wp-content/uploads/2022/06/Intel-Arc-380-Graphics-Card-Specifications.jpg",
                ProductRatingImageData = "",
                IsActive = true
            });
            modelBuilder.Entity<ProductRatingImage>().HasData(new ProductRatingImage()
            {
                ProductRatingImageId = 5,
                ProductRatingId = 2,
                ProductRatingImageName = "rating image 5",
                ProductRatingImageLocation = "https://pc.watch.impress.co.jp/img/pcw/docs/1430/766/a01_l.jpg",
                ProductRatingImageData = "",
                IsActive = true
            });
            modelBuilder.Entity<ProductRatingImage>().HasData(new ProductRatingImage()
            {
                ProductRatingImageId = 6,
                ProductRatingId = 3,
                ProductRatingImageName = "rating image 6",
                ProductRatingImageLocation = "https://static.techspot.com/articles-info/2510/images/intel-arc-4.jpg",
                ProductRatingImageData = "",
                IsActive = true
            });
            modelBuilder.Entity<ProductRatingImage>().HasData(new ProductRatingImage()
            {
                ProductRatingImageId = 7,
                ProductRatingId = 4,
                ProductRatingImageName = "Clothes Images assorted",
                ProductRatingImageLocation = "https://ichef.bbci.co.uk/news/640/cpsprodpb/10B12/production/_126607386_infinitedfibersclothesexamples.jpg",
                ProductRatingImageData = "",
                IsActive = true
            });

            //Weight model builder
            modelBuilder.Entity<WeightModel>().HasData(new WeightModel()
            {
                WeightModelId = 1,
                WeightModelName = "kilogram",
                WeightModelShortName = "kg"
            });
            modelBuilder.Entity<WeightModel>().HasData(new WeightModel()
            {
                WeightModelId = 2,
                WeightModelName = "milligram",
                WeightModelShortName = "mg"
            });
            modelBuilder.Entity<WeightModel>().HasData(new WeightModel()
            {
                WeightModelId = 3,
                WeightModelName = "pounds",
                WeightModelShortName = "lbs"
            });

            //Dimension model builder
            modelBuilder.Entity<DimensionsModel>().HasData(new DimensionsModel()
            {
                DimensionsModelId = 1,
                DimensionsModelName = "inches",
                DimensionsModelShortName = "in"
            });
            modelBuilder.Entity<DimensionsModel>().HasData(new DimensionsModel()
            {
                DimensionsModelId = 2,
                DimensionsModelName = "feet",
                DimensionsModelShortName = "ft"
            });
            modelBuilder.Entity<DimensionsModel>().HasData(new DimensionsModel()
            {
                DimensionsModelId = 3,
                DimensionsModelName = "centimeters",
                DimensionsModelShortName = "cm"
            });
            modelBuilder.Entity<DimensionsModel>().HasData(new DimensionsModel()
            {
                DimensionsModelId = 4,
                DimensionsModelName = "millimeters",
                DimensionsModelShortName = "mm"
            });

            //User Type model builder
            modelBuilder.Entity<UserType>().HasData(new UserType()
            {
                UserTypeId = 1,
                TypeName = "Super Admin"
            });
            modelBuilder.Entity<UserType>().HasData(new UserType()
            {
                UserTypeId = 2,
                TypeName = "Admin"
            });
            modelBuilder.Entity<UserType>().HasData(new UserType()
            {
                UserTypeId = 3,
                TypeName = "Seller"
            });
            modelBuilder.Entity<UserType>().HasData(new UserType()
            {
                UserTypeId = 4,
                TypeName = "Buyer"
            });

            //Government Id type builder
            modelBuilder.Entity<GovernmentIdentification>().HasData(new GovernmentIdentification()
            {
                GovernmentIdentificationId = 1,
                GovIdName = "Philippine Passport",
                GovIdShortName = "DFA",
                isActive = true
            });
            modelBuilder.Entity<GovernmentIdentification>().HasData(new GovernmentIdentification()
            {
                GovernmentIdentificationId = 2,
                GovIdName = "Social Security System",
                GovIdShortName = "SSS",
                isActive = true
            });
            modelBuilder.Entity<GovernmentIdentification>().HasData(new GovernmentIdentification()
            {
                GovernmentIdentificationId = 3,
                GovIdName = "Government Service Insurance System",
                GovIdShortName = "GSIS",
                isActive = true
            });
            modelBuilder.Entity<GovernmentIdentification>().HasData(new GovernmentIdentification()
            {
                GovernmentIdentificationId = 4,
                GovIdName = "Unified Multi-Purpose Identification",
                GovIdShortName = "UMID",
                isActive = true
            });
            modelBuilder.Entity<GovernmentIdentification>().HasData(new GovernmentIdentification()
            {
                GovernmentIdentificationId = 5,
                GovIdName = "Driver’s License",
                GovIdShortName = "LTO",
                isActive = true
            });
            modelBuilder.Entity<GovernmentIdentification>().HasData(new GovernmentIdentification()
            {
                GovernmentIdentificationId = 6,
                GovIdName = "Professional Regulatory Commission",
                GovIdShortName = "PRC",
                isActive = true
            });
            modelBuilder.Entity<GovernmentIdentification>().HasData(new GovernmentIdentification()
            {
                GovernmentIdentificationId = 7,
                GovIdName = "Professional Regulatory Commission",
                GovIdShortName = "Voter’s ID",
                isActive = true
            });
            modelBuilder.Entity<GovernmentIdentification>().HasData(new GovernmentIdentification()
            {
                GovernmentIdentificationId = 8,
                GovIdName = "School ID",
                GovIdShortName = "",
                isActive = true
            });

            //Conversation builder
            modelBuilder.Entity<Conversation>().HasData(new Conversation()
            {
                ConversationId = 1,
                ProductId = 1,
                CreatedById = 2,
                ReceiverId = 1,
                DateCreated = DateTime.Now,
                ConversationTitle = "Intel ARC a380",
                IsRead = false,
                IsActive = true
            });

            //Message builder
            modelBuilder.Entity<Message>().HasData(new Message()
            {
                MessageId = 1,
                ConversationId = 1,
                SenderId = 2,
                MessageContent = "Hello",
                ImageData = string.Empty,
                DateSent = DateTime.Now,
                IsRead = false,
                IsActive = true
            });
            modelBuilder.Entity<Message>().HasData(new Message()
            {
                MessageId = 2,
                ConversationId = 1,
                SenderId = 1,
                MessageContent = "Yes?",
                ImageData = string.Empty,
                DateSent = DateTime.Now,
                IsRead = false,
                IsActive = true
            });
            modelBuilder.Entity<Message>().HasData(new Message()
            {
                MessageId = 3,
                ConversationId = 1,
                SenderId = 2,
                MessageContent = "Still available?",
                ImageData = string.Empty,
                DateSent = DateTime.Now,
                IsRead = false,
                IsActive = true
            });
            modelBuilder.Entity<Message>().HasData(new Message()
            {
                MessageId = 4,
                ConversationId = 1,
                SenderId = 1,
                MessageContent = "Yes, it is available",
                ImageData = string.Empty,
                DateSent = DateTime.Now,
                IsRead = false,
                IsActive = true
            });

            //Auction Event builder
            modelBuilder.Entity<AuctionEvent>().HasData(new AuctionEvent()
            {
                AuctionEventId = 1,
                UserId = 1,
                AuctionEventTitle = "Maxsun B660M iCraft Wifi",
                AuctionEventDescription = "Maxsun B660M iCraft Wifi Motherboard - New",
                AuctionEventStartingBid = 8000.99M,
                AuctionEventDateStart = DateTime.Now,
                AuctionEventDateEnd = DateTime.Now,
                ProductConditionId = 1,
                IsActive = true,
                HasEnded = false,
                HasStarted = false,
                Deleted = false
            });
            //AuctionEvent images builder
            modelBuilder.Entity<AuctionProductImage>().HasData(new AuctionProductImage()
            {
                AuctionProductImageId = 1,
                AuctionEventId = 1,
                AuctionProductImageTitle = "Maxsun B660M iCraft Wifi",
                AuctionProductImageUrl = "https://x0.ifengimg.com/res/2022/16FC76B2979CE52987FBC116504BC8B551B84A6A_size79_w640_h480.jpeg",
                AuctionProductImageData = "",
                IsActive = true
            });
            modelBuilder.Entity<AuctionProductImage>().HasData(new AuctionProductImage()
            {
                AuctionProductImageId = 2,
                AuctionEventId = 1,
                AuctionProductImageTitle = "Maxsun B660M iCraft Wifi",
                AuctionProductImageUrl = "https://www.alitrade.com.my/image/alitrade/image/data/all_product_images/product-311/eCvSpxzh1661177257.jpg",
                AuctionProductImageData = "",
                IsActive = true
            });
            modelBuilder.Entity<AuctionProductImage>().HasData(new AuctionProductImage()
            {
                AuctionProductImageId = 3,
                AuctionEventId = 1,
                AuctionProductImageTitle = "Maxsun B660M iCraft Wifi",
                AuctionProductImageUrl = "https://media.karousell.com/media/photos/products/2022/9/18/maxsun_ms_b660m_icraft_wifi_mo_1663474563_96b660d4.jpg",
                AuctionProductImageData = "",
                IsActive = true
            });
            //AuctionEvent participants builder
            modelBuilder.Entity<AuctionEventParticipant>().HasData(new AuctionEventParticipant()
            {
                AuctionEventParticipantId = 1,
                AuctionEventId = 1,
                UserId = 1,
                IsActive = true,
                IsBanned = false
            });
            modelBuilder.Entity<AuctionEventParticipant>().HasData(new AuctionEventParticipant()
            {
                AuctionEventParticipantId = 2,
                AuctionEventId = 1,
                UserId = 2,
                IsActive = true,
                IsBanned = false
            });
            //AuctionEvent messages builder
            modelBuilder.Entity<AuctionMessage>().HasData(new AuctionMessage()
            {
                AuctionMessageId = 1,
                AuctionEventId = 1,
                SenderId = 1,
                MessageContent = "I bid for",
                AuctionBidAmt = 1000.99M,
                DateSent = DateTime.Now.AddMinutes(1),
                IsRead = false,
                IsBidWinner = false,
                IsActive = true,
                IsBanned = false
            });
            modelBuilder.Entity<AuctionMessage>().HasData(new AuctionMessage()
            {
                AuctionMessageId = 2,
                AuctionEventId = 1,
                SenderId = 2,
                MessageContent = "This is my bid",
                AuctionBidAmt = 1100.99M,
                DateSent = DateTime.Now.AddMinutes(2),
                IsRead = false,
                IsBidWinner = false,
                IsActive = true,
                IsBanned = false
            });
            modelBuilder.Entity<AuctionMessage>().HasData(new AuctionMessage()
            {
                AuctionMessageId = 3,
                AuctionEventId = 1,
                SenderId = 1,
                MessageContent = "Upping it to",
                AuctionBidAmt = 1500.99M,
                DateSent = DateTime.Now.AddMinutes(3),
                IsRead = false,
                IsBidWinner = false,
                IsActive = true,
                IsBanned = false
            });

            //Community Post builder
            modelBuilder.Entity<CommunityPost>().HasData(new CommunityPost()
            {
                CommunityPostId = 1,
                ThreadStaterUserId = 1,
                CommunityPostTitle = "Cheapest Bags I could find (Steal)",
                CommunityPostType = 7,
                DateCreated = DateTime.Now.AddMinutes(30),
                IsRead = false,
                IsActive = true
            });
            modelBuilder.Entity<CommunityPost>().HasData(new CommunityPost()
            {
                CommunityPostId = 2,
                ThreadStaterUserId = 2,
                CommunityPostTitle = "My Items refuse to go into cart help!",
                CommunityPostType = 9,
                DateCreated = DateTime.Now.AddMinutes(35),
                IsRead = false,
                IsActive = true
            });
            //Community Message Builder
            modelBuilder.Entity<CommunityMessage>().HasData(new CommunityMessage()
            {
                CommunityMessageId = 1,
                CommunityPostId = 1,
                SenderId = 1,
                MessageContent = "Found this really cool Jansport bag on the website and its cheap and still in really good shape link: www.Link.Jansport.com\r\n\r\n",
                DateSent = DateTime.Now.AddMinutes(30),
                IsRead = false,
                IsActive = true
            });
            modelBuilder.Entity<CommunityMessage>().HasData(new CommunityMessage()
            {
                CommunityMessageId = 2,
                CommunityPostId = 2,
                SenderId = 1,
                MessageContent = "Good day everyone. I was just browsing on this lovely website until I saw This Item that really caught my attention. When I tried to add it to card it Wouldnt come through. Any help would be appreciated thanks!",
                DateSent = DateTime.Now.AddMinutes(35),
                IsRead = false,
                IsActive = true
            });
            //Community Post Type Builder
            modelBuilder.Entity<CommunityPostType>().HasData(new CommunityPostType()
            {
                CommunityPostTypeId = 1,
                CommunityPostTypeName = "Books",
                IsActive = true
            });
            modelBuilder.Entity<CommunityPostType>().HasData(new CommunityPostType()
            {
                CommunityPostTypeId = 2,
                CommunityPostTypeName = "Clothings",
                IsActive = true
            });
            modelBuilder.Entity<CommunityPostType>().HasData(new CommunityPostType()
            {
                CommunityPostTypeId = 3,
                CommunityPostTypeName = "Electronics",
                IsActive = true
            });
            modelBuilder.Entity<CommunityPostType>().HasData(new CommunityPostType()
            {
                CommunityPostTypeId = 4,
                CommunityPostTypeName = "Jewelries",
                IsActive = true
            });
            modelBuilder.Entity<CommunityPostType>().HasData(new CommunityPostType()
            {
                CommunityPostTypeId = 5,
                CommunityPostTypeName = "Paintings",
                IsActive = true
            });
            modelBuilder.Entity<CommunityPostType>().HasData(new CommunityPostType()
            {
                CommunityPostTypeId = 6,
                CommunityPostTypeName = "Tools",
                IsActive = true
            });
            modelBuilder.Entity<CommunityPostType>().HasData(new CommunityPostType()
            {
                CommunityPostTypeId = 7,
                CommunityPostTypeName = "Bags",
                IsActive = true
            });
            modelBuilder.Entity<CommunityPostType>().HasData(new CommunityPostType()
            {
                CommunityPostTypeId = 8,
                CommunityPostTypeName = "Others",
                IsActive = true
            });
            modelBuilder.Entity<CommunityPostType>().HasData(new CommunityPostType()
            {
                CommunityPostTypeId = 9,
                CommunityPostTypeName = "Help",
                IsActive = true
            });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserValidationImage> UserValidationImages { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductCondition> ProductConditions { get; set; }
        public DbSet<ProductRating> ProductRatings { get; set; }
        public DbSet<ProductRatingImage> ProductRatingImages { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
        public DbSet<ProductListedAs> ProductsListedAs { get; set; }
        public DbSet<WeightModel> Weights { get; set; }
        public DbSet<DimensionsModel> Dimensions { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<LiveSelling> LiveSellings { get; set; }
        public DbSet<LiveSellingImage> LiveSellingImages { get; set; }
        public DbSet<AuctionEvent> AuctionEvents { get; set; }
        public DbSet<AuctionProductImage> AuctionProductImages { get; set; }
        public DbSet<AuctionEventParticipant> AuctionEventParticipants { get; set; }
        public DbSet<AuctionMessage> AuctionMessages { get; set; }
        public DbSet<GovernmentIdentification> GovernmentTypeIds { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<CommunityPost> CommunityPosts { get; set; }
        public DbSet<CommunityMessage> CommunityMessages { get; set; }
        public DbSet<CommunityImage> CommunityImages { get; set; }
        public DbSet<CommunityFileAttachment> CommunityFileAttachments { get; set; }
        public DbSet<CommunityPostRating> CommunityPostsRatings { get; set;}
        public DbSet<CommunityPostType> CommunityPostTypes { get; set; }
    }
}
