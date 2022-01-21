using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;

    public float speed;


    private void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        
        Vector3 dir = new Vector3(horiz, 0, vert);
        dir.Normalize();

        rb.velocity = transform.TransformDirection(dir) * speed * Time.fixedDeltaTime;
    }
}
