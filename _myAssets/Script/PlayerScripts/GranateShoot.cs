using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GranateShoot : MonoBehaviour
{
    public float speed = 20f;
    public int granadesLeft = 3;
    public Transform launchPoint;
    public GameObject granadePrefab;

    void OnGranade(InputValue input)
    {
        bool value = input.isPressed;

        if (value && granadesLeft > 0)
        {
            granadesLeft--;
            GameObject projectile = Instantiate(granadePrefab);
            projectile.transform.position = launchPoint.position;
            projectile.transform.rotation = launchPoint.rotation;


            Vector2 direction = launchPoint.right;
            direction = (Vector2)launchPoint.position - (Vector2)transform.position;
            direction.Normalize();

            projectile.GetComponent<Hitbox>().Init(direction, speed);

        }
    }
}
