using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veritaspay
{
    public class APICall : SharedMethod
    {
        Cloudinary _Cloadinary;
        public APICall()
        {
            Account objAccount = new Account(
                    Constants.CLOUD_NAME,
                    Constants.API_KEY,
                    Constants.API_SECRETS
            );

            _Cloadinary = new Cloudinary(objAccount);
        }

        // <summary>
        /// Method to Upload Image
        /// </summary>
        /// <param name="SourcePath">Image source path in local storage. Absoloute path</param>
        /// <param name="DestinationPath">Image destination in cloudinary. Relative path</param>
        internal void mtdUploadImage(string Filename, string SourcePath, string DestinationPath)
        {
            string strFile = String.Format("{0}/{1}", SourcePath, Filename);
            try
            {
                var objUploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(strFile),
                    Folder = DestinationPath
                };

                var uploadResult = _Cloadinary.Upload(objUploadParams);
            }
            catch (Exception err)
            {
                mtdDisplayError(err.Message);
            }
        }

        // <summary>
        /// Delete Uploaded Image
        /// </summary>
        /// <param name="PublicID">Image public ID</param>
        /// <param name="Path">Image path in cloudinary. Relative path</param>
        internal void mtdDeleteImage(string PublicID, string Path)
        {
            try
            {
                var DelParams = new DeletionParams(PublicID)
                {
                    PublicId = String.Format("{0}/{1}", Path, PublicID)

                };

                var deletionResult = _Cloadinary.Destroy(DelParams);

            }
            catch(Exception err)
            {
                mtdDisplayError(err.Message);
            }
        }

        // <summary>
        /// Create folder
        /// </summary>
        /// <param name="FolderPath">Folder Path</param>
        internal void mtdCreateFolder(string FolderPath)
        {
            try
            {
                
                var result = _Cloadinary.CreateFolder(FolderPath);

            }
            catch(Exception err)
            {
                mtdDisplayError(err.Message);
                
            }
        }

        // <summary>
        /// Delete folder
        /// </summary>
        /// <param name="FolderPath">Folder Path</param>
        internal void mtdDeleteFolder(string FolderPath)
        {
            try
            {
                var result = _Cloadinary.DeleteFolder(FolderPath);

                
            }
            catch (Exception err)
            {
                mtdDisplayError(err.Message);
                
            }
        }
    }
}