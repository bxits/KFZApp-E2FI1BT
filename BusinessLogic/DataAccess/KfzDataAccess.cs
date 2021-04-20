using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LinqToDB;
using Model;

namespace BusinessLogic.DataAccess
{
	class KfzDataAccess
	{
		public List<KFZ> FilterKFZ()
		{
			using (var db = new DbDev())
			{
				return (from kfzs in db.Kfz select kfzs).ToList();
			}
		}

		public void SaveDomainObjectList<T>(IEnumerable<T> domainObjects)
		{
			using (var db = new DbDev())
			{
				foreach (var domainObject in domainObjects)
				{
					var propertyInfo = domainObject.GetType().GetProperties()
						.FirstOrDefault(a => a.CustomAttributes.Any(c => c.AttributeType.Name == "IdentityAttribute"));
					if (propertyInfo?.GetValue(domainObject) != null)
					{
						db.Update(domainObject);
					}
					else
					{
						db.Insert(domainObject);
					}
				}
			}
		}

		public void SaveDomainObject<T>(T domainObject)
		{
			using (var db = new DbDev())
			{
				var propertyInfo = domainObject.GetType().GetProperties()
					.FirstOrDefault(a => a.CustomAttributes.Any(c => c.AttributeType.Name == "IdentityAttribute"));
				if (propertyInfo?.GetValue(domainObject) != null)
				{
					db.Update(domainObject);
				}
				else
				{
					db.Insert(domainObject);
				}
			}
		}
	}
}
