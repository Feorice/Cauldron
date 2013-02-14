using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Cauldron
{

    /// <summary>
    /// Example control inherits from GraphicsDeviceControl, which allows it to
    /// render using a GraphicsDevice. This control shows how to draw animating
    /// 3D graphics inside a WinForms application. It hooks the Application.Idle
    /// event, using this to invalidate the control, which will cause the animation
    /// to constantly redraw.
    /// </summary>
    //class EditorViewport : GraphicsDeviceControl
    //{
    //    BasicEffect effect;
    //    Stopwatch timer;
    //    SpriteFont font;
    //    SpriteBatch spriteBatch;
    //    ContentManager content;
    //    GraphicsDeviceManager graphics;
    //    SpriteFont OutputFont;
    //    float Fps = 0f;
    //    private const int NumberSamples = 50; //Update fps timer based on this number of samples
    //    int[] Samples = new int[NumberSamples];
    //    int CurrentSample = 0;
    //    int TicksAggregate = 0;
    //    int SecondSinceStart = 0;


    //    // Vertex positions and colors used to display a spinning triangle.
    //    public readonly VertexPositionColor[] Vertices =
    //    {
    //        new VertexPositionColor(new Vector3(-1,1,1), Color.Azure),
    //        new VertexPositionColor(new Vector3(1,-1,1), Color.Bisque),
    //        new VertexPositionColor(new Vector3(1,1,-1), Color.BlueViolet),
    //    };


    //    /// <summary>
    //    /// Initializes the control.
    //    /// </summary>
    //    protected override void Initialize()
    //    {
            
    //        // Create our effect.
    //        effect = new BasicEffect(GraphicsDevice);

    //        effect.VertexColorEnabled = true;

    //        // Start the animation timer.
    //        timer = Stopwatch.StartNew();

    //        // Hook the idle event to constantly redraw our animation.
    //        Application.Idle += delegate { Invalidate(); };
    //        content = new ContentManager(Services, "Content");
    //        spriteBatch = new SpriteBatch(GraphicsDevice);
    //        font = content.Load<SpriteFont>("hudFont");


    //        graphics.SynchronizeWithVerticalRetrace = false;
    //        int DesiredFrameRate = 60;
    //        TargetElapsedTime = new TimeSpan(TimeSpan.TicksPerSecond / DesiredFrameRate);
    //    }


    //    /// <summary>
    //    /// Draws the control.
    //    /// </summary>
    //    protected override void Draw()
    //    {
    //        GraphicsDevice.Clear(Color.Black);

    //        // Spin the triangle according to how much time has passed.
    //        float time = (float)timer.Elapsed.TotalSeconds;

    //        float yaw = time * 0.7f;
    //        float pitch = time * 0.8f;
    //        float roll = time * 0.9f;

    //        // Set transform matrices.
    //        float aspect = GraphicsDevice.Viewport.AspectRatio;

    //        effect.World = Matrix.CreateFromYawPitchRoll(yaw, pitch, roll);

    //        effect.View = Matrix.CreateLookAt(new Vector3(0, 0, -5),
    //                                          Vector3.Zero, Vector3.Up);

    //        effect.Projection = Matrix.CreatePerspectiveFieldOfView(1, aspect, 1, 10);

    //        // Set renderstates.
    //        GraphicsDevice.RasterizerState = RasterizerState.CullNone;

    //        // Draw the triangle.
    //        effect.CurrentTechnique.Passes[0].Apply();

    //        GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, Vertices, 0, 1);
            
    //        if (Form1.showingFPS)
    //        {
                
    //            spriteBatch.Begin();
    //            spriteBatch.DrawString(font, "Time: " + time, new Vector2(10, 10), Color.Aqua);
    //            spriteBatch.End();
    //        }
    //    }
    //}

    //class Viewport : GraphicsDeviceControl
    //{
    //    public Viewport()
    //    {
    //        InitializeComponent();
    //    }

    //    public Viewport(IContainer container)
    //    {
    //        container.Add(this);

    //        InitializeComponent();
    //    }
    //}
}
