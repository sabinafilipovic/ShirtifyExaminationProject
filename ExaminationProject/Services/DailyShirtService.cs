using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ExaminationProject.Model;

namespace ExaminationProject.Services
{
    public class ShirtService
    {
        private static readonly Lazy<ShirtService> instance = new(() => new ShirtService());

        public static ShirtService Instance => instance.Value;

        private ShirtService()
        {
            LoadShirts();
            RandomizeShirt();
        }

        public ObservableCollection<Shirt> Shirts { get; private set; } = new ObservableCollection<Shirt>();

        public Shirt CurrentShirt { get; set; }

        public void LoadShirts()
        {
            Shirts.Clear();
            var shirtsFromDatabase = DatabaseService.GetShirts();
            foreach (var shirt in shirtsFromDatabase)
            {
                Shirts.Add(shirt);
            }
        }

        public void RandomizeShirt()
        {
            if (Shirts.Count == 0)
                return;

            Random rand = new Random();
            int randIndex = rand.Next(Shirts.Count);
            CurrentShirt = Shirts[randIndex];
        }

        public void SetCurrentShirt(Shirt newShirt)
        {
            CurrentShirt = newShirt;
        }
    }
}
