using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    private Transform player;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] private float speed;
    [SerializeField] private float retreatDistance;
    
    private float timeBetweenShots;
    [SerializeField] private float startTimeBetweenShots;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBetweenShots = startTimeBetweenShots;
    }

    private void Update()
    {


        if (timeBetweenShots <= 0)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }


    }


}
