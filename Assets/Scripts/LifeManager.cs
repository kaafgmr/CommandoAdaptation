using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{

    public void OnDiePlayer()
    {
        SceneManager.LoadScene("mainMenu");
    }
    public void OnDieEnemy()
    {
       
        Destroy(gameObject);
    }
}
