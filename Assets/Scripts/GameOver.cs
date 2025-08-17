using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision) {
    if(collision.gameObject.CompareTag("Player"))
    {
        SceneManager.LoadScene(0);
    }
   }
}
