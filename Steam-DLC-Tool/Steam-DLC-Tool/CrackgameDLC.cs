using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace Steam_DLC_Tool
{
    internal class CrackgameDLC
    {
        //Modify a file name in the specified path
        public static void ModifyFileName(string path, string oldName, string newName, string gamePath)
        {
            string[] files = System.IO.Directory.GetFiles(path);
            foreach (string file in files)
            {
                if (file.Contains(oldName))
                {
                    try
                    {
                        string newFile = file.Replace(oldName, newName);
                        System.IO.File.Move(file, newFile);
                    }
                    catch (Exception)
                    {
                        DeleteFile(gamePath + "\\steam_api64_o.dll");
                        string newFile = file.Replace(oldName, newName);
                        System.IO.File.Move(file, newFile);
                    }
                    
                }
            }
        }
        //download file
        public static void DownloadFile(string url, string path)
        {
            using (System.Net.WebClient client = new System.Net.WebClient())
            {
                client.DownloadFile(url, path + "\\FogMoe-TempData.zip");
            }
        }
        //unzip and overwrite files
        public static void Unzip(string path)
        {
            using (ZipArchive archive = ZipFile.OpenRead(path + "\\FogMoe-TempData.zip"))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                        string destinationPath = Path.GetFullPath(Path.Combine(path, entry.FullName));
                    
                        if (destinationPath.StartsWith(path, StringComparison.Ordinal))
                            entry.ExtractToFile(destinationPath,true);
                    
                }
            }
        }
        //Delete file
        public static void DeleteFile(string path)
        {
            System.IO.File.Delete(path);
        }





    }
}
