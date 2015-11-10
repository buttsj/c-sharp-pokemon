using Microsoft.Xna.Framework;

namespace MonoGame
{
    class GrassFactory
    {
        public enum GrassType
        {
            // tiles
            shortGrass, tallGrass
        }

        SpriteFactory factory;
        IGrassState state;

        public GrassFactory()
        {
        }

        public Grass builder(GrassType type, Vector2 location)
        {
            factory = new SpriteFactory();
            if (type == GrassType.shortGrass)
            {
                state = new GrassTileState(SpriteFactory.sprites.grass);
            }
            if (type == GrassType.tallGrass)
            {
                state = new GrassTileState(SpriteFactory.sprites.grass);
            }
            Grass product = new Grass(state, location);
            return product;
        }
    }
}
