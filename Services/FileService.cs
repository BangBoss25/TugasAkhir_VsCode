namespace TugasAkhir_VsCode.Services;

public class FileService
{
    IWebHostEnvironment env;

    public FileService(IWebHostEnvironment env)
    {
        this.env = env;
    }

    public async Task<string> SaveFile(IFormFile file, string id, string no)
    {
        string namaFolder = "File" + "/" + id;

        if (file == null)
        {
            return string.Empty;
        }

        var savePath = Path.Combine(env.WebRootPath, namaFolder);

        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }

        var namaFile = no + "_" + file.FileName;
        var alamatFile = Path.Combine(savePath, namaFile);

        using (var stream = new FileStream(alamatFile, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Path.Combine("/" + namaFolder + "/", namaFile);
    }
}