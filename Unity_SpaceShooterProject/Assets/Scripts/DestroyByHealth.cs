using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class DestroyByHealth : MonoBehaviour {

    public int health;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DecreaseHealth()
    {
        health--;
    }
}
