using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KFZApp.Model;
using System.Threading.Tasks;
using System.ComponentModel; //Brauchen wir für INotifyPropertyChanged

namespace KFZApp.ViewModels
{
    class MainViewModel : INotifyPropertyChanged //vgl. abstrakten Klasse
    {
        public List<KFZ> AlleKFZs { get; set; }
        public KFZ _selectedKFZ;
        public KFZ SelectedKFZ
        {
            get
            {
                return _selectedKFZ;
            }

            set
            {
                _selectedKFZ = value;
                
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedKFZ"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel() //Standardkonstruktor
        {
            AlleKFZs = new List<KFZ>();
            AlleKFZs.Add(new KFZ() { Kennzeichen = "S-RT 584", Typ = "SUV", Leistung = 90, FahrgestellNr = "FG-0815472312_C" });
            AlleKFZs.Add(new KFZ() { Kennzeichen = "RT-XD 5213", Typ = "Cabrio", Leistung = 225, FahrgestellNr = "FX-5123451_A" });
            AlleKFZs.Add(new KFZ() { Kennzeichen = "B-BD 4302", Typ = "Crossover", Leistung = 112, FahrgestellNr = "FM-2526212_J" });


        }


    }
}
