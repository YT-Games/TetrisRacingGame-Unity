using UnityEngine;

/**
 * This component moves its object in a fixed velocity.
 * NOTE: velocity is defined as speed+direction.
 *       speed is a number; velocity is a vector.
 */
public class Mover: MonoBehaviour {
    private Rigidbody rb;
    [Tooltip("Movement speed of the approaching cars")] [SerializeField] public float forwardForce = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, -forwardForce * Time.deltaTime, ForceMode.VelocityChange);
    }
}
