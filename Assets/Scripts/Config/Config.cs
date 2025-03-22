using System;
using UnityEngine;

namespace Config
{
    [Serializable]
    public class Config
    {
        public string StartLevel;
        
        public static Config LoadConfig()
        {
           Config config = JsonUtility.FromJson<Config>(Resources.Load<TextAsset>("config").text);
           return config;
        }
    }
    
    
}

