using GameReviewAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = "Server=tcp:myfirstdatabase-brandon.database.windows.net,1433;Initial Catalog=myfirstdatabase;Persist Security Info=False;User ID=bsassano;Password=Bts2000!!!;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<GameIRepository>(sp => new GameRepository(connectionString, sp.GetRequiredService<ILogger<GameRepository>>()));
builder.Services.AddSingleton<ReviewIRepository>(sp => new ReviewRepository(connectionString, sp.GetRequiredService<ILogger<ReviewRepository>>()));
builder.Services.AddSingleton<TagsIRepository>(sp => new TagsRepository(connectionString, sp.GetRequiredService<ILogger<TagsRepository>>()));
builder.Services.AddSingleton<UserIRepository>(sp => new UserRepository(connectionString, sp.GetRequiredService<ILogger<UserRepository>>()));

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
