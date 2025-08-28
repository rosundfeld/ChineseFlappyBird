using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    private bool isDeath = false;

    public Rigidbody2D rig;
    public float fixedXPosition;
    public float jumpForce = 5f;
    public float rotationSpeed;
    public bool Srinky = false;

    [SerializeField] public TextMeshProUGUI scoreText;
    public int score = 0;

    public AudioSource gameOverSound;
    public AudioSource scoreSound;

    public AudioSource[] audioSources;
    private int audioInx = 0;

    public Button restartButton;

    void Start()
    {
        fixedXPosition = transform.position.x;
    }

    void Update()
    {
        AddScore();
        Moviment();
        checkIfIsDead();
        if(Srinky)
        {
            startSrinking();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Score"))
        {
            score += 1;
            scoreSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            setDeath();
            stopGame();
        }
    }

    private void stopGame()
    {
        gameOverSound.Play();
        Time.timeScale = 0f;
    }

    public void setDeath() {
        isDeath = true;
    }

    public void startSrinking()
    {
        transform.localScale = Vector3.Lerp(
        transform.localScale,
        new Vector3(1f, 1f, 1f),
        Time.deltaTime
    );
    }
    private void AddScore()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    private void checkIfIsDead()
    {
        if (isDeath)
        {
            Time.timeScale = 0f;
            restartButton.gameObject.SetActive(true);
        }
    }

    private void Moviment()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = fixedXPosition;
        transform.position = currentPosition;

        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.linearVelocity = new Vector2(rig.linearVelocityX, 0f);
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            playJumpSound(audioInx);
            if (audioInx >= 2)
            {
                audioInx = 0;
            }
            else
            {
                audioInx += 1;
            }
        }
    }

    private void playJumpSound(int soundInx)
    {
        audioSources[soundInx].Play();
    }

}
