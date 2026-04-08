using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using C3.XNA;

namespace TowerOfHanoi2
{
    public class Disc
    {
        private GraphicsDeviceManager graphics;

        public Rectangle disc;
        public Vector2 firstTowerPos;
        public Vector2 discPos;

        public Tower tower;

        public int discCount;
        public int discHeight;
        public int discWidth;
        public bool shouldMoveUp = false;
    

        public Disc(int count, GraphicsDeviceManager graph, Tower towerCS)
        {
            discCount = count;
            tower = towerCS;
            graphics = graph;
            discWidth = 100 - 10 * discCount;
            discHeight = 20;

            discPos.X = graphics.PreferredBackBufferWidth / 4 - 50 + 5 * discCount;

            discPos.Y = tower.towerSource.Y + 300 - 30 * discCount;
            disc = new Rectangle((int)discPos.X, (int)discPos.Y, discWidth, discHeight);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.FillRectangle(disc, Color.SandyBrown);
        }
    }
}