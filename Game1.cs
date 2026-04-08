using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using C3.XNA;





namespace TowerOfHanoi2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public Stack<Disc>[] stacks = new Stack<Disc>[3];
        private Tower tower;
        private SpriteFont font;
        private SpriteFont timerFont;

        private int stackAmount;
        private int floorY;

        public int discsInSource;
        public int discsInAux;
        public int discsInDest;

        private Solver solver;
        private bool movedSmallest = false;
        private bool movedOther = false;
        private bool spacePressed = false;

        private Moves move;
        bool moveUp = false;
        bool moveSide = false;
        bool moveDown = false;
        private bool initializeAnimation = true;
        bool animate = false;


 


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            graphics.PreferredBackBufferWidth = 1000;
            graphics.PreferredBackBufferHeight = 500;
            stackAmount = 5;//add discs here <=========
        }


      


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            tower = new Tower(graphics);
            solver = new Solver(stackAmount, tower);
            for (int i = 0; i < stackAmount; i++)
            {
                solver.discstower1.Push(new Disc(i, graphics, tower));
            }
            base.Initialize();
        }


       


        protected override void LoadContent()
        { // TODO: use this.Content to load your game content here
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Font1");
            timerFont = Content.Load<SpriteFont>("Font1"); // Load a font for the timer display

        }


 


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

 
            discsInSource = solver.discstower1.Count;
            discsInAux = solver.discstower2.Count;
            discsInDest = solver.discstower3.Count;
            stacks[0] = solver.discstower1;
            stacks[1] = solver.discstower2;
            stacks[2] = solver.discstower3;

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                spacePressed = true; // Set the flag to true when spacebar is pressed
            }
            if (spacePressed)
            {
                // TODO: Add your update logic here
                if (discsInDest == stackAmount)
                {

                    if (solver.moveQueue.Count >= 1 && initializeAnimation)
                    {
                        initializeAnimation = false;
                        animate = true;
                    }
                }
                else
                {
                    if (!movedSmallest)
                    {

                        movedSmallest = true;
                        solver.MoveSmallestDisc(stacks);
                    }
                    else if (!movedOther)
                    {
                        movedOther = true;
                        solver.MoveOtherDisc(stacks);

                    }
                    if (movedOther && movedSmallest)
                    {
                        movedSmallest = false;
                        movedOther = false;
                    }

                }
                if (animate)
                {
                    if (solver.moveQueue.Count >= 1)
                    {
                        move = solver.moveQueue.Dequeue();
                        animate = false;
                        moveUp = true;
                    }
                }
                if (moveUp)
                {
                    bool moving = MovingUp();
                    if (moving == true)
                    {
                        moveUp = false;
                        moveSide = true;
                    }
                }
                if (moveSide)
                {
                    bool moving = MovingSideWays();
                    if (moving == true)
                    {
                        moveSide = false;
                        moveDown = true;
                    }
                }
                if (moveDown)
                {
                    bool moving = MoveDown();
                    if (moving == true)
                    {
                        moveDown = false;
                        animate = true;
                    }
                }
            }

            base.Update(gameTime);
        }
        public bool MovingUp()
        {
            if (move.discToMove.disc.Y > graphics.PreferredBackBufferHeight / 3)
            {
                move.discToMove.disc.Y -= 10;
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool MovingSideWays()
        {
            if (move.discToMove.disc.X < move.TowerPos.X)
            {
                move.discToMove.disc.X += 10;
                return false;
            }
            else if (move.discToMove.disc.X > move.TowerPos.X)
            {
                move.discToMove.disc.X -= 10;
                return false;
            }
            if (move.discToMove.disc.X - move.TowerPos.X < 1)
            {
                return true;
            }
            return false;
        }
        public bool MoveDown()
        {
            if (move.discToMove.disc.Y < move.TowerPos.Y)
            {
                move.discToMove.disc.Y += 10;
                return false;
            }
            else
            {
                return true;
            }
        }



        protected override void Draw(GameTime gameTime)
        {
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Cornsilk);
          
            tower.Draw(spriteBatch);
            foreach (Disc disc in solver.discstower1)
            {
                disc.Draw(spriteBatch);
            }
            foreach (Disc disc in solver.discstower2)
            {
                disc.Draw(spriteBatch);
            }
            foreach (Disc disc in solver.discstower3)
            {
                disc.Draw(spriteBatch);
            }

            spriteBatch.FillRectangle(0, floorY + 470, 1000, 50, Color.BurlyWood);

            if (!spacePressed)
            {
                spriteBatch.DrawString(timerFont, "WELCOME, PRESS SPACE!!", new Vector2(400, 100), Color.Black);
            }

            spriteBatch.End();

            base.Draw(gameTime);


        }
    }
}