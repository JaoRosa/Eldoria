using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float JumpForce = 6;

    private float playerHalfHeight;
    private bool isGrounded;

    private void Start()
    {
        playerHalfHeight = spriteRenderer.bounds.extents.y;
    }

    void Update()
    {

        if (Input.GetButtonDown("Jump") && GetIsGrounded())
        {
            Jump();
        } 
    }

    private bool GetIsGrounded()
    {
       return Physics2D.Raycast(transform.position, Vector2.down, playerHalfHeight + 0.1f, LayerMask.GetMask("Ground"));
    }

    private void Jump()
    {
        rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }
}
