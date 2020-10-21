using System.Linq;
using System;
namespace WindowsServiceCsvFileWorker.Model
{
    public class AirlineSafety
    {
        public static bool CanCreate(string fileLine)
        {
            var elements = fileLine.Split(',')?.ToList();
            if (fileLine is null)
                return false;
            if (elements.Count != 8)
                return false;
            if (elements.Any(x => x is null))
                return false;
            if (elements.Skip(1).All(x => x.Map((v) => long.TryParse(v, out _))))
                return false;
            return true;
        }
        public  AirlineSafety()
        {

        }
        public static AirlineSafety Create(string fileLine)
        {
            if (CanCreate(fileLine))
                return new AirlineSafety(fileLine);
            else
                return null;
        }
        private AirlineSafety(string fileLine)
        {
            var elements = fileLine.Split(',');
            Name = elements[0];
            AvailableSeatKilometers = elements[1].Map(long.Parse);
            IncidentsBetween1985And1999 = elements[2].Map(long.Parse);
            FatalAccidentsBetween1985And1999 = elements[3].Map(long.Parse);
            FatalitiesBetween1985And1999 = elements[4].Map(long.Parse);
            IncidentsBetween2000And2014 = elements[5].Map(long.Parse);
            FatalAccidentsBetween2000And2014 = elements[6].Map(long.Parse);
            FatalitiesBetween2000And2014 = elements[7].Map(long.Parse);
        }
        public string Name { get; set; }
        public long AvailableSeatKilometers { get; set; }
        public long IncidentsBetween1985And1999 { get; set; }
        public long FatalAccidentsBetween1985And1999 { get; set; }
        public long FatalitiesBetween1985And1999 { get; set; }
        public long IncidentsBetween2000And2014 { get; set; }
        public long FatalAccidentsBetween2000And2014 { get; set; }
        public long FatalitiesBetween2000And2014 { get; set; }
    }
}
