using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace ThumnailDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch st = new Stopwatch();
            st.Start();
            string path = @"D:\demo\deneme";


            var files = Directory.GetFiles(path);

            Parallel.ForEach(files, (item) =>
            {
                Image image = new Bitmap(item);
                Image thumbnail = image.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);
                thumbnail.Save(Path.Combine(path, "thumbnail2", Path.GetFileName(item)));
            });
        
            st.Stop();

            WriteToConsole($"Süre:{st.ElapsedMilliseconds}");
            st.Reset();

            st.Start();

            foreach (var item in files)
            {
                Image image = new Bitmap(item);
                Image thumbnail = image.GetThumbnailImage(50, 50, () => false, IntPtr.Zero);
                thumbnail.Save(Path.Combine(path, "thumbnail1", Path.GetFileName(item)));
            }

            WriteToConsole($"Süre:{st.ElapsedMilliseconds}");


        }

        static void WriteToConsole(string msg)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}