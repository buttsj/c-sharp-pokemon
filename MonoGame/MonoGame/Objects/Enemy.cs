using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.Diagnostics;

namespace MonoGame
{
    public class Enemy
    {
        public List<IAnimatedSprite> Sprites { get; set; }
        public IPlayerState state { get; set; }
        public Vector2 position;
        public Vector2 oldPosition;
        
        public List<Monster> pocketMonsters = new List<Monster>();
        public int monsterCount = 0;
        public MonsterBuilder monsterBuilder;

        public bool displayMonsters = false;
        public bool talkedTo = false;

        public Textbox textBox;

        public Enemy(Vector2 startingPosition)
        {
            Sprites = new List<IAnimatedSprite>();
            position = startingPosition;
            oldPosition = startingPosition;
            monsterBuilder = new MonsterBuilder("Index/Index.csv");
            CreateAMonster();
        }

        public void CreateTextbox(string text)
        {
            textBox = new Textbox(text);
        }

        public void CreateAMonster()
        {
            pocketMonsters.Add(monsterBuilder.monsterList["Jigglypuff"]);
            monsterCount++;
        }

        public void Idle()
        {
            state.Idle();
        }

        public void Down()
        {
            state.Down();
            position.Y += 1;
    }

        public void Left()
        {
            state.Left();
            position.X -= 1;
        }

        public void Right()
        {
            state.Right();
            position.X += 1;
        }

        public void Up()
        {
            state.Up();
            position.Y -= 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            state.Draw(spriteBatch, position, Color.White);
            if (talkedTo)
            {
                textBox.Draw(spriteBatch, position);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (!talkedTo)
            {
                Random rnd = new Random();
                int value = RandomExtension.NextInt(rnd, 0, 100);
                if (value == 0)
                {
                    value = RandomExtension.NextInt(rnd, 0, 3);
                    if (value == 0)
                    {
                        state.Up();
                    }
                    else if (value == 1)
                    {
                        state.Down();
                    }
                    else if (value == 2)
                    {
                        state.Left();
                    }
                    else
                    {
                        state.Right();
                    }
                }
                state.Update(gameTime);
            }
            else
            {
                textBox.Update(gameTime);
                if (textBox.complete == true)
                {
                    talkedTo = false;
                }
            }
        }
    }
}
