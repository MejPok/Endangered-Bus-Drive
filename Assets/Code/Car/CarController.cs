using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class CarController : MonoBehaviour
{

    public float acceleration = 10f;
    public float maxSpeed = 5f;
    public float steeringTorque = 200f;
    public float drag = 0.5f; // Braking drag

    private Rigidbody2D rb;
    private float moveInput;
    private float turnInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = drag;

    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");     // W/S or Up/Down
        turnInput = Input.GetAxisRaw("Horizontal");   // A/D or Left/Right
    }

    void FixedUpdate()
    {
        Vector2 forward = transform.up;

        // Speed in the forward direction
        float forwardSpeed = Vector2.Dot(rb.velocity, forward);

        // Apply acceleration when under speed limit or changing direction
        if (Mathf.Abs(forwardSpeed) < maxSpeed || Mathf.Sign(moveInput) != Mathf.Sign(forwardSpeed))
        {
            rb.AddForce(forward * moveInput * acceleration);
        }

        // ✅ Allow rotation when physically moving (not based on input)
        bool isPhysicallyMoving = rb.velocity.magnitude > 0.8f;

        if (isPhysicallyMoving && Mathf.Abs(turnInput) > 0f)
        {
            float direction = -turnInput * Mathf.Sign(forwardSpeed != 0 ? forwardSpeed : 1);
            rb.AddTorque(direction * (puddleDrift + steeringTorque) * Time.fixedDeltaTime);
        }
    }
    public float puddleDrift;
    public float puddleChange;
    public void EnterPuddle()
    {
        puddleDrift = puddleChange;
    }
    public void LeavePuddle()
    {
        puddleDrift = 0;
    }



}