using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class WinOnCollission : MonoBehaviour
{
    public GameObject winScreen;

    public void Start()
    {
        winScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (!GameMNGR.instance.GetHasKey())
        {
            return;
        }
        
        if (trig.gameObject.CompareTag("Player"))
        {
            winScreen.SetActive(true);
        }
    }

}
