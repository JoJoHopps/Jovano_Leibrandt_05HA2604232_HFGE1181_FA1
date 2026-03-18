using UnityEngine;
using UnityEngine.UI;

public class ItenCollector : MonoBehaviour
{
    private int CherryCollected = 0;

    [SerializeField] private Text CherriesText;
   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.gameObject.CompareTag("Cherry"))
       {
           Destroy(collision.gameObject);
            CherryCollected++;
            CherriesText.text = "Cherries Collected: " + CherryCollected;

            Debug.Log("Cherry Collected: " + CherryCollected);

        }
    }
}
