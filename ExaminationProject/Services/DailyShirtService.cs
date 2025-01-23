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

        private ShirtService() { }

        public DateTime LastTimeUsed = new DateTime(2025, 1, 12);

        public int AmountOfTimesUsed = 10;

        public ObservableCollection<Shirt> Shirts { get; private set; } = new ObservableCollection<Shirt>();
        private Shirt _currentShirt;
        public Shirt CurrentShirt
        {
            get => _currentShirt;
            set
            {
                if (_currentShirt != value)
                {
                    _currentShirt = value;
                    CurrentShirtChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public event EventHandler CurrentShirtChanged;

        public void LoadShirts()
        {
            /* Implementation */
            Shirts.Clear();
            var shirtsFromDatabase = DatabaseService.GetShirts();
            foreach (var shirt in shirtsFromDatabase)
            {
                Shirts.Add(shirt);
            }
        }

        public void RandomizeShirt() {
            /* Implementation */
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
