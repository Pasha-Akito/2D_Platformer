using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private SoundController sc;
    [SerializeField] AudioClip PlayerDeath;

    private Rigidbody2D rb;
    [SerializeField] public Transform spawnPoint;
    [SerializeField] private int startHealth = 1;
    [SerializeField] private ParticleSystem effectPrefab;

    private int currentHealth;
    private bool isDead = false;

    void Start()
    {
        currentHealth = startHealth;
        rb = GetComponent<Rigidbody2D>();
        sc = FindObjectOfType<SoundController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Takedamage(10);
        }

        if (isDead && Input.GetKeyDown(KeyCode.R))
        {
            rb.transform.position = spawnPoint.position;
            currentHealth = startHealth;
            Movement move = GetComponent<Movement>();
            move.enabled = true;
            sc.StopOneShot(PlayerDeath);

            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            sr.enabled = true;

            isDead = false;

            SceneManager.UnloadSceneAsync("Game Over");

        }
    }


    public void Takedamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }

    }

    private void Die()
    {
        Debug.Log("Player died");
        isDead = true;

        sc.PlayOneShot(PlayerDeath);

        ParticleSystem ps = Instantiate(effectPrefab, rb.transform);
        Destroy(ps, 2.0f);

        SceneManager.LoadScene("Game Over", LoadSceneMode.Additive);

       
        Movement move = GetComponent<Movement>();
        move.enabled = false;

        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }
}
