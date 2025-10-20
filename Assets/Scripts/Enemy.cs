using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    public float speed;
    //private SpriteRenderer spriteRenderer;

    private float distance;
    private bool stopMoving = false;
    

    void Update()
    {
        if(stopMoving != true){
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;

            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var EnemyCharacter = collision.gameObject.name;

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
}
