using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace WindowsFormsApp1Tests1
{
    public class MockGoogleDriveManager : IGoogleDriveManager
    {

        public MockGoogleDriveManager()
        {
            UpLoadTimes = 0;
            DownLoadTimes = 0;
        }

        public int UpLoadTimes
        {
            get;
            set;
        }

        public int DownLoadTimes
        {
            get;
            set;
        }

        //DownloadFileFromGoogleDrive
        public void DownloadFileFromGoogleDrive()
        {
            DownLoadTimes += 1;
        }

        //UploadToGoogleDrive
        public void UploadToGoogleDrive()
        {
            UpLoadTimes += 1;
        }
    }
}
