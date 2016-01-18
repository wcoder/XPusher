using System.Threading.Tasks;

namespace XPusher.Infrastructure
{
	public interface IPushSender
	{
		string Name { get; }

		Task<string> SendMessageAsync(string apiKey, string message);
	}
}