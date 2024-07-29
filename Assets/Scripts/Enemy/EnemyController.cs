using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;
    private Transform target;

    public float damage;

    public float hitWaitTime = 1f;
    private float hitCounter;

    public float health = 5f;

    public float knockBackTime = 0.5f;
    private float knockBackCounter;

    public int expToGive = 1;

    public int coinValue = 1;
    public float coinDropRate = 0.5f;

    public int healthValueToPick = 2;
    public float healthDropRate = 0.2f;

    private void Start()
    {
        target = PlayerHealthController.instance.transform;
    }

    private void Update()
    {
        if (PlayerController.instance.gameObject.activeSelf)
        {
            if (knockBackCounter > 0f)
            {
                knockBackCounter -= Time.deltaTime;

                if (moveSpeed > 0)
                {
                    moveSpeed = -moveSpeed * 2f;
                }

                if (knockBackCounter <= 0f)
                {
                    moveSpeed = Mathf.Abs(moveSpeed * 0.5f);
                }

            }

            theRB.velocity = (target.position - transform.position).normalized * moveSpeed;

            if (hitCounter > 0f)
            {
                hitCounter -= Time.deltaTime;
            }
        }
        else
        {
            theRB.velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && hitCounter <= 0f)
        {
            PlayerHealthController.instance.UpdateHealth(-damage);

            hitCounter = hitWaitTime;
        }
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if(health <= 0f)
        {
            Destroy(gameObject);

            ExperienceLevelController.instance.SpawnExp(transform.position, expToGive);

            if(Random.value <= coinDropRate)
            {
                CoinController.instance.DropCoin(transform.position, coinValue);
            }
            if(Random.value <= healthDropRate)
            {
                HealthPickupController.instance.DropHealthPickup(transform.position, healthValueToPick);
            }
        }

        DamageNumberController.instance.SpawnDamage(damageToTake, transform.position);
    }

    public void TakeDamage(float damageToTake, bool shouldKnockBack)
    {
        TakeDamage(damageToTake);

        if(shouldKnockBack)
        {
            knockBackCounter = knockBackTime;
        }
    }

}
