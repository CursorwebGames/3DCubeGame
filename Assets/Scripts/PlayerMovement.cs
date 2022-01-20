using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform player;
    public Rigidbody rb;

    private void FixedUpdate()
    {
        Vector3 localUp = player.up;
    }
}
