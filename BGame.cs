using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Cauldron.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Cauldron
{
    public class BGame : Microsoft.Xna.Framework.Game
    {
        VirtualScreen virtualScreen;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public MouseState originalMouseState;

        public CauldronMainForm _form;
        public EnvironmentService EnvironmentService { get; private set; }
        public CameraService CameraService { get; private set; }
        public InputService InputService { get; private set; }

        public BasicEffect Effect { get; private set; }
        private List<IntPtr> _drawSurface;

        public BGame(List<IntPtr> drawSurface)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _drawSurface = new List<IntPtr>();
            foreach (IntPtr j in drawSurface)
            {
                _drawSurface.Add(j);
            }

            //this._drawSurface = drawSurface[0];
            graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);
            System.Windows.Forms.Control.FromHandle(this.Window.Handle).VisibleChanged += new EventHandler(BGame_VisibleChanged);
            //graphics.PreferredBackBufferWidth = 1280;
            //graphics.PreferredBackBufferHeight = 720;
        }

        public BGame(CauldronMainForm form)
        {
            
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _drawSurface = new List<IntPtr>();
            foreach (IntPtr j in form.getBaseDrawControlList())
            {
                _drawSurface.Add(j);
            }

            _form = form;
            //this._drawSurface = drawSurface[0];
            graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(graphics_PreparingDeviceSettings);
            System.Windows.Forms.Control.FromHandle(this.Window.Handle).VisibleChanged += new EventHandler(BGame_VisibleChanged);
            //graphics.PreferredBackBufferWidth = 1280;
            //graphics.PreferredBackBufferHeight = 720;
        }

        protected override void Initialize()
        {
            //Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
            Window.AllowUserResizing = true;
            RasterizerState rs = new RasterizerState();
            rs.FillMode = FillMode.Solid;
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
            graphics.ApplyChanges();
            GraphicsDevice.RasterizerState = rs;

            
            Mouse.SetPosition(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);
            originalMouseState = Mouse.GetState();

            Effect = new BasicEffect(GraphicsDevice);
            CameraService = new CameraService(this);
            EnvironmentService = new EnvironmentService(this);
            InputService = new InputService(this);
            CauldronMainForm.ActiveForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form_DoClosingAction);
            

            Matrix worldMatrix = Matrix.Identity;
            Effect.World = worldMatrix;
            Effect.View = CameraService.ViewMatrix;
            Effect.Projection = CameraService.ProjectionMatrix;
            CauldronMainForm.game = this;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            //if (!CameraService.Moving)
            //{
            //}
            InputService.Update();
            EnvironmentService.Update();
            CameraService.Update(gameTime);
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //virtualScreen.BeginCapture();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //virtualScreen.EndCapture();

            //spriteBatch.Begin();
            //virtualScreen.Draw(spriteBatch);
            //spriteBatch.End();

            CameraService.Draw(Effect);

            base.Draw(gameTime);
        }

        private void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
        {
            foreach (IntPtr j in _drawSurface)
            {
                e.GraphicsDeviceInformation.PresentationParameters.DeviceWindowHandle = j;
            }
            
        }

        private void BGame_VisibleChanged(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Control.FromHandle(this.Window.Handle).Visible == true)
            {
                System.Windows.Forms.Control.FromHandle(this.Window.Handle).Visible = false;
            }
        }

        private void Form_DoClosingAction(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
