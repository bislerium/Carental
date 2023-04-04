namespace Carental.Application.Interfaces.File
{
    public interface IFileProvider
    {
        Stream Read(string path);

        string Write(Stream file, string filename);
    }
}
