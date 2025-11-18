using Kafker.API.Config;

namespace Kafker.API.ViewModels;

public record ClusterConfigViewModel(string Address, string Alias, string? UserName)
{
	public ClusterConfigViewModel(ClusterConfigOptions options)
		: this(Address: options.Address, Alias: options.Alias, UserName: options.SaslUsername) { }
}
