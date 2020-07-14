using System;
using System.Collections.Generic;
using System.Reflection;

namespace ObjectCompareDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            User user1 = new User { Age = 9, Id = 1, Name = "Kerem", Sex = 'E' };
            User user2 = new User { Age = 9, Id = 1, Name = "Emirhan", Sex = 'E' };


            var difreneces = CompareObjectsAndGetDifferences<User>(user1, user2);


            foreach (var item in difreneces)
            {
                Console.WriteLine(item);
            }
        }

        public static List<MemberComparisonResult> CompareObjectsAndGetDifferences<T>(T firstObj, T secondObj)
        {
            var differenceInfoList = new List<MemberComparisonResult>();

            foreach (var member in typeof(T).GetProperties())
            {
                if (member.MemberType == MemberTypes.Property)
                {
                    var property = (PropertyInfo)member;
                    if (property.CanRead && property.GetGetMethod().GetParameters().Length == 0)
                    {
                        var xValue = property.GetValue(firstObj, null);
                        var yValue = property.GetValue(secondObj, null);
                        if (!object.Equals(xValue, yValue))
                            differenceInfoList.Add(new MemberComparisonResult(property.Name, xValue, yValue));
                    }
                    else
                        continue;
                }
            }
            return differenceInfoList;
        }
    }
}
