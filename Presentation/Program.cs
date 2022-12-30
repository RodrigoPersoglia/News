using AccesData;
using AccesData.Commands;
using AccesData.Queries;
using Applications.Services;
using AutoMapper;
using Domain.Entities;
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

builder.Services.AddTransient<NewsContext>();

builder.Services.AddTransient<IQueries<Tag>, Queries<Tag>>();
builder.Services.AddTransient<ICommands<Tag>, Commands<Tag>>();
builder.Services.AddTransient<ITagService, TagService>();

builder.Services.AddTransient<IQueries<Categoria>, Queries<Categoria>>();
builder.Services.AddTransient<ICommands<Categoria>, Commands<Categoria>>();
builder.Services.AddTransient<ICategoriaService, CategoriaService>();

builder.Services.AddTransient<IQueries<User>, Queries<User>>();
builder.Services.AddTransient<ICommands<User>, Commands<User>>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IQueries<Noticia>, Queries<Noticia>>();
builder.Services.AddTransient<INoticiaQuery, NoticiaQuery>();
builder.Services.AddTransient<ICommands<Noticia>, Commands<Noticia>>();
builder.Services.AddTransient<INoticiaService, NoticiaService>();

builder.Services.AddTransient<IComentarioQuery, ComentarioQuery>();
builder.Services.AddTransient<ICommands<Comentario>, Commands<Comentario>>();
builder.Services.AddTransient<IComentarioService, ComentarioService>();

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
