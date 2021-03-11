using System.Collections.Generic;
using KFZApp.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices; //Brauchen wir für INotifyPropertyChanged

namespace KFZApp.ViewModels
{
    class MainViewModel : INotifyPropertyChanged //vgl. abstrakten Klasse
    {
	    private List<KFZ> _alleKfZs;

	    public List<KFZ> AlleKFZs
	    {
		    get => _alleKfZs;
		    set
		    {
			    if (value != null)
			    {
					_alleKfZs = value;
					NotifyPropertyChanged();
				}
		    }
	    }

	    public MainViewModel()
        {
            AlleKFZs = new List<KFZ>();
            AlleKFZs.Add(new KFZ() { Kennzeichen = "S-RT 584", Typ = "Suv"});
            AlleKFZs.Add(new KFZ() { Kennzeichen = "RT-XD 5213", Typ = "Coupe"});
            AlleKFZs.Add(new KFZ() { Kennzeichen = "B-BD 4302", Typ = "Roller"});
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
	        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
