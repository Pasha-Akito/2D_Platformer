using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletUp : MonoBehaviour
{

    [SerializeField] private float bulletSpeed = 20.0f;
    [SerializeField] private float bulletLife = 2f;
    [SerializeField] private int attackDamage = 40;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, bulletLife);
    }
    void Update()
    {
        rb.velocity = new Vector2(0.0f, bulletSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.Takedamage(attackDamage);
        }
        Destroy(gameObject);
    }
}
