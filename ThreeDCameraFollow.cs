using UnityEngine;

public class ThreeDCameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float smoothSpeed = 0.1f;
    public float staticY; //Holds Y position if follow Y is false

    public bool followY;

    private void Start()
    {
        // You can also specify your own offset from inspector as it is public variable
        offset = transform.position - target.position;
        offset.y = 1;
    }

    private void LateUpdate()
    {
        SmoothFollow();
    }

    public void SmoothFollow()
    {
        Vector3 targetPos = target.position + offset;
        float transY = 0;
        float targY = 0;
        float transZ = 0;
        float targZ = 0;

        if (followY)
        {
            transY = transform.position.y;
            targY = targetPos.y;

        }
        else
        {
            transY = staticY;
            targY = staticY;

        }

        Vector3 smoothFollow = Vector3.Lerp(new Vector3(transform.position.x, transY, transZ), new Vector3(targetPos.x, targY, targZ), smoothSpeed);

        transform.position = smoothFollow;

    }
}
