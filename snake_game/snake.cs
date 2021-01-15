using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

class Snake
{
    static void Main(string[] args)
    {
        var rand = new Random();

        Console.WindowHeight = 16;
        Console.WindowWidth = 32;
        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowWidth;
        Border border = new Border(screenWidth, screenHeight);
 
        Pixel berry = new Pixel(rand.Next(0, screenWidth), 
                                rand.Next(0, screenHeight),
                                ConsoleColor.Cyan);

        Pixel snakeHead = new Pixel(screenWidth/2, 
                                    screenHeight/2,
                                    ConsoleColor.Red);

        List<Pixel> snake = new List<Pixel>() {
                                              new Pixel(screenWidth/2, screenHeight/2 + 1, ConsoleColor.Cyan),
                                              new Pixel(screenWidth/2, screenHeight/2 + 2, ConsoleColor.Cyan),
                                              new Pixel(screenWidth/2, screenHeight/2 + 3, ConsoleColor.Cyan),
                                              new Pixel(screenWidth/2, screenHeight/2 + 4, ConsoleColor.Cyan),
                                              };


        ///--------------------------------- THE MAIN LOOP STARTS HERE ---------------------------------
        drawEmptyBoard(border);/// draw the entire board once 
        while (true)
        {
            reDrawBoard(berry, snake, snakeHead);

            if (berry.Equals(snakeHead))
            {
                berry = new Pixel(rand.Next(0, screenWidth),
                                rand.Next(0, screenHeight),
                                ConsoleColor.Cyan);

                /// append + to snake(probs based on movement, and the position of last Pixel)
                /// var lastPixel = snake[snake.Count - 1]
                /// appendSnake(lastPixel, movementDirection)
            }
            if (snake.Contains(snakeHead) || (border.borderPixels.Contains(snakeHead)))
            {

            }


        }
        static void reDrawBoard(Pixel berry, List<Pixel> snake, Pixel snakeHead)
        {
            int pass;
            ///init list of points with all zeros and input berry, snake and snakeHead
        }

        static void drawEmptyBoard(Border border)
        {

            foreach (Pixel pix in List<Pixel> border.borderPixels)
            {
                Console.SetCursorPosition(pix.x, pix.y);
                Console.Write("■");

            }
        }
    class Pixel
    {
        /*
        public Pixel(int xPos, int yPos, ConsoleColor color)
        {
            XPos = xPos;
            YPos = yPos;
            ScreenColor = color;
        }

        public int XPos { get; set; }
        public int YPos { get; set; }
        public ConsoleColor ScreenColor { get; set; }

        */
        public int x, y;
        public ConsoleColor color;

        public Pixel(int x, int y, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.color = color;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Pixel p = (Pixel) obj;
                return (x == p.x) && (y == p.y);
            }
        }
    }

    class Border
    {
        public int screenWidth, screenHeight;
        public List<Pixel> borderPixels = new List<Pixel>();
        public ConsoleColor color = ConsoleColor.Black;

        public Border(int screenWidth, int screenHeight )
        {
            for (int i = 0; i < screenWidth; i++) /// upper boarder line (edges included)
            {
                borderPixels.Append(new Pixel(i, screenHeight, color));
            }
            for (int i = 0; i < screenWidth; i++) /// bottom boarder line (edges included)
            {
                borderPixels.Append(new Pixel(i, 0, color));
            }
            ///---------------------------------------------------------------------------
            for (int i = 0; i < screenHeight; i++) /// right boarder line (edges included)
            {
                borderPixels.Append(new Pixel(screenWidth, i, color));
            }
            for (int i = 0; i < screenHeight; i++) /// left boarder line (edges included)
            {
                borderPixels.Append(new Pixel(0, i, color));
            }




            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.color = ConsoleColor.Black;
            this.borderPixels = borderPixels;
        }
    }
}
