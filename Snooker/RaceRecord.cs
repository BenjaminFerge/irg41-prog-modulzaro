using System;

namespace Snooker
{
    public class RaceRecord
    {
        private readonly int _place;
        private readonly string _name;
        private readonly string _nation;
        private readonly double _prize;

        public static string China = "Kína";
        public static string Norway = "Norvégia";
        public static int PlaceIdx = 0;
        public static int NameIdx = 1;
        public static int NationIdx = 2;
        public static int PrizeIdx = 3;

        public RaceRecord(int place, string name, string nation, double prize)
        {
            _place = place;
            _name = name;
            _nation = nation;
            _prize = prize;
        }

        public static RaceRecord Create(string row)
        {
            return Create(row.Split(RaceTable.SplitBy));
        }

        public static RaceRecord Create(string[] row)
        {
            int colc = row.Length;
            if (colc != 4)
            {
                throw new ExamException(
                    String.Format("Érvénytelen oszlopszám. " +
                        "Várt: {0}, kapott: {1}", colc, RaceTable.ColumnCount));
            }

            string name = row[NameIdx];
            string nation = row[NationIdx];
            string placeStr = row[PlaceIdx];
            string prizeStr = row[PrizeIdx];

            if (!Int32.TryParse(placeStr, out int place))
            {
                throw new ExamException(
                    String.Format("Helyezés nem szöveg: {0}", placeStr));
            }
            if (!Double.TryParse(prizeStr, out double prize))
            {
                throw new ExamException(
                    String.Format("Díj nem szöveg: {0}", prizeStr));
            }

            return new RaceRecord(place, name, nation, prize);
        }

        private bool IsNationality(string nation)
        {
            return _nation == Norway;
        }

        public bool IsNorwegian()
        {
            return IsNationality(Norway);
        }

        public double GetPrize()
        {
            return _prize;
        }

        public double GetPrizeIn(Currencies currency)
        {
            switch (currency)
            {
                case Currencies.HUF:
                    return Currency.GbhToHuf(_prize);
                case Currencies.GBH:
                    return _prize;
                default:
                    throw new ExamException(
                        String.Format("Valuta ({0}) nincs implementálva.",
                            currency));
            }
        }

        public string GetNation()
        {
            return _nation;
        }

        public int GetPlace()
        {
            return _place;
        }

        public override string ToString()
        {
            return String.Format(
                "\tHelyezés: {0}\n" +
                "\tNév: {1}\n" +
                "\tOrszág: {2}\n" +
                "\tNyeremény összege: {3:n0} Ft\n",
                _place, _name, _nation, GetPrizeIn(Currencies.HUF));
        }
    }
}
