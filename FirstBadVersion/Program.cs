/*
 You are a product manager and currently leading a team to develop a new product.Unfortunately, the latest version of your product fails the quality check.
 Since each version is developed based on the previous version, all the versions after a bad version are also bad.
 
Suppose you have n versions[1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.

You are given an API bool isBadVersion(version) which returns whether version is bad.Implement a function to find the first bad version.You should minimize the number of calls to the API.
*/


using System;

namespace FirstBadVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    /* The isBadVersion API is defined in the parent class VersionControl.
          bool IsBadVersion(int version); */

    public class VersionControl
    {
        public bool IsBadVersion(int version)
        {
            return false;
        }
    }

    public class Solution : VersionControl
    {
        public int FirstBadVersion(int n)
        {
            if (n == 1)
                return n;

            Int64 loVersion = 1;
            Int64 hiVersion = n;
            if (IsBadVersion((int)loVersion))
                return 1;

            while (loVersion < hiVersion)
            {
                var version = (hiVersion + loVersion) / 2;
                var isBad = IsBadVersion((int)version);
                if (isBad)
                    hiVersion = version;
                else
                    loVersion = version;

                if (hiVersion - loVersion == 1)
                    break;
            }

            return (int)hiVersion;
        }
    }

}
