using UnityEngine;
using TMPro;

public class UIValueChanger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textToChange;
    
    public void ChangeValueTo(int value)
    {
        textToChange.text = "" + value;
    }

    public void ChangeValueTo(float value)
    {
        textToChange.text = "" + value;
    }
}
