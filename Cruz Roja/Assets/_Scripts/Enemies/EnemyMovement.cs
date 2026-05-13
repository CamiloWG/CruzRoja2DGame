using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Puntos de patrulla")]
    public Transform startPoint;
    public Transform endPoint;

    [Header("Configuración")]
    public float speed = 2f;
    public float waitTime = 1f;

    [Header("Referencias de Colliders")]
    [SerializeField] private Collider2D colliderCuerpo; 
    [SerializeField] private Collider2D colliderCabeza; 

    [Header("Ajustes de Rebote")]
    [SerializeField] private float fuerzaRebote = 12f; 

    private Vector3 target;
    private bool waiting = false;
    private SpriteRenderer sprite;
    private Animator anim;

    private bool isDead = false;
    private Collider2D col;

    void Start()
    {
        target = endPoint.position;
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (waiting || isDead)
        {
            if(!isDead) anim.SetFloat("movX", 0);
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );

        if (Vector2.Distance(transform.position, target) < 0.05f)
        {
            StartCoroutine(ChangeTarget());
        }

        Flip();
    }

    System.Collections.IEnumerator ChangeTarget()
    {
        waiting = true;

        yield return new WaitForSeconds(waitTime);

        target = (target == startPoint.position) ? endPoint.position : startPoint.position;

        waiting = false;
    }

    void Flip()
    {
        if (sprite == null) return;

        if (target.x > transform.position.x)
        {
            sprite.flipX = true;
            anim.SetFloat("movX", 1);
        }
        else
        {
            sprite.flipX = false;
            anim.SetFloat("movX", 1);
        }   
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;
        if(collision.CompareTag("Player"))
        {
            if (colliderCabeza.IsTouching(collision))
            {
                isDead = true;
                Rigidbody2D rbJugador = collision.GetComponent<Rigidbody2D>();

                rbJugador.velocity = new Vector2(rbJugador.velocity.x, 0f);
                rbJugador.AddForce(Vector2.up * fuerzaRebote, ForceMode2D.Impulse);

                Destroy(gameObject);
            }
            else if (colliderCuerpo.IsTouching(collision))
            {
                collision.gameObject.GetComponent<PlayerInfo>().SetPlayerDeath(0.5f);
            }        
        }
    }


    public void AttackEnemy()
    {
        if (isDead) return;
        //AudioController.instance.PlayGolpe();
        StartCoroutine(DeathRoutine());
    }


    System.Collections.IEnumerator DeathRoutine()
    {
        isDead = true;

        col.enabled = false;

        anim.SetTrigger("foxDeath");

        yield return new WaitForSeconds(5f);

        anim.SetTrigger("foxReanim");

        yield return new WaitForSeconds(0.5f);

        col.enabled = true;
        isDead = false;
    }

    


}
