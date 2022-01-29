using UnityEngine;

public class DaylightCycle : MonoBehaviour
{
    public int speed = 10;

    private void Update()
    {
        transform.Rotate(speed * Time.deltaTime, 0, 0);
    }
}
