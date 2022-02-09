using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isPlaying = true;

    private void Update()
    {
        if (isPlaying)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPlaying = false;
        }
        
        if (Input.GetMouseButton(0)) // primary
        {
            isPlaying = true;
        }
    }
}
