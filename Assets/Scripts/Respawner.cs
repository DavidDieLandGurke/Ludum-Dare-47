using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public Transform spawnPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.transform.position = spawnPos.position;
    }
}
