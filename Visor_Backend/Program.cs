global using Visor_Backend.Services.EmailService;
global using Visor_Backend.Services.TrabajoService;
global using Visor_Backend.Services.FileService;
global using Visor_Backend.Services.PubliImageService;
global using Visor_Backend.Models;
global using DB;
using Microsoft.Extensions.FileProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Visor_Backend.Services.TrabajoService;
using Visor_Backend.Services.LoginService;
using Visor_Backend.Handlers;
using Visor_Backend.Services.EmailService;
using Visor_Backend.Services.PubliImageService;
using Visor_Backend.Services.FileService;
using Visor_Backend.Services.CatalogoService;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
string SCivilesPolicy = "SCivilesPolicy";

// Add services to the container.
/*
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:4200");
        });
});*/

builder.Services.AddCors(options => options.AddPolicy(name: SCivilesPolicy, builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));


builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ITrabajoService, TrabajoService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ICatalogoService, CatalogoService>();
builder.Services.AddScoped<IPubliImageService, PubliImageService>();
builder.Services.AddTransient<JwtHandler>();

builder.Services.AddHttpClient();

builder.Services.AddDbContext<SolucionesContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

builder.WebHost.ConfigureKestrel(serverOptions => {
    serverOptions.ListenAnyIP(7073); // HTTP
});

var app = builder.Build();

/* ************ESTO CREA LA BASE DE DATOS SI AUN NO EXISTE. SI YA ESTA CREADA, COMENTAR ******
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SolucionesContext>();
    context.Database.Migrate();
}*/

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

// Agregar HttpClient

app.MapGet("/", () => "�El servidor dockerizado est� funcionando!");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Resources")),
    RequestPath = "/Resources"
});
//app.UseCors("AllowAnyOrigin");

/*app.UseCors(options =>
    options.WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader());*/

app.UseCors(SCivilesPolicy);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
