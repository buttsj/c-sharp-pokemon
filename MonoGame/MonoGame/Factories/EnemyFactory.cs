using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System;

namespace MonoGame
{
    class EnemyFactory
    {
        public enum EnemyType
        {
            // enemies
            rival, girl
        }

        Dictionary<int, string> conversations = new Dictionary<int, string>();

        public EnemyFactory()
        {
            StreamReader sr;
            sr = File.OpenText(Game1.GetInstance().Content.RootDirectory + "\\Index\\Text.csv");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                conversations.Add(Int32.Parse(words[0]), words[1]);
            }
        }

        public Enemy builder(EnemyType type, Vector2 location, int reference)
        {
            Enemy product = new Enemy(location);
            if (type == EnemyType.rival)
            {
                Texture2D enemyLeftIdle = Game1.gameContent.Load<Texture2D>("EnemySprites/Rival/rivalLeftIdle");
                Texture2D enemyLeftWalking = Game1.gameContent.Load<Texture2D>("EnemySprites/Rival/rivalLeftWalking");
                Texture2D enemyRightIdle = Game1.gameContent.Load<Texture2D>("EnemySprites/Rival/rivalRightIdle");
                Texture2D enemyRightWalking = Game1.gameContent.Load<Texture2D>("EnemySprites/Rival/rivalRightWalking");
                Texture2D enemyUpIdle = Game1.gameContent.Load<Texture2D>("EnemySprites/Rival/rivalUpIdle");
                Texture2D enemyUpWalking = Game1.gameContent.Load<Texture2D>("EnemySprites/Rival/rivalUpWalking");
                Texture2D enemyDownIdle = Game1.gameContent.Load<Texture2D>("EnemySprites/Rival/rivalDownIdle");
                Texture2D enemyDownWalking = Game1.gameContent.Load<Texture2D>("EnemySprites/Rival/rivalDownWalking");
                product.Sprites.Add(new StaticSprite(enemyLeftIdle));
                product.Sprites.Add(new PlayerMovingSprite(enemyLeftWalking, 1, 3));
                product.Sprites.Add(new StaticSprite(enemyRightIdle));
                product.Sprites.Add(new PlayerMovingSprite(enemyRightWalking, 1, 3));
                product.Sprites.Add(new StaticSprite(enemyUpIdle));
                product.Sprites.Add(new PlayerMovingSprite(enemyUpWalking, 1, 3));
                product.Sprites.Add(new StaticSprite(enemyDownIdle));
                product.Sprites.Add(new PlayerMovingSprite(enemyDownWalking, 1, 3));
                product.CreateTextbox(conversations[reference]);
            }
            if (type == EnemyType.girl)
            {
                Texture2D enemyLeftIdle = Game1.gameContent.Load<Texture2D>("EnemySprites/Girl/girlLeftIdle");
                Texture2D enemyLeftWalking = Game1.gameContent.Load<Texture2D>("EnemySprites/Girl/girlLeftMoving");
                Texture2D enemyRightIdle = Game1.gameContent.Load<Texture2D>("EnemySprites/Girl/girlRightIdle");
                Texture2D enemyRightWalking = Game1.gameContent.Load<Texture2D>("EnemySprites/Girl/girlRightMoving");
                Texture2D enemyUpIdle = Game1.gameContent.Load<Texture2D>("EnemySprites/Girl/girlUpIdle");
                Texture2D enemyUpWalking = Game1.gameContent.Load<Texture2D>("EnemySprites/Girl/girlUpMoving");
                Texture2D enemyDownIdle = Game1.gameContent.Load<Texture2D>("EnemySprites/Girl/girlDownIdle");
                Texture2D enemyDownWalking = Game1.gameContent.Load<Texture2D>("EnemySprites/Girl/girlDownMoving");
                product.Sprites.Add(new StaticSprite(enemyLeftIdle));
                product.Sprites.Add(new PlayerMovingSprite(enemyLeftWalking, 1, 4));
                product.Sprites.Add(new StaticSprite(enemyRightIdle));
                product.Sprites.Add(new PlayerMovingSprite(enemyRightWalking, 1, 4));
                product.Sprites.Add(new StaticSprite(enemyUpIdle));
                product.Sprites.Add(new PlayerMovingSprite(enemyUpWalking, 1, 4));
                product.Sprites.Add(new StaticSprite(enemyDownIdle));
                product.Sprites.Add(new PlayerMovingSprite(enemyDownWalking, 1, 4));
                product.CreateTextbox(conversations[reference]);
            }
            product.state = new EDownIdleState(product);
            return product;
        }
    }
}
