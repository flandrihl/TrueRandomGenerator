using System.Security.Cryptography;

namespace TrueRandomGenerator
{
    public  class Random
    {
        public static int Next()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[4];
                rng.GetBytes(randomNumber);
                int trueRandomNumber = BitConverter.ToInt32(randomNumber, 0);

                return trueRandomNumber;
            }
        }
    }
}