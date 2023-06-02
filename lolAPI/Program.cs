using lolAPI.Data;
using lolAPI.Interfaces;
using lolAPI.Repos;
using lolAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<lolAPIdb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("lolAPIdb") ?? string.Empty));
builder.Services.AddTransient<IRequestsRepo,RequestsRepo>();
builder.Services.AddTransient<IServersRepo,ServersRepo>();
builder.Services.AddTransient<ISummonersService,SummonersService>();
builder.Services.AddTransient<IConfigRepo,ConfigRepo>();
builder.Services.AddTransient<IQueueFiltersRepo,QueueFiltersRepo>();
builder.Services.AddTransient<IMatchesService,MatchesService>();
builder.Services.AddTransient<IJsonRepo,JsonRepo>();
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