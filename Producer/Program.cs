using Confluent.Kafka;

using Newtonsoft.Json;

using Shared;

using System.Threading;

var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

using var producer = new ProducerBuilder<Null, string>(config).Build();

try
{

    string? state;

    while ((state = Console.ReadLine()) != null)
    {
        var response =
            await producer.ProduceAsync(
                "Kefka", new Message<Null, string>
                {
                    Value = JsonConvert.SerializeObject(new Monster(11, 21, 13, 9, "Slime"))
                }
            );

    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

