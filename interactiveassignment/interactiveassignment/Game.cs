using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        // Define colors
        Color darkBlue = new Color("#696fC7");
        Color lightBlue = new Color("#A7AAE1");
        Color beige = new Color("#F5D3C4");
        Color peach = new Color("#F2AEBB");

        // Shape and color arrays
        string[] shapeArray = ["Circle", "Square", "Triangle"];
        Color[] colorArray;

        public void Setup()
        {
            Window.SetTitle("Interactive Drawing");
            Window.SetSize(800, 600);
            Window.ClearBackground(Color.OffWhite);
            colorArray = new Color[] { darkBlue, lightBlue, beige, peach };

        }

        public void Update()
        {
            if (Input.IsMouseButtonPressed(MouseInput.Left))
            {

                Window.ClearBackground(Color.OffWhite);
                //mouth
                DrawShapesInOrder(225, 500, 10, 25, 15, false); // bottom of mouth
                DrawShapesInOrder(225, 500, 10, 10, 15, true); // left side of mouth
                DrawShapesInOrder(600, 500, 10, 10, 15, true);// right side of mouth
                                                              // eyes
                DrawShapesInOrder(260, 300, 10, 10, 15, true);// left eye
                DrawShapesInOrder(565, 300, 10, 10, 15, true);// right eye


                DrawShapesInOrder(19, 600, 25, 7, 100, true);// left wall
                DrawShapesInOrder(19, 550, 25, 7, 100, true);//  left wall


                DrawShapesInOrder(781, 600, 25, 7, 100, true);// right wall
                DrawShapesInOrder(781, 550, 25, 7, 100, true);//  right wall


                DrawShapesInOrder(15, 19, 25, 9, 90, false);// top wall
                DrawShapesInOrder(65, 19, 25, 9, 90, false);// top wall


                DrawShapesInOrder(15, 581, 25, 9, 90, false);// bot wall
                DrawShapesInOrder(65, 581, 25, 9, 90, false);// bot wall


            }

        }

        void DrawShapesInOrder(int xStart, int yStart, int r, int amount, float space, bool isUp)
        {
            Draw.LineSize = 1;

            // random shape/colour
            string pickedShape = shapeArray[Random.Integer(0, shapeArray.Length)];
            Draw.FillColor = colorArray[Random.Integer(0, colorArray.Length)];

            //
            for (int i = 0; i < amount; i++)
            {
                float x = xStart;
                float y = yStart;

                // if true, draws the shapes verticlly, else, horizontaly
                if (isUp)
                {
                    y -= space * i;
                }

                else
                {
                    x += space * i;
                }


                if (pickedShape == "Circle")
                {
                    Draw.Circle(x, y, r);
                }
                else if (pickedShape == "Triangle")
                {
                    float size = r * 1.2f;
                    Vector2 top = new Vector2(x, y - size);
                    Vector2 left = new Vector2(x - size, y + size);
                    Vector2 right = new Vector2(x + size, y + size);
                    Draw.Triangle(top, left, right);
                }
                else if (pickedShape == "Square")
                {
                    float size = r * 2;
                    Draw.Rectangle(x - r, y - r, size, size);
                }
            }
        }
    }
}