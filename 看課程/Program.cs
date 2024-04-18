using MongoD;
using 看課程.Services.Identity;
using Service.Identity.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


//== ▼cors▼ ===
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost5500",
        policy => policy.WithOrigins("http://127.0.0.1:5500")  
                        .AllowAnyMethod()  // 允許任何 HTTP 方法
                        .AllowAnyHeader());  // 允許任何標頭
});
//== ▲cors▲ ===
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,  
        ValidateAudience = false, 
        ValidateLifetime = true,  
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("refreshToken_secretKey_testtesttest_22222222222222222")),
        ClockSkew = TimeSpan.Zero

    };
});

builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings")
);
builder.Services.AddSingleton<IIdentityService, IdentityService>();
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
app.UseAuthentication(); // jwt
app.UseAuthorization();
app.MapControllers();

app.Run();
