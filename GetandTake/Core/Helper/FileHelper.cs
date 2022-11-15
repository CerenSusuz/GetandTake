namespace GetandTake.Core.Helper;

public class FileHelper
{
    public static string Upload(IFormFile file)
    {
        try
        {
            if (file.Length > 0 && file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Environment.CurrentDirectory, @"wwwroot\uploads", fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return $"\\uploads\\{fileName}";
            }
        }
        catch (Exception exception)
        {
            return exception.Message;
        }

        return null;
    }
}
