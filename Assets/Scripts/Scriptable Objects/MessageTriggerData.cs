using UnityEngine;

[CreateAssetMenu(
    fileName = "New Message", 
    menuName = "Custom/MessageTrigger")]
public class MessageTriggerData : ScriptableObject
{
    public string Text;
}
