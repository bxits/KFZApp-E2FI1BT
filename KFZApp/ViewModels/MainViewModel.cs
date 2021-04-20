using System;
using System.Collections.Generic;
using System.ComponentModel; //Brauchen wir für INotifyPropertyChanged
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using BusinessLogic.DataAccess;
using CommandHelper;
using Model;

namespace KFZApp.ViewModels
{
	class MainViewModel : INotifyPropertyChanged //vgl. abstrakten Klasse
	{
		private List<KFZ> _alleKfZs;
		private KFZ _selectedKfz;
		private ICommand _saveAllKfzCommand;
		private ICommand _saveDetailKfzCommand;
		private BaseLogic _baseLogic;

		public MainViewModel()
		{
			//AlleKFZs = new List<KFZ>();
			//AlleKFZs.Add(new KFZ()
			//	{ Kennzeichen = "S-RT 584", Typ = "Suv", Leistung = 456, FahrgestellNummer = "ashfa5as4f4a6" });
			//AlleKFZs.Add(new KFZ()
			//	{ Kennzeichen = "RT-XD 5213", Typ = "Coupe", Leistung = 80, FahrgestellNummer = "ashf239as87faff" });
			//AlleKFZs.Add(new KFZ()
			//	{ Kennzeichen = "B-BD 4302", Typ = "Roller", Leistung = 120, FahrgestellNummer = "ahff9a7sfjnälsg0" });
			_baseLogic = new BaseLogic();
			AlleKFZs = _baseLogic.FilterKFZ();
		}

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

		public KFZ SelectedKfz
		{
			set
			{
				_selectedKfz = value;
				NotifyPropertyChanged(nameof(SelectedKfz));
			}
			get => _selectedKfz;
		}

		public ICommand SaveAllKFZCommand
		{
			get
			{
				return _saveAllKfzCommand ?? (_saveAllKfzCommand = new RelayCommand(c => SaveAllKFZ()));
			}
		}

		public ICommand SaveDetailKFZCommand
		{
			get
			{
				return _saveDetailKfzCommand ?? (_saveDetailKfzCommand = new RelayCommand(c => SaveDetailKFZ()));
			}
		}

		private void SaveAllKFZ()
		{
			_baseLogic.SaveAllKFZ(AlleKFZs);
			MessageBox.Show("Gespeichert");
		}
		private void SaveDetailKFZ()
		{
			_baseLogic.SaveSingleKFZ(SelectedKfz);
			MessageBox.Show($"{SelectedKfz.Kennzeichen} Gespeichert");
		}

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
