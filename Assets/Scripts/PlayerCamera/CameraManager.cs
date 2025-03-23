using DG.Tweening;
using UnityEngine;

namespace PlayerCamera
{
    public class CameraManager
    {
        private Camera _camera;
        
        public CameraMode Mode { get; private set; }
        public enum CameraMode
        {
            WHOLE,
            TABLE,
            MACHINE,
        }
        
        public CameraManager(Camera camera)
        {
            _camera = camera;
        }

        public void MoveToTable()
        {
            switch (Mode)
            {
                case CameraMode.TABLE:
                    return;
                default:
                    Sequence sequence = DOTween.Sequence();
                    sequence.Append(_camera.transform.DOMove(new Vector3(0, 4, 1.5f), 0.5f));
                    sequence.Join(_camera.transform.DORotate(new Vector3(85, 0, 0), 0.5f));
                    Mode = CameraMode.TABLE;
                    break;
            }
        }

        public void MoveToWhole()
        {
            switch (Mode)
            {
                case CameraMode.WHOLE:
                    return;
                default:
                    Sequence sequence = DOTween.Sequence();
                    sequence.Append(_camera.transform.DOMove(new Vector3(0, 3.5f, -0.5f), 0.5f));
                    sequence.Join(_camera.transform.DORotate(new Vector3(43, 0, 0), 0.5f));
                    Mode = CameraMode.WHOLE;
                    break;
            }
        }
    }
}