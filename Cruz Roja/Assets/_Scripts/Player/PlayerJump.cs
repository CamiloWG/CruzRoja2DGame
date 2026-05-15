using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rd;
    public float jumpForce;
    public Animator anim;
    public Animator hudAnim;


    // Start is called before the first frame update
    void Start()
    {
        _rd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Mathf.Abs(_rd.velocity.y) < 0.05) 
        {
            anim.SetBool("Jumping", false);  
            hudAnim.SetBool("isJumping", false);
        } 
    }
    // Metodo que permita saltar al personaje
    public void Jump()
    {
        if (Mathf.Abs(_rd.velocity.y) < 0.01)
        {
            _rd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);            
            anim.SetBool("Jumping", true);
            hudAnim.SetBool("isJumping", true);
            AudioController.instance.PlayJump();
        } 
    }
}
