using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace TrueRandomGenerator
{
    public  class Random
    {
        public static T? Next<T>() where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[Marshal.SizeOf(typeof(T))];
                rng.GetBytes(randomNumber);
                var trueRandomNumber = GetRandom<T>(randomNumber);

                return trueRandomNumber;
            }
        }

        private static T? GetRandom<T>(byte[] bytes) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
        {
            T? GetResult<TResult>(TResult value) => Convert.ChangeType(value, typeof(T)) as T?;

            if (typeof(T) == typeof(byte))
                return GetResult(bytes[0]);
            if (typeof(T) == typeof(char))
                return GetResult(BitConverter.ToChar(bytes, 0));
            if (typeof(T) == typeof(bool))
                return GetResult(BitConverter.ToBoolean(bytes, 0));
            if (typeof(T) == typeof(short))
                return GetResult(BitConverter.ToInt16(bytes, 0));
            if (typeof(T) == typeof(ushort))
                return GetResult(BitConverter.ToUInt16(bytes, 0));
            if (typeof(T) == typeof(int))
                return GetResult(BitConverter.ToInt32(bytes, 0));
            if (typeof(T) == typeof(uint))
                return GetResult(BitConverter.ToUInt32(bytes, 0));
            if (typeof(T) == typeof(long))
                return GetResult(BitConverter.ToInt64(bytes, 0));
            if (typeof(T) == typeof(ulong))
                return GetResult(BitConverter.ToUInt64(bytes, 0));
            if (typeof(T) == typeof(float))
                return GetResult(BitConverter.ToSingle(bytes, 0));
            if (typeof(T) == typeof(double))
                return GetResult(BitConverter.ToDouble(bytes, 0));
            if (typeof(T) == typeof(string))
                return GetResult(BitConverter.ToDouble(bytes, 0));

            return default(T?);
        }
    }
}