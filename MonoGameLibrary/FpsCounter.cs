using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLibrary
{
    public static class FpsCounter
    {
        private static List<double> tmp = new List<double>();
        public static int BufferSize = 1;
        private static int fpsResult = 0;
        private static int count = 0;

        //  System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        public static double getDeltaTime(GameTime gameTime)
        {
            double delta = (double)gameTime.ElapsedGameTime.Milliseconds/1000;

            // Console.WriteLine(n);
            // sw.Stop();
            // double res = sw.ElapsedMilliseconds ;
            // sw.Reset();
            // sw.Start();
            return delta;
        }
        public static int fpsCounter(double delta)
        {
            tmp.Add(1 / delta * 1000);
            if (count == BufferSize)
            {
                int total = 0;
                foreach (int i in tmp)
                {
                    total += i;
                }
                fpsResult = total / BufferSize;
                if (fpsResult < 0) fpsResult = 0;
                tmp.Clear();
                count = 0;
            }
            count++;
            return fpsResult;
        }
    }
}
