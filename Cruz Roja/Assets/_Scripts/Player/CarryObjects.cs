using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObjects : MonoBehaviour
{
    private GameObject currentObject = null;
    public Transform objectPos;
    private PlayerMovementGrimm player;    
    private PlayerInfo pInfo;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMovementGrimm>();
        pInfo = GetComponent<PlayerInfo>();
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

    public void TakeOffObject()
    {
        Destroy(currentObject);
        currentObject = null;
        player.carrying = false;
        pInfo.AddPoints(1);
    }

    public TYPE_OBJECTS? GetCurrentObject()
    {
        return currentObject ? currentObject.GetComponent<carryableObjects>().tipo : null;
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
