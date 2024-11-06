using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Monogame___Assignment_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D sunsetTexture, birdTexture, boatTexture;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            sunsetTexture = Content.Load<Texture2D>("sunset");
            birdTexture = Content.Load<Texture2D>("birdSilhouette");
            boatTexture = Content.Load<Texture2D>("canoeSilhouette");

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Random generator = new Random();
            _spriteBatch.Begin();

            _spriteBatch.Draw(sunsetTexture, new Vector2(0, 0), Color.White);
            for (int i = 0; i < 10; i++)
            {
                _spriteBatch.Draw(birdTexture, new Vector2(generator.Next(20, 730), generator.Next(10, 200)), Color.White);
            }
            _spriteBatch.Draw(boatTexture, new Vector2(250, 375), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
