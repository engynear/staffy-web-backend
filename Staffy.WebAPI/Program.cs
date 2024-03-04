using Microsoft.OpenApi.Models;
using Staffy.Bll;
using Staffy.Dal;
using Staffy.Dal.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "StaffyWebAPI", Version = "v1" });
});
builder.Services.AddRepositories();
builder.Services.AddDalInfrastructure(builder.Configuration);
builder.Services.AddBllServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StaffyWebAPI"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// app.MigrateDown();
app.MigrateUp();

app.Run();