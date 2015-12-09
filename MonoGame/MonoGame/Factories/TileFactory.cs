using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoGame
{
    class TileFactory
    {
        public enum TileType
        {
            // tiles
            treeTile, sign,

            // ledges
            ledgeLeftCurve, ledgeRightCurve, ledgeLeftEnd, ledgeRightEnd, ledgeMiddle,

            // poke center stuff
            pokeEndCornerLeft, pokeEndCornerRight, pokeEndCounterLeft, pokeEndCounterRight, pokeHorizontal, pokeMiddleSection, pokeVerticalLeft, pokeVerticalRight,
            pokeBookShelf, pokeChairs, pokeComputer, pokeStairsDown, pokeTree,

            // exit
            exit,

            // background
            grass, pokeFloorSpot, pokePlainFloor, pokeFloorPrint
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
            if (type == TileType.pokeBookShelf)
            {
                state = new GenericTileState(SpriteFactory.sprites.pokeBookShelf);
            }
            if (type == TileType.pokeChairs)
            {
                state = new GenericTileState(SpriteFactory.sprites.pokeChairs);
            }
            if (type == TileType.pokeComputer)
            {
                state = new GenericTileState(SpriteFactory.sprites.pokeComputer);
            }
            if (type == TileType.pokeFloorPrint)
            {
                state = new GenericTileState(SpriteFactory.sprites.pokeFloorPrint);
            }
            if (type == TileType.pokeStairsDown)
            {
                state = new GenericTileState(SpriteFactory.sprites.pokeStairsDown);
            }
            if (type == TileType.pokeTree)
            {
                state = new GenericTileState(SpriteFactory.sprites.pokeTree);
            }
            if (type == TileType.sign)
            {
                state = new GenericTileState(SpriteFactory.sprites.sign);
            }
            Tile product = new Tile(state, location);
            return product;
        }
    }
}
