using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    [SerializeField] GameObject gameObject;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -20)
        {
            Destroy(gameObject);
        }
        
    }
}
