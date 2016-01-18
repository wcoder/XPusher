using XPusher.Base;

namespace XPusher.ViewModels
{
	class MainPageViewModel : BaseViewModel
	{
		public SendPageViewModel Android { get; set; }
		public SendPageViewModel iOS { get; set; }
		public SendPageViewModel WindowsMobile { get; set; }

		public MainPageViewModel()
		{
			Android = new SendPageViewModel {Title = "Android"};
			iOS = new SendPageViewModel { Title = "iOS" };
			WindowsMobile = new SendPageViewModel { Title = "Windows Mobile" };
		}
	}
}
