using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [Tooltip("Player health"), Range(0, 10)]
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
    }

    void UpdateHealth()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter2D(Collision2D hitInfo)
    {
        SE.Bomber enemy = hitInfo.gameObject.GetComponent<SE.Bomber>();
        if (enemy != null)
        {
            Debug.Log("Player has been hit!");
            health = health - 1;
            if (health <= 0)
            {
                health = 0;
                Debug.Log("PLAYER IS DEAD!");
            }
            Debug.Log("Current health: " + health);
        }
    }
}
