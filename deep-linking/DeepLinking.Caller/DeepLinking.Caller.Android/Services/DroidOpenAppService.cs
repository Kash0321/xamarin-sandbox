using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Net;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Xamarin.Forms;
using DeepLinking.Caller.Droid.Services;

[assembly: Dependency(typeof(DroidOpenAppService))]
namespace DeepLinking.Caller.Droid.Services
{
    /// <summary>
    /// Implementación de la interfaz <see cref="IOpenAppService"/> (Servicio de apertura de aplicaciones) para Android
    /// </summary>
    public class DroidOpenAppService : Activity, IOpenAppService
    {
        /// <contentfrom />
        public Task<bool> LaunchAsync(string stringUri, string appPackageName)
        {
            #region Alternative code, but not works

            //try
            //{
            //    Intent intent = Android.App.Application.Context.PackageManager.GetLaunchIntentForPackage(stringUri);

            //    if (intent != null)
            //    {
            //        intent.AddFlags(ActivityFlags.NewTask);
            //        Forms.Context.StartActivity(intent);
            //    }
            //    else
            //    {
            //        intent = new Intent(Intent.ActionView);
            //        intent.AddFlags(ActivityFlags.NewTask);
            //        // This launches the PlayStore and search for the app if it's not installed on your device
            //        intent.SetData(Android.Net.Uri.Parse("market://details?id=" + stringUri));
            //        Forms.Context.StartActivity(intent);
            //    }
            //    return Task.FromResult(true);
            //}
            //catch
            //{
            //    return Task.FromResult(false);
            //}

            #endregion

            try
            {
                var aUri = Android.Net.Uri.Parse(stringUri);
                var intent = new Intent(Intent.ActionView, aUri);
                Xamarin.Forms.Forms.Context.StartActivity(intent);
                return Task.FromResult(true); // I was opened
            }
            catch (ActivityNotFoundException)
            {
                try
                {
                    var intent = new Intent(Intent.ActionView, Uri.Parse("market://details?id=" + appPackageName));
                    // we need to add this, because the activity is in a new context.
                    // Otherwise the runtime will block the execution and throw an exception
                    intent.AddFlags(ActivityFlags.NewTask);

                    Forms.Context.StartActivity(intent);
                }
                catch (ActivityNotFoundException)
                {
                    var intent = new Intent(Intent.ActionView, Uri.Parse("http://play.google.com/store/apps/details?id=" + appPackageName));
                    // we need to add this, because the activity is in a new context.
                    // Otherwise the runtime will block the execution and throw an exception
                    intent.AddFlags(ActivityFlags.NewTask);

                    Forms.Context.StartActivity(intent);
                }
                return Task.FromResult(false); // I was not found
            }
        }
    }
}