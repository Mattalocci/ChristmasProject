using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Lifeform
{

  
    public HUD hud;
    public float invulnerabilityTime = 1f;

    private PlayerAim aim;
    // private PlayerEquip equip;
    private PlayerLocomotions locomotion;
    protected override void Awake()
    {
        base.Awake();
        //equip = GetComponent<PlayerEquip>();
        aim = GetComponent<PlayerAim>();
        locomotion = GetComponent<PlayerLocomotions>();
    }

    protected override void Start()
    {
        base.Start();
        hud.UpdateLifepoint(currentHp, hp);
    }

    public void UnlockPlayer()
    {
        //equip.enabled = true;
        aim.enabled = true;
        locomotion.enabled = true;
    }
    public void LockPlayer()
    {
        //equip.enabled = false;
        aim.enabled = false;
        locomotion.enabled = false;
    }

    public override void UpdateLifepoint(int value)
    {
        base.UpdateLifepoint(value);
        hud.UpdateLifepoint(currentHp, hp);

    }

    public override void Damage(int value)
    {
        if(gameObject.layer != LayerMask.NameToLayer("Invincible"))
            base.Damage(value);
        if (currentHp > 0)
            StartCoroutine(Invulnerable());
        Debug.Log(currentHp);
    }
    public override void Death()
    {
        LockPlayer();
        base.Death();

        GameController.instance.GameOver();
    }

    public IEnumerator Invulnerable()
    {
        gameObject.layer = LayerMask.NameToLayer("Invincible");
        yield return new WaitForSeconds(invulnerabilityTime);
        gameObject.layer = originalLayerMask;

    }
}

