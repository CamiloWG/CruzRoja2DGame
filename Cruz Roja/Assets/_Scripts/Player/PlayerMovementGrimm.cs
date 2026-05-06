using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementGrimm : MonoBehaviour
{

    private Rigidbody2D _rd;
    private NewInputGrimm _newInput;
    public Animator anim;
    public PlayerInfo pInfo;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        _rd = GetComponent<Rigidbody2D>();
        _newInput = GetComponent<NewInputGrimm>();
        pInfo = GetComponent<PlayerInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Move();
    }
    //Metodo para moverse
    public void Move()
    {
        if(!pInfo.isAlive) return;
        _rd.velocity = new Vector2(_newInput.inputX * speed, _rd.velocity.y);
        Flip();
    }

    public void Flip()
    {
        if(_newInput.inputX > 0)
        {            
            transform.rotation = Quaternion.Euler(0, 0, 0);
            SetAnimVal(1);
        } else if( _newInput.inputX < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            SetAnimVal(1);
        } else SetAnimVal(0);
    }


    private void SetAnimVal(float n)
    {
        anim.SetFloat("movX", n);
    }
}
