﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    class EUpIdleState : IPlayerState
    {
        Enemy enemy;
        public IAnimatedSprite Sprite { get; set; }

        public EUpIdleState(Enemy currentEnemy)
        {
            Sprite = currentEnemy.Sprites[4];
            enemy = currentEnemy;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void Down()
        {
            enemy.state = new EDownIdleState(enemy);
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
            //enemy.state = new EUpWalkingState(enemy);
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
