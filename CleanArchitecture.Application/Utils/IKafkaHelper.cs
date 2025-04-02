namespace CleanArchitecture.Application.Utils;

public interface IKafkaHelper<T> where T : class
{
    Task ProduceMessageAsync(string topic,string key, T message);
}
