using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcsController : MonoBehaviour
{
    [SerializeField] private TYPE_OBJECTS objectNeeded;
    [SerializeField] private float tiempoDeDesvanecimiento = 1.5f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            CarryObjects jugador = collision.GetComponent<CarryObjects>();            
            if(jugador.GetCurrentObject() == objectNeeded)
            {
                StartCoroutine(DestroyNpc(gameObject));
                jugador.TakeOffObject();
            }
        }
    }


    private IEnumerator DestroyNpc(GameObject objeto)
    {
        SpriteRenderer spriteRenderer = objeto.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            Color colorInicial = spriteRenderer.color;
            
            Color colorDestino = new Color(0f, 0f, 0f, colorInicial.a); 
            float tiempoTranscurrido = 0f;

            while (tiempoTranscurrido < tiempoDeDesvanecimiento)
            {
                tiempoTranscurrido += Time.deltaTime;
                float porcentaje = tiempoTranscurrido / tiempoDeDesvanecimiento;
                
                spriteRenderer.color = Color.Lerp(colorInicial, colorDestino, porcentaje);
                
                yield return null; 
            }
        }

        Destroy(objeto);
    }
}
