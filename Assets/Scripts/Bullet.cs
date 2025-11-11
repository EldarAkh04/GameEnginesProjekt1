using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float bulletSpeed = 20f;
    public Rigidbody2D rb;
    

    void Start()
    {
          rb.velocity = transform.right * bulletSpeed;
    }

    void Awake() 
    { 
        rb = GetComponent<Rigidbody2D>(); 
    }



    void OnTriggerEnter2D(Collider2D collide)
    {
        var ShootingBullet = collide.gameObject.name;
        //Debug.Log(ShootingBullet);


        if (ShootingBullet == "Square1" || ShootingBullet == "Square2")
        {
            Destroy(gameObject);
        }

        if (collide.gameObject.GetComponentInParent<Enemy>() != null)
        {
            // Finde den Gegner (das Parent-Objekt, das das Enemy-Skript hält)
            Enemy enemy = collide.gameObject.GetComponentInParent<Enemy>();
            
            // Verursache Schaden im Enemy-Skript
            // (Wir gehen davon aus, dass Enemy.cs eine TakeDamage-Funktion hat)
            // enemy.TakeDamage(20); 
            
            // Zerstöre das Geschoss
            Destroy(gameObject); 
        }
    }

    /* void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name.Contains("Enemy(clone)")){
            //Destroy(collide.gameObject);
            Destroy(gameObject);
        }
    } */
}
