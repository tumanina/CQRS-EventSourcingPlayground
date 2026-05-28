using DigitalWallet.Api.CommandHandlers;
using DigitalWallet.Api.Commands;
using DigitalWallet.Api.Dispatchers;
using DigitalWallet.Api.Models;
using DigitalWallet.Api.Projections;
using DigitalWallet.Api.Queries;
using DigitalWallet.Api.QueryHandlers;
using JasperFx;
using JasperFx.Events.Projections;
using Marten;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddMarten(options =>
{
    options.Connection("Host=localhost;Port=5432;Database=wallet_db;Username=postgres;Password=playgroundpass");
    options.DatabaseSchemaName = "wallet";
    options.AutoCreateSchemaObjects = AutoCreate.All;
    options.Projections.Add<WalletProjection>(ProjectionLifecycle.Inline);
});

builder.Services.AddScoped<ICommandDispatcher, CommandDispatcher>();
builder.Services.AddScoped<ICommandHandler<CreateWalletCommand, Guid>, CreateWalletCommandHandler>();
builder.Services.AddScoped<ICommandHandler<DepositMoneyCommand, bool>, DepositMoneyCommandHandler>();
builder.Services.AddScoped<ICommandHandler<WithdrawMoneyCommand, bool>, WithdrawMoneyCommandHandler>();
builder.Services.AddScoped<IQueryDispatcher,QueryDispatcher>();
builder.Services.AddScoped<IQueryHandler<GetWalletByIdQuery, WalletView?>, GetWalletByIdQueryHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
