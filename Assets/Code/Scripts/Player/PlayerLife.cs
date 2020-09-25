using SE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace SE
{
    public class PlayerLife : MonoBehaviour
    {
        [Tooltip("Player health"), Range(0, 10)]
        public int health;

        // Update is called once per frame
        void Update()
        {
            UpdateHealth();
            GameManager.Instance.lifeText.text = health.ToString();
        }

        /// <summary>
        /// Reload scene when player health is zero
        /// </summary>
        public void UpdateHealth()
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
                health = health - 1;
                if (health <= 0)
                {
                    health = 0;
                }
            }
        }
    }
}