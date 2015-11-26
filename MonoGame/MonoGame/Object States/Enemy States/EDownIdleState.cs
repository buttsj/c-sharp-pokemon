using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    class EDownIdleState : IPlayerState
    {
        Enemy enemy;
        public IAnimatedSprite Sprite { get; set; }

        public EDownIdleState(Enemy currentEnemy)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.builder(SpriteFactory.sprites.downIdlePlayer);
            enemy = currentEnemy;
        }

        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void Down()
        {
            enemy.state = new EDownWalkingState(enemy);
        }
        
        public void Left()
        {
            enemy.state = new ELeftIdleState(enemy);
        }

        public void Right()
        {
            enemy.state = new ERightIdleState(enemy);
        }

        public void Up()
        {
            enemy.state = new EUpIdleState(enemy);
        }

        public void Idle()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Sprite.Draw(spriteBatch, location, color);
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
    }
}
