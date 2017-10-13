
using Foundation;
using UIKit;

namespace exrin.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
            Exrin.Framework.App.Init();
            LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
