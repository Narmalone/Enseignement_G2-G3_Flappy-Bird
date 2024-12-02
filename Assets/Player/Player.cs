using UnityEngine;

public class FlappyBirdController : MonoBehaviour
{
    // Variables de configuration
    public float flapForce = 5f;  // Force du saut
    public float MinRotation = -30f;
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
        // Calcule la rotation en fonction de la vitesse verticale
        float rotationZ = Mathf.Clamp(rb.linearVelocity.y * fallRotationSpeed, MinRotation, maxRotation);

        // Applique la rotation en conservant une rotation 2D (seulement sur Z)
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.OnGameOver();
    }

}
