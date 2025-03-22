using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Messages
{
    public class MessageView: MonoBehaviour
    {
        public TextMeshPro text;
        public GameObject paperModel;

        private Transform _messageSpawnPoint;
        public MessageView(Transform messageSpawnPoint)
        {
            _messageSpawnPoint = messageSpawnPoint;
        }
        
        public void MoveTo(Vector3 finalPosition)
        {
            transform.DOMove(finalPosition, 0.5f);
        }
    }
}