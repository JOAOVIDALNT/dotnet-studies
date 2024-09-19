using blazor_crud.Api.Data;
using blazor_crud.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=appdb.db");
});

builder.Services.AddCors(x => x.AddPolicy(CorsConfig.CLIENT_NAME, policy => policy
    .WithOrigins([
        CorsConfig.WEB_URL,
        CorsConfig.API_URL
        ])
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
));

var app = builder.Build();

app.UseCors(CorsConfig.CLIENT_NAME);

app.MapGet("/categories", async (AppDbContext context) =>
{
    var list = await context.Categories.AsNoTracking().ToListAsync();

    return Results.Ok(list); 

}).Produces<List<Category>>();

app.MapPost("/categories", async (AppDbContext context, Category category) =>
{
    await context.Categories.AddAsync(category);
    await context.SaveChangesAsync();

    return Results.Created($"categories/{category.Id}", category);
});

app.Run();