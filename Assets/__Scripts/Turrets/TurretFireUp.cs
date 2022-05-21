using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFireUp : MonoBehaviour
{
    [SerializeField] private BulletUp bulletprefab;
    [SerializeField] private float firingRate = 1.0f;

    private GameObject bulletParent;
    private Coroutine firingCoroutine;

    private void Start()
    {
        bulletParent = GameObject.Find("BulletParent");
        if (!bulletParent)
        {
            bulletParent = new GameObject("BulletParent");
        }
        Fire();
    }
    private void Update()
    {

    }

    private void Fire()
    {
        firingCoroutine = StartCoroutine(FireCoroutine());
    }

    private IEnumerator FireCoroutine()
    {
        while (true)
        {
            FireBullet();
            yield return new WaitForSeconds(firingRate);
        }
    }

    private void FireBullet()
    {
        BulletUp b = Instantiate(bulletprefab, bulletParent.transform);
        b.transform.position = gameObject.transform.position;
    }
}
