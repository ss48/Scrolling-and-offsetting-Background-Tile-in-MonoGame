using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
//using System.Globalization;

namespace Tile_and_Grids

{
    
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D Smiley, Anim, Tile;
        Vector2 BgTileOffset = Vector2.Zero;
        const float BgDegPerSec = 33.0f;
      
       //for game state calculation
        double TotalSeconds = 0.0;
        double ElapsedSeconds = 0.0;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

      
        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
          
            Smiley = Content.Load<Texture2D>("smiley");
         
            Anim = Content.Load<Texture2D>("SmileyAnim");
            Tile = Content.Load<Texture2D>("charTile");
        }

        
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
           
        }

       
        protected override void Update(GameTime gameTime)
        {
           //track elapsed time since last frame, add since the game started
           // records the time that has elapsed since the last call to the update and other tracks the total time that the game has been running.
           ElapsedSeconds = gameTime.ElapsedGameTime.TotalSeconds;
           TotalSeconds += ElapsedSeconds;
          
           base.Update(gameTime);
        }

       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            DrawBackgroundTile(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
       
       void DrawBackgroundTile(SpriteBatch spriteBatch)
        {
           double degree = BgDegPerSec * TotalSeconds;
           double radians = MathHelper.ToRadians((float)degree);
           BgTileOffset.X += -50.0f * (float)ElapsedSeconds;
           BgTileOffset.Y = (float)(200 * Math.Sin(radians));
           // make sure that the first tile isn't too far left
          while(BgTileOffset.X<-Tile.Width)
          {
             BgTileOffset.X += Tile.Width;
          }
          // make sure that the first tile isn't too far right
          while (BgTileOffset.X >0)
          {
             BgTileOffset.X -= Tile.Width;
          }
          // make sure that the first tile isn't too far up
          while (BgTileOffset.Y < -Tile.Height)
          {
             BgTileOffset.Y += Tile.Height;
          }
          // make sure that the first tile isn't too far down
          while (BgTileOffset.Y >0)
          {
             BgTileOffset.Y -= Tile.Height;
          }

          // init current tile location with location of the top, left tile
         Vector2 Loc = BgTileOffset;
         // draw our background tile in a grid that fills the screen
          for (int y = 0; y <= GraphicsDevice.Viewport.Height/Tile.Height +1; y++ )
          {
             Loc.Y = BgTileOffset.Y + y * Tile.Height;
             for (int x = 0; x <= GraphicsDevice.Viewport.Width / Tile.Width + 1; x++)
             {
                Loc.X = BgTileOffset.X + x * Tile.Width;
                spriteBatch.Draw(Tile,Loc,Color.White);
             }
          }
 }    
    }}
