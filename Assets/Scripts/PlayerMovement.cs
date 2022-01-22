using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 vec = transform.right * x + transform.forward * z;

        controller.Move(vec * speed * Time.deltaTime);
    }
}
