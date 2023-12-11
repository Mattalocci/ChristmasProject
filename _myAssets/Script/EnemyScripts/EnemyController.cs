using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Lifeform
{
    public List<PlayerController> PlayerList = new List<PlayerController>();
    private EnemyLocomotion locomotion;
    //private EnemyAttack attack;

    protected override void Awake()
    {
        base.Awake();
        locomotion = GetComponent<EnemyLocomotion>();
       // attack = GetComponent<EnemyAttack>();
    
    }

    public void LockEnemy()
    {
        locomotion.enabled = false;
        //attack.enabled = false;
    }
    public void UnlockEnemy()
    {
        locomotion.enabled = true;
        //attack.enabled = true;
    }

    public override void Death()
    {
        LockEnemy();
        base.Death();

        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;

    }

    public PlayerController GetNearestPlayerInRange(float range)
    {
        PlayerController result = null;

        if (PlayerList.Count <= 0)
            return null;

        float nearest = Mathf.Infinity;

        foreach (PlayerController player in PlayerList)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if ((distance < nearest) && (distance <= range))
            {
                result = player;
                nearest = distance;
            }

        }


        return result;
    }

}
