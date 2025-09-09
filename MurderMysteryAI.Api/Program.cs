using MurderMysteryAI.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using MurderMysteryAI.Application.Abstraction;
using MurderMysteryAI.Application.Implementation;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Serilog
builder.Host.UseSerilog((ctx, cfg) => cfg.ReadFrom.Configuration(ctx.Configuration));


// Db
builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("Default")));


// Services
builder.Services.AddScoped<IEvidenceSearch, EvidenceSearch>();
builder.Services.AddScoped<IContradictionService, ContradictionService>();
builder.Services.AddScoped<IAppDbContext, AppDbContext>();

// LLM client (fake for MVP)
builder.Services.AddSingleton<ILlmClient, LlmClientFake>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddDbContext<AppDbContext>((sp, options) =>
{
    var cs = builder.Configuration.GetConnectionString("Default");
    options.UseNpgsql(cs ?? throw new ArgumentNullException("configuration"), sql => sql.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

