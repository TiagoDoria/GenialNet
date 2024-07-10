using Application.Services;
using AutoMapper;
using Domain.Repositories.Fornecedores;
using Domain.Repositories.Produtos;
using Infrastructure.Data;
using Infrastructure.Repositories.Fornecedores;
using Infrastructure.Repositories.Produtos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
                           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Infrastructure")));

builder.Services.AddScoped<AppDbContext>();

IMapper mapper = Mappings.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);

var assemblies = AppDomain.CurrentDomain.GetAssemblies();
foreach (var assembly in assemblies)
{
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
}

builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddHttpClient<IViaCepService, ViaCepService>();


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
