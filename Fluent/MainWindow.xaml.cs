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
using FluentValidation;
using FluentValidation.Results;

namespace Fluent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Persona> People = new List<Persona>();
        public MainWindow()
        {
            InitializeComponent();

        }
       
        private void stylesBack()
        {
            NError.Text = "";
            NError.Background = null;
            LError.Text = "";
            LError.Background = null;
            DateError.Text = "";
            DateError.Background = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime time;
            Persona person = new Persona();
            person.Name = XName.Text;
            person.LastName = XLastName.Text;
            bool parse = DateTime.TryParse(XBdate.Text, out time);
            if (parse)
            {
                person.BirthDate = time;
            }
            
            

            PersonaValidate validator = new PersonaValidate();
            
            //validator.ValidateAndThrow(person);
            var results = validator.Validate(person);
            bool success = results.IsValid;
            
            if (success == true)
            {
                XName.Background = Brushes.GreenYellow;
                XLastName.Background = Brushes.GreenYellow;
                XBdate.Background = Brushes.GreenYellow;
                stylesBack();
            }
            else
            {
                foreach(var failures in results.Errors)
                {
                    if (failures.PropertyName == "Name")
                    {
                        NError.Text = " " + failures.ErrorMessage;
                        NError.Background = Brushes.Red;
                    }
                    else if (failures.PropertyName == "LastName")
                    {
                        LError.Text = " " + failures.ErrorMessage;
                        LError.Background = Brushes.Red;
                    }
                    else
                    {
                        DateError.Text = " " + failures.ErrorMessage;
                        DateError.Background = Brushes.Red;
                    }
                }
            }
            





        }
    }
}
