using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private Player m_player;
    private Text m_text;
    private int m_lives;
    private int m_health;
    private int m_score;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.Find("Player").GetComponent<Player>();
        m_text = GameObject.Find("Text").GetComponent<Text>();
        m_score = 0;
    }

    void Update()
    {
        m_lives = m_player.m_lives;
        m_health = m_player.m_health;
        string text = "Lives: " + m_lives + " Health: " + m_health + " Score: " + m_score;
        m_text.text = text;
    }

    public void UpdateScore(int value) {
        m_score += value;
    }
}
