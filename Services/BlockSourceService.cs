using System.Collections.Generic;
using Cauldron.Models;
using Microsoft.Xna.Framework.Content;

namespace Cauldron.Services
{
    public class BlockSourceHandler
    {
        public static List<BlockType> LoadBlockTypes(ContentManager cm)
        {
            var blist = new List<BlockType>();

            blist.Add(new BlockType(cm, "vox_4px_gray", "red", true, true));
            blist.Add(new BlockType(cm, "vox_2px_red", "red", true, true));
            blist.Add(new BlockType(cm, "vox_single", "single", true, true));
            blist.Add(new BlockType(cm, "grassy", "box", true, true));
            blist.Add(new BlockType(cm, "grassy", "block", true, true));
            blist.Add(new BlockType(cm, "grassy", "platform", true, true));
            blist.Add(new BlockType(cm, "grassy", "grass", false, false));
            blist.Add(new BlockType(cm, "grassy", "fridge", true, false));
            blist.Add(new BlockType(cm, "box100", "dishwasher", true, false));
            blist.Add(new BlockType(cm, "box50", "ivy", true, false));
            blist.Add(new BlockType(cm, "box250", "house", true, false));

            return blist;
        }
    }
}
