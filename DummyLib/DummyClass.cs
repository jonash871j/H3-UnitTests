using System;

namespace DummyLib
{
    public class DummyClass
    {
        public bool IsAllowed(string username)
        {
            if (username == "admin")
            {
                return true;
            }
            return false;
        }

        public double AbsNumber(double value)
        {
            return Math.Abs(value);
        }

        public double SignNumber(double value)
        {
            return Math.Sign(value);
        }
    }
}
