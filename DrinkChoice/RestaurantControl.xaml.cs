using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrinkChoice
{
    /// <summary>
    /// Interaction logic for RestaurantControl.xaml
    /// </summary>
    public partial class RestaurantControl : UserControl
    {
        public RestaurantControl()
        {
            InitializeComponent();
        }


        public void LoadChoices()
        {
            //Create and addd checkboxes for all SodaChoices

            if(DataContext is Restaurant r)
            {
                //We want a checkbox for everything in r PossibleSodas
                //Put all checkboxes in a stack panel
                StackPanel stack = new();

                foreach (SodaChoice choice in r.PossibleSodas)
                {
                    //Creates a checkbox for each choice in PossibleSodas, set up its binding and made connections
                    CheckBox box = new();
                    box.DataContext = choice;
                    Binding binding = new();
                    binding.Path = new PropertyPath(nameof(choice.Chosen));
                    binding.Mode = BindingMode.TwoWay;
                    BindingOperations.SetBinding(box, CheckBox.IsCheckedProperty, binding);

                    //Adds the content of the checkbox
                    TextBlock block = new();
                    block.Text = choice.ToString();
                    box.Content = block;


                    //Makes checkboxes part of the elements tree
                    stack.Children.Add(box);        //adds the checkbox to the stack panel
                }
                //Add stack to my dock panel MUST HAVE A NAME
                restDock.Children.Add(stack);   //Adds the stackpanel to the dock panel
            }
        }
    }
}
