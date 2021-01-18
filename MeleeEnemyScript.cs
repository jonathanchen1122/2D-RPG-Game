using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyScript : MonoBehaviour
{
    public float speed;
    public float bounds;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x <= -bounds)
        { // on the left
            speed *= -1;  
        }

        if (transform.position.x >= bounds)
        { // on the Right
            speed *= -1;
        }
    }
}
