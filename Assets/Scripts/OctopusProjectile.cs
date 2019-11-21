using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusProjectile : MonoBehaviour
{
    float m_lifeTime = 5.0f;
    float m_speed;
    Vector3 m_direction;

    void Start()
    {
        // find the player's current position on instantiation and then fly in a straight line in that direction
        m_speed = 8.0f;
        Vector3 playerPosition = GameObject.Find("Player").GetComponent<Transform>().position;
        m_direction = (playerPosition - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        // despawn projectile after a certain time (in case they don't collide)
        m_lifeTime -= Time.deltaTime;
        if(m_lifeTime <= 0.0f)
            Die();

        // keep moving forward each frame
        transform.position += m_direction * m_speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(m_direction, Vector3.up);
    }

    // deal 1 damage to player on contact, then despawn
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            other.GetComponent<Player>().TakeDamage(1);
            Die();
        }
        else if(other.gameObject.tag == "Wall") {
            Die();
        }
    }

    void Die() {
        Destroy(gameObject);
    }
}
