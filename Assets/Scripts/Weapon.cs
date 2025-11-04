using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    private float fireTimer;
    [Range(0.1f, 2f)]
    [SerializeField] private float fireRate = 0.5f;

    void Update()
    {
        if(!PauseMenu.isPaused && !GameOver.isOver){
            if(Input.GetButtonDown("Fire1") && fireTimer <= 0f){
                Shoot();
                fireTimer = fireRate;
            } else {
                fireTimer -= Time.deltaTime;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
