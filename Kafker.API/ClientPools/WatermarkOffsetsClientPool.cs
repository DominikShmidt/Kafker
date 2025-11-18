using Confluent.Kafka;
using Kafker.API.Config;
using Microsoft.Extensions.Options;

namespace Kafker.API.ClientPools;

public class WatermarkOffsetsClientPool : AbstractClientPool<IConsumer<Ignore, Ignore>>
{
	private readonly MessageConsumerOptions _options;

	public WatermarkOffsetsClientPool(
		IReadOnlyList<ClusterConfigOptions> clusterConfigs,
		IOptions<MessageConsumerOptions> options
	)
		: base(clusterConfigs) => _options = options.Value;

	protected override IConsumer<Ignore, Ignore> BuildClient(ClusterConfigOptions clusterConfig)
	{
		var consumer = new ConsumerBuilder<Ignore, Ignore>(
			new ConsumerConfig
			{
				BootstrapServers = clusterConfig.Address,
				SaslUsername = clusterConfig.SaslUsername,
				SaslPassword = clusterConfig.SaslPassword,
				SaslMechanism = clusterConfig.SaslMechanism,
				SecurityProtocol = clusterConfig.SecurityProtocol,
				GroupId = _options.GroupId,
				EnableAutoCommit = false,
			}
		).Build();

		return consumer;
	}
}
