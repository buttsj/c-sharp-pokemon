using Microsoft.Xna.Framework;
using System.Diagnostics;


namespace MonoGame
{
    class EnemyCollisionResponse
    {
        Game1 game;

        public EnemyCollisionResponse(Game1 game)
        {
            this.game = game;
        }

        public void PlayerEnemyCollide(Player player, Enemy enemy)
        {
            Rectangle playerBox = player.state.GetBoundingBox(player.position);
            Rectangle enemyBox = enemy.state.GetBoundingBox(enemy.position);
            Rectangle intersection = Rectangle.Intersect(playerBox, enemyBox);
            player.interactable = true;
            player.interactEnemy = enemy;
            if (intersection.Height > intersection.Width)
            {
                if (playerBox.Right > enemyBox.Left && playerBox.Right < enemyBox.Right)
                {
                    player.position.X -= intersection.Width; // left
                }
                else
                {
                    player.position.X += intersection.Width; // right
                }
            }
            else if (intersection.Height < intersection.Width)
            {
                if (playerBox.Bottom > enemyBox.Top && playerBox.Bottom < enemyBox.Bottom)
                {
                    player.position.Y -= intersection.Height; // up
                }
                else
                {
                    player.position.Y += intersection.Height; // down
                }
            }
        }
    }
}
