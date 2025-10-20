using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private bool jumped;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;

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

    private void OnCollisionEnter2D(Collision2D collision){
        //Debug.Log(collision.gameObject.name);
        jumped = true;
    }

    private void FlipCharacterX()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(x) > 0.01f)
            transform.rotation = Quaternion.Euler(0f, x > 0f ? 0f : 180f, 0f);

    }

} 