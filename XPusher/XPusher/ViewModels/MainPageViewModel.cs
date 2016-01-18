using XPusher.Base;
using XPusher.Services;

namespace XPusher.ViewModels
{
	internal class MainPageViewModel : BaseViewModel
	{
		public SendPageViewModel Android { get; set; }
		public SendPageViewModel iOS { get; set; }
		public SendPageViewModel WindowsMobile { get; set; }

		public MainPageViewModel()
		{
			Android = new SendPageViewModel(new AndroidPushSender()) {Title = "Android"};
			//iOS = new SendPageViewModel() { Title = "iOS" };
			//WindowsMobile = new SendPageViewModel() { Title = "Windows Mobile" };
		}
	}
}