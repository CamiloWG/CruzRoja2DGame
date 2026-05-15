using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public bool isAlive = true;
    public int puntaje = 0;
    public bool female = false;

    private int playerLife = 3;
    private bool playerDamage = false;
    public Animator[] heartsAnim;

    public Animator pAnim;
    public Animator hudAnim;

    private int capaJugador;
    private int capaInvulnerable;

    void Start()
    {
        capaJugador = LayerMask.NameToLayer("Player");
        capaInvulnerable = LayerMask.NameToLayer("PlayerDamaged");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerDeath(float distance, bool buryPlayer = false)
    {
        if (!isAlive || playerDamage) return;   
        gameObject.layer = capaInvulnerable; 
        if(playerLife > 1)
        {
            hudAnim.SetTrigger("playerDamage");
            heartsAnim[playerLife-1].SetBool("playerDamage", true);
            playerDamage = true;
            playerLife--;
            StartCoroutine(restartDamage());
            pAnim.SetBool("playerDamage", true);
            return;
        }

        heartsAnim[0].SetBool("playerDamage", true);
        hudAnim.SetFloat("playerState", 3f);
        isAlive = false;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 5f);

        GetComponent<Animator>().SetTrigger("playerDeath");

        //AudioController.instance.PlayDeath(this);
        
        if(buryPlayer) StartCoroutine(BajarJugador(transform, rb, distance));
    }

    private IEnumerator BajarJugador(Transform playerTransform, Rigidbody2D rb, float distance)
    {
        Vector3 destino = playerTransform.position + new Vector3(0, -distance, 0);
        rb.bodyType = RigidbodyType2D.Static;
        while (Vector3.Distance(playerTransform.position, destino) > 0.01f)
        {
            playerTransform.position = Vector3.MoveTowards(playerTransform.position, destino, 3f * Time.deltaTime);
            yield return null;
        }


    }

    private IEnumerator restartDamage()
    {
        yield return new WaitForSeconds(3f);
        pAnim.SetBool("playerDamage", false);
        gameObject.layer = capaJugador;
        playerDamage = false;
    }

    public void AddPoints(int points)
    {
        puntaje += points;
    }
}
