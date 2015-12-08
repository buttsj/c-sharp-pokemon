using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoGame
{
    class TileFactory
    {
        public enum TileType
        {
            // tiles
            treeTile,

            // ledges
            ledgeLeftCurve, ledgeRightCurve, ledgeLeftEnd, ledgeRightEnd, ledgeMiddle,

            // poke center stuff
            pokeEndCornerLeft, pokeEndCornerRight, pokeEndCounterLeft, pokeEndCounterRight, pokeHorizontal, pokeMiddleSection, pokeVerticalLeft, pokeVerticalRight,

            // exit
            exit,

            // background
            grass, pokeFloorSpot, pokePlainFloor
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
            if (type == TileType.ledgeLeftCurve)
            {
                state = new GenericTileState(SpriteFactory.sprites.ledgeLeftCurve);
            }
            if (type == TileType.ledgeLeftEnd)
            {
                state = new GenericTileState(SpriteFactory.sprites.ledgeLeftEnd);
            }
            if (type == TileType.ledgeMiddle)
            {
                state = new GenericTileState(SpriteFactory.sprites.ledgeMiddle);
            }
            if (type == TileType.ledgeRightCurve)
            {
                state = new GenericTileState(SpriteFactory.sprites.ledgeRightCurve);
            }
            if (type == TileType.ledgeRightEnd)
            {
                state = new GenericTileState(SpriteFactory.sprites.ledgeRightEnd);
            }
            if (type == TileType.pokeEndCornerLeft)
            {
                state = new GenericTileState(SpriteFactory.sprites.pokeEndCornerLeft);
            }
            if (type == TileType.pokeEndCornerRight)
            {
                state = new GenericTileState(SpriteFactory.sprites.pokeEndCornerRight);
            }
            if (type == TileType.pokeEndCounterLeft)
            {
                state = new GenericTileState(SpriteFactory.sprites.pokeEndCounterLeft);
            }
            if (type == TileType.pokeEndCounterRight)
            {
                state = new GenericTileState(SpriteFactory.sprites.pokeEndCounterRight);
            }
            if (type == TileType.pokeHorizontal)
            {
                state = new GenericTileState(SpriteFactory.sprites.pokeHorizontal);
            }
            if (type == TileType.pokeMiddleSection)
            {
                state = new GenericTileState(SpriteFactory.sprites.pokeMiddleSection);
            }
            if (type == TileType.pokeVerticalLeft)
            {
                state = new GenericTileState(SpriteFactory.sprites.pokeVerticalLeft);
            }
            if (type == TileType.pokeVerticalRight)
            {
                state = new GenericTileState(SpriteFactory.sprites.pokeVerticalRight);
            }
            if (type == TileType.exit)
            {
                state = new GenericTileState(SpriteFactory.sprites.exit);
            }
            if (type == TileType.grass)
            {
                state = new GenericTileState(SpriteFactory.sprites.grassBack);
            }
            if (type == TileType.pokeFloorSpot)
            {
                state = new GenericTileState(SpriteFactory.sprites.pokeFloorSpot);
            }
            if (type == TileType.pokePlainFloor)
            {
                state = new GenericTileState(SpriteFactory.sprites.pokePlainFloor);
            }
            Tile product = new Tile(state, location);
            return product;
        }
    }
}
