using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;
    public int jumpforce;
    public Animator anim;
    public Collider2D coll;
    public LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Movement();
        }
    // Update is called once per frame
    void Update()
    {
        Movement();
        SwitchAnim();
    }
    void Movement()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float facedirection = Input.GetAxisRaw("Horizontal");
        if (horizontalMove != 0)
        {
            rb.velocity = new Vector2(horizontalMove * speed * Time.deltaTime , rb.velocity.y);
            anim.SetFloat("running", Mathf.Abs(facedirection));//È¡¾ø¶ÔÖµ
        }
        if (facedirection != 0)
        {
            transform.localScale = new Vector3(facedirection, 1, 1);
        }
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.deltaTime);
            anim.SetBool("jumping",true);

        }
        
    }
    void SwitchAnim()
    {
        if (anim.GetBool("jumping"))
        {
            anim.SetBool("idle", false);
            if (rb.velocity.y < 0)
            {
                anim.SetBool("jumping", false);
                anim.SetBool("falling", true);
            }
        }
        else if(coll.IsTouchingLayers(ground))
        {
            anim.SetBool("falling", false);
            anim.SetBool("idle", true);
        }
      
    }
}
