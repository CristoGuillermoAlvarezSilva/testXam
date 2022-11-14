using System;
using System.Collections.Generic;
using System.Text;
using Xamarinconversor.Services;

namespace Xamarinconversor.Models
{
    public abstract class AbstractDownloadManager : IDownloadManager
    {
        public event EventHandler<DownloadStatusEventArgs> DownloadStatusChanged;

        protected void OnDownloadStatusChanged(DownloadStatusEventArgs e)
        {
            DownloadStatusChanged?.Invoke(this, e);
        }

        public abstract void DownloadFile(string path, string fileurl);


    }
}
