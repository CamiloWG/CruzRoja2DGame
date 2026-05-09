using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObjects : MonoBehaviour
{
    private GameObject currentObject = null;
    public Transform objectPos;
    private PlayerMovementGrimm player;    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMovementGrimm>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!currentObject && other.CompareTag("carryableObject"))
        {
            currentObject = other.gameObject;
            other.transform.SetParent(objectPos);
            other.transform.localPosition = Vector3.zero;
            other.transform.localRotation = Quaternion.identity;
            player.carrying = true;
        }
    }
}


public enum TYPE_OBJECTS
{
    Moneda,
    Celular,
    Bandeja,
    Botiquin,
    Rollo
}
