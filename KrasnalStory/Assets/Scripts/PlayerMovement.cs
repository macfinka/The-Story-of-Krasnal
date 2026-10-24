using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    float _movement;
    [SerializeField] float speed = 10;
    [SerializeField] float jumpStrength = 35;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))  // New input system to be implemented
        {
            _rb.linearVelocityY = 0;
            _rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        _movement = Input.GetAxis("Horizontal"); // New input system to be implemented
        _rb.linearVelocityX= _movement * speed;
    }
}
