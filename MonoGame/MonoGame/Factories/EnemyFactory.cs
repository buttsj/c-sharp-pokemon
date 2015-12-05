using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MonoGame
{
    class EnemyFactory
    {
        public enum EnemyType
        {
            // enemies
            rival
        }

        public EnemyFactory()
        {
        }

        public Enemy builder(EnemyType type, Vector2 location)
        {
            Enemy product = new Enemy(location);
            if (type == EnemyType.rival)
            {
                Texture2D enemyLeftIdle = Game1.gameContent.Load<Texture2D>("EnemySprites/rivalLeftIdle");
                Texture2D enemyLeftWalking = Game1.gameContent.Load<Texture2D>("EnemySprites/rivalLeftWalking");
                Texture2D enemyRightIdle = Game1.gameContent.Load<Texture2D>("EnemySprites/rivalRightIdle");
                Texture2D enemyRightWalking = Game1.gameContent.Load<Texture2D>("EnemySprites/rivalRightWalking");
                Texture2D enemyUpIdle = Game1.gameContent.Load<Texture2D>("EnemySprites/rivalUpIdle");
                Texture2D enemyUpWalking = Game1.gameContent.Load<Texture2D>("EnemySprites/rivalUpWalking");
                Texture2D enemyDownIdle = Game1.gameContent.Load<Texture2D>("EnemySprites/rivalDownIdle");
                Texture2D enemyDownWalking = Game1.gameContent.Load<Texture2D>("EnemySprites/rivalDownWalking");
                product.Sprites.Add(new StaticSprite(enemyLeftIdle));
                product.Sprites.Add(new PlayerMovingSprite(enemyLeftWalking, 1, 3));
                product.Sprites.Add(new StaticSprite(enemyRightIdle));
                product.Sprites.Add(new PlayerMovingSprite(enemyRightWalking, 1, 3));
                product.Sprites.Add(new StaticSprite(enemyUpIdle));
                product.Sprites.Add(new PlayerMovingSprite(enemyUpWalking, 1, 3));
                product.Sprites.Add(new StaticSprite(enemyDownIdle));
                product.Sprites.Add(new PlayerMovingSprite(enemyDownWalking, 1, 3));
            }
            product.state = new EDownIdleState(product);
            return product;
        }
    }
}
