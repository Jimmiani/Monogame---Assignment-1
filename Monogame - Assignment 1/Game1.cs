using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Monogame___Assignment_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D sunsetTexture, birdTexture, boatTexture;

        List<Vector2> birds;    
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Random generator = new Random();
            birds = new List<Vector2>();
            for (int i = 0; i < 10; i++)
            {
                birds.Add(new Vector2(generator.Next(20, 600), generator.Next(10, 200)));
            }
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            sunsetTexture = Content.Load<Texture2D>("sunset");
            birdTexture = Content.Load<Texture2D>("birdSilhouette");
            boatTexture = Content.Load<Texture2D>("boat");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(sunsetTexture, new Vector2(0, 0), Color.White);
            for (int i = 0; i < birds.Count - 1; i++)
            {
                _spriteBatch.Draw(birdTexture, birds[i], Color.White);
            }
            _spriteBatch.Draw(boatTexture, new Vector2(200, 300), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
