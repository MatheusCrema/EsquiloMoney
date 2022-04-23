using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Infrastructure.Data.Repositories;
using Infrastructure.Data.Repositories.raw;
using ApplicationCore.Interfaces.Repositories;
using ApplicationCore.Interfaces.Repositories.raw;
using ApplicationCore.Interfaces.Services.Helper;
using ApplicationCore.Services.Helper;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using System.Threading.Tasks;

namespace HelperConsole
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var host = CreateHostBuilder(args).Build();
            
            var svc = ActivatorUtilities.CreateInstance<StringHelperService>(host.Services);
            
            await svc.FormatDateFromColumn("a", "b", "c");

        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    //services.AddTransient<Program>();
                    services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=DESKTOP-PE3NEFA\\SQLEXPRESS;Database=EsquiloMoney;Trusted_Connection=True;MultipleActiveResultSets=true;").EnableSensitiveDataLogging());
                    services.AddTransient<IUnitOfWork, UnitOfWork>();
                    services.AddTransient<ITransactionRawOldRepository, TransactionRawOldRepository>();
                    services.AddTransient<IStringHelperService, StringHelperService>();
                });
        }

    }

}
