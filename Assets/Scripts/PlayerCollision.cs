using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] CircleShieldController prefabToSpawn;
    GameObject newObject;
    private bool HaveShild = false;
    float counter = 0;

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
            Destroy(collision.gameObject);
            
        }else if(collision.collider.tag == "Shield" && HaveShild)
        {
            Debug.Log("We allready have shild");
        }
    }

    private void ActivateShild()
    {
        Debug.Log("We got a shild");
        Vector3 positionOfPlayerObject = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        newObject = Instantiate(prefabToSpawn.gameObject, positionOfPlayerObject, Quaternion.Euler(0,0,0));
    }

    private void CancelShild()
    {
        
    }
    void FixedUpdate()
    {
        if (HaveShild == true)
        {
            counter += Time.deltaTime;
            if (counter > 10)
            {
                counter = 0;
                Destroy(newObject);
                HaveShild = false;
            }
        }
    }
}
