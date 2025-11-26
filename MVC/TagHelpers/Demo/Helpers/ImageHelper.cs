namespace Demo.Helpers;

using System;
using System.IO;
public class ImageHelper
{
    public static string SaveImage(IFormFile imageFile, string dir)
    {
        string finalDirPath = $"wwwroot/{dir}";
        if (imageFile == null || imageFile.Length == 0)
        {
            throw new Exception();
        }

        if (!Directory.Exists(finalDirPath))
        {
            Directory.CreateDirectory(finalDirPath);
        }
        //extract extension from file
        string fileExtension = Path.GetExtension(imageFile.FileName); // e.g. .jpg, .png, etc.

        //genrate unique file name
        // using Guid to generate unique file name
        // you can also use other methods like DateTime.Now.Ticks or a random number generator
        // but Guid is a good choice for uniqueness
        string uniqueNameForFile = $"{Guid.NewGuid()}.{fileExtension}";
        

        //get full path which we will store in db ( we dont need to store from wwwroot)
        string fullPathToStoreInDB = $"{dir}/{uniqueNameForFile}";

        //get path where we store image means wwwroot
        string fullPathToWrite = $"{finalDirPath}/{uniqueNameForFile}";


        // use stream to manipulate or save image in disk
        FileStream stream = new FileStream(fullPathToWrite, FileMode.CreateNew);
        imageFile.CopyTo(stream);
        stream.Close();

        //return path which we will store in db
        return fullPathToStoreInDB;
    }
}