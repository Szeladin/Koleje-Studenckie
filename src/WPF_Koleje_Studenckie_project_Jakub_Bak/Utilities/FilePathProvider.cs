using System;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak.Utilities
{
    public static class FilePathProvider
    {
        public static string GetTrainDataFilePath()
        {
            return JsonHelper.GetDataFilePath("trains.json");
        }

        public static string GetPersonelDataFilePath()
        {
            return JsonHelper.GetDataFilePath("personel.json");
        }
    }
} 