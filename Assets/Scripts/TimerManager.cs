using UnityEngine;
using UnityEngine.Events;
public class TimerManager : MonoBehaviour
{
    [SerializeField] private float startValue = 120;
    [SerializeField] private int minimunValue = 0;

    private float timerValue;
    private int timerReturnValue;
    private int lastValue;

    public UnityEvent<int> TimeChanged;
    public UnityEvent TimeIsUp;

    private void Start()
    {
        timerValue = startValue;
    }

    private void Update()
    {
        lastValue = timerReturnValue;

        timerValue -= Time.deltaTime;
        timerReturnValue = Mathf.RoundToInt(timerValue);
        
        if (timerReturnValue != lastValue)
        {
            lastValue = timerReturnValue;
            TimeChanged.Invoke(timerReturnValue);
        }

        if (timerReturnValue <= minimunValue)
        {
            TimeIsUp.Invoke();
        }
    }

    public int ReturnTime()
    {
        return timerReturnValue;
    }
}
