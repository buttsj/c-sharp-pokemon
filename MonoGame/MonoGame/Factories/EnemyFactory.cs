using Microsoft.Xna.Framework;

namespace MonoGame
{
    class EnemyFactory
    {
        public enum EnemyType
        {
            // enemies
            enemyGuy
        }

        SpriteFactory factory;
        IBuildingState state;

        public EnemyFactory()
        {
        }

        public Enemy builder(EnemyType type, Vector2 location)
        {
            factory = new SpriteFactory();
            if (type == EnemyType.enemyGuy)
            {
                state = new BuildingTileState(SpriteFactory.sprites.pokeCenterLeft);
            }
            Enemy product = new Enemy(location);
            return product;
        }
    }
}
