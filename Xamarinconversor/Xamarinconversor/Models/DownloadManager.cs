using Plugin.DownloadManager.Abstractions;
using Plugin.DownloadManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Xamarinconversor.Models
{
    public class DownloadManager : AbstractDownloadManager
    {
        private string downloadPath;

        public DownloadManager()
        {
            //Initialize Download Dir on CrossDownloadManager
            CrossDownloadManager.Current.PathNameForDownloadedFile = new System.Func<IDownloadFile, string>(fileUrl => {
                return downloadPath;
            });
        }

        public override void DownloadFile(string path, string fileurl)
        {
            downloadPath = path;
            var downloadManager = CrossDownloadManager.Current;
            IDownloadFile file = downloadManager.CreateDownloadFile(fileurl);
            file.PropertyChanged += File_PropertyChanged;
            downloadManager.Start(file);
        }

        private void File_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            IDownloadFile file = (IDownloadFile)sender;
            if (file.Status == DownloadFileStatus.COMPLETED)
            {
                OnDownloadStatusChanged(new DownloadStatusEventArgs(DownloadStatusEventArgs.DownloadStatusType.COMPLETED));
            }
        }
    }
}
