using Confluent.Kafka;

using Newtonsoft.Json;

using Shared;

using System.Threading;

var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

using var producer = new ProducerBuilder<Null, string>(config).Build();

try
{

    string? state;

    Console.WriteLine("Please Create a Monster!");

    Console.WriteLine(args);
    while (true)
    {
        var smarts = int.Parse(Console.ReadLine());
        var vitlity = int.Parse(Console.ReadLine());
        var strength = int.Parse(Console.ReadLine());
        var agility = int.Parse(Console.ReadLine());
        var name = Console.ReadLine();

        var response =
            await producer.ProduceAsync(
                "Kefka", new Message<Null, string>
                {
                    Value = JsonConvert.SerializeObject(
                        new Monster(
                            smarts,
                            vitlity,
                            strength,
                            agility,
                            name
                            )
                        )
                }
            );

        Console.WriteLine(response);

    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

