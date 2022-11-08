namespace GetandTake.Core.Helper;

public class FileHelper
{
    public static string Add(IFormFile file)
    {
        var result = NewPath(file);
        try
        {
            var sourcePath = Path.GetTempFileName();
            if (file.Length > 0)
                using (var stream = new FileStream(sourcePath, FileMode.Create))
                    file.CopyTo(stream);
            File.Move(sourcePath, result.NewPath);
        }
        catch (Exception exception)
        {
            return exception.Message;
        }
        return result.LastPath;
    }

    public static string Update(string sourcePath, IFormFile file)
    {
        var result = NewPath(file);
        try
        {
            if (sourcePath.Length > 0)
            {
                using var stream = new FileStream(result.NewPath, FileMode.Create);
                file.CopyTo(stream);
            }
            File.Delete(sourcePath);
        }
        catch (Exception exception)
        {
            return exception.Message;
        }
        return result.LastPath;
    }

    public static void Delete(string path)
    {
        File.Delete(path);
    }

    public static (string NewPath, string LastPath) NewPath(IFormFile file)
    {
        FileInfo ff = new FileInfo(file.FileName);
        string fileExtension = ff.Extension;
        var newPath = Guid.NewGuid() + fileExtension;
        string path = Environment.CurrentDirectory + @"\wwwroot\img";
        string result = $@"{path}\{newPath}";

        return (result, $"\\img\\{newPath}");
    }
}
