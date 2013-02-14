using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Cauldron.Services
{
    public enum CamPositions
    {
        South,
        East,
        North,
        West
    }

    public class Direction
    {
        public Vector3 CameraPosition { get; set; }
        public Direction Next { get; set; }
        public Direction Previous { get; set; }
    }

    public class CameraService
    {
        BaseDrawControl baseDrawControl;
        float timeDifference;
        public Direction South { get; set; }
        public Direction East { get; set; }
        public Direction North { get; set; }
        public Direction West { get; set; }
        public bool isRotating { get; set; }
        bool mouseDown = false;

        private BGame _game;
        public Vector3 CurrentCameraPosition { get; set; }
        
        //Camera Stuff
        public Matrix ViewMatrix {get; set;}
        public Matrix ProjectionMatrix { get; set;}
        private Vector3 _lookPosition;        

        private Direction _cameraDirection;
        public Direction CameraDirection
        {
            get { return _cameraDirection; }
            set
            {
                if (value == null)
                    return;
                
                AnimationStart = _cameraDirection;
                _cameraDirection = value;
                AnimationEnd = _cameraDirection;
            }
        }

        //Animation Stuff
        private float _rotationAngle;
        private float _rotationTime;
        private const float RotationTimeTotal = 1.0f;
        private const int CamDistance = 500;

        private Direction AnimationStart { get; set; }
        private Direction AnimationEnd { get; set; }

        

        public CameraService(BGame game)
        {
            _game = game;

            baseDrawControl = _game._form.getBaseDrawControl();
            baseDrawControl.MouseCaptureChanged += new EventHandler(mouseCaptureChanged);
            baseDrawControl.MouseDown += new System.Windows.Forms.MouseEventHandler(mouseDownEvent);
            baseDrawControl.MouseUp += new System.Windows.Forms.MouseEventHandler(mouseUpEvent);
            CurrentCameraPosition = new Vector3(0, 0, CamDistance);
            _lookPosition = new Vector3(0, 0, 0);
            ViewMatrix = Matrix.CreateLookAt(CurrentCameraPosition, _lookPosition, new Vector3(0, 1, 0));
            //ProjectionMatrix = Matrix.CreateOrthographicOffCenter(-400, 400, -200, 200, 0.2f, 5500.0f);
            ProjectionMatrix = Matrix.CreateOrthographic(320, 180, 0.2f, 5500.0f);
            
            CameraDirection = East;

            East = new Direction() {CameraPosition = new Vector3(CamDistance, 0, 0)};
            North = new Direction() { CameraPosition = new Vector3(0, 0, -CamDistance)};
            West = new Direction() { CameraPosition = new Vector3(-CamDistance, 0, 0)};
            South = new Direction() { CameraPosition = new Vector3(0, 0, CamDistance)};
            isRotating = false;

            East.Next = North;
            East.Previous = South;

            North.Previous = East;
            North.Next = West;

            West.Previous = North;
            West.Next = South;

            South.Next = East;
            South.Previous = West;

            CameraDirection = South;

            AnimationEnd = null;
        }

        public void Update(GameTime gameTime)
        {
            if(AnimationEnd == null)
            {
                UpdateCamPosition();
            }
            else
            {
                PlayAnimation(gameTime);
            }


            if(_rotationTime == RotationTimeTotal)
            {
                AnimationEnd = null;
                _rotationTime = 0;
            }

            if (CauldronMainForm.freeCam)
            {
                UpdateViewMatrix();
            }

            timeDifference = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000.0f;
            if (mouseDown)
            {
                ProcessInput(timeDifference);
            }

            _game.Effect.View = ViewMatrix;
            
        }

        private void UpdateCamPosition()
        {
            CurrentCameraPosition = CameraDirection.CameraPosition;
            ViewMatrix = Matrix.CreateLookAt(CurrentCameraPosition, _lookPosition, new Vector3(0, 1, 0));
        }

        private void PlayAnimation(GameTime gameTime)
        {
            isRotating = true;
            _rotationTime += gameTime.ElapsedGameTime.Milliseconds / ( RotationTimeTotal * 1000 );
            _rotationTime = MathHelper.Clamp(_rotationTime, 0.0f, 1.0f);
            _rotationAngle = MathHelper.SmoothStep(0, 90, _rotationTime);

            var _cameraRotatedPosition = Vector3.Transform(AnimationStart.CameraPosition, Matrix.CreateRotationY(MathHelper.ToRadians(_rotationAngle * ((AnimationEnd.Previous == AnimationStart) ? 1 : -1) )));
            _cameraRotatedPosition += _lookPosition;
            ViewMatrix = Matrix.CreateLookAt(_cameraRotatedPosition, _lookPosition, new Vector3(0, 1, 0));

            // This keeps the camera from snapping if the camera is already
            // moving and we attempt to change direction during this movement.
            if (_rotationTime == RotationTimeTotal)
            {
                isRotating = false;
            }
        }

        public void Draw(BasicEffect effect)
        {
            _game.EnvironmentService.Draw(effect, ViewMatrix, ProjectionMatrix);
        }

        public void MoveCamera(KeyboardState _currentKeyboardState, KeyboardState _previousKeyboardState)
        {
            if (_currentKeyboardState.IsKeyUp(Keys.Right) &&
                _previousKeyboardState.IsKeyDown(Keys.Right))
            {
                if (!isRotating)
                {
                    CameraDirection = CameraDirection.Next;
                }
            }
            else if (_currentKeyboardState.IsKeyUp(Keys.Left) &&
                     _previousKeyboardState.IsKeyDown(Keys.Left))
                if (!isRotating)
                {
                    CameraDirection = CameraDirection.Previous;
                }
        }

        
        private void mouseDownEvent(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (CauldronMainForm.freeCam)
            {
                mouseDown = true;
            }
        }

        private void mouseUpEvent(object sender, EventArgs e)
        {
            mouseDown = false;
        }

        private void mouseCaptureChanged(object sender, EventArgs e)
        {

        }

        Vector3 cameraPosition = new Vector3(130, 30, -50);
        float leftrightRot = MathHelper.PiOver2;
        float updownRot = -MathHelper.Pi / 10.0f;
        const float rotationSpeed = 0.3f;
        const float moveSpeed = 30.0f;

        private void UpdateViewMatrix()
        {
            Matrix cameraRotation = Matrix.CreateRotationX(updownRot) * Matrix.CreateRotationY(leftrightRot);

            Vector3 cameraOriginalTarget = new Vector3(0, 0, -1);
            Vector3 cameraRotatedTarget = Vector3.Transform(cameraOriginalTarget, cameraRotation);
            Vector3 cameraFinalTarget = cameraPosition + cameraRotatedTarget;

            Vector3 cameraOriginalUpVector = new Vector3(0, 1, 0);
            Vector3 cameraRotatedUpVector = Vector3.Transform(cameraOriginalUpVector, cameraRotation);

            ViewMatrix = Matrix.CreateLookAt(cameraPosition, cameraFinalTarget, cameraRotatedUpVector);
        }

        private void ProcessInput(float amount)
        {
            MouseState currentMouseState = Mouse.GetState();
            if (currentMouseState != _game.originalMouseState)
            {
                float xDifference = currentMouseState.X - _game.originalMouseState.X;
                float yDifference = currentMouseState.Y - _game.originalMouseState.Y;
                leftrightRot -= rotationSpeed * xDifference * amount;
                updownRot -= rotationSpeed * yDifference * amount;
                Mouse.SetPosition(_game.GraphicsDevice.Viewport.Width / 2, _game.GraphicsDevice.Viewport.Height / 2);
                UpdateViewMatrix();
            }

            Vector3 moveVector = new Vector3(0, 0, 0);
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.Up) || keyState.IsKeyDown(Keys.W))
                moveVector += new Vector3(0, 0, -1);
            if (keyState.IsKeyDown(Keys.Down) || keyState.IsKeyDown(Keys.S))
                moveVector += new Vector3(0, 0, 1);
            if (keyState.IsKeyDown(Keys.Right) || keyState.IsKeyDown(Keys.D))
                moveVector += new Vector3(1, 0, 0);
            if (keyState.IsKeyDown(Keys.Left) || keyState.IsKeyDown(Keys.A))
                moveVector += new Vector3(-1, 0, 0);
            if (keyState.IsKeyDown(Keys.Q))
                moveVector += new Vector3(0, 1, 0);
            if (keyState.IsKeyDown(Keys.Z))
                moveVector += new Vector3(0, -1, 0);
            AddToCameraPosition(moveVector * amount);
        }

        private void AddToCameraPosition(Vector3 vectorToAdd)
        {
            Matrix cameraRotation = Matrix.CreateRotationX(updownRot) * Matrix.CreateRotationY(leftrightRot);
            Vector3 rotatedVector = Vector3.Transform(vectorToAdd, cameraRotation);
            cameraPosition += moveSpeed * rotatedVector;
            UpdateViewMatrix();
        }
    }
}
