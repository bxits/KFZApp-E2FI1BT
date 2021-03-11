using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KFZApp.Model;
using System.Threading.Tasks;

namespace KFZApp.ViewModels
{
    class MainViewModel
    {
        public List<KFZ> AlleKFZs { get; set; }

        public MainViewModel()
        {
            AlleKFZs = new List<KFZ>();
            AlleKFZs.Add(new KFZ() { Kennzeichen = "S-RT 584" });
            AlleKFZs.Add(new KFZ() { Kennzeichen = "RT-XD 5213" });
            AlleKFZs.Add(new KFZ() { Kennzeichen = "B-BD 4302" });
        }
    }
}
