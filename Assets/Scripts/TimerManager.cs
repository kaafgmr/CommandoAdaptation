using UnityEngine;
using UnityEngine.Events;
public class TimerManager : MonoBehaviour
{
    public float TimerValue;
    public int MinimunValue;
    private int TimerReturnValue;

    public UnityEvent TimeIsUp;
    private void Update()
    {
        TimerValue -= Time.deltaTime;
        TimerReturnValue = Mathf.RoundToInt(TimerValue);
        
        if (TimerReturnValue <= MinimunValue)
        {
            TimeIsUp.Invoke();
        }
    }

    public int ReturnTime()
    {
        return TimerReturnValue;
    }
}
