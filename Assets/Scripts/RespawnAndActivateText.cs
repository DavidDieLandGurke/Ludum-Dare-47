using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAndActivateText : MonoBehaviour
{
    public Transform spawnPos;

    public GameObject textObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.position = spawnPos.position;

            if(textObject != null)
            {
                textObject.SetActive(true);
            }
        }
    }
}
