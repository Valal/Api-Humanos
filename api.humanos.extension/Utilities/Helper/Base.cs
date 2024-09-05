namespace api.humanos.extension.Utilities.Helper;

public static class Base{
    public static string GetRootPath() => Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, @"../../../"));
}