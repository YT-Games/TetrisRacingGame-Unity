using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShieldController : MonoBehaviour
{
    [SerializeField] Transform player;
    float counter;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        player = FindObjectOfType<PlayerCollision>().transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z);
    }
}