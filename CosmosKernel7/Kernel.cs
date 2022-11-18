using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.Drawing;
using Cosmos.System.Graphics;

namespace CosmosKernel7
{
    public class Kernel : Sys.Kernel
    {
        private static int screenX = 800;
        private static int screenY = 640;
        private static Color[] pixelBuffer = new Color[(screenX * screenY) + screenX];
        private static Color[] pixelBufferOld = new Color[(screenX * screenY) + screenX];
        private static Canvas canvas;
        protected override void BeforeRun()
        {
            canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(screenX, screenY, ColorDepth.ColorDepth8));
        }
        protected override void Run()
        {

            while (true) {
                update();
            }

            
        }

        public static void setPixel(int x, int y, Color c)
        {
            if (x > screenX || y > screenY) return;
            pixelBuffer[(x * y) + x] = c;
        }
        public static void drawScreen()
        {
            Pen pen = new Pen(Color.Orange);
            for (int y = 0, h = screenY; y < h; y++)
            {
                for (int x = 0, w = screenX; x < w; x++)
                {
                    if (!(pixelBuffer[(y * x) + x] == pixelBufferOld[(y * y) + x]))
                    {
                        pen.Color = pixelBuffer[(y * screenX) + x];
                        canvas.DrawPoint(pen, x, y);
                    }
                }
            }
            for (int i = 0, len = pixelBuffer.Length; i < len; i++)
            {
                pixelBuffer[i] = pixelBufferOld[i];
            }
            canvas.Display();
        }
        public static void clearScreen(Color c)
        {
            for (int i = 0, len = pixelBuffer.Length; i < len; i++)
            {
                pixelBuffer[i] = c;
            }
        }
        public static void update()
        {
            clearScreen(Color.Blue);
            setPixel(1, 1, Color.Black);
            setPixel(1, 2, Color.Black);
            setPixel(2, 1, Color.Black);
            setPixel(2, 2, Color.Black);
            drawScreen();
        }
    }
}
