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
    [SerializeField]
    GameObject m_projectile;

    void Start()
    {
        m_speed = 6.0f;
        m_player = GameObject.Find("Player");

        // shoot a projectile at the player every 5 seconds
        InvokeRepeating("SpawnProjectile", 5.0f, 5.0f);
    }

    void Update()
    {
        // find the player's position and chase them
        m_destination = m_player.GetComponent<Transform>().position;
        m_direction = (m_destination - transform.position).normalized;
        transform.position += m_direction * m_speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(m_direction, Vector3.up);
    }

    void Die() {
        Destroy(gameObject);
    }

    // kill the player (player only has 2 life) on contact, then despawn
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            other.GetComponent<Player>().TakeDamage(2);
            Die();
        }
    }

    void SpawnProjectile() {
        Instantiate(m_projectile, transform.position, Quaternion.identity);
    }
}
