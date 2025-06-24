
var builder = WebApplication.CreateBuilder(args);
var users = UserMockData.GetUsers();

builder.Services.AddControllers();
builder.Services.AddSingleton<IEnumerable<User>>(users);
builder.Services.AddSingleton<InMemoryUserStore>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();

app.Run();