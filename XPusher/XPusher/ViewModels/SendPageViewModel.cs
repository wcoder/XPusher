using System;
using System.Windows.Input;
using Acr.UserDialogs;
using Plugin.Settings;
using Xamarin.Forms;
using XPusher.Base;
using XPusher.Infrastructure;

namespace XPusher.ViewModels
{
	internal class SendPageViewModel : BaseViewModel
	{
		private readonly IPushSender _sender;
		private string _apiKey;
		private string _message;

		#region properties

		public string Title { get; set; }

		public string ApiKey
		{
			get { return _apiKey; }
			set
			{
				_apiKey = value;
				OnPropertyChanged();
			}
		}

		private string SettingsApiKey
		{
			get { return CrossSettings.Current.GetValueOrDefault<string>($"ApiKey{_sender.Name}"); }
			set { CrossSettings.Current.AddOrUpdateValue($"ApiKey{_sender.Name}", value); }
		}

		public string Message
		{
			get { return _message; }
			set
			{
				_message = value;
				OnPropertyChanged();
			}
		}

		public ICommand SendCommand { get; private set; }

		#endregion

		public SendPageViewModel(IPushSender sender)
		{
			_sender = sender;

			SendCommand = new Command(Send);
			ApiKey = SettingsApiKey;
		}

		private async void Send()
		{
			if (!string.IsNullOrWhiteSpace(ApiKey)
			    && !string.IsNullOrWhiteSpace(Message))
			{
				SettingsApiKey = ApiKey;

				UserDialogs.Instance.ShowLoading();
				try
				{
					var result = await _sender.SendMessageAsync(ApiKey, Message);

					UserDialogs.Instance.HideLoading();
					UserDialogs.Instance.Alert(result, "Result");
				}
				catch (Exception e)
				{
					UserDialogs.Instance.HideLoading();
					UserDialogs.Instance.Alert(e.Message, "Exception");
				}
			}
			else
			{
				UserDialogs.Instance.Alert("All fields must be filled!", "Warning");
			}
		}
	}
}