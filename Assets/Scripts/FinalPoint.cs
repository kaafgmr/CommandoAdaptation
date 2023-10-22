using UnityEngine;
using UnityEngine.Events;

public class FinalPoint : MonoBehaviour
{
    public UnityEvent FinishGame;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerController _))
        {
            FinishGame.Invoke();
        }
    }
}
