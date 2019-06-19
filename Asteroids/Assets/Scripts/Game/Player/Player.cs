using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float movementSpeed = 10f; // Movement in units
    public float rotationSpeed = 360f; // Rotation
    private Rigidbody2D rigid; // Reference to rigidbody

    // Use this for initialization
    void Start()
    {
        // Get reference to rigidbody
        rigid = GetComponent<Rigidbody2D>();

    }

    void Control()
    {
        //float inputV = Input.GetAxis("Vertical");
        //rigid.AddForce(inputV * transform.up * movementSpeed);

        // if the Up key is pressed
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Add a force up
            rigid.AddForce(transform.up * movementSpeed);
        }

        // if the Down key is pressed
        // Add a force down

        // if the lewft key is pressed
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Rotate counter-clockwise per second
            rigid.rotation += rotationSpeed * Time.deltaTime;

        }

        // If the Right key is pressed
        // Rotate counter-clockwise per second


    }

    // Update is called once per frame
    void Update()
    {
        Control();
    }
}
