using DG.Tweening;
using UnityEngine;

namespace Camera
{
    public class CameraManager
    {
        private UnityEngine.Camera _camera;
        
        public CameraMode Mode { get; private set; }
        public enum CameraMode
        {
            WHOLE,
            TABLE,
            MACHINE,
        }
        
        public CameraManager(UnityEngine.Camera camera)
        {
            _camera = camera;
        }

        public void MoveToTable()
        {
            switch (Mode)
            {
                case CameraMode.WHOLE:
                    break;
                default:
                    Sequence sequence = DOTween.Sequence();
                    sequence.Append(_camera.transform.DOMove(new Vector3(0, 4, 1.5f), 0.5f));
                    sequence.Join(_camera.transform.DORotate(new Vector3(85, 0, 0), 0.5f));
                    break;
            }
        }
    }
}