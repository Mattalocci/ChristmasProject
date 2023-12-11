using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocomotion : MonoBehaviour
{
    [Header("Wandering Settings")]
    public float walkingSpeed = 1f;
    public float walkingStoppingDistance = 0;
    public LayerMask obstaclesLayermask;

    
    private Vector2 lastWallCollision;
    private bool facingRight = false;
    private Rigidbody rigidbody;
    private float Xdirection = 1f;

    private float minimumStoppingDistance = 0.3f;

    private void Awake()
    {
       rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector3(Xdirection * walkingSpeed, rigidbody.velocity.y, 0);
    }

   
    void WalkDirection()
    {
        if (facingRight)
            gameObject.transform.rotation = Quaternion.Euler(0,180,0);
        else
            gameObject.transform.rotation = Quaternion.Euler(0,0,0);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Xdirection *= -1f;
            lastWallCollision = collision.transform.position;
            facingRight = !facingRight;
            WalkDirection();
        }
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerController>().Damage(1);
                
            }
        }

    }



}
