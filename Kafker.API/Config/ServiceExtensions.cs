using System.Collections.Immutable;
using Kafker.API.ClientPools;

namespace Kafker.API.Config;

public static class ServiceExtensions
{
	public static WebApplicationBuilder ConfigureClusterConfigOptions(
		this WebApplicationBuilder builder
	)
	{
		var clusters =
			builder
				.Configuration.GetSection("Kafker:Clusters")
				.Get<List<ClusterConfigOptions>>()
				?.ToImmutableArray()
			?? throw new InvalidOperationException(
				$"Missing or invalid configuration for 'Kafker:Clusters'. "
					+ $"Expected to bind to {typeof(List<ClusterConfigOptions>).FullName}. "
					+ "Check your appsettings.json or environment variables."
			);

		builder.Services.AddSingleton<IReadOnlyList<ClusterConfigOptions>>(clusters);

		return builder;
	}

	public static WebApplicationBuilder AddAdminClientConfigOptions(
		this WebApplicationBuilder builder
	)
	{
		var sectionName = $"Kafker:{nameof(AdminClientPool)}";

		builder
			.Services.AddOptions<AdminClientConfigOptions>()
			.Bind(builder.Configuration.GetSection(sectionName))
			.ValidateDataAnnotations()
			.ValidateOnStart();

		return builder;
	}

	public static WebApplicationBuilder AddWatermarkOffsetsMessageConsumerOptions(
		this WebApplicationBuilder builder
	)
	{
		var sectionName = $"Kafker:WatermarkOffsets";

		builder
			.Services.AddOptions<MessageConsumerOptions>()
			.Bind(builder.Configuration.GetSection(sectionName))
			.ValidateDataAnnotations()
			.ValidateOnStart();

		return builder;
	}

	public static WebApplicationBuilder AddMessagesReaderServiceOptions(
		this WebApplicationBuilder builder
	)
	{
		var sectionName = $"Kafker:MessagesReaderService";

		builder
			.Services.AddOptions<MessagesReaderServiceOptions>()
			.Bind(builder.Configuration.GetSection(sectionName))
			.ValidateDataAnnotations()
			.ValidateOnStart();

		return builder;
	}
}
