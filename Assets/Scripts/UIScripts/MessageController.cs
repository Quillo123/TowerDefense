using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{

    [SerializeField] Text _messageTextPrefab;

    float _waitTime = 3.95f;
    public void PlayMessage(string message)
    {
        Text playerMessage = Instantiate(_messageTextPrefab, transform) as Text; ;
        playerMessage.text = message;
        StartCoroutine(DestroyMessage(playerMessage));
    }

    private IEnumerator DestroyMessage(Text message)
    {
        yield return new WaitForSeconds(_waitTime);
        Destroy(message.gameObject);
    }
}
