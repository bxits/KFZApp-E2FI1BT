using LinqToDB.Mapping;

namespace Model
{
	[Table(Name = "kfztable")]
    public class KFZ
    {
        [Column(Name = nameof(idKFZ)), Identity, PrimaryKey]
        public int? idKFZ { get; set; }

        [Column(Name = nameof(Kennzeichen))]
        public string Kennzeichen { get; set; }

        [Column(Name = nameof(Typ))]
        public string Typ { get; set; }

        [Column(Name = nameof(Leistung))]
        public int? Leistung { get; set; }

        [Column(Name = nameof(FahrgestellNummer))]
        public string FahrgestellNummer { get; set; }
    }
}
