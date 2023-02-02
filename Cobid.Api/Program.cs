global using Microsoft.EntityFrameworkCore;
global using Cobid.Api.Connector;
global using Cobid.Api.Entities;
global using Cobid.Api.Entities.UserModel;
global using Cobid.Api.Entities.Images;
global using Cobid.Api.Entities.Product;
global using Cobid.Api.Entities.Measurement;
global using Cobid.Api.Entities.LiveSellingModels;
global using Cobid.Api.Entities.Auction;
global using Cobid.Api.Entities.Enums;
global using Cobid.Api.Entities.Messaging;
global using Cobid.Api.Entities.Community;
global using Cobid.Api.Data;
global using Cobid.Api.Services;
global using Cobid.Api.Services.AuctionService;
global using Cobid.Api.Services.AuthenticationService;
global using Cobid.Api.Services.CommunityService.CommunityPostService;
global using Cobid.Api.Services.CommunityService.CommunityMessageService;
global using Cobid.Api.Services.GenderService;
global using Cobid.Api.Services.LiveSellingService;
global using Cobid.Api.Services.ImageService;
global using Cobid.Api.Services.ImageService.AuctionProductImageService;
global using Cobid.Api.Services.ImageService.LiveSellingImageService;
global using Cobid.Api.Services.ImageService.ProductImageService;
global using Cobid.Api.Services.ImageService.ProductRatingImageService;
global using Cobid.Api.Services.MessagingServices.AuctionMessageService;
global using Cobid.Api.Services.MessagingServices.MessageService;
global using Cobid.Api.Services.MessagingServices.ConversationService;
global using Cobid.Api.Services.ProductService;
global using Cobid.Api.Services.RatingService;
global using Cobid.Api.Services.UserTypeService;
global using Cobid.Api.Services.UserService;
global using Cobid.Api.Services.EnumsService.GovernmentIdService;
global using Cobid.Api.Services.EnumsService.ProductListedAsService;
global using Cobid.Api.Services.EnumsService.ProductStatusService;
global using Cobid.Api.Services.EnumsService.ProductConditionService;
global using Cobid.Api.Services.EnumsService.ProductCategoryService;
global using Cobid.Api.Hubs;
global using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http.Connections;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextPool<CobidDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CobidDBConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = 
            new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IAuctionProductImageService, AuctionProductImageService>();
builder.Services.AddScoped<IAuctionParticipantService, AuctionParticipantService>();
builder.Services.AddScoped<IAuctionMessageService, AuctionMessageService>();
builder.Services.AddScoped<ICommunityPostService, CommunityPostService>();
builder.Services.AddScoped<ICommunityMessageService, CommunityMessageService>();
builder.Services.AddScoped<IConversationService, ConversationService>();
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IGovernmentIdService, GovernmentIdService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<ILiveSellingService, LiveSellingService>();
builder.Services.AddScoped<ILiveSellingImageService, LiveSellingImageService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductListedAsService, ProductListedAsService>();
builder.Services.AddScoped<IProductStatusService, ProductStatusService>();
builder.Services.AddScoped<IProductConditionService, ProductConditionService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IProductRatingImageService, ProductRatingImageService>();
builder.Services.AddScoped<IRatingService, RatingService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserTypeService, UserTypeService>();

builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", builder =>
     builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
});

builder.Services.AddRazorPages();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapHub<HubConnector>("/connector", options =>
//{
//    options.Transports =
//        HttpTransportType.WebSockets |
//        HttpTransportType.LongPolling;
//});
app.MapHub<HubConnector>("/connector");
app.UseCors("NewPolicy");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
