using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ThreeDMovement : MonoBehaviour
{
    public Vector3 movement;

    public float speed = 5f;
    public float jumpForce;

    public Rigidbody rb;

    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(new Vector3(0f, jumpForce, 0f) * jumpForce, ForceMode.Impulse);
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
