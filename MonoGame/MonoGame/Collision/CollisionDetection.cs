using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoGame
{
    class CollisionDetection
    {
        Game1 game;
        ISpriteFactory factory = new SpriteFactory();

        private TileCollisionResponse tileResponse;
        private GrassCollisionResponse grassResponse;
        private LedgeCollisionResponse ledgeResponse;
        private BuildingCollisionResponse buildingResponse;
        private EnemyCollisionResponse enemyResponse;
        private ExitCollisionResponse exitResponse;

        public CollisionDetection(Player player, Game1 game)
        {
            this.game = game;
            grassResponse = new GrassCollisionResponse(game);
            tileResponse = new TileCollisionResponse(game);
            ledgeResponse = new LedgeCollisionResponse(game);
            buildingResponse = new BuildingCollisionResponse(game);
            enemyResponse = new EnemyCollisionResponse(game);
            exitResponse = new ExitCollisionResponse(game);
        }

        public void Detect(Player player, List<Tile> levelTiles, List<Grass> levelGrass, List<Ledge> levelLedges, List<Building> levelBuildings, List<Enemy> levelEnemies, List<Exit> levelExits)
        {
            Rectangle playerBox = player.state.GetBoundingBox(player.position);
            foreach (Tile tile in levelTiles)
            {
                Rectangle tileBox = tile.GetBoundingBox();
                if (tileBox.Intersects(playerBox))
                {
                    tileResponse.PlayerTileCollide(player, tile);
                }
            }
            foreach (Grass grass in levelGrass)
            {
                Rectangle grassBox = grass.GetBoundingBox();
                if (grassBox.Intersects(playerBox) && !grass.intersected)
                {
                    grass.intersected = true;
                    grassResponse.PlayerTileCollide(grass);
                }
                if (!grassBox.Intersects(playerBox))
                {
                    grass.intersected = false;
                }
            }
            foreach (Ledge ledge in levelLedges)
            {
                Rectangle ledgeBox = ledge.GetBoundingBox();
                if (ledgeBox.Intersects(playerBox))
                {
                    ledgeResponse.PlayerTileCollide(player, ledge);
                }
            }
            foreach (Building building in levelBuildings)
            {
                Rectangle buildingBox = building.GetBoundingBox();
                if (buildingBox.Intersects(playerBox))
                {
                    buildingResponse.PlayerTileCollide(player, building);
                }
            }
            foreach (Enemy enemy in levelEnemies)
            {
                Rectangle enemyBox = enemy.state.GetBoundingBox(enemy.position);
                if (enemyBox.Intersects(playerBox))
                {
                    enemyResponse.PlayerEnemyCollide(player, enemy);
                }
            }
            foreach (Exit exit in levelExits)
            {
                Rectangle exitBox = exit.sprite.GetBoundingBox(exit.position);
                if (exitBox.Intersects(playerBox))
                {
                    exitResponse.PlayerTileCollide(player, exit);
                }
            }
        }
    }
}
