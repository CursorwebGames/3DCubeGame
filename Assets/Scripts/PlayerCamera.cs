using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform parent;

    public float xSens;
    public float ySens;
    public float maxY;

    private Quaternion camDefault;

    private void Start()
    {
        camDefault = transform.localRotation;
    }

    private void Update()
    {
        RotateY();
        RotateX();
    }

    private void RotateX()
    {
        float horiz = Input.GetAxis("Mouse X") * xSens;
        Quaternion rotation = Quaternion.AngleAxis(horiz, Vector3.up);
        parent.localRotation *= rotation;
    }

    private void RotateY()
    {
        float vert = Input.GetAxis("Mouse Y") * ySens;
        Quaternion rotation = Quaternion.AngleAxis(vert, Vector3.left);
        Quaternion delta = transform.localRotation * rotation;
        if (Quaternion.Angle(camDefault, delta) < maxY) transform.localRotation = delta;
    }
}
