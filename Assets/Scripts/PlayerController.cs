using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpVelocity = 15.0f;
    public float lateralVelocity = 0.25f;
    public float maxVelocity = 2.0f;
    public ParticleSystem smoke;
    public ThrustMeterController thrustMeter;
    public float thrustConsumption = 0.05f;
    public float fillSpeed = 0.10f;

    private float thrust = 1.0f;
    private float sqrMaxVelocity;
    private Rigidbody2D rb;

    void SetMaxVelocity(){
        sqrMaxVelocity = maxVelocity * maxVelocity;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        SetMaxVelocity();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        smoke.enableEmission = false;

        Vector2 velocity = rb.velocity;

        if (Input.GetKey(KeyCode.Space) && thrust >= thrustConsumption)
        {
            velocity += Vector2.up * jumpVelocity;
            smoke.enableEmission = true;

            updateThrust(-thrustConsumption);
        }
        else {
            updateThrust(fillSpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow)) {
            velocity += Vector2.left * lateralVelocity;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity += Vector2.right * lateralVelocity;
        }

        if (velocity.sqrMagnitude > sqrMaxVelocity)
        {
            rb.velocity = velocity.normalized * maxVelocity;
        }
        else {
            rb.velocity = velocity;
        }

    }

    void updateThrust(float val) {
        thrust += val;

        if (thrust < 0f)
        {
            thrust = 0f;
        }
        else if (thrust > 1f) {
            thrust = 1.0f;
        }
        thrustMeter.setValue(thrust);
    }
}
