namespace Snooker
{
    public static class Currency
    {
        public static float GbhInHuf = 380.0f;
        public static double GbhToHuf(double huf)
        {
            return huf * Currency.GbhInHuf;
        }
    }

    public enum Currencies
    {
        HUF,
        GBH
    }
}
