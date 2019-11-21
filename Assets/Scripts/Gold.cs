using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    private float m_lifeTime;
    private float m_rotationSpeed;
    private int m_size;

    public GameObject particle;

    void Start()
    {
        m_lifeTime = 20.0f;
        m_rotationSpeed = 90.0f;
        m_size = Random.Range(1, 4);

        // scale the gold object based on it's size
        switch(m_size) {
            case 1:
                transform.localScale *= 1;
                break;
            case 2:
                transform.localScale *= 3;
                break;
            case 3:
                transform.localScale *= 5;
                break;
            default:
                transform.localScale *= 1;
                break;
        }

        Quaternion rotation = Quaternion.LookRotation(Vector3.up, Vector3.up);
        Instantiate(particle, transform.position, rotation);
    }


    void Update()
    {
        // reduce the gold's lifetime and kill it if life is over
        m_lifeTime -= Time.deltaTime;
        if(m_lifeTime <= 0.0f)
            Die();

        // spin the gold coin
        float angle = m_rotationSpeed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(angle, Vector3.up);
    }

    void Die() {
        // stop emitting bubbles when the coin dies
        particle.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
        Destroy(gameObject);
    }

    // when the player touches the gold, transfer it to them and despawn the gold object
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Player player = other.GetComponent<Player>();
            if(player.m_gold == 0) {
                switch(m_size) {
                    case 1:
                        player.m_gold = 1;
                        break;
                    case 2:
                        player.m_gold = 2;
                        break;
                    case 3:
                        player.m_gold = 10;
                        break;
                    default:
                        player.m_gold = 1;
                        break;
                }
                Die();
            }
        }
    }
}
