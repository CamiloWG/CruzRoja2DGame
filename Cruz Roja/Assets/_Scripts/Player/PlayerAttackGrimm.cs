using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackGrimm : MonoBehaviour
{
    public Animator anim;
    public float attackCooldown = 3f;
    float lastAttackTime = 0f;
    Meele ataqueCuerpo;
    //playerShoot pShoot;


    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Meele>(out ataqueCuerpo);
        //TryGetComponent<playerShoot>(out pShoot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if(context.performed && Time.time > lastAttackTime + attackCooldown)
        {
            anim.ResetTrigger("playerAttack");
            anim.SetTrigger("playerAttack");   
            if(ataqueCuerpo) ataqueCuerpo.AttackMeele();
            //if(pShoot) pShoot.Shoot();
            lastAttackTime = Time.time;
        }
    }
}
