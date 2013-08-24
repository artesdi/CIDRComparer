namespace CIDRComparer
{
    public class CIDRComparator
    {
        public CIDRComparatorResult CompareCidr(string a, string b)
        {
            var result = CIDRComparatorResult.None;

            var ipA = new IPBinary(a);
            var ipB = new IPBinary(b);

            if (ipA.Prefix == null || ipB.Prefix == null)
            {
                return result;
            }

            result = CIDRComparatorResult.Disjoint;

            if (ipA.Mask == ipB.Mask)
            {
                if (CompareOnEquals(ipA, ipB))
                {
                    result = CIDRComparatorResult.Equals;
                }
            }
            else if (ipA.Mask > ipB.Mask)
            {
                if (CompareOnSubset(ipA, ipB))
                {
                    result = CIDRComparatorResult.Subset;
                }
            }
            else if (ipA.Mask < ipB.Mask)
            {
                if (CompareOnSuperset(ipA, ipB))
                {
                    result = CIDRComparatorResult.Superset;
                }
            }

            return result;
        }

        private bool CompareOnEquals(IPBinary ip1, IPBinary ip2)
        {
            for (var i = 0; i < ip1.Mask; i++)
            {
                if (ip1.Prefix[i] != ip2.Prefix[i])
                {
                    return false;
                }
            }
            return true;
        }

        private bool CompareOnSubset(IPBinary ip1, IPBinary ip2)
        {
            for (var i = 0; i < ip1.Mask; i++)
            {
                if (ip1.Prefix[i] != ip2.Prefix[i])
                {
                    return false;
                }
            }
            return true;
        }

        private bool CompareOnSuperset(IPBinary ip1, IPBinary ip2)
        {
            for (var i = 0; i < ip2.Mask; i++)
            {
                if (ip1.Prefix[i] != ip2.Prefix[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}