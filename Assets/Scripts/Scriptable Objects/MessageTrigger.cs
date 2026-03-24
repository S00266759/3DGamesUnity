using UnityEngine;

public class MessageTrigger : MonoBehaviour
{
    [SerializeField] private MessageTriggerData MessageData;
    private bool hasBeenTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            if (!hasBeenTriggered)
            {
                Debug.Log(MessageData.Text);
                hasBeenTriggered = true;
            }
    }
}
