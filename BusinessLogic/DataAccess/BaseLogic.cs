using System.Collections.Generic;
using Model;

namespace BusinessLogic.DataAccess
{
	public class BaseLogic
	{
		private KfzDataAccess _dataAccess;
		public BaseLogic()
		{
			_dataAccess = new KfzDataAccess();
		}
		public void SaveAllKFZ(List<KFZ> alleKfZs)
		{
			_dataAccess.SaveDomainObjectList(alleKfZs);
		}

		public void SaveSingleKFZ(KFZ selectedKfz)
		{
			_dataAccess.SaveDomainObject(selectedKfz);
		}

		public List<KFZ> FilterKFZ()
		{
			return _dataAccess.FilterKFZ();
		}
	}
}
