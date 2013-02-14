using Microsoft.Xna.Framework.Input;

namespace Cauldron.Services
{
    public class InputService
    {
        private BGame _game;
        private CameraService _cameraService;
        private KeyboardState _currentKeyboardState;
        private KeyboardState _previousKeyboardState;

        public InputService(BGame game)
        {
            _game = game;
            _cameraService = game.CameraService;
        }

        public void Update()
        {
            _previousKeyboardState = _currentKeyboardState;
            _currentKeyboardState = Keyboard.GetState();

            if(_currentKeyboardState.IsKeyUp(Keys.Right) ||
                _currentKeyboardState.IsKeyUp(Keys.Left) ||
                _currentKeyboardState.IsKeyUp(Keys.Enter))
            {
                _game.CameraService.MoveCamera(_currentKeyboardState, _previousKeyboardState);
            }
        }
    }
}
