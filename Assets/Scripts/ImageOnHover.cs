using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ImageOnHover : MonoBehaviour
{
    private SpriteRenderer Image;

    private void Awake()
    {
        Image = GetComponentInChildren<SpriteRenderer>();
        Image.enabled = false;
    }
    public void OnHoverEnter()
    {
        Image.enabled = true;
    }

    public void OnHoverExit()
    {
        Image.enabled = false;
    }
}
