using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoGame
{
    class TileFactory
    {
        public enum TileType
        {
            // tiles
            treeTile, wallTile
        }

        SpriteFactory factory;
        ITileState state;

        public TileFactory()
        {
        }

        public Tile builder(TileType type, Vector2 location)
        {
            factory = new SpriteFactory();
            if (type == TileType.treeTile)
            {
                state = new GenericTileState(SpriteFactory.sprites.treeTile);
            }
            if (type == TileType.wallTile)
            {
                state = new GenericTileState(SpriteFactory.sprites.wallTile);
            }
            Tile product = new Tile(state, location);
            return product;
        }
    }
}
