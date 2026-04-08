using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using C3.XNA;

namespace TowerOfHanoi2
{
    public class Tower
    {
        private int towerHeight;
        private int towerWidth;
        private int towerPosX;
        private int towerPosY;
        private int screenHeight;
        private int screenWidth;

        public Rectangle towerSource;
        public Rectangle towerAux;
        public Rectangle towerDest;

        public Tower(GraphicsDeviceManager graphics)
        {

            screenWidth = graphics.PreferredBackBufferWidth;
            screenHeight = graphics.PreferredBackBufferHeight;

            towerHeight = 320;
            towerWidth = 10;
            towerPosY = screenHeight / 2-100;
            towerPosX = screenWidth / 2;

            towerSource = new Rectangle(towerPosX / 2 - towerWidth / 2, towerPosY, towerWidth, towerHeight);
            towerAux = new Rectangle(towerPosX - towerWidth / 2, towerPosY, towerWidth, towerHeight);
            towerDest = new Rectangle(towerPosX / 2 * 3 - towerWidth / 2, towerPosY, towerWidth, towerHeight);

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.FillRectangle(towerSource, Color.Gray);
            spriteBatch.FillRectangle(towerAux, Color.Gray);
            spriteBatch.FillRectangle(towerDest, Color.Gray);

        }
    }
}