using UnityEngine;

public class FlappyBirdController : MonoBehaviour
{
    // Variables de configuration
    public float flapForce = 5f;  // Force du saut
    public float maxRotation = 30f;  // Angle maximum d'inclinaison vers le haut
    public float fallRotationSpeed = 10f;  // Vitesse d'inclinaison vers le bas

    private Rigidbody2D rb;  // R�f�rence au Rigidbody2D

    void Start()
    {
        // R�cup�re le Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // D�tecte un clic ou une touche pour "flapper"
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * flapForce;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.linearVelocity.y * fallRotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.OnGameOver();
    }

}
