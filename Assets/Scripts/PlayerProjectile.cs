using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    float m_lifeTime;
    float m_travelTime = 1.5f;
    float m_speed = 18.0f;
    Vector3 m_direction;

    void Start()
    {
        m_lifeTime = 10.0f;
        GameObject camera = GameObject.Find("MainCamera");
        GameObject gunTip = GameObject.Find("GunTip");

        // fly in the direction the camera is facing (gun tip is placed directly in front of camera)
        m_direction = (gunTip.transform.position - camera.transform.position).normalized;
    }

    void Update()
    {
        // shiny objects will dissapear after 10 seconds
        m_lifeTime -= Time.deltaTime;
        if(m_lifeTime <= 0.0f)
            Die();

        // shiny objects have a max travel distance
        m_travelTime -= Time.deltaTime;
        if(m_travelTime > 0.0f)
            transform.position += m_direction * m_speed * Time.deltaTime;
    }

    // despawn on contact with a shark
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Shark") {
            Debug.Log("shark collision");
            Die();
        }
    }

    void Die() {
        Destroy(gameObject);
    }


}
