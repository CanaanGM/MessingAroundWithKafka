using Confluent.Kafka;

using Newtonsoft.Json;

using Shared;

using System.Threading;

var config = new ConsumerConfig
{
    GroupId = "Kefka-Consumer",
    BootstrapServers = "localhost:9092",
    AutoOffsetReset = AutoOffsetReset.Earliest
};


var consumer = new ConsumerBuilder<Null, string>(config).Build();

consumer.Subscribe("Kefka");
CancellationTokenSource token = new();

try
{

    while (true)
    {
        var response = consumer.Consume(token.Token);
        if (response.Message == null)
        {
            var monster = JsonConvert.DeserializeObject<Monster>(response.Message.Value);
            Console.WriteLine($"a new monster appears: {monster} !!");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}