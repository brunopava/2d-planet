using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform LookTransform;
 
    public float speed = 6.0f;
    public float maxVelocityChange = 10.0f;
    public float jumpForce = 5.0f;
    public float GroundHeight = 1.1f;
    private float xRotation;
    private float yRotation;

    void FixedUpdate () 
    {
        // RaycastHit groundedHit;
        // bool grounded = Physics.Raycast(transform.position, -transform.up, out groundedHit, GroundHeight);
 
        // if (grounded)
        // {
            // Calculate how fast we should be moving
            Vector3 forward = Vector3.Cross(transform.up, -LookTransform.right).normalized;
            Vector3 right = Vector3.Cross(transform.up, LookTransform.forward).normalized;
            Vector3 targetVelocity = (forward * Input.GetAxis("Vertical") + right * Input.GetAxis("Horizontal")) * speed;
 
            Vector3 velocity = transform.InverseTransformDirection(GetComponent<Rigidbody2D>().velocity);
            velocity.y = 0;
            velocity = transform.TransformDirection(velocity);
            Vector3 velocityChange = transform.InverseTransformDirection(targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            velocityChange = transform.TransformDirection(velocityChange);
 
            GetComponent<Rigidbody2D>().AddForce(velocityChange, ForceMode2D.Force);
 
            if (Input.GetButton("Jump"))
            {
                GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce, ForceMode2D.Force);
            }
        // }
    }
}