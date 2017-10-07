using DeepLinking.Caller.iOS.Services;
using Foundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(iOSOpenAppService))]
namespace DeepLinking.Caller.iOS.Services
{
    /// <summary>
    /// Implementación de la interfaz <see cref="IOpenAppService"/> (Servicio de apertura de aplicaciones) para iOS
    /// </summary>
    public class iOSOpenAppService : IOpenAppService
    {
        /// <contentfrom />
        public Task<bool> LaunchAsync(string stringUri, string appPackageName)
        {
            //TODO: Falta aplicar esto: https://developer.apple.com/library/content/qa/qa1629/_index.html
            // para que se abra el APP Store cuando la aplicación no esté instalada

            NSUrl request = new NSUrl(stringUri);
            try
            {
                bool canOpen = UIApplication.SharedApplication.CanOpenUrl(request);

                if (canOpen)
                {
                    UIApplication.SharedApplication.OpenUrl(request);
                    return Task.FromResult(true);
                }
                else
                {
                    UIApplication.SharedApplication.OpenUrl(request);
                    return Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Cannot open url: {0}, Error: {1}", request.AbsoluteString, ex.Message);
                var alertView = new UIAlertView("Error", ex.Message, null, "OK", null);

                alertView.Show();

                return Task.FromResult(false);
            }
        }

    }
}
