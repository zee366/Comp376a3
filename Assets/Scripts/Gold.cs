using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    private float m_lifeTime;
    private float m_rotationSpeed;
    private int m_size;

    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        m_lifeTime = 20.0f;
        m_rotationSpeed = 90.0f;
        m_size = Random.Range(0, 3);

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

    // Update is called once per frame
    void Update()
    {
        m_lifeTime -= Time.deltaTime;
        if(m_lifeTime <= 0.0f)
            Die();

        float angle = m_rotationSpeed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(angle, Vector3.up);
    }

    void Die() {
        // stop emitting not working
        particle.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Player player = other.GetComponent<Player>();
            switch(m_size) {
                case 1:
                    player.GainGold(1);
                    break;
                case 2:
                    player.GainGold(2);
                    break;
                case 3:
                    player.GainGold(3);
                    break;
                default:
                    player.GainGold(0);
                    break;
            }
            Die();
        }
    }
}
