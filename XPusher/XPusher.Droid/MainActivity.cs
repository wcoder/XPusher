using Android.App;
using Android.Content.PM;
using Android.OS;
using Acr.UserDialogs;

namespace XPusher.Droid
{
	[Activity(Label = "XPusher.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			UserDialogs.Init(this);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new XPusher());
		}
	}
}

