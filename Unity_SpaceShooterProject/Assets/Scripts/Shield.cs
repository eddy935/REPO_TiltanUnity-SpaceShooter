using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shield : MonoBehaviour
{

    private GameObject player;
    private bool isPickedUp = false;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isPickedUp)
            {
                Debug.Log("BOOM!!!!!!!!!!!!!!!!!!");
                Pickup(other);
            }

            Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAA");
        }
        if(other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        isPickedUp = true;
    }
    void Pickup(Collider player)
    {
        //Instantiate(//effect, transform.position, transform.rotation)
        GetComponent<MeshRenderer>().enabled = false;
        AddShield(player);
        
    }

    void AddShield(Collider player)
    {
        gameObject.GetComponent<Collider>().transform.SetParent(player.transform);
        gameObject.transform.localPosition = new Vector3(0, 0, 0);
        gameObject.transform.localScale = new Vector3(2, 2, 2);
    }
}
