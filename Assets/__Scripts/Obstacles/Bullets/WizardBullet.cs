using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class WizardBullet : MonoBehaviour
{

    [SerializeField] private float bulletSpeed = 20.0f;
    [SerializeField] private float bulletLife = 2f;
    [SerializeField] private int attackDamage = 40;

    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, bulletLife);
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, bulletSpeed * Time.deltaTime);
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
