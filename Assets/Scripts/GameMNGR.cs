using System;
using TMPro;
using UnityEngine;

public class GameMNGR : MonoBehaviour
{
    public static GameMNGR instance;

    private bool hasKey = false;

    [SerializeField] private GameObject loseScreen;
    [SerializeField] private GameObject winScreen;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void EnableLoseScreen(string deathMessage)
    {
        loseScreen.SetActive(true);
        loseScreen.transform.Find("tmpDeathMessage").GetComponent<TextMeshProUGUI>().text = deathMessage;
        winScreen.SetActive(false);
    }
    
    public void EnableWinScreen(string winMessage)
    {
        winScreen.SetActive(true);
        winScreen.transform.Find("tmpWinMessage").GetComponent<TextMeshProUGUI>().text = winMessage;
        loseScreen.SetActive(false);
    }

    public void SetHasKey(bool value)
    {
        hasKey = value;
    }

    public bool GetHasKey()
    {
        return hasKey;
    }
}
