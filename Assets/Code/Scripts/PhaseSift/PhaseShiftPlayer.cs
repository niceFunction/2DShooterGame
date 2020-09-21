using SE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class PhaseShiftPlayer : MonoBehaviour
    {
        [HideInInspector]
        public int shiftPhase; // "lightColor" = 0, "darkColor" = 1

        //public SE.Colors.Objects colorObjects;
        public SpriteRenderer playerTarget;
        public SE.Bullet bulletTarget;
        //public SpriteRenderer bullet;
        public Color lightTargetColor;
        public Color darkTargetColor;

        //[Range(0, 1)]
        //public float transparentEnemyAlpha;
        //private float _solidAlpha = 1;

        // Personal note: normally a static object should be destroyed
        public static PhaseShiftPlayer Instance { get; private set; }

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

        // Start is called before the first frame update
        void Start()
        {
            /*
            colorObjects.player = GetComponentInChildren<SpriteRenderer>();
            colorObjects.bullet = GetComponentInChildren<SpriteRenderer>();
            colorObjects.bomber = GetComponentInChildren<SpriteRenderer>();
            */
        }

        // Update is called once per frame
        void Update()
        {
            //ShiftChange();
        }

        /// <summary>
        /// "Shifts" between colors
        /// </summary>
        public void PlayerShiftChange()
        {
            //TODO Set the PhaseShift color changes in the other objects & "call" on them from here

            if (GameManager.Instance.shiftPhase == 0)
            {
                // "Light" colors
                Debug.Log("PhaseShift: " + playerTarget + "light");
                /*
                colorObjects.player.color = colorObjects.lightPlayerColor;
                colorObjects.bullet.color = colorObjects.lightPlayerColor;
                colorObjects.camera.backgroundColor = colorObjects.lightCameraColor;
                */
                // Use "Dark" color for Bomber here
                //colorObjects.bomber.color = colorObjects.darkBomberColor;
            }
            else if (GameManager.Instance.shiftPhase == 1)
            {
                // "Dark" colors
                Debug.Log("PhaseShift: " + playerTarget + "light");
                /*
                colorObjects.player.color = colorObjects.darkPlayerColor;
                colorObjects.bullet.color = colorObjects.darkPlayerColor;
                colorObjects.camera.backgroundColor = colorObjects.darkCameraColor;
                */
                // Use "Light" color for Bomber here
                //colorObjects.bomber.color = colorObjects.lightBomberColor;
            }
        }
    }

}