using UnityEngine;
using TMPro;

public class TextHealthManager : MonoBehaviour
{
    private TextMeshProUGUI LifeText;

    private void Awake()
    {
        LifeText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateLifeValue(float Value)
    {
        LifeText.text = "" + Value;
    }
}
