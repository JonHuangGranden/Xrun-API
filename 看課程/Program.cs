using MongoD;
using 看課程.Services.DataService;
using 看課程.Services.DataService.Interface;
using 看課程.Services.Identity;
using Service.Identity.Interface;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//=====
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings"));


//builder.Services.AddSingleton<IDataService, DataService>();

if (builder.Environment.IsProduction())
{
    builder.Services.AddSingleton<IDataService, MySQLService>();
}
else
{
    //builder.Services.AddSingleton<IDataService, DataService>();
    builder.Services.AddSingleton<IIdentityService, IdentityService>();

}

//=====


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
