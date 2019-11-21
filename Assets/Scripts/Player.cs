using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    public int m_lives { get; set; }
    public int m_health { get; set; }
    public int m_gold { get; set; }
    public float m_airTank { get; set; }

    private RigidbodyFirstPersonController rbController;
    private Vector3 spawnPoint;

    [SerializeField]
    GameObject m_projectile;

    // Start is called before the first frame update
    void Start()
    {
        m_lives = 2;
        m_health = 2;
        m_gold = 0;
        m_airTank = 30.0f;
        rbController = GetComponent<RigidbodyFirstPersonController>();
        spawnPoint = GameObject.Find("PlayerSpawn").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // change the player's movement speed depending on how much gold they are carrying
        switch(m_gold) {
            case 0:
                UpdateMovement(12, 6, 8);
                break;
            case 1:
                UpdateMovement(10, 5, 6);
                break;
            case 2:
                UpdateMovement(8, 4, 4);
                break;
            case 10:
                UpdateMovement(6, 3, 2);
                break;
            default:
                UpdateMovement(12, 6, 8);
                break;
        }

        // shoot projectile on left mouse click
        if(Input.GetButtonDown("Fire1")) {
            Instantiate(m_projectile, transform.position, Quaternion.AngleAxis(-90.0f, Vector3.right));
        }

        CheckAirTank();
    }

    private void UpdateMovement(int forward, int backward, int strafe) {
        rbController.movementSettings.ForwardSpeed = forward;
        rbController.movementSettings.BackwardSpeed = backward;
        rbController.movementSettings.StrafeSpeed = strafe;
    }

    // reduce health by damage taken (health is the number of air tanks left)
    // respawn if the player has additional lives, otherwise game over
    public void TakeDamage(int value) {
        m_health -= value;
        if(m_health <= 0) {
            if(m_lives > 0) {
                Respawn();
            }
            else {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    // reset the player's carried gold, reduce lives by 1 and respawn on the boat
    public void Respawn() {
        m_lives--;
        m_health = 2;
        m_gold = 0;
        transform.position = spawnPoint;
        rbController.Velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // called when the palyer touches a gold object
    public void GainGold(int value) {
        m_gold += value;
    }

    // reduce air in the tank while they are underwater, or refill it if they go above water
    // if air runs out while underwater, take 1 damage
    void CheckAirTank() {
        if(transform.position.y < 50.0f) {
            m_airTank -= Time.deltaTime;
        }
        else if(transform.position.y >= 50.0f) {
            m_airTank = 30.0f;
        }

        if(m_airTank <= 0.0f) {
            TakeDamage(1);
            m_airTank = 30.0f;
        }
    }
}
