using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Cauldron
{
    public partial class BaseDrawControl : GraphicsDeviceControl
    {
        public BaseDrawControl()
        {
            InitializeComponent();
        }

        public BaseDrawControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void Draw()
        {
        }

        protected override void Initialize()
        {
        }
    }
}
