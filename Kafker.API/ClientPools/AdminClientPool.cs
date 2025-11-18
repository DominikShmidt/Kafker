using Confluent.Kafka;
using Kafker.API.Config;

namespace Kafker.API.ClientPools;

public class AdminClientPool : AbstractClientPool<IAdminClient>
{
	public AdminClientPool(IReadOnlyList<ClusterConfigOptions> clusterConfigs)
		: base(clusterConfigs) { }

	protected override IAdminClient BuildClient(ClusterConfigOptions clusterConfig)
	{
		var config = new AdminClientConfig
		{
			BootstrapServers = clusterConfig.Address,
			SaslUsername = clusterConfig.SaslUsername,
			SaslPassword = clusterConfig.SaslPassword,
			SaslMechanism = clusterConfig.SaslMechanism,
			SecurityProtocol = clusterConfig.SecurityProtocol,
		};
		
		return new AdminClientBuilder(config).Build();
	}
}
