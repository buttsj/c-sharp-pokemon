using Microsoft.Xna.Framework;

namespace MonoGame
{
    class BuildingFactory
    {
        public enum BuildingType
        {
            // buildings
            pokeCenterLeft, pokeCenterRight, japBuildingLeft, japBuildingRight
        }

        SpriteFactory factory;
        IBuildingState state;

        public BuildingFactory()
        {
        }

        public Building builder(BuildingType type, Vector2 location)
        {
            factory = new SpriteFactory();
            if (type == BuildingType.pokeCenterLeft)
            {
                state = new BuildingTileState(SpriteFactory.sprites.pokeCenterLeft);
            }
            if (type == BuildingType.pokeCenterRight)
            {
                state = new BuildingTileState(SpriteFactory.sprites.pokeCenterRight);
            }
            Building product = new Building(state, location);
            return product;
        }
    }
}
