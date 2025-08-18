using UnityEngine;
using TMPro;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public TextMeshProUGUI scoreText;
    public float spawnRate;
    public float maxY;
    public float minY;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnRate)
        {
            timer = 0;
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(minY, maxY)), Quaternion.identity);
        }
    }
}
