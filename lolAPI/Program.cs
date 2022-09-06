using lolAPI.Data;
using lolAPI.Repos;
using lolAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<lolAPIdb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("lolAPIdb") ?? string.Empty));
builder.Services.AddTransient<RequestsRepo>();
builder.Services.AddTransient<ServersRepo>();
builder.Services.AddTransient<SummonersService>();
builder.Services.AddTransient<ConfigRepo>();
builder.Services.AddTransient<QueueFiltersRepo>();
builder.Services.AddTransient<MatchesService>();
builder.Services.AddTransient<JsonRepo>();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials()); 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();