using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMeleeScript : MonoBehaviour
{
    private float attackDuration;
    public float attackTime;

    public Transform attackPos;
    public float attackRange;
    public LayerMask enemy;

    void Start()
    {
        attackDuration = attackTime;
    }

    void Update()
    {
        if (attackDuration <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            //attack
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);

            for (int i = 0; i < enemies.Length; i++) {
                //attack enemies
            }

            attackDuration = attackTime;
        }
        else {
            attackDuration -= Time.deltaTime;
        }
    }
}
