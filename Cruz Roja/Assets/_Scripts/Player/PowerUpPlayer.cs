using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("powerupObject"))
        {
            Debug.Log("test");
            Destroy(other.gameObject, 0.3f);
        }
    }
}


public enum POWERUPS_TYPE
{
    Cafe,
    Drop,
    Guantes
}
