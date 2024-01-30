using Repositories;
using CrossCutting;
using Microsoft.Extensions.Hosting;
using Serverless_Api.Middlewares;

var host = new HostBuilder()
    .ConfigureServices(services =>
    {
        services.AddEventStore();
        services.AddDomainDependencies();
    })
    .ConfigureFunctionsWorkerDefaults(builder => builder.UseMiddleware<AuthMiddleware>())
    .Build();

CrossCutting.ServiceCollectionExtensions.SetServiceProvider(host.Services);

host.Run();
