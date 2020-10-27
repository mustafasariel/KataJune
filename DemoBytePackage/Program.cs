using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace DemoBytePackage
{
    class Program
    {
        private byte start = 240;
        private byte finish = 241;
        private byte count = 3;
        static private Dictionary<int, byte[]> list = new Dictionary<int, byte[]>();

        static void Main(string[] args)
        {
            FillPackages(1, new byte[] {240, 240, 240, 1, 2, 3, 4});
            FillPackages(1, new byte[] {5, 6, 7, 8,241,241,241});
            FillPackages(1, new byte[] {240,240,240,9, 10, 11, 12, 13, 14, 15});
            FillPackages(1, new byte[] {16, 17, 18});
            FillPackages(2, new byte[] {240, 240, 240, 1, 2, 3, 4, 241, 241, 241});


            Console.WriteLine("*************************************");
            WriteToConsole(list);
        }

        private static void WriteToConsole(Dictionary<int, byte[]> dictionary)
        {
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} : {string.Join(",", item.Value)}");
            }
        }

        static bool IsFirstStartNumber(byte[] arr, byte b, byte count)
        {
            for (int i = 0; i < count; i++)
            {
                if (arr[i] != b)
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsFullPackage(byte[] arr, byte start, byte finish, byte count)
        {
            var bStart = IsFirstStartNumber(arr, start, count);
            var bFinish = IsLastFinishNumber(arr, finish, count);
            if (bStart == true && bFinish == true)
            {
                return true;
            }

            return false;
        }

        static bool IsLastFinishNumber(byte[] arr, byte b, byte count)
        {
            var arr2 = arr.Reverse().ToArray<byte>();
            for (int i = 0; i < count; i++)
            {
                if (arr[i] != b)
                {
                    return false;
                }
            }

            return true;
        }


        static void FillPackages(int id, byte[] arr)
        {
            byte[] f;

            if (list.TryGetValue(id, out f))
            {


                list[id] = ConcatArrays(f, arr);
            }
            else
            {
                list.Add(id, arr);
            }

            //Console.WriteLine(string.Join(",", f));
        }

        public static T[] ConcatArrays<T>(params T[][] args)
        {
            if (args == null)
                throw new ArgumentNullException();

            var offset = 0;
            var newLength = args.Sum(arr => arr.Length);

            var newArray = new T[newLength];

            foreach (var arr in args)
            {
                Buffer.BlockCopy(arr, 0, newArray, offset, arr.Length);
                offset += arr.Length;
            }

            return newArray;
        }

        public class FullPackage
        {
            public int Id { get; set; }
            public byte[] Bytes;
        }
    }
}