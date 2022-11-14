using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using Xamarin.Forms.PlatformConfiguration;


//using System.net.Uri;
//using android.os.Build;
//using android.os.Environment; 

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.App;

//using System.ComponentModel;
//using Plugin.DownloadManager.Abstractions;


namespace Xamarinconversor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateApp : ContentPage
    {
        public UpdateApp()
        {
            InitializeComponent();
        }

        public string GetLocalDownloadPathFromFileName(string fileName)
        {
            string downloadDir = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath;
            return System.IO.Path.Combine(downloadDir, fileName);
        }

        public String GetLocalDownloadPathFromUrl(string url)
        {
            string fileName = Android.Net.Uri.Parse(url).Path.Split('/').Last();
            return GetLocalDownloadPathFromFileName(fileName);
        }

        public void OpenDownloads()
        {
            Android.App.Application.Context.StartActivity(new Intent(Android.App.DownloadManager.ActionViewDownloads));
        }

        public void OpenApk(string filepath)
        {
            Java.IO.File file = new Java.IO.File(filepath);
            Intent install = new Intent(Intent.ActionView);

            // Old Approach
            if (Android.OS.Build.VERSION.SdkInt < BuildVersionCodes.N)
            {
                install.SetFlags(ActivityFlags.NewTask | ActivityFlags.GrantReadUriPermission);
                install.SetDataAndType(Android.Net.Uri.FromFile(file), "application/vnd.android.package-archive"); //mimeType
            }
            else
            {
                Android.Net.Uri apkURI = Androidx.core.Content.FileProvider.GetUriForFile(Android.App.Application.Context, Android.App.Application.Context.ApplicationContext.PackageName + ".fileprovider", file);
                install.SetDataAndType(apkURI, "application/vnd.android.package-archive");
                install.AddFlags(ActivityFlags.NewTask);
                install.AddFlags(ActivityFlags.GrantReadUriPermission);
            }

            Android.App.Application.Context.StartActivity(install);
        }
    }
}