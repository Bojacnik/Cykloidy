namespace Data.Basic.Implementations
{
    public struct Degree : IEquatable<Degree>
    {
        int degrees;
        public Degree(int degrees)
        {
            this.degrees = normalize(degrees);
        }

        public int Get()
        {
            return degrees;
        }
        public void Set(int degrees)
        {
            this.degrees = normalize(degrees);
        }

        private static int normalize(int degrees)
        {
            if (degrees >= 0 && degrees <= 359)
            {
                return degrees;
            }
            else
            {
                degrees %= 360;
                if (degrees < 0)
                {
                    degrees += 360;
                }
                return degrees;
            }
        }

        public bool Equals(Degree other)
        {
            if (this.degrees == other.degrees) return true;
            return false;
        }

        public static Degree operator +(Degree first, Degree second)
        {
            return new Degree(first.Get() + second.Get());
        }
        public static Degree operator -(Degree first, Degree second)
        {
            return new Degree(first.Get() - second.Get());
        }
        public static Degree operator *(Degree first, Degree second)
        {
            return new Degree(first.Get() * second.Get());
        }
        public static Degree operator /(Degree first, Degree second)
        {
            return new Degree(first.Get() / second.Get());
        }

    }
}
