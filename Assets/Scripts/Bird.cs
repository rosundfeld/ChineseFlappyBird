using UnityEngine;

public class Bird : MonoBehaviour
{
    public float fixedXPosition;
    public float jumpForce = 5f;
    public Rigidbody2D rig;
    public float rotationSpeed;
   
    void Start()
    {
        fixedXPosition = transform.position.x;
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition.x = fixedXPosition;
        transform.position = currentPosition;

        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.linearVelocity = new Vector2(rig.linearVelocityX, 0f);
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
