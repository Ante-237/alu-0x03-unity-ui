using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 40f;
    public int health = 5;

    /// <summary>
    /// keeps reference to text element.
    /// </summary>
    public TextMeshProUGUI scoreText;

    /// <summary>
    /// keeps reference to health text element
    /// </summary>
    public TextMeshProUGUI healthText;
    
    private Rigidbody rb;

    private int score = 0;

    private float horizontal;
    private float vertical;



    void SetScoreText()
    {
        scoreText.text = "Score : " + score;
    }

    void SetHealth()
    {
        healthText.text = "Health : " + health;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Time.frameCount % 10 == 0)
        {
            if (health <= 0)
            {
                Debug.Log("Game Over!");
                health = 5;
                score = 0;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void FixedUpdate()
    {
        PlayerMovements();
    }


    public void PlayerMovements()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        rb.AddForce(new Vector3(horizontal, 0, vertical) * (speed * Time.deltaTime), ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            SetHealth();
        }

        if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }
}
