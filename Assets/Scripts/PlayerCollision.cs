using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] CircleShieldController prefabToSpawn;
    private bool HaveShild = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy" && !HaveShild)
        {
            Debug.Log("Hit!!");
            FindObjectOfType<GameManager>().EndGame();
        }else if (collision.collider.tag == "Enemy" && HaveShild)
        {
            HaveShild = false;
            Debug.Log("We have shild!!");
        }else if (collision.collider.tag == "Shield" && !HaveShild)
        {
            HaveShild = true;
            ActivateShild();
            
        }else if(collision.collider.tag == "Shield" && HaveShild)
        {
            Debug.Log("We allready have shild");
        }
    }

    private void ActivateShild()
    {
        Debug.Log("We got a shild");
        Vector3 positionOfPlayerObject = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfPlayerObject, Quaternion.Euler(0,0,0));
    }

    private void CancelShild()
    {
        
    }
}
