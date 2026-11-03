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

    void Update()
    {
        // WebGL mobile: UI buttons don't reliably receive taps, so a tap anywhere works too
        if (!Tapped()) return;
        if (titleScreen.activeSelf) StartGame();
        else if (bird.restartButton.gameObject.activeSelf) RestartGame();
    }

    // WebGL mobile doesn't reliably simulate mouse from touch
    public static bool Tapped()
    {
        return Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began);
    }

    public void StartGame()
    {
        if (!titleScreen.activeSelf) return; // button click can follow the tap
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
