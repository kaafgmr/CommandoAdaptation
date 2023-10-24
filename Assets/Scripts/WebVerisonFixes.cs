using UnityEngine;

public class WebVerisonFixes : MonoBehaviour
{
#if UNITY_WEBGL
    public GameObject[] objectsToDesappearList;
    private void Start()
    {
        foreach (GameObject obj in objectsToDesappearList)
        {
               obj.SetActive(false);
        }
    }
#endif
}
