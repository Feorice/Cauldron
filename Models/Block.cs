using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Cauldron.Models
{
    public enum TileCollision
    {
        /// <summary>
        /// A passable tile is one which does not hinder player motion at all.
        /// </summary>
        Passable = 0,

        /// <summary>
        /// An impassable tile is one which does not allow the player to move through
        /// it at all. It is completely solid.
        /// </summary>
        Impassable = 1,

        /// <summary>
        /// A platform tile is one which behaves like a passable tile except when the
        /// player is above it. A player can jump up through a platform as well as move
        /// past it to the left and right, but can not fall down through the top of it.
        /// </summary>
        Platform = 2,
    }

    //public enum BlockType
    //{
    //    Platform,
    //    Decoration
    //}

    public class Block
    {
        public Vector3 Position { get; private set; }
        private int ToEdge = 25;
        private int ToEdgeX { get { return Type.Texture.Width/2; } }
        private BGame _game;
        private List<VertexPositionTexture> verticeslist = new List<VertexPositionTexture>();
        //private List<VertexPositionNormalTexture> verticeslist = new List<VertexPositionNormalTexture>();
        public BlockType Type { get; set; }

        public Block(BGame game , Vector3 position, BlockType type)
        {
            Position = position;
            _game = game;
            Type = type;
        }

        public void Update()
        {
            //verticeslist.Clear();
            if (verticeslist.Count <= 0)
            {
                BuildBlock();
            }
        }

        #region DrawCam
        private void BuildBlock()
        {
            var zero = new VertexPositionTexture();
            //var zero = new VertexPositionNormalTexture();

            //zero.Normal = new Vector3(0, 0, 1);

            zero.Position = new Vector3(Position.X - ToEdgeX, Position.Y - ToEdge + Type.Texture.Height, Position.Z + ToEdgeX);
            zero.TextureCoordinate.X = 0;
            zero.TextureCoordinate.Y = 0;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X + ToEdgeX, Position.Y - ToEdge, Position.Z + ToEdgeX);
            zero.TextureCoordinate.X = 1;
            zero.TextureCoordinate.Y = 1;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X - ToEdgeX, Position.Y - ToEdge, Position.Z + ToEdgeX);
            zero.TextureCoordinate.X = 0;
            zero.TextureCoordinate.Y = 1;
            verticeslist.Add(zero);
            //-----------------------------------------------------

            zero.Position = new Vector3(Position.X + ToEdgeX, Position.Y - ToEdge, Position.Z + ToEdgeX);
            zero.TextureCoordinate.X = 1;
            zero.TextureCoordinate.Y = 1;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X - ToEdgeX, Position.Y - ToEdge + Type.Texture.Height, Position.Z + ToEdgeX);
            zero.TextureCoordinate.X = 0;
            zero.TextureCoordinate.Y = 0;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X + ToEdgeX, Position.Y - ToEdge + Type.Texture.Height, Position.Z + ToEdgeX);
            zero.TextureCoordinate.X = 1;
            zero.TextureCoordinate.Y = 0;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X + ToEdgeX, Position.Y - ToEdge, Position.Z + ToEdgeX);
            zero.TextureCoordinate.X = 0;
            zero.TextureCoordinate.Y = 1;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X + ToEdgeX, Position.Y - ToEdge + Type.Texture.Height, Position.Z + ToEdgeX);
            zero.TextureCoordinate.X = 0;
            zero.TextureCoordinate.Y = 0;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X + ToEdgeX, Position.Y - ToEdge + Type.Texture.Height, Position.Z - ToEdgeX);
            zero.TextureCoordinate.X = 1;
            zero.TextureCoordinate.Y = 0;
            verticeslist.Add(zero);

            //-----------------------------------------------------

            zero.Position = new Vector3(Position.X + ToEdgeX, Position.Y - ToEdge, Position.Z + ToEdgeX);
            zero.TextureCoordinate.X = 0;
            zero.TextureCoordinate.Y = 1;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X + ToEdgeX, Position.Y - ToEdge + Type.Texture.Height, Position.Z - ToEdgeX);
            zero.TextureCoordinate.X = 1;
            zero.TextureCoordinate.Y = 0;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X + ToEdgeX, Position.Y - ToEdge, Position.Z - ToEdgeX);
            zero.TextureCoordinate.X = 1;
            zero.TextureCoordinate.Y = 1;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X + ToEdgeX, Position.Y - ToEdge, Position.Z - ToEdgeX);
            zero.TextureCoordinate.X = 0;
            zero.TextureCoordinate.Y = 1;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X + ToEdgeX, Position.Y - ToEdge + Type.Texture.Height, Position.Z - ToEdgeX);
            zero.TextureCoordinate.X = 0;
            zero.TextureCoordinate.Y = 0;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X - ToEdgeX, Position.Y - ToEdge + Type.Texture.Height, Position.Z - ToEdgeX);
            zero.TextureCoordinate.X = 1;
            zero.TextureCoordinate.Y = 0;
            verticeslist.Add(zero);

            //-----------------------------------------------------

            zero.Position = new Vector3(Position.X - ToEdgeX, Position.Y - ToEdge + Type.Texture.Height, Position.Z - ToEdgeX);
            zero.TextureCoordinate.X = 1;
            zero.TextureCoordinate.Y = 0;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X - ToEdgeX, Position.Y - ToEdge, Position.Z - ToEdgeX);
            zero.TextureCoordinate.X = 1;
            zero.TextureCoordinate.Y = 1;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X + ToEdgeX, Position.Y - ToEdge, Position.Z - ToEdgeX);
            zero.TextureCoordinate.X = 0;
            zero.TextureCoordinate.Y = 1;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X - ToEdgeX, Position.Y - ToEdge + Type.Texture.Height, Position.Z - ToEdgeX);
            zero.TextureCoordinate.X = 0;
            zero.TextureCoordinate.Y = 0;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X - ToEdgeX, Position.Y - ToEdge, Position.Z + ToEdgeX);
            zero.TextureCoordinate.X = 1;
            zero.TextureCoordinate.Y = 1;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X - ToEdgeX, Position.Y - ToEdge, Position.Z - ToEdgeX);
            zero.TextureCoordinate.X = 0;
            zero.TextureCoordinate.Y = 1;
            verticeslist.Add(zero);

            //-----------------------------------------------------

            zero.Position = new Vector3(Position.X - ToEdgeX, Position.Y - ToEdge + Type.Texture.Height, Position.Z - ToEdgeX);
            zero.TextureCoordinate.X = 0;
            zero.TextureCoordinate.Y = 0;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X - ToEdgeX, Position.Y - ToEdge + Type.Texture.Height, Position.Z + ToEdgeX);
            zero.TextureCoordinate.X = 1;
            zero.TextureCoordinate.Y = 0;
            verticeslist.Add(zero);

            zero.Position = new Vector3(Position.X - ToEdgeX, Position.Y - ToEdge, Position.Z + ToEdgeX);
            zero.TextureCoordinate.X = 1;
            zero.TextureCoordinate.Y = 1;
            verticeslist.Add(zero);
        }

        #endregion

        public void Draw(BasicEffect effect, Matrix _viewMatrix, Matrix _projectionMatrix)
        {
            effect.TextureEnabled = true;
            effect.Texture = Type.Texture;



            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
            }

            _game.GraphicsDevice.SamplerStates[0] = SamplerState.LinearClamp;
            _game.GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, verticeslist.ToArray(), 0, (verticeslist.Count / 3), VertexPositionTexture.VertexDeclaration);

        }
    }
}
