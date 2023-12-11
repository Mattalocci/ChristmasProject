using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Campi di mira")]
    public Transform aimPoint;
 


    public float rotationSpeed;





    private Vector2 aimDirection;
    private Vector3 direction;


    private void LateUpdate()
    {
        aimPoint.rotation = Quaternion.Slerp(aimPoint.rotation, Quaternion.Euler(direction), rotationSpeed * Time.deltaTime);
        
    }

    void OnMove(InputValue input)
    {

        Vector2 value = input.Get<Vector2>();
        aimDirection = value;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        direction = new Vector3(0, 0, angle);
    }



}
