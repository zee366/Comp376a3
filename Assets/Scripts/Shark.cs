using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    private float m_lifeTime;
    private float m_speed;
    private Vector3 m_initialPos;
    private Vector3 m_destination;
    private Vector3 m_direction;
    private float m_bounds;

    // Start is called before the first frame update
    void Start()
    {
        m_lifeTime = 45.0f;
        m_speed = 5.0f;
        m_bounds = 25.0f;
        m_initialPos = GetComponent<Transform>().position;
        m_destination = new Vector3(-m_initialPos.x, m_initialPos.y, -m_initialPos.z);
        m_direction = (m_destination - m_initialPos).normalized;

        Quaternion rotation = Quaternion.LookRotation(m_direction, Vector3.up);
        transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        m_lifeTime -= Time.deltaTime;
        transform.position = transform.position + (m_direction * m_speed * Time.deltaTime);
        if(Mathf.Abs(transform.position.x) > m_bounds || Mathf.Abs(transform.position.z) > m_bounds) {
            if(m_lifeTime <= 0.0f)
                Die();
            else
                transform.position = m_initialPos;
        }
    }

    void Die() {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            other.GetComponent<Player>().TakeDamage(1);
        }
    }
}
