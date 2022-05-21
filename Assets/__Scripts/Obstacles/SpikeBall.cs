using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float speed = 600.0f;
    [SerializeField] private int attackDamage = 40; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Random.insideUnitSphere * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player)
        {
            player.Takedamage(attackDamage);
        }
    }
}
