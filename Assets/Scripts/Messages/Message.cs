using UnityEngine;

[CreateAssetMenu(fileName = "Message", menuName = "Scriptable Objects/Message")]
public class Message : ScriptableObject
{
    public string message;
    public string senderName;
    public string recieverName;

    public GameObject paperPrefab;
}
