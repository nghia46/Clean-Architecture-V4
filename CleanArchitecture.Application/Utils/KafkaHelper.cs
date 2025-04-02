using Confluent.Kafka;
using Newtonsoft.Json;

namespace CleanArchitecture.Application.Utils;

public class KafkaHelper<T>(ProducerConfig config) : IKafkaHelper<T> where T : class
{
    private readonly IProducer<string, string> _producer = new ProducerBuilder<string, string>(config).Build();
    
    public async Task ProduceMessageAsync(string topic,string key, T message)
    {
        try
        {
            var serializedMessage = JsonConvert.SerializeObject(message);
            var kafkaMessage = new Message<string, string>
            {
                Key = key,
                Value = serializedMessage
            };
            
            var deliveryReport = await _producer.ProduceAsync(topic, kafkaMessage);
            Console.WriteLine($"Delivered message to {deliveryReport.TopicPartitionOffset}");
        }
        catch (ProduceException<string, string> ex)
        {
            Console.WriteLine($"Error producing message: {ex.Error.Reason}");
        }
    }
}
