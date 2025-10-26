using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    public float speed;
    public bool flip = true;
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
        FlipCharacterX();
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

    private void FlipCharacterX()
{
    float moveAxis = Input.GetAxis("Horizontal"); // Unused line
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
}
