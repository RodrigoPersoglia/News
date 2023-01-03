using AccesData;
using AccesData.Commands;
using AccesData.Queries;
using Applications.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Presentation;
using Presentation.Controllers.Extensiones;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigurationManager Configuration = builder.Configuration;
builder.Services.AddControllers();
builder.Services.AddOptions(Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options =>
{
options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
var jwtAppSettings = Configuration.GetSection("JwtIssuerOptions");

options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidIssuer = jwtAppSettings["Issuer"],

    ValidateAudience = true,
    ValidAudience = jwtAppSettings["Audience"],

    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAppSettings["SecretKey"])),

    ValidateLifetime = true,
    ClockSkew = TimeSpan.Zero
};
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("Token-Expired", "true");
            }
            return Task.CompletedTask;
        }
    };
});

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

builder.Services.AddTransient<IUserQuery, UserQuery>();
builder.Services.AddTransient<ICommands<User>, Commands<User>>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IQueries<Noticia>, Queries<Noticia>>();
builder.Services.AddTransient<INoticiaQuery, NoticiaQuery>();
builder.Services.AddTransient<ICommands<Noticia>, Commands<Noticia>>();
builder.Services.AddTransient<INoticiaService, NoticiaService>();

builder.Services.AddTransient<IComentarioQuery, ComentarioQuery>();
builder.Services.AddTransient<ICommands<Comentario>, Commands<Comentario>>();
builder.Services.AddTransient<IComentarioService, ComentarioService>();

builder.Services.AddTransient<IQueries<NoticiaTag>, Queries<NoticiaTag>>();
builder.Services.AddTransient<ICommandsNoticiaTag, CommandsNoticiaTag>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
