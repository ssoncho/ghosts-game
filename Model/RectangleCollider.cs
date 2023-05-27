using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostsGame.Model
{
    public class RectangleCollider
    {
        public Rectangle Boundary { get; private set; }
        public RectangleCollider(int x, int y, int width, int height)
        {
            Boundary = new Rectangle(x, y, width, height);
        }

        public static bool IsCollided(RectangleCollider r1, RectangleCollider r2)
        {
            return r1.Boundary.Intersects(r2.Boundary);
        }

        public static bool IsPlayerOnTopOf(RectangleCollider pr, RectangleCollider r2)
        {
            var playerRectangle = pr.Boundary;
            var anotherRectangle = r2.Boundary;
            return playerRectangle.Bottom == anotherRectangle.Top &&
                 playerRectangle.Right >= anotherRectangle.Right &&
                 playerRectangle.Left <= anotherRectangle.Left;
        }
    }
}
