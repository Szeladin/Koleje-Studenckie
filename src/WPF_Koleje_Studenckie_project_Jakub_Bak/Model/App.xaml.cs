﻿using System.Windows;
using System.Collections.ObjectModel;
using Domain.Entities;
using System.IO;
using System.Text.Json;
using WPF_Koleje_Studenckie_project_Jakub_Bak.Services;

namespace WPF_Koleje_Studenckie_project_Jakub_Bak
{
    public partial class App : Application
    {
        public static ObservableCollection<Train> Trains { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Trains = new ObservableCollection<Train>();
            LoadTrains();
        }

        private void LoadTrains()
        {
            string filePath = GetDataFilePath();
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                var loadedTrains = JsonSerializer.Deserialize<ObservableCollection<TrainDTO>>(json);
                if (loadedTrains != null)
                {
                    foreach (var trainDto in loadedTrains)
                    {
                        var train = new Train(trainDto.Name, trainDto.MaxSpeed, trainDto.CarriageCount);
                        train.Movement.IsMoving = trainDto.IsMoving;
                        Trains.Add(train);
                    }
                }
            }
        }

        public static string GetDataFilePath()
        {
            string projectDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
            string dataFolderPath = Path.Combine(projectDirectory, "Data");
            Directory.CreateDirectory(dataFolderPath);
            return Path.Combine(dataFolderPath, "trains.json");
        }
    }
}
