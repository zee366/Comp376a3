using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Player m_player;
    private Text m_text1;
    private Text m_text2;
    public int m_level { get; set; }
    private int m_lives;
    private int m_health;
    private int m_score;
    private float m_airTank;

    void Start()
    {
        m_level = 1;
        m_player = GameObject.Find("Player").GetComponent<Player>();
        m_text1 = GameObject.Find("Text").GetComponent<Text>();
        m_text2 = GameObject.Find("Text2").GetComponent<Text>();
        m_score = 0;

        // increase difficulty every 30 seconds
        InvokeRepeating("IncreaseLevel", 30.0f, 30.0f);
    }

    // Every frame, update the UI with current player attribuyes and total score
    void Update()
    {
        m_lives = m_player.m_lives;
        m_health = m_player.m_health;
        m_airTank = m_player.m_airTank;
        m_text1.text = "Level: " + m_level + " Lives: " + m_lives + " Air Tanks: " + m_health + " Score: " + m_score;
        m_text2.text = "AIR RESERVE: " + (int)m_airTank;
    }

    public void UpdateScore(int value) {
        m_score += value;
    }

    void IncreaseLevel() {
        m_level++;
    }
}
