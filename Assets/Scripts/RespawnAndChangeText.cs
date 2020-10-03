using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RespawnAndChangeText : MonoBehaviour
{
    public Transform spawnPos;

    public TMP_Text textObject;
    public string changedText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.position = spawnPos.position;

            if(textObject != null)
            {
                textObject.text = changedText;
            }
        }
    }
}
