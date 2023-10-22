using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CameraMovement.OnFinalPoint = true;
    }
}
