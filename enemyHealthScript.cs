using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealthScript : MonoBehaviour
{
    public int Health;

    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void damage( int amount)
    {
        Health -= amount;
    }
}
