using Microsoft.Xna.Framework;


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

            if (intersection.Height > intersection.Width)
            {
                if (playerBox.Right > enemyBox.Left && playerBox.Right < enemyBox.Right)
                {
                    player.position.X -= intersection.Width;
                }
                else
                {
                    player.position.X += intersection.Width;
                }
            }
            else if (intersection.Height < intersection.Width)
            {
                if (playerBox.Bottom > enemyBox.Top && playerBox.Bottom < enemyBox.Bottom)
                {
                    if (intersection.Height > 1)
                    {
                        player.position.Y -= intersection.Height;
                    }
                }
                else
                {
                    player.position.Y += intersection.Height;
                }
            }
        }
    }
}
