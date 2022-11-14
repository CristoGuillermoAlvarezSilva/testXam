using System;
using System.Collections.Generic;
using System.Text;

public class DownloadStatusEventArgs : EventArgs
{
    public enum DownloadStatusType
    {
        COMPLETED = 0
    }

    public DownloadStatusType DownloadStatus { get; }

    public DownloadStatusEventArgs(DownloadStatusType downloadStatus) : base()
    {
        DownloadStatus = downloadStatus;
    }
}
