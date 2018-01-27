using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class DestroyByHealth : MonoBehaviour {

    public int health;

    private float bossHealthMultiplier;
    private GameController _gameControllerRef;

    // Use this for initialization
    void Start () {
        bossHealthMultiplier = 1.3f;
        FindGameController();
        SetBossHealth();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DecreaseHealth()
    {
        health--;
    }

    void FindGameController()
    {
        var gameControllerObj = GameObject.FindWithTag("GameController");
        if (gameControllerObj != null)
        {
            _gameControllerRef = gameControllerObj.GetComponent<GameController>();
        }

        if (gameControllerObj == null)
        {
            Debug.Log("Cannot find GameControllerRef script!!!");
        }
    }

    void SetBossHealth()
    {
        for (int i = 0; i < _gameControllerRef.bossesKilled; i++)
        {
            health = (int)Mathf.Round((health * bossHealthMultiplier));
        }
    }
}
