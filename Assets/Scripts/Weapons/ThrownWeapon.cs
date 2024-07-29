using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownWeapon : MonoBehaviour
{
    public float throwPower;
    public Rigidbody2D theRB;
    public float rotateSpeed;

    private void Start()
    {
        theRB.velocity = new Vector2(Random.Range(-throwPower, throwPower), throwPower);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0f,0f, transform.rotation.eulerAngles.z + (rotateSpeed * 360f * Time.deltaTime * Mathf.Sign(theRB.velocity.x)));
    }

}
