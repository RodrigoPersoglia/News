using AccesData;
using AccesData.Commands;
using AccesData.Queries;
using Applications.Services;
using AutoMapper;
using Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var mapConfir = new MapperConfiguration(m => { m.AddProfile(new AutoMapperProfile()); });
IMapper mapper = mapConfir.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<NewsContext>();
builder.Services.AddTransient<ITagService, TagService>();
builder.Services.AddTransient<ITagQueries, TagQueries>();
builder.Services.AddTransient<ITagRepository, TagRepository>();


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
