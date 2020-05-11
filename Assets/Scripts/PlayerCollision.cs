using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Debug.Log("Hit!!");
            FindObjectOfType<GameManager>().EndGame();
        }
        if (collision.collider.tag == "Shield")
        {
            Debug.Log("Shield!!");
        }
    }
}
