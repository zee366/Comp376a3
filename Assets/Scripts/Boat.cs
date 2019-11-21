using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    private GameController gameController;
 
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // When the player reaches the boat, transfer their gold to the total score
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Player player = GameObject.Find("Player").GetComponent<Player>();
            gameController.UpdateScore(player.m_gold);
            player.m_gold = 0;
        }
    }
}
