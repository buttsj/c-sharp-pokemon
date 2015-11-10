using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MonoGame
{
    class LedgeFactory
    {
        public enum LedgeType
        {
            // ledges
            ledgeLeftCurve, ledgeRightCurve, ledgeLeftEnd, ledgeRightEnd, ledgeMiddle
        }

        SpriteFactory factory;
        ILedgeState state;

        public LedgeFactory()
        {
        }

        public Ledge builder(LedgeType type, Vector2 location)
        {
            factory = new SpriteFactory();
            if (type == LedgeType.ledgeLeftCurve)
            {
                state = new LedgeTileState(SpriteFactory.sprites.ledgeLeftCurve);
            }
            if (type == LedgeType.ledgeLeftEnd)
            {
                state = new LedgeTileState(SpriteFactory.sprites.ledgeLeftEnd);
            }
            if (type == LedgeType.ledgeMiddle)
            {
                state = new LedgeTileState(SpriteFactory.sprites.ledgeMiddle);
            }
            if (type == LedgeType.ledgeRightCurve)
            {
                state = new LedgeTileState(SpriteFactory.sprites.ledgeRightCurve);
            }
            if (type == LedgeType.ledgeRightEnd)
            {
                state = new LedgeTileState(SpriteFactory.sprites.ledgeRightEnd);
            }
            Ledge product = new Ledge(state, location);
            return product;
        }
    }
}
