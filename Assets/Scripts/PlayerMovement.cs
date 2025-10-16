using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private bool jumped;
    private float xPosLastFrame;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D> ();
    }

    private void Update(){
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed,body.velocity.y);
        FlipCharacterX();

        

        if(Input.GetKey(KeyCode.Space) && jumped == true){
            jumped = false;
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }
    }

    private bool OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision.gameObject.name);
        jumped = true;
        return jumped;
    }

    private void FlipCharacterX()
    {
        float input = Input.GetAxis("Horizontal");
        //Rechts
        if(input > 0 && (transform.position.x > xPosLastFrame)){
            spriteRenderer.flipX = false;
        //Links
        }else if(input < 0 && (transform.position.x < xPosLastFrame)){
            spriteRenderer.flipX = true;
        }

        xPosLastFrame = transform.position.x;
    }

} 