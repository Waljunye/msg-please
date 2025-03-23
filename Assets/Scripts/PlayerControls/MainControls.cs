using PlayerCamera;

namespace PlayerControls
{
    public class MainControls
    {
        private Main_controls _actions;
        private CameraManager _cameraManager;
        
        public MainControls(CameraManager cameraManager)
        {
            _actions = new Main_controls();
            _cameraManager = cameraManager;
        }

        public void Enable()
        {
            _actions.Enable();
        }
        
        public void Disable()
        {
            _actions.Disable();
        }
        
        public void Initialize()
        {
            _actions.Player.MoveToTable.performed += ctx =>
            {
                _cameraManager.MoveToTable();
            };

            _actions.Player.MoveToWhole.performed += ctx =>
            {
                _cameraManager.MoveToWhole();
            };
        }
    }
}