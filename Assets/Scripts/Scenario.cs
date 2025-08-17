using UnityEngine;

public class Scenario : MonoBehaviour
{
    public GameObject wall;
    public float spawnRate;
    public float offsetX = -2f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnRate)
        {
            Vector3 spawnPosition = new Vector3(
               this.transform.position.x + offsetX,
               this.transform.position.y,
               this.transform.position.z
           );
            Instantiate(wall, spawnPosition, Quaternion.identity);
            timer = 0;
        }
    }
}
