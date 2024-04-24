using MongoD;
using 看課程.Services.Identity;
using Service.Identity.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using 看課程.Extensions;
using MongoDB.Driver;
using 看課程.DataAccess.Identity.Interface;
using 看課程.DataAccess.Identity;
using 看課程.Repositories.Interfaces;
using 看課程.Repositories;


var builder = WebApplication.CreateBuilder(args);


//== ▼cors▼ ===
//您所展示的两段代码中都使用了“options”这一术语
//，这实际上是ASP.NET Core框架中一个常见的配置模式。
//这种模式通常用于在服务注册（ConfigureServices 方法中）
//和中间件配置（Configure 方法中）时设置各种选项。
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowLocalhost5500",
//        policy => policy.WithOrigins("http://127.0.0.1:5500")  
//                        .AllowAnyMethod()  // 允許任何 HTTP 方法
//                        .AllowAnyHeader());  // 允許任何標頭
//});
builder.Services.AddCorsConfiguration();

//== ▲cors▲ ===


//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = false,  
//        ValidateAudience = false, 
//        ValidateLifetime = true,  
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("refreshToken_secretKey_testtesttest_22222222222222222")),
//        ClockSkew = TimeSpan.Zero

//    };
//});
builder.Services.AddJwtAuthentication("refreshToken_secretKey_testtesttest_22222222222222222");



builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings")
);



// 配置授权
//-----------------------------------------
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("ReqRole",
//        policy => policy.RequireRole("Administrator"));
//});
builder.Services.AddCustomAuthorization();

//-----------------------------------------


builder.Services.AddSingleton<IUserToDbRepository, UserToDbRepository>();
builder.Services.AddSingleton<IIdentityDataAccess, IdentityDataAccess>();
builder.Services.AddSingleton<IIdentityService, IdentityService>();


//===============================

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//===============================



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage(); // ?

}
app.UseRouting();
app.UseCors("AllowLocalhost5500");
app.UseHttpsRedirection();

//---
app.UseAuthentication(); // jwt
app.UseAuthorization();
//驗證 (Authentication)就是讓系統認得你是誰
//授權 (Authorization)讓系統判斷你是否有權限
//---

app.MapControllers();

app.Run();
