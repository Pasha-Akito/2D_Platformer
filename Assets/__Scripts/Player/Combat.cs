using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{


    [SerializeField] private Transform attackPoint;
    [SerializeField] LayerMask enemyLayer;

    [SerializeField] private float attackRange = 1f;
    [SerializeField] private int attackDamage = 40;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Attack();
        }


    }

    private void Attack()
    {


        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        // Damage them
        foreach(Collider2D enemy in hitEnemies)
        {

            enemy.GetComponent<Enemy>().Takedamage(attackDamage);
        }


    }

    private void OnDrawGizmosSelected()
    {

        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


}
