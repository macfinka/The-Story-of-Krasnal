using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _moveInput;
    private bool _jumpInput;
    private GroundCheck _groundCheck;
    [SerializeField] float speed = 10;
    [SerializeField] float jumpStrength = 35;
    
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _groundCheck = GetComponentInChildren<GroundCheck>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<float>();
    }

   public void OnJump(InputAction.CallbackContext context)
    {
            if (context.performed)
            {
                _jumpInput = true;
            }
    }
   
    void FixedUpdate()
    {
        _rb.linearVelocityX= _moveInput * speed;
        if (_jumpInput && _groundCheck.IsGrounded())
        {
            _rb.linearVelocityY = 0;
            _rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse); 
        }
        _jumpInput = false;
    }
}
