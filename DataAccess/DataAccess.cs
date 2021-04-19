using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonTypes;

namespace DataAccess
{
    public class DataAccess
    {
        public void SaveKFZ(KFZ kfz)
        {
            MessageBox.Show($"Jetzt wird KFZ {kfz.Kennzeichen} gespeichert.");
            //In Azure-DB speichern

        }
    }
}
