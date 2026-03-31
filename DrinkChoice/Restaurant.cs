using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkChoice
{
    public class Restaurant : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public string Name { get; init; }

        private List<SodaChoice> _possibleSodas = new List<SodaChoice>();
        public List<SodaChoice> PossibleSodas => _possibleSodas;

        public void OnChosenChange(object? sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumChosen)));
        }

        public Restaurant(string n)
        {
            Name = n;

            foreach (SodaType soda in Enum.GetValues(typeof(SodaType)))
            {
                SodaChoice choice = new SodaChoice(soda);
                PossibleSodas.Add(new SodaChoice(soda));
            }

            foreach(SodaChoice choice in PossibleSodas)
            {
                choice.PropertyChanged += OnChosenChange;
            }
        }

        public int NumChosen
        {
            get
            {
                int count = 0;
                foreach (SodaChoice choice in PossibleSodas)
                {
                    if (choice.Chosen) count++;
                }

                return count;
            }
        }
    }
}
