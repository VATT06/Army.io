using UnityEngine;

public class IaBehaviour : MonoBehaviour
{
    private Rigidbody2D ia;
    public Transform player;
    public Vector2 initialPosition;
    public float speed = 2f;
    public float rotationSpeed = 5f; // Ajusta este valor para controlar la velocidad de rotación

    void Start()
    {
        ia = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    void Update()
    {
        if (player != null)
        {
            RotateTowardsPlayer(player.position);
            MoveTowardsPlayer(player.position);
        }
        else
        {
            ReturnToInitialPosition();
        }
    }

    void RotateTowardsPlayer(Vector2 targetPosition)
    {
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    void MoveTowardsPlayer(Vector2 targetPosition)
    {
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        Vector2 velocity = direction * speed;
        ia.velocity = velocity;
    }

    void ReturnToInitialPosition()
    {
        Vector2 direction = (initialPosition - (Vector2)transform.position).normalized;
        Vector2 velocity = direction * speed;
        ia.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform == player)
        {
            player = null;
        }
    }
}
