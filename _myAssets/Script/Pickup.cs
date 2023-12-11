using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Vector2 position;
    public float rotation;
    public GameObject hitboxPrefab;
    public GameObject weaponGrahpic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerEquip>().UpdateWeapon(hitboxPrefab, weaponGrahpic, position, rotation);
            DestroyPickup();
        }
    }


    void DestroyPickup()
    {
        Destroy(gameObject);
    }
}
