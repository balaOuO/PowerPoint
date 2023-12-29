using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Download;
using Google.Apis.Drive.v2.Data;
using System.Net;

namespace GoogleDriveUploader.GoogleDrive
{
    public class GoogleDriveService
    {
        private readonly string[] _scopes = new[] { DriveService.Scope.DriveFile, DriveService.Scope.Drive };
        private DriveService _service;
        private const int KB = 0x400;
        private const int DOWNLOAD_CHUNK_SIZE = 256 * KB;
        private int _timeStamp;
        private string _applicationName;
        private string _clientSecretFileName;
        private UserCredential _credential;
        private const string TITLE = "title = '{0}'";

        /// <summary>
        /// 創造一個Google Drive Service
        /// </summary>
        /// <param name="applicationName">應用程式名稱</param>
        /// <param name="clientSecretFileName">ClientSecret檔案名稱</param>
        public GoogleDriveService(string applicationName, string clientSecretFileName)
        {
            _applicationName = applicationName;
            _clientSecretFileName = clientSecretFileName;
            this.CreateNewService(applicationName, clientSecretFileName);
        }

        //CreateNewService
        private void CreateNewService(string applicationName, string clientSecretFileName)
        {
            const string USER = "user";
            const string CREDENTIAL_FOLDER = ".credential/";
            UserCredential credential;
            using (FileStream stream = new FileStream(clientSecretFileName, FileMode.Open, FileAccess.Read))
            {
                string credentialPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credentialPath = Path.Combine(credentialPath, CREDENTIAL_FOLDER + applicationName);
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.FromStream(stream).Secrets, _scopes, USER, CancellationToken.None, new FileDataStore(credentialPath, true)).Result;
            }
            DriveService service = new DriveService(new BaseClientService.Initializer()
            { 
                HttpClientInitializer = credential, ApplicationName = applicationName });
            _credential = credential;
            DateTime now = DateTime.Now;
            _timeStamp = UNIXNowTimeStamp;
            _service = service;
        }

        private int UNIXNowTimeStamp
        {
            get
            {
                const int UNIX_START_YEAR = 1970;
                DateTime unixStartTime = new DateTime(UNIX_START_YEAR, 1, 1);
                return Convert.ToInt32((DateTime.Now.Subtract(unixStartTime).TotalSeconds));
            }
        }

        //Check and refresh the credential if credential is out-of-date
        private void CheckCredentialTimeStamp()
        {
            const int ONE_HOUR_SECOND = 3600;
            int nowTimeStamp = UNIXNowTimeStamp;

            if ((nowTimeStamp - _timeStamp) > ONE_HOUR_SECOND)
                this.CreateNewService(_applicationName, _clientSecretFileName);
        }

        /// <summary>
        /// 上傳檔案
        /// </summary>
        /// <param name="uploadFileName">上傳的檔案名稱 </param>
        /// <param name="contentType">上傳的檔案種類，請參考MIME Type : http://www.iana.org/assignments/media-types/media-types.xhtml </param>
        /// <param name="uploadProgressEventHandler"> 上傳進度改變時呼叫的函式</param>
        /// <param name="responseReceivedEventHandler">收到回應時呼叫的函式 </param>
        /// <returns>上傳成功，回傳上傳成功的 Google Drive 格式之File</returns>
        public Google.Apis.Drive.v2.Data.File UploadFile(string uploadFileName, string contentType)
        {
            string title = Split(uploadFileName);
            DeleteFile(title);
            FileStream uploadStream = new FileStream(uploadFileName, FileMode.Open, FileAccess.Read);
            this.CheckCredentialTimeStamp();
            Google.Apis.Drive.v2.Data.File fileToInsert = new Google.Apis.Drive.v2.Data.File 
            { 
                Title = title };
            FilesResource.InsertMediaUpload insertRequest = _service.Files.Insert(fileToInsert, uploadStream, contentType);
            insertRequest.ChunkSize = FilesResource.InsertMediaUpload.MinimumChunkSize * (1 + 1);

            Upload(insertRequest, uploadStream);

            return insertRequest.ResponseBody;
        }

        //Upload
        public void Upload(FilesResource.InsertMediaUpload insertRequest , FileStream uploadStream)
        {
            try
            {
                insertRequest.Upload();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                uploadStream.Close();
            }
        }

        //Split
        public string Split(string filePath)
        {
            const char SPLASH = '/';

            if (filePath.LastIndexOf(SPLASH) != -1)
                return filePath.Substring(filePath.LastIndexOf(SPLASH) + 1);
            else
                return filePath;
        }

        /// <summary>
        /// 下載檔案
        /// </summary>
        /// <param name="fileToDownload">欲下載的檔案(Google Drive File) 一般會從List取得</param>
        /// <param name="downloadPath">下載到路徑</param>
        /// <param name="downloadProgressChangedEventHandler">當下載進度改變時，呼叫這個函式</param>
        public void DownloadFile(string downLoadFileName , string downloadPath, Action<IDownloadProgress> downloadProgressChangedEventHandler = null)
        {
            const string SPLASH = @"\";

            FilesResource.ListRequest listRequest = _service.Files.List();
            listRequest.Q = string.Format(TITLE , downLoadFileName);
            IList<Google.Apis.Drive.v2.Data.File> files = listRequest.Execute().Items;

            CheckCredentialTimeStamp();
            if (!String.IsNullOrEmpty(files[0].DownloadUrl))
            {
                Task<byte[]> downloadByte = _service.HttpClient.GetByteArrayAsync(files[0].DownloadUrl);
                byte[] byteArray = downloadByte.Result;
                string downloadPosition = downloadPath + SPLASH + files[0].Title;
                System.IO.File.WriteAllBytes(downloadPosition, byteArray);
            }
        }

        /// <summary>
        /// 刪除符合FileID的檔案
        /// </summary>
        /// <param name="fileId">欲刪除檔案的FileID</param>
        public void DeleteFile(string fileName)
        {
            FilesResource.ListRequest listRequest = _service.Files.List();
            listRequest.Q = string.Format(TITLE, fileName);
            IList<Google.Apis.Drive.v2.Data.File> files = listRequest.Execute().Items;

            foreach (Google.Apis.Drive.v2.Data.File file in files)
            {
                CheckCredentialTimeStamp();
                try
                {
                    _service.Files.Delete(file.Id).Execute();
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }
    }
}
