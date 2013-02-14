using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Cauldron.Models
{
    public class BlockType
    {
        public string TextureName { get; set; }
        public string TextureLink { get; set; }
        public bool Solid { get; set; }
        public bool DrawTop { get; set; }
        public Texture2D Texture { get; set; }

        public BlockType(ContentManager cm, string textureLink, string textureName, bool solid, bool drawTop)
        {
            TextureLink = textureLink;
            TextureName = textureName;
            Solid = solid;
            DrawTop = drawTop;

            Texture = cm.Load<Texture2D>(textureLink);
        }
    }
}
