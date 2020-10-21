using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json.Linq;

namespace Veritaspay
{
    class Program
    {
        static void Main(string[] args)
        {
            APICall objAPICall = new APICall();

            string strFolderPath = "";
            string strImageFilename = "";
            string strImageSourcePath = "";
            string strDestinationPath = "";
            string strPublicID = "";
            string strPath = "";

            // Create Folder
            strFolderPath = "veritas/folder_01";
            objAPICall.mtdCreateFolder(strFolderPath);

            // Second Folder
            strFolderPath = "veritas/folder_02";
            objAPICall.mtdCreateFolder(strFolderPath);

            // Delete Folder
            strFolderPath = "veritas/folder_02";
            objAPICall.mtdDeleteFolder(strFolderPath);

            // Upload Images
            strImageFilename = "Test.PNG";
            strImageSourcePath = @"C:\test_image\";
            strDestinationPath = "veritas/folder_01";
            objAPICall.mtdUploadImage(strImageFilename, strImageSourcePath, strDestinationPath);

            // Delete Images
            strPublicID = "bhb2jonzeixvlevb9av9";
            strPath = "veritas/folder_01";
            objAPICall.mtdDeleteImage(strPublicID, strPath);

            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
