using System;

namespace CIDRComparer
{
    internal class IPBinary
    {
        public bool[] Prefix { get; private set; }
        public ushort Mask { get; private set; }

        public IPBinary(string prefix, string mask)
        {
            try
            {
                Prefix = ConvertIpToBinary(prefix);
                Mask = Convert.ToUInt16(mask);
            }
            catch
            {
                Prefix = null;
            }
        }

        public IPBinary(string subnet)
        {
            try
            {
                var prefix = subnet.Split('/')[0];
                var mask = subnet.Split('/')[1];

                Prefix = ConvertIpToBinary(prefix);
                Mask = Convert.ToUInt16(mask);
            }
            catch
            {
                Prefix = null;
            }
        }

        private bool[] ConvertIpToBinary(string stringIp)
        {
            var result = new bool[32];
            var resultIndexer = 0;
            var quartet = stringIp.Split('.');

            foreach (var s in quartet)
            {
                var stringOktet = Convert.ToString(UInt16.Parse(s), 2);
                var binOktet = new bool[8];

                for (var i = 1; i <= stringOktet.Length; i++)
                {
                    binOktet[binOktet.Length - i] = CharToBoolean(stringOktet[stringOktet.Length - i]);
                }
                foreach (var b in binOktet)
                {
                    result[resultIndexer++] = b;
                }
            }
            return result;
        }

        private bool CharToBoolean(char ch)
        {
            return Convert.ToBoolean((UInt16.Parse(ch.ToString())));
        }
    }
}