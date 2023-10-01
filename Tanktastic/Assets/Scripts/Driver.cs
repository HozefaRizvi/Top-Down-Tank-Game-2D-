using UnityEngine;
using UnityEngine.Tilemaps;
public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 50f;
    [SerializeField] float moveSpeed = 30f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletPoint;
    [SerializeField] private Tilemap tilemap;
    private float originalMoveSpeed;
    private bool isSpeedupActive = false;
    private float speedupDuration = 2f;
    private float speedupStartTime;

    private bool isOilSpillActive = false; // Check if oil spill is active
    private float oilSpillDuration = 2f; // Duration of oil spill slowdown in seconds
    private float oilSpillStartTime; // Time when oil spill slowdown was applied

    void Start()
    {
        originalMoveSpeed = moveSpeed;
        Debug.Log("Hello hozefa");
    }

    void Update()
    {
        Move();
        Fire();

        // Check for speedup duration
        if (isSpeedupActive)
        {
            float elapsedTime = Time.time - speedupStartTime;
            if (elapsedTime >= speedupDuration)
            {
                moveSpeed = originalMoveSpeed;
                isSpeedupActive = false;
            }
        }

        // Check for oil spill duration
        if (isOilSpillActive)
        {
            float elapsedTime = Time.time - oilSpillStartTime;
            if (elapsedTime >= oilSpillDuration)
            {
                moveSpeed = originalMoveSpeed;
                isOilSpillActive = false;
            }
        }
    }

    void Move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Rotate(0f, 0f, -steerSpeed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.up * moveSpeed * verticalInput * Time.deltaTime);
    }

void Fire()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        if (bulletPoint != null && bullet != null)
        {
            GameObject newBullet = Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
            newBullet.SetActive(true);
            Rigidbody2D bulletRigidbody = newBullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = transform.up * moveSpeed;
        }
    }
}



    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision Started");
    }

    void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log("Collision Ended");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Started");
        if (other.gameObject.tag == "SpeedupTag")
        {
            moveSpeed *= 2f;
            isSpeedupActive = true;
            speedupStartTime = Time.time;
        }
        else if (other.gameObject.tag == "OilSpillTag")
        {
            moveSpeed /= 2f;
            isOilSpillActive = true;
            oilSpillStartTime = Time.time;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger Ended");
    }
}
