using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupController : MonoBehaviour
{
    public static HealthPickupController instance;

    public HealthPickup healthPickup;

    private void Awake()
    {
        instance = this;
    }


    public void AddHealth(int healthToAdd)
    {
        PlayerController.instance.GetComponent<PlayerHealthController>().UpdateHealth(healthToAdd);
    }

    public void DropHealthPickup(Vector3 position, int value)
    {
        HealthPickup health = Instantiate(healthPickup, position + new Vector3(0.3f, 0.2f, 0f), Quaternion.identity);

        health.healthAmount = value;
        health.gameObject.SetActive(true);
    }
}
