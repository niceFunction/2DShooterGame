using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace SE
{
    public class GameManager : MonoBehaviour
    {
        [HideInInspector] public int shiftPhase = 0;
        [HideInInspector] public int enemyShiftPhase;
        [HideInInspector] public int killCount;

        [Header("Player"), Tooltip("The sprite of the player")]
        public SpriteRenderer playerSprite;
        [Tooltip("The camera for the player")]
        public Camera playerCamera;
        [Tooltip("Reference for the player's life script")]
        public PlayerLife playerLife;

        [Header("GUI"), Tooltip("The 'icon' that represents the player's life")]
        public TextMeshProUGUI lifeIcon;
        [Tooltip("The text component that will display amount of life left")]
        public TextMeshProUGUI lifeText;
        [Tooltip("The 'icon' that represents the player's kill count")]
        public TextMeshProUGUI killIcon;
        [Tooltip("The text component that displays the player's kill count")]
        public TextMeshProUGUI killText;
        [Tooltip("Colors that changes the visuals of the 'life' text")]
        public Color lightLife;
        public Color darkLife;

        [Header("Border"), Tooltip("The sprite of the 'border'")]
        public SpriteRenderer borderSprite;
        public Color lightBorder;
        public Color darkBorder;

        public static GameManager Instance { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            // What the color of the life will be at the start
            lifeIcon.color = lightLife;
            lifeText.color = lightLife;
            killIcon.color = lightLife;
            killText.color = lightLife;

            killText.text = killCount.ToString();
            killCount = 0;

            // Starting color of the "border"
            borderSprite.color = lightBorder;

        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        // Update is called once per frame
        void Update()
        {
            playerLife.UpdateHealth();
            Debug.Log(killCount);
            killText.text = killCount.ToString();
        }

        /// <summary>
        /// Changes the colors of intended objects where 0 is "Light" & 1 is "Dark, Intended objects updates themselves.
        /// </summary>
        public void ChangePhase()
        {
            var enemies = FindObjectsOfType<PhaseShiftEnemy>();
            
            foreach(var enemy in enemies)
            {
                enemy.EnemyShiftChange();
            }

            if (shiftPhase == 0)
            {
                //Debug.Log("PhaseShift: " + shiftPhase + " light");
                shiftPhase = 1;
                lifeIcon.color = darkLife;
                lifeText.color = darkLife;
                killIcon.color = darkLife;
                killText.color = darkLife;
                borderSprite.color = darkBorder;
            }
            else
            {
                //Debug.Log("PhaseShift: " + shiftPhase + " dark");
                shiftPhase = 0;
                lifeIcon.color = lightLife;
                lifeText.color = lightLife;
                killIcon.color = lightLife;
                killText.color = lightLife;
                borderSprite.color = lightBorder;
            }
        }
    }
}