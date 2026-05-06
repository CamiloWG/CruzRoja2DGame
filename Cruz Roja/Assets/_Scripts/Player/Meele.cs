using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meele : MonoBehaviour
{
    public Transform posGolpe;
    public float radioGolpe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackMeele()
    {
        Vector2 vectorGolpe = new Vector2(posGolpe.position.x, posGolpe.position.y);
        Collider2D[] objs = Physics2D.OverlapCircleAll(vectorGolpe, radioGolpe);
        
        foreach (Collider2D item in objs)
        {
            if (item.CompareTag("Enemy"))            {
                //item.gameObject.GetComponent<EnemyMovement>().AttackEnemy();
            }
        }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(posGolpe.position, radioGolpe);
    }
}
