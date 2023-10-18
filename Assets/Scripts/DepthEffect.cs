using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthEffect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("DepthDown");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<Renderer>().sortingLayerID = SortingLayer.NameToID("DepthUp");
    }
}
