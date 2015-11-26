using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    class SpriteFactory : ISpriteFactory
    {
        public enum sprites
        {
            // player
            leftIdlePlayer, leftWalkingPlayer, rightIdlePlayer, rightWalkingPlayer, upIdlePlayer, upWalkingPlayer, downIdlePlayer, downWalkingPlayer,

            // tiles
            treeTile, wallTile,

            // gui
            arrow,

            // encounters
            grass,

            // ledges
            ledgeLeftCurve, ledgeRightCurve, ledgeLeftEnd, ledgeRightEnd, ledgeMiddle,

            // buildings
            pokeCenterLeft, pokeCenterRight, japBuildingLeft, japBuildingRight,

            // poke center stuff
            pokeCounterLeft, pokeCounterBottom, pokeCounterMiddle, pokeCounterRight,

            // exit
            exit,

            // enemy
            enemyGuy
        }

        public SpriteFactory()
        {
        }

        public IAnimatedSprite builder(SpriteFactory.sprites sprite)
        {
            if (sprite == sprites.downIdlePlayer)
            {
                Texture2D downIdleTexture = Game1.gameContent.Load<Texture2D>("PlayerSprites/DownIdlePlayer");
                return new StaticSprite(downIdleTexture);
            }
            if (sprite == sprites.downWalkingPlayer)
            {
                Texture2D downWalkingTexture = Game1.gameContent.Load<Texture2D>("PlayerSprites/DownMovingPlayer");
                return new PlayerMovingSprite(downWalkingTexture, 1, 3);
            }
            if (sprite == sprites.leftIdlePlayer)
            {
                Texture2D leftIdleTexture = Game1.gameContent.Load<Texture2D>("PlayerSprites/LeftIdlePlayer");
                return new StaticSprite(leftIdleTexture);
            }
            if (sprite == sprites.leftWalkingPlayer)
            {
                Texture2D leftWalkingTexture = Game1.gameContent.Load<Texture2D>("PlayerSprites/LeftMovingPlayer");
                return new PlayerMovingSprite(leftWalkingTexture, 1, 3);
            }
            if (sprite == sprites.rightIdlePlayer)
            {
                Texture2D rightIdleTexture = Game1.gameContent.Load<Texture2D>("PlayerSprites/RightIdlePlayer");
                return new StaticSprite(rightIdleTexture);
            }
            if (sprite == sprites.rightWalkingPlayer)
            {
                Texture2D rightWalkingTexture = Game1.gameContent.Load<Texture2D>("PlayerSprites/RightMovingPlayer");
                return new PlayerMovingSprite(rightWalkingTexture, 1, 3);
            }
            if (sprite == sprites.upIdlePlayer)
            {
                Texture2D upIdleTexture = Game1.gameContent.Load<Texture2D>("PlayerSprites/UpIdlePlayer");
                return new StaticSprite(upIdleTexture);
            }
            if (sprite == sprites.upWalkingPlayer)
            {
                Texture2D upWalkingTexture = Game1.gameContent.Load<Texture2D>("PlayerSprites/UpMovingPlayer");
                return new PlayerMovingSprite(upWalkingTexture, 1, 3);
            }
            if (sprite == sprites.wallTile)
            {
                Texture2D wallTileTexture = Game1.gameContent.Load<Texture2D>("TileSprites/treeTileSprite");
                return new StaticSprite(wallTileTexture);
            }
            if (sprite == sprites.treeTile)
            {
                Texture2D treeTileTexture = Game1.gameContent.Load<Texture2D>("TileSprites/treeTileSprite");
                return new StaticSprite(treeTileTexture);
            }
            if (sprite == sprites.arrow)
            {
                Texture2D arrowTexture = Game1.gameContent.Load<Texture2D>("arrowCursor");
                return new StaticSprite(arrowTexture);
            }
            if (sprite == sprites.grass)
            {
                Texture2D grassTexture = Game1.gameContent.Load<Texture2D>("TileSprites/grassTexture");
                return new DynamicSprite(grassTexture, 1, 1);
            }
            if (sprite == sprites.ledgeLeftCurve)
            {
                Texture2D ledgeTexture = Game1.gameContent.Load<Texture2D>("TileSprites/Ledges/ledgeLeftCurve");
                return new StaticSprite(ledgeTexture);
            }
            if (sprite == sprites.ledgeLeftEnd)
            {
                Texture2D ledgeTexture = Game1.gameContent.Load<Texture2D>("TileSprites/Ledges/ledgeLeftEnd");
                return new StaticSprite(ledgeTexture);
            }
            if (sprite == sprites.ledgeMiddle)
            {
                Texture2D ledgeTexture = Game1.gameContent.Load<Texture2D>("TileSprites/Ledges/ledgeMiddle");
                return new StaticSprite(ledgeTexture);
            }
            if (sprite == sprites.ledgeRightCurve)
            {
                Texture2D ledgeTexture = Game1.gameContent.Load<Texture2D>("TileSprites/Ledges/ledgeRightCurve");
                return new StaticSprite(ledgeTexture);
            }
            if (sprite == sprites.ledgeRightEnd)
            {
                Texture2D ledgeTexture = Game1.gameContent.Load<Texture2D>("TileSprites/Ledges/ledgeRightEnd");
                return new StaticSprite(ledgeTexture);
            }
            if (sprite == sprites.pokeCenterLeft)
            {
                Texture2D pokeLTexture = Game1.gameContent.Load<Texture2D>("TileSprites/Buildings/pokeCenterLeft");
                return new StaticSprite(pokeLTexture);
            }
            if (sprite == sprites.pokeCenterRight)
            {
                Texture2D pokeRTexture = Game1.gameContent.Load<Texture2D>("TileSprites/Buildings/pokeCenterRight");
                return new StaticSprite(pokeRTexture);
            }
            if (sprite == sprites.pokeCounterLeft)
            {
                Texture2D pokeCounter = Game1.gameContent.Load<Texture2D>("TileSprites/PokeCenter/pokeCounterLeft");
                return new StaticSprite(pokeCounter);
            }
            if (sprite == sprites.pokeCounterMiddle)
            {
                Texture2D pokeCounter = Game1.gameContent.Load<Texture2D>("TileSprites/PokeCenter/pokeCounterMiddle");
                return new StaticSprite(pokeCounter);
            }
            if (sprite == sprites.pokeCounterBottom)
            {
                Texture2D pokeCounter = Game1.gameContent.Load<Texture2D>("TileSprites/PokeCenter/pokeCounterBottom");
                return new StaticSprite(pokeCounter);
            }
            if (sprite == sprites.pokeCounterRight)
            {
                Texture2D pokeCounter = Game1.gameContent.Load<Texture2D>("TileSprites/PokeCenter/pokeCounterRight");
                return new StaticSprite(pokeCounter);
            }
            if (sprite == sprites.exit)
            {
                Texture2D pokeCounter = Game1.gameContent.Load<Texture2D>("TileSprites/PokeCenter/exitTexture");
                return new StaticSprite(pokeCounter);
            }
            if (sprite == sprites.enemyGuy)
            {
                Texture2D enemy = Game1.gameContent.Load<Texture2D>("");
                return new PlayerMovingSprite(enemy, 1, 1);
            }
            return null;
        }
    }
}
