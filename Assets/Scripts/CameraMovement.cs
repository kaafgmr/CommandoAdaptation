using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Target;
    public float smoothValue;
    public static bool OnFinalPoint = false;

    private void Start()
    {
        OnFinalPoint = false;
    }

    private void FixedUpdate()
    {
        MoveCamera();
    }
    public void MoveCamera()
    {
        if(Target.position.y >= transform.position.y && !OnFinalPoint)
        {
            Vector3 SmoothMovement = Vector3.Lerp(transform.position, Target.position, smoothValue * Time.fixedDeltaTime);
            transform.position = new Vector3(transform.position.x, SmoothMovement.y, transform.position.z);
        }
    }
}
