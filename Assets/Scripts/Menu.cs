using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class Menu : MonoBehaviour
{
    public Bird bird;
    public GameObject titleScreen;
    public GameObject scoreText;
    public AudioSource yoooo;
    public AudioSource startSX;
    public AudioSource music;

    void Start()
    {
        Time.timeScale = 0f;
        yoooo.Play();
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        titleScreen.SetActive(false);
        scoreText.SetActive(true);
        startSX.Play();
        music.Play();
        bird.Srinky = true;
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }
}
