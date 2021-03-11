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

        public MainViewModel()
        {
            AlleKFZs = new List<KFZ>();
            AlleKFZs.Add(new KFZ() { Kennzeichen = "S-RT 584" });
            AlleKFZs.Add(new KFZ() { Kennzeichen = "RT-XD 5213" });
            AlleKFZs.Add(new KFZ() { Kennzeichen = "B-BD 4302" });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
