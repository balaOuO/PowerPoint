using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using WindowsFormsApp1.ModelObject.File;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;

namespace WindowsFormsApp1
{
    public class FileManager
    {
        const string FILE_PATH = "/PowerPointData.json";

        //Save
        public static void Save(List<Shapes> pageList)
        {
            PowerPointFileFormat powerPointFileFormat = new PowerPointFileFormat(pageList);
            string fileData = JsonConvert.SerializeObject(powerPointFileFormat);

            File.WriteAllText(FILE_PATH, fileData);
        }

        //Load
        public static List<Shapes> Load()
        {
            string fileData = File.ReadAllText(FILE_PATH);
            PowerPointFileFormat powerPointFileFormat = JsonConvert.DeserializeObject<PowerPointFileFormat>(fileData);
            return powerPointFileFormat.Read();
        }
    }
}
