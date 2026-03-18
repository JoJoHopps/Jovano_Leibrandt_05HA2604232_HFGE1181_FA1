using UnityEngine;
using UnityEngine.Android;

public class KeyPickup : MonoBehaviour
{
  private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameState.hasKey = true;
            gameObject.SetActive(false);
        }
    }
}
