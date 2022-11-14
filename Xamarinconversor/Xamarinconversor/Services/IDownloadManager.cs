using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarinconversor.Services
{
    public interface IDownloadManager
    {
        event EventHandler<DownloadStatusEventArgs> DownloadStatusChanged;
        void DownloadFile(string path, string fileurl);
    }
}
