using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class ProjectFile
    {
        public const string SAVE_FILE_NAME = "PowerPointData.json";
        public const string SAVE_FILE_TYPE = "application/json";
        private const string FILE_PATH = "/WindowsFormsApp1/ModelObject/File/";

        public string Root
        {
            get
            {
                return Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))));
            }
        }

        public string SaveFilePath
        {
            get
            {
                return Root + FILE_PATH;
            }
        }
    }
}
