namespace FiileSorterApp;

public class FileSorterApp
{
    private string[] dirs;
    private string[] files;

    private FileSorter.FileSorter _fileSorter = new();

    public void Initialize()
    {
        _fileSorter.GetDirectoryPath();
        dirs =  _fileSorter.GetDirectories();
        files = _fileSorter.GetFiles();
    }
    public void Run()
    {
        Dictionary<string, string> dirPaths = _fileSorter.CreateDirectoryPathsDictionary(dirs);
        _fileSorter.MoveFilesToDirectories(files, dirPaths);
        
        Console.WriteLine("Sorting completed.");
        Console.ReadLine();
    }
}