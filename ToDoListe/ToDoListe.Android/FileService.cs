using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ToDoListe.Droid;
using ToDoListe.Interface;


[assembly: Xamarin.Forms.Dependency(typeof(FileService))]
namespace ToDoListe.Droid
{
    public class FileService : IFileService
    {
        public string GetRootPath()
        {
            return Application.Context.GetExternalFilesDir(null).ToString();
        }

        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(GetRootPath(), filename);
        }

        public bool FileExist()
        {
            var file = Path.Combine(GetRootPath(), "ListeTodo.txt");
            if (File.Exists(file))
            {
                return true;
            }
            else{
                return false;
            }
        }

        public void CreateFile(string textMessage)
        {
            var filename = "ListeTodo.txt";
            var destination = Path.Combine(GetRootPath(), filename);

            if (!File.Exists(destination))
            {
                File.Create(destination).Dispose();
                File.AppendAllText(destination, textMessage);
            }
            else
            {
                //ajouter les données dans le fichier
                File.AppendAllText(destination, textMessage);
            }
        }

        public void DeleteLigne(string ligne1, string ligne2)
        {
            var filename = "ListeTodo.txt";
            var destination = Path.Combine(GetRootPath(), filename);
            List<string> lines = new List<string>();
            if (File.Exists(destination))
            {
                {
                    StreamReader file = new StreamReader(destination);
                    while (!file.EndOfStream)
                    {
                        string line = file.ReadLine();
                        
                        lines.Add(line);
                    }
                    int i = 0;
                    do
                    {
                        if (lines[i] == ligne1 && lines[i + 1] == ligne2)
                        {
                            for (int j = i; j < lines.Count - 2; j++)
                            {
                                lines[j] = lines[j + 2];
                            }
                            lines.RemoveRange(lines.Count - 2, 2);
                        }
                        i += 2;
                    } while (i < lines.Count - 1);
                    DeleteFile();
                    CreateFile(lines[0] + "\n");
                    for (int k = 1; k < lines.Count; k++)
                    {
                        File.AppendAllText(destination, lines[k] + "\n");
                    }

                }
            }
        }
        
        
        public void DeleteFile()
        {
            var filename = "ListeTodo.txt";
            var destination = Path.Combine(GetRootPath(), filename);

            if (File.Exists(destination))
            {
                File.Delete(destination);
            }
        }
    }
}