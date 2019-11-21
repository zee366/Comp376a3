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
    private bool m_distracted;
    private float m_detectionRange;
    private GameController gameController;

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        m_lifeTime = 25.0f;
        m_speed = 3.0f + (2 * gameController.m_level);
        m_bounds = 25.0f;
        m_initialPos = GetComponent<Transform>().position;
        m_destination = new Vector3(-m_initialPos.x, m_initialPos.y, -m_initialPos.z);
        m_direction = (m_destination - m_initialPos).normalized;
        m_distracted = false;
        m_detectionRange = 20.0f;

        transform.rotation = Quaternion.LookRotation(m_direction, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        // Sharks live for 25 seconds
        m_lifeTime -= Time.deltaTime;

        // every frame, try and find the closest diamond thrown by the player (within the shark's detection range)
        // change direction towards the diamond if one is found
        // otherwise resum straight line movement
        GameObject diamond = FindClosestDiamond();
        if(diamond) {
            m_distracted = true;
            m_direction = (diamond.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(m_direction);
        }
        else {
            if(m_distracted) {
                m_distracted = false;
                ResetMovement();
            }
        }

        // move in a straight line and reappear on the opposite side of the level if they hit a wall
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

    // deal 1 damage to the player on contact
    // reset to straight line movememnt on contact with a diamond
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            other.GetComponent<Player>().TakeDamage(1);
        }
        else if(other.gameObject.tag == "Diamond") {
            m_distracted = false;
            ResetMovement();
        }
    }

    // look for the closest diamond within detection range
    GameObject FindClosestDiamond() {
        GameObject[] diamonds;
        diamonds = GameObject.FindGameObjectsWithTag("Diamond");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach(GameObject go in diamonds) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance < distance && curDistance < (m_detectionRange * m_detectionRange)) {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    // reset to straight line horizontal movement
    void ResetMovement() {
        transform.rotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y, 0.0f);
        m_direction = transform.forward;
    }
}
