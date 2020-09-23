using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class GameManager : MonoBehaviour
    {
        //TODO animation input: Have 2 different animations to switch between

        [HideInInspector] public int shiftPhase = 0;
        [HideInInspector] public int enemyShiftPhase;

        public SpriteRenderer playerSprite;
        public Camera playerCamera;

        public static GameManager Instance { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            
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
            //Debug.Log(enemyShiftPhase);
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
            }
            else
            {
                //Debug.Log("PhaseShift: " + shiftPhase + " dark");
                shiftPhase = 0;
            }
        }
    }
}