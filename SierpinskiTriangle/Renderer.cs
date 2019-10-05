using Nakov.TurtleGraphics;
using System.Drawing;
using System.Threading;

namespace SierpinskiTriangle
{
    internal class Renderer
    {
        const int originAbsoluteX = -750;
        const int originAbsoluteY = -300;

        const int masterSize = 400;
        const int totalLevels = 7;

        public void DrawSierpinski()
        {
            Turtle.PenUp();
            Turtle.PenSize = 1;

            Turtle.MoveTo(originAbsoluteX, originAbsoluteY);
            Turtle.RotateTo(90);

            DrawSierpinski2();
        }

        public void DrawSierpinski2()
        {
            Turtle.Delay = 0;

            for (var levels = 2; levels <= totalLevels; levels++)
            {
                // Master triangle
                DrawEquilateralTriangle(masterSize, levels);

                // Recurse...
                DrawLevel(masterSize, levels);
                Thread.Sleep(0);
            }

            Turtle.ShowTurtle = false;
        }

        private void DrawLevel(float parentSize, int numberOfLevels)
        {
            // Satellites
            var satelliteSize = parentSize / 2;

            Turtle.Forward(parentSize / 2);
            Turtle.Rotate(-60);
            DrawEquilateralTriangle(satelliteSize, numberOfLevels);
            Turtle.Rotate(60);

            --numberOfLevels;

            if (numberOfLevels > 0)
            {

                DrawLevel(satelliteSize, numberOfLevels);
                Turtle.Backward(parentSize - satelliteSize / 2);

                DrawLevel(satelliteSize, numberOfLevels);

                Turtle.Backward(satelliteSize / 2);
                Turtle.Rotate(-60);
                Turtle.Forward(parentSize / 2);
                Turtle.Rotate(60);

                DrawLevel(satelliteSize, numberOfLevels);

                // Now back to where we started...
                Turtle.Rotate(-60);
                Turtle.Forward(-parentSize / 2);
                Turtle.Rotate(60);
                Turtle.Backward(-satelliteSize / 2);
            }
        }

        private void DrawEquilateralTriangle(float size, int levelNumber)
        {
            Turtle.PenColor = Color.FromArgb(255 / levelNumber, 255 / (levelNumber + 1), 128);

            Turtle.PenDown();
            Turtle.Forward(size);

            Turtle.Rotate(-120);
            Turtle.Forward(size);

            Turtle.Rotate(-120);
            Turtle.Forward(size);

            Turtle.Rotate(-120);
            Turtle.PenUp();
        }
    }
}
