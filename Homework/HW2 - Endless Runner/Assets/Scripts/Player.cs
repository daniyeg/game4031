// using UnityEngine;

// public class Player : MonoBehaviour
// {
//     public Sprite[] sprites;
//     public float flapStrength = 5f; // Speed of movement up and down
//     public float tiltAngle = 5f; // Angle for tilting effect

//     private SpriteRenderer spriteRenderer;
//     private Vector3 direction;
//     private bool isFlappingUp;

//     private int spriteIndex;

//     private void Awake()
//     {
//         spriteRenderer = GetComponent<SpriteRenderer>();
//     }



//     private void AnimateSprite()
//     {
//         spriteIndex++;

//         if (spriteIndex >= sprites.Length)
//         {
//             spriteIndex = 0;
//         }

//         spriteRenderer.sprite = sprites[spriteIndex];
//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.gameObject.CompareTag("Obstacle"))
//         {
//             GameManager.Instance.GameOver();
//         }
//         else if (other.gameObject.CompareTag("Scoring"))
//         {
//             GameManager.Instance.IncreaseScore();
//         }
//     }
// }




using UnityEngine;

public class Player : MonoBehaviour
{
    public Sprite[] sprites;
    public float flapStrength = 5f;
    public float gravity = -9.81f;
    public float tiltAngle = 5f;
    private bool isFlappingUp;


    private SpriteRenderer spriteRenderer;
    private Vector3 direction;
    private int spriteIndex;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
        direction = Vector3.down * flapStrength; // Start moving down
    }

    private void Update()
    {
        // Check for input to change direction
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            isFlappingUp = !isFlappingUp; // Toggle direction
            direction = isFlappingUp ? Vector3.up * flapStrength : Vector3.down * flapStrength;
        }

        // Apply direction to position
        transform.position += direction * Time.deltaTime;

        // Smoothly tilt the bird based on its vertical movement
        Vector3 rotation = transform.eulerAngles;
        rotation.z = direction.y * tiltAngle;
        transform.eulerAngles = rotation;
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0) {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) {
            GameManager.Instance.GameOver();
        } else if (other.gameObject.CompareTag("Scoring")) {
            GameManager.Instance.IncreaseScore();
        }
    }

}
