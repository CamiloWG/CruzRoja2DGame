using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionController : MonoBehaviour
{
    [Header("Referencias de UI")]
    [SerializeField] private GameObject canvasTransicion;
    [SerializeField] private Animator busAnimator; 
    [SerializeField] private Transform posMedellin;

    private void Awake() {
        canvasTransicion.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvasTransicion.SetActive(true);
            busAnimator.SetBool("transicionNivel", true);
            StartCoroutine(Transicion(collision.gameObject));
        }
    }

    private IEnumerator Transicion(GameObject player)
    {        
        player.transform.position = posMedellin.position;        
        yield return new WaitForSeconds(5f);
        canvasTransicion.SetActive(false);
        Destroy(gameObject);        
    }

}
