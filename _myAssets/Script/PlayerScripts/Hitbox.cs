using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [Header("Settings")]
    public int damage = 1;
    public float lifespan;

    [Header("Elements")]
    public GameObject impactPrefab;

    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void Init(Vector2 direction, float speed)
    {
      rigidbody.velocity = direction * speed;
        Invoke("DestroyHitBox", lifespan);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().Damage(damage);

        }
        CreateImpact(other.ClosestPoint(transform.position));
        DestroyHitBox();
        
    }

    void CreateImpact(Vector3 hitpoint)
    {
        GameObject impact = Instantiate(impactPrefab);
        impact.transform.position = hitpoint;
        impact.transform.rotation = Quaternion.identity;

        

    }

    void DestroyHitBox()
    {
        CancelInvoke("DestroyHitBox");
        Destroy(gameObject);
    }

}
