using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class TwoDMovementPlatformer : MonoBehaviour
{
    public Vector2 movement;

    public float speed = 5f;
    public float jumpForce;

    public Rigidbody2D rb;

    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(new Vector3(0f, jumpForce, 0f) * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void OnCollisionExit()
    {
        isGrounded = false;
    }
}
