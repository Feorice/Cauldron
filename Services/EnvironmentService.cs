using System.Collections.Generic;
using Cauldron.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cauldron.Services
{
    public class EnvironmentService
    {
        private BGame _game;
        private MapService MapService { get; set; }

        public List<Block> BlockList
        {
            get { return MapService.BlockList; }
        }

        public EnvironmentService(BGame game)
        {
            _game = game;
            MapService = new MapService(game);
        }

        public void Update()
        {
            MapService.Update();
        }

        public void Draw(BasicEffect effect, Matrix _viewMatrix, Matrix _projectionMatrix)
        {
            MapService.Draw(effect,_viewMatrix,_projectionMatrix);
        }

        public MapService getMapService()
        {
            return MapService;
        }
    }
}
