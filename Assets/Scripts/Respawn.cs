using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public void RespawnObject()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }
}
