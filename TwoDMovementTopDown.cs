using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TwoDMovementTopDown : MonoBehaviour
{
    public Vector2 movement;

    public float speed = 5f;

    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
