using UnityEngine;
using TMPro;

public class TextTimerController : MonoBehaviour
{
    private TextMeshProUGUI TimerText;
    private TimerManager TimerScript;

    private void Start()
    {
        TimerScript = GetComponent<TimerManager>();
        TimerText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        UpdateTimerValue();
    }
    public void UpdateTimerValue()
    {
        TimerText.text = "" + TimerScript.ReturnTime();
    }
}
