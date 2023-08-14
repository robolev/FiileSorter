using System.IO;

namespace FileSorter
{
    public class FileSorter
    {
        private string rootPath = @"";
        private string[] dirs;
        private string[] files;
        
        public void GetDirectoryPath()
        {
            Console.Write("Enter directory path: ");
            string directory = Console.ReadLine();
            SetDirectoryPath(directory);
        }

        public void SetDirectoryPath(string directory)
        {
            if (Directory.Exists(directory))
            {
                rootPath = directory;
                Console.WriteLine("Directory path set successfully.");
            }
            else
            {
                Console.WriteLine("Invalid directory path.");
            }
        }

        public string[] GetDirectories()
        {
            return Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories);
        }

        public string[] GetFiles()
        {
            return Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories);
        }

        public Dictionary<string, string> CreateDirectoryPathsDictionary(string[] dirs)
        {
            Dictionary<string, string> dirPaths = new Dictionary<string, string>();
            foreach (string dir in dirs)
            { 
                string dirName = Path.GetFileNameWithoutExtension(dir);
                dirPaths[dirName] = dir;
            }
            return dirPaths;
        }

        public void MoveFilesToDirectories(string[] files, Dictionary<string, string> dirPaths)
        {
            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                
                if (dirPaths.TryGetValue(fileName, out string targetDir))
                {
                    string newPath = Path.Combine(targetDir, Path.GetFileName(file));
                    File.Move(file, newPath);
                    Console.WriteLine($"Moved '{fileName}' to '{targetDir}'.");
                }
                else
                {
                    Console.WriteLine($"No matching directory found for '{fileName}'.");
                }
            }
        }
    }
}
