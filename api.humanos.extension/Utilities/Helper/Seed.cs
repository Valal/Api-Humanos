using System.Text.Json;
using static api.humanos.extension.Utilities.Helper.Base;

namespace api.humanos.extension.Utilities.Helper;

public static class Seed{
    public static List<TEntity> SeedData<TEntity>(string fileName, string path, bool customPath = false){
        string currentdirectory = Directory.GetCurrentDirectory();
        if(customPath)
            currentdirectory = GetRootPath();
        
        string fullPath = Path.Combine(currentdirectory, path, fileName);
        using(StreamReader reader = new StreamReader(fullPath)){
            string json = reader.ReadToEnd();
            return JsonSerializer.Deserialize<List<TEntity>>(json);
        }
    }
}