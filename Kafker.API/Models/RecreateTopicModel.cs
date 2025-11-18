using System.ComponentModel.DataAnnotations;

namespace Kafker.API.Models;

public record RecreateTopicModel(
	[Range(1, 10000)] int numPartitions,
	[Range(1, short.MaxValue)] short replicationFactor
);
