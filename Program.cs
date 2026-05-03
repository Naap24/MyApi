var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Register in-memory data store
builder.Services.AddSingleton<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.Run();
