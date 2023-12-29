using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Drive.v2;
using GoogleDriveUploader.GoogleDrive;
using WindowsFormsApp1;

namespace WindowsFormsApp1
{
    
    public class GoogleDriveManager : IGoogleDriveManager
    {
        GoogleDriveService _googleDriveService;
        const string SECRET_PATH = "/WindowsFormsApp1/ModelObject/GoogleDrive/client_secret_798314932778-nsrmdrte433qdrsdqr77v3ddtusk0tip.apps.googleusercontent.com.json";

        public string ClientSecretFileName
        {
            get
            {
                return new ProjectFile().Root + SECRET_PATH;
            }
        }

        public GoogleDriveManager()
        {
            const string APPLICATION_NAME = "PowerPoint";
            _googleDriveService = new GoogleDriveService(APPLICATION_NAME, ClientSecretFileName);
        }

        //UploadToGoogleDrive
        public virtual void UploadToGoogleDrive()
        {
            _googleDriveService.UploadFile(new ProjectFile().SaveFilePath + ProjectFile.SAVE_FILE_NAME, ProjectFile.SAVE_FILE_TYPE);
        }

        //DownloadFileFromGoogleDrive
        public virtual void DownloadFileFromGoogleDrive()
        {
            _googleDriveService.DownloadFile(ProjectFile.SAVE_FILE_NAME, new ProjectFile().SaveFilePath);
        }
    }
}
