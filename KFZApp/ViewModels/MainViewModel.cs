using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel; //Brauchen wir für INotifyPropertyChanged
using System.Windows.Input;  //Brauchen wir für ICommand
using CommandHelper;
using CommonTypes;
using DataAccess;

namespace KFZApp.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public List<KFZ> AlleKFZs { get; set; }
        private KFZ _selectedKFZ;
        private ICommand _saveAllKFZCommand;

        
        public ICommand SaveAllKFZCommand
        {
            //Damit der Button-Click-Event später zu der Methode
            //SaveAllKFZ() umgeleitet wird.
            //Dieser get wird beim Start des Programms aufgerufen, nicht
            //beim Klicken des Buttons.
            get
            {
                if (_saveAllKFZCommand == null)
                {
                    _saveAllKFZCommand = new RelayCommand(c => SaveAllKFZ());
                }
                return _saveAllKFZCommand;
            }

        }

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

        //Das müssen wir hier implementieren, weil das das Interface "INotifyPropertyChanged" vorgibt.
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel() //Standardkonstruktor
        {
            AlleKFZs = new List<KFZ>();
            AlleKFZs.Add(new KFZ() { Kennzeichen = "S-RT 584", Typ = "SUV", Leistung = 90, FahrgestellNr = "FG-0815472312_C" });
            AlleKFZs.Add(new KFZ() { Kennzeichen = "RT-XD 5213", Typ = "Cabrio", Leistung = 225, FahrgestellNr = "FX-5123451_A" });
            AlleKFZs.Add(new KFZ() { Kennzeichen = "B-BD 4302", Typ = "Crossover", Leistung = 112, FahrgestellNr = "FM-2526212_J" });
        }

        private void SaveAllKFZ()
        {
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            //Diese Methode speichert die Liste AllKFZs in der DB.
            foreach (var kfz in AlleKFZs)
            {
                da.SaveKFZ(kfz);
            }

        }
    }
}
