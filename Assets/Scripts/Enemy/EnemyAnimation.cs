using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Transform sprite;

    public float speed;

    public float minSize;
    public float maxSize;

    private float activeSize;

    private void Start()
    {
        activeSize = maxSize;

        speed = speed * Random.Range(0.75f, 1.25f);
    }

    private void Update()
    {
        sprite.localScale = Vector3.MoveTowards(sprite.localScale, Vector3.one * activeSize, speed * Time.deltaTime);

        if(sprite.localScale.x == activeSize)
        {
            if (activeSize == maxSize)
            {
                activeSize = minSize;
            }
            else
            {
                activeSize = maxSize;
            }
        }

    }

}
