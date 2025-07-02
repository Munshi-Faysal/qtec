
using MediatR;
using Microsoft.EntityFrameworkCore;
using qtec.application.Accounts.Queries.GetAccounts;
using qtec.application.Common.Mappings;
using qtec.infrastructure.Persistence;
using qtec.infrastructure.RegisterServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddInfrastructure();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// qtec.api/Program.cs (example)
builder.Services.AddDbContext<QtecDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("http://localhost:5173", "https://qtec-front.vercel.app").AllowAnyMethod().AllowAnyHeader()
            .AllowCredentials();
}));


//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("corsapp", policy =>
//    {
//        policy
//            .SetIsOriginAllowed(origin => true) // allow all origins dynamically
//            .AllowAnyMethod()
//            .AllowAnyHeader()
//            .AllowCredentials();
//    });
//});


builder.Services.AddMediatR(typeof(GetAccountsQueryHandler).Assembly);
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}




app.UseHttpsRedirection();
app.UseCors("corsapp");
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Qtec API V1");
    //if (app.Environment.IsProduction())
    //{
    //    c.RoutePrefix = string.Empty;
    //}
});

app.UseAuthorization();

app.MapControllers();

app.Run();
