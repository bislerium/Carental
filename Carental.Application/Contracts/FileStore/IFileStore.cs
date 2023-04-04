namespace Carental.Application.Interfaces.File
{
    public interface IFileStore
    {
        Stream Read(string path);

        string Write(Stream file, string filename);
    }
}
