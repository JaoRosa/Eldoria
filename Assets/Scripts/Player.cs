using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public bool isJumping;

    private Rigidbody2D rig;

    [SerializeField] private Animator animator;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float input = Input.GetAxis("Horizontal");
        Vector3 move = new Vector3(input, 0f, 0f);
        transform.position += move * Time.deltaTime * Speed;

        if (input != 0f)
        {
            animator.SetBool("isRunning", true);
            transform.eulerAngles = new Vector3(0f, input > 0 ? 0f : 180f, 0f);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
