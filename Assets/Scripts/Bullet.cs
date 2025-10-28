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


        if(ShootingBullet == "Square1" || ShootingBullet == "Square2")
        {
            Destroy(gameObject);
        }

        if(collide.gameObject.GetComponent<Enemy>() != null){
            //Destroy(collide.gameObject);
            Destroy(gameObject);
        }
    }
}
