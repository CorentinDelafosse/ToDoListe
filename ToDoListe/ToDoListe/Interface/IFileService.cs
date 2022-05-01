using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListe.Interface
{
    public interface IFileService
    {
        string GetRootPath();

        string GetLocalFilePath(string filename);
        
        void CreateFile(string textMessage);

        void DeleteFile();

        void DeleteLigne(string line, string line2);

        bool FileExist();
    }
}
