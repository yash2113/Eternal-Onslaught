using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseAttackWeapon : Weapon
{
    public EnemyDamager damager;

    private float attackCounter;
    private float direction;

    private void Start()
    {
        SetStats();
    }

    private void Update()
    {
        if(statsUpdated)
        {
            statsUpdated = false;

            SetStats();
        }

        attackCounter -= Time.deltaTime;
        if (attackCounter <= 0)
        {
            attackCounter = stats[weaponLevel].timeBetweenAttacks;

            direction = Input.GetAxisRaw("Horizontal");

            if (direction != 0)
            {
                if (direction > 0)
                {
                    damager.transform.rotation = Quaternion.identity;
                }
                else
                {
                    damager.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                }
            }
            Instantiate(damager, damager.transform.position, damager.transform.rotation, transform).gameObject.SetActive(true);

            for (int i = 1; i < stats[weaponLevel].amount; i++)
            {
                float rot = (360f / stats[weaponLevel].amount) * i;

                Instantiate(damager, damager.transform.position, Quaternion.Euler(0f, 0f, damager.transform.rotation.eulerAngles.z + rot), transform).gameObject.SetActive(true);
            }
        }
    }


    private void SetStats()
    {
        damager.damageAmount = stats[weaponLevel].damage;
        damager.lifeTime = stats[weaponLevel].duration;

        damager.transform.localScale = Vector3.one * stats[weaponLevel].range;

        attackCounter = 0f;

    }

}
