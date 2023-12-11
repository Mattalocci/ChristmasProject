using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class weaponShoot : MonoBehaviour
{
    public float speed = 20f;

    public GameObject weaponMesh;
    public GameObject projectileInstance;
    public Transform firepoint;

    void OnFire(InputValue input)
    {
        bool value = input.isPressed;
        if (value)
        {
            GameObject projectile = Instantiate(projectileInstance);
            projectile.transform.position = firepoint.position;
            projectile.transform.rotation = firepoint.rotation;

           
            Vector2 direction = firepoint.right;
            direction = (Vector2)firepoint.position - (Vector2)transform.position;
            direction.Normalize();

            projectile.GetComponent<Hitbox>().Init(direction, speed);
            

        }
    }

  
}
