using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Octopus : MonoBehaviour
{
    private float m_speed;
    private Vector3 m_initialPos;
    private Vector3 m_destination;
    private Vector3 m_direction;
    private GameObject m_player;

    // Start is called before the first frame update
    void Start()
    {
        m_speed = 4.0f;
        m_player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        m_destination = m_player.GetComponent<Transform>().position;
        m_direction = (m_destination - transform.position).normalized;
        transform.position += m_direction * m_speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(m_direction, Vector3.up);
    }

    void Die() {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "player") {
            other.GetComponent<Player>().TakeDamage(2);
            Die();
        }
    }
}
