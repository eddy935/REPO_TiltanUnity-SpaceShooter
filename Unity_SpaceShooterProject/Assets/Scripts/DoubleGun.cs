using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
public class DoubleGun : MonoBehaviour {
    private float duration=5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }
    IEnumerator Pickup(Collider player)
    {
        
        PlayerController playerController = player.GetComponent<PlayerController>();
        gameObject.GetComponent<Collider>().transform.SetParent(player.transform);
        gameObject.transform.localPosition = new Vector3(0, 0, 0);
        playerController.isDoubleGun = true;
        yield return new WaitForSeconds(duration);
        playerController.isDoubleGun = false;
        Destroy(gameObject);
    }
}
