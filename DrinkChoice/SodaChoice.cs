using System.ComponentModel;

namespace DrinkChoice
{
    public class SodaChoice : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public SodaType Soda { get; init; }

        private bool _chosen = false;
        public bool Chosen
        {
            get => _chosen;
            set
            {
               _chosen = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Chosen)));
            }
        }

        public SodaChoice(SodaType type)
        {
            Soda = type;
        }

        public override string ToString()
        {
            switch (Soda)
            {
                case SodaType.Coke:
                    return "Coke";
                case SodaType.DietCoke:
                    return "Diet Coke";
                case SodaType.DrPepper:
                    return "Dr. Pepper";
                case SodaType.DietDrPepper:
                    return "Diet Dr. Pepper";
                case SodaType.MountainDew:
                    return "Mountain Dew";
                case SodaType.Sprite:
                    return "Sprite";
                case SodaType.RootBeer:
                    return "Root Beer";
                default:
                    return "No match";
            }
        }
    }
}
