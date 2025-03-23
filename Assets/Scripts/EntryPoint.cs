using System.Collections.Generic;
using Messages;
using PlayerCamera;
using PlayerControls;
using UnityEngine;

public class EntryPoint : MonoBehaviour
    {
        [SerializeField]
        private Transform messageSpawnPoint;
        [SerializeField]
        private Transform messageViewOnTableStartPoint;
        
        private MessageManager _messageManager;
        private CameraManager _cameraManager;
        private MainControls _playerControls;
        
        private GameObject _messageViewGameObject;
        private List<Message> _messages;
        private int _currentMessageIndex = 0;
        
        public enum GameState
        {
            GAME
        }

        private GameState newState;
        private string levelID;
    
        public GameState State
        {
            get {return newState;}
            set {newState = value;}
        }

        public string LevelID
        {
            get {return levelID;}
            private set {levelID = value;}
        }

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            _messageManager = new MessageManager(this, messageSpawnPoint, messageViewOnTableStartPoint);
            _cameraManager = new CameraManager(Camera.main);
            _playerControls = new MainControls(_cameraManager);
            
            _playerControls.Initialize();
            _playerControls.Enable();
            
            Config.Config config = Config.Config.LoadConfig();
            
            LevelID = config.StartLevel;
            State = GameState.GAME;
            
            LoadLevel(LevelID);
            
        }

        private void LoadLevel(string levelID)
        {
            Debug.Log($"Loading level {levelID}");
            
            _messageManager.InstantiateMessagesForLevel(levelID);
            _messageManager.InstantiateMessageView();
            _messageManager.PlaceCurrentMessage();
            
            LevelID = levelID;
            Debug.Log($"Level {levelID} loaded");
        }
        
       
}

