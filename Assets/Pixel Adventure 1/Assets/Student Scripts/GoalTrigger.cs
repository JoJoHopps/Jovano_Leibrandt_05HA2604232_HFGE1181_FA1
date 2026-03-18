using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GoalTrigger : MonoBehaviour
{
    [SerializeField] private GameObject WinScreen;
    [SerializeField] private GameObject KeyRequiredMsg;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name != "Player") return;

        Debug.Log("Has key: " + GameState.hasKey);

        if (GameState.hasKey)
        {
            collision.GetComponent<PlayerMovement>().enabled = false;
            collision.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

            WinScreen.SetActive(true);
        }
        else
        {
            Debug.Log("Player does not have the key.");
            StartCoroutine(ShowKeyRequired());
        }
    }
    private IEnumerator ShowKeyRequired()
    {
        KeyRequiredMsg.SetActive(true);
        yield return new WaitForSeconds(2f);
        KeyRequiredMsg.SetActive(false);
    }
    public void PlayAgain()
    {
        GameState.hasKey = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
