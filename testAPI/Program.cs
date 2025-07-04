using Microsoft.EntityFrameworkCore;
using testAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

//builder.Services.AddOpenApi();

//btw this is called service registration
builder.Services.AddDbContextPool<IssueDbContext>(
   options => options.UseSqlServer(builder.Configuration.GetConnectionString("IssueDBConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
