using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifeform : MonoBehaviour
{
    public int hp;

    [Header("audio")]
    public AudioClip hurtAudio;
    public AudioClip deathAudio;

    protected Rigidbody rigidbody;
    protected AudioSource audioSource;
    protected int currentHp;
    protected LayerMask originalLayerMask;


    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    protected virtual void Start()
    {
        originalLayerMask = gameObject.layer;
        currentHp = hp;
    }
    public virtual void UpdateLifepoint(int value)
    {
        currentHp += value;

    }



    public virtual void Damage(int value)
    {
        UpdateLifepoint(-value);
        if (currentHp > 0)
        {
            audioSource.clip = hurtAudio;
            audioSource.Play();
            
        }
        else
        {
            Death();    
        }
    }


    public virtual void Death()
    {
        gameObject.layer = LayerMask.NameToLayer("Invincible");
        
        audioSource.clip = deathAudio;
        audioSource.Play();
       

        Destroy(gameObject, 2f);
    }
}
