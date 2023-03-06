using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkingSystem_NTTDigital;
using ParkingSystem_NTTDigital.Data;
using ParkingSystem_NTTDigital.Repositories;
using ParkingSystem_NTTDigital.Services;
using ParkingSystem_NTTDigital.UI;

var host = CreateHostBuilder(args).Build();
var serviceProvider = host.Services;

try
{
    var app = serviceProvider.GetRequiredService<App>();
    app.Run();
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

static IHostBuilder CreateHostBuilder(string[] args) => 
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((context, services) =>
        {
            services.AddDbContext<AppDbContext>(builder => 
                builder.UseSqlServer("Server=Fadhlih\\SQLEXPRESS;Database=ParkingSystem;Trusted_Connection=True;TrustServerCertificate=True;"));
            
            //Repositoy
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IPersistence, DbPersistence>();
            services.AddTransient<IReportRepository, ReportRepository>();
            
            //Service
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IReportService, ReportService>();
            
            //ui
            services.AddTransient<CheckInUi>();
            services.AddTransient<ReportUi>();
            services.AddTransient<App>();
        });

