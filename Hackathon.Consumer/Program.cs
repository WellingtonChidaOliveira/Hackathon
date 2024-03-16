using Hackathon.Consumer;
using Hackathon.Consumer.Extensions;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddMassTransit(hostContext.Configuration);
    })
    .Build();

host.Run();
