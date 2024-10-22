using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScripts : MonoBehaviour
{
    public GameObject StartPoint;
    public GameObject Player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.transform.position = StartPoint.transform.position; 
        }
    }
}
