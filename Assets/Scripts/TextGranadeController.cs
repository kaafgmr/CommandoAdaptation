using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextGranadeController : MonoBehaviour
{
    private TextMeshProUGUI GranadeText;

    private void Awake()
    {
        GranadeText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateGranadeText(int Value)
    {
        GranadeText.text = "" + Value;
    }
}
