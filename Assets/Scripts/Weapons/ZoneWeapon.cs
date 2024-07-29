using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneWeapon : Weapon
{
    public EnemyDamager damager;

    private float spawnTime;
    private float spawnCounter;

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

        spawnCounter -= Time.deltaTime;
        if(spawnCounter <= 0f)
        {
            spawnCounter = spawnTime;

            EnemyDamager newZone = Instantiate(damager, damager.transform.position, Quaternion.identity, transform);
            newZone.gameObject.transform.localScale = Vector3.one * 0.5f;    
            newZone.gameObject.SetActive(true);
        }

    }

    private void SetStats()
    {
        damager.damageAmount = stats[weaponLevel].damage;

        damager.lifeTime = stats[weaponLevel].duration;

        damager.timeBetweenDamage = stats[weaponLevel].speed;

        damager.transform.localScale = Vector3.one * stats[weaponLevel].range;

        spawnTime = stats[weaponLevel].timeBetweenAttacks;

        spawnCounter = 0f;
    }

}
