using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _moveInput;
    private bool _isJumpHeld;
    private float _coyoteTimer;
    private float _jumpBufferTimer;
    private GroundCheck _groundCheck;
    [SerializeField] float speed = 10;
    [SerializeField] float jumpStrength = 35;
    [SerializeField] float coyoteTime = 0.05f;
    [SerializeField] float jumpBufferTime = 0.1f;
    [SerializeField] float maxFallSpeed = 25;

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
            _jumpBufferTimer = jumpBufferTime;
            _isJumpHeld = true;
        }
        if (context.canceled)
        {
            _isJumpHeld = false;
        }
    }

    void JumpAction()
    {
        _jumpBufferTimer -= Time.fixedDeltaTime;
        if (_rb.linearVelocityY > 0 && _isJumpHeld)
        {
            _rb.gravityScale = 9; //gravity during jump
        }
        else
        {
            _rb.gravityScale = 16;
        }
        if (_groundCheck.IsGrounded())
        {
            _coyoteTimer = coyoteTime;
        }
        else
        {
            _coyoteTimer -= Time.fixedDeltaTime;
        }
        if (_jumpBufferTimer > 0 && _coyoteTimer > 0)
        {
            _rb.linearVelocityY = 0;
            _rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            _coyoteTimer = 0;
            _jumpBufferTimer = 0;
        }
    }

    void FixedUpdate()
    {
        _rb.linearVelocityX = _moveInput * speed;
        JumpAction();
        _rb.linearVelocityY = Mathf.Max(_rb.linearVelocityY, -maxFallSpeed);
    }
}