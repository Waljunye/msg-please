using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utils;

namespace Messages
{
    public class MessageManager
    {
        private EntryPoint _entryPoint;
        private Transform _messageSpawnPoint;
        private Transform _messageViewOnTableStartPoint;
        
        private GameObject _textObject;
        private GameObject _planeObject;
        
        private float _planeWidth;
        private float _planeHeight;
        
        private List<Message> _messages;
        private int _currentMessageIndex = 0;
        
        public MessageView MessageView { get; private set; }

        
        
        public MessageManager(EntryPoint entryPoint, Transform messageSpawnPoint, Transform messageViewOnTableStartPoint)
        {
            _entryPoint = entryPoint;
            _messageSpawnPoint = messageSpawnPoint;
            _messageViewOnTableStartPoint = messageViewOnTableStartPoint;
        }
        
        public void InstantiateMessagesForLevel(string levelID)
        {
            _messages = new List<Message>();  
            Message[] loadedMessages = Resources.LoadAll<Message>($"Levels/{levelID}/Messages");

            foreach (var msg in loadedMessages)
            {
                _messages.Add(msg);
            }
            _messages.Shuffle();
        }
        
        public void InstantiateMessageView()
        {
            GameObject messageViewGameObject = new GameObject("MessageView");
            MessageView mv = messageViewGameObject.AddComponent<MessageView>();
            
            messageViewGameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            messageViewGameObject.transform.position = _messageSpawnPoint.position;
            MessageView = mv;
        }
        
       
        public void PlaceCurrentMessage()
        {
            Debug.Log(_messages);
            InstantiateMessagePlane(_messages[_currentMessageIndex]);
            InstantiateMessageText(_messages[_currentMessageIndex]);
            MessageView.MoveTo(_messageViewOnTableStartPoint.position);
        }
        
       
        private void ClearMessageView()
        {
            Object.Destroy(_planeObject);
            Object.Destroy(_textObject);
        }
        
        private void InstantiateMessageText(Message message)
        {
            GameObject textObject = new GameObject("TextMeshProObject");
            TextMeshPro textMeshPro = textObject.AddComponent<TextMeshPro>();
            textObject.transform.SetParent(MessageView.transform);
            textObject.transform.position = new Vector3(MessageView.paperModel.transform.position.x, MessageView.paperModel.transform.position.y + 0.001f, MessageView.paperModel.transform.position.z);
            textObject.transform.rotation = Quaternion.Euler(90, 0, 0);
            
            textMeshPro.text = message.message;
            textMeshPro.fontSize = 3;
            textMeshPro.enableAutoSizing = false;
            textMeshPro.rectTransform.sizeDelta = new Vector2(_planeHeight, _planeWidth);

            MessageView.text = textMeshPro;
            _textObject = textObject;
        }

        private void InstantiateMessagePlane(Message message)
        {
            GameObject plane = GameObject.Instantiate(message.paperPrefab, MessageView.gameObject.transform);
            
            _planeWidth = 9f * plane.transform.localScale.x;
            _planeHeight = 9f * plane.transform.localScale.z;
            
            MessageView.paperModel = plane;
            _planeObject = plane;
        }
        
        
    }
}