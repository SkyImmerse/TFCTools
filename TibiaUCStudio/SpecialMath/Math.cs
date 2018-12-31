

namespace Game.SpecialMath
{
    public static class GlobalMembersMath
    {

        public static uint Adler32(byte[] data, int index, int length)
        {
            const ushort adler = 65521;

            uint a = 1, b = 0;

            while (length > 0)
            {
                int tmp = (length > 5552) ? 5552 : length;
                length -= tmp;

                do
                {
                    a += data[index++];
                    b += a;
                } while (--tmp > 0);

                a %= adler;
                b %= adler;
            }

            return (b << 16) | a;
        }

        public static int random_range(int min, int max)
        {
            return 0;
        }

        public static float random_range(float min, float max)
        {

            return 0;
        }

        public static double round(double r)
        {
            return (r > 0.0) ? System.Math.Floor(r + 0.5) : System.Math.Ceiling(r - 0.5);
        }
    }
}