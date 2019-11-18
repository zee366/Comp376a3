using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int m_health;
    private int m_gold;
    // Start is called before the first frame update
    void Start()
    {
        m_health = 2;
        m_gold = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int value) {
        m_health -= value;
    }

    public void GainGold(int value) {
        m_gold += value;
    }
}
