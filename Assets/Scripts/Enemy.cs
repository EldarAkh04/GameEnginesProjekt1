using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    public float speed;
    public bool flip = true;

    public int maxHealth = 40;
    public int currentHealth;
    public EnemyHealthBar healthBar;

    private float distance;
    private bool stopMoving = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    

    void Update()
    {
        if(stopMoving != true){
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        FlipCharacterX();
    }


    void OnTriggerEnter2D(Collider2D collide)
    {
        var Enemy = collide.gameObject.name;

        if(Enemy == "Bullet(Clone)"){
            TakeDamage(20);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var EnemyCharacter = collision.gameObject.name;
        Debug.Log(collision.gameObject.name);

        /* if(collision.gameObject.GetComponent<Bullet>() != null){
            TakeDamage(20);
        } */
        if(EnemyCharacter == "Player"){
            stopMoving = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        var EnemyCharacter = collision.gameObject.name;

        if(EnemyCharacter == "Player"){
            stopMoving = false;
        }
    } 

    private void FlipCharacterX()
    {
        Vector3 scale = transform.localScale;

        if(player.transform.position.x > transform.position.x){
            scale.x = Mathf.Abs(scale.x) * 1 * (flip ? -1 : 1);
            //transform .Translate(speed * Time.deltaTime, transform.position.y, transform.position.z);
        } else {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
            //transform.Translate(speed * Time.deltaTime * -1, transform.position.y, transform.position.z);
        }

        transform. localScale = scale;
    }

    void TakeDamage(int damage)
    {
         currentHealth -= damage;
         healthBar.SetHealth(currentHealth);

         if(currentHealth <= 0){
            Destroy(gameObject);
        }
    }
}
