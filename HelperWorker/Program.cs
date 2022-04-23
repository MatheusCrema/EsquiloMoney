using HelperWorker;

using ApplicationCore.Interfaces.Repositories.raw;
using ApplicationCore.Interfaces.Services.Helper;
using ApplicationCore.Services.Helper;
using Infrastructure.Data.Repositories.raw;
using ApplicationCore.Interfaces.Repositories;
using Infrastructure.Data.Repositories;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();

        services.AddScoped<ITransactionRawOldRepository, TransactionRawOldRepository>();
        services.AddScoped<IStringHelperService, StringHelperService>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
    })
    .Build();

await host.RunAsync();
