using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLocomotions : MonoBehaviour
{
    [Header("valori giocatore")]
    public float speed;
    public float jumpSpeed;


    [Header("Ground")]
    public LayerMask layerground;
    public float groundDistance;
    public float gravityMultiplier = 1.5f;
    public bool airMovement = true;

   
    private bool isJumping;
    private bool isGrounded = false;
    private Rigidbody rigidbody;
    private Vector2 direction;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
    
        Gizmos.DrawWireSphere(transform.position, groundDistance); //da cambiare appena il modello ha il pivot in basso

    }

    private void Start()
    {
       
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
    
      isGrounded = Physics.CheckSphere(transform.position, groundDistance, layerground);


        if (isGrounded|| airMovement)
        {
            Vector3 velocity = direction * speed;
            velocity.y = rigidbody.velocity.y;
            rigidbody.velocity = velocity;
        }
        if (rigidbody.velocity.y < 0)
        {
            rigidbody.velocity += Vector3.up * Physics.gravity.y * gravityMultiplier * Time.fixedDeltaTime;
        }
        else if (rigidbody.velocity.y > 0 && isJumping == false)
        {
            rigidbody.velocity += Vector3.up * Physics.gravity.y * gravityMultiplier * Time.fixedDeltaTime;

        }
    }

    private void OnDisable()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.Sleep();
    }


    void OnJump(InputValue input)
    {
      isJumping = input.isPressed;


        if (isJumping && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);

        }

    }

    void OnMove(InputValue input)
    {
        Vector2 value = input.Get<Vector2>();
        direction = value;
        direction.y = 0;
       
    }

   
}
