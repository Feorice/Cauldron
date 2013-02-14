using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Cauldron.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cauldron.Services
{
    public class MapService
    {
        private BGame _game;
        public List<Block> BlockList = new List<Block>();
        public List<BlockType> BlockTypes { get; set; }
        int voxSize = 4;
        int _x, _y, _z = 0;

        public MapService(BGame game)
        {
            _game = game;
            BlockTypes = BlockSourceHandler.LoadBlockTypes(game.Content);

            BuildBlocks();
        }

        private void BuildBlocks()
        {
            for (int z = 0; z < 16; z++)
            {
                _z++;
                for (int y = 0; y < 16; y++)
                {
                    for (int x = 0; x < 16; x++)
                    {
                        BlockList.Add(new Block(_game, new Vector3((voxSize * _x), (voxSize * _y), (voxSize * _z)), BlockTypes[0]));
                        _x++;
                    }
                    _y++;
                    _x = 0;
                }
                _y = 0;
            }
            if (BlockList.Count == 4096)
            {
                _x = 0;
            }
        }

        public void Update()
        {
            foreach (var block in BlockList)
            {
                block.Update();
            }
        }

        public void Draw(BasicEffect effect, Matrix _viewMatrix, Matrix _projectionMatrix)
        {
            foreach (var block in BlockList)
            {
                block.Draw(effect, _viewMatrix, _projectionMatrix);
            }
        }

        public List<Block> getBlockList()
        {
            return BlockList;
        }
    }
}
