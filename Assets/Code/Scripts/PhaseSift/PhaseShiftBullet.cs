using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class PhaseShiftBullet : MonoBehaviour
    {
        [HideInInspector]
        public int shiftPhase; // "lightColor" = 0, "darkColor" = 1

        //public SE.Colors.Objects colorObjects;
        public SpriteRenderer bulletTarget;
        //public SpriteRenderer bullet;
        public Color lightTargetColor;
        public Color darkTargetColor;

        //[Range(0, 1)]
        //public float transparentEnemyAlpha;
        //private float _solidAlpha = 1;

        //public static PhaseShift Instance { get; private set; }

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
        public void ShiftChange()
        {
            //TODO Set the PhaseShift color changes in the other objects & "call" on them from here

            if (shiftPhase == 0)
            {
                // "Light" colors
                Debug.Log("PhaseShift: " + bulletTarget + "light");
                /*
                colorObjects.player.color = colorObjects.lightPlayerColor;
                colorObjects.bullet.color = colorObjects.lightPlayerColor;
                colorObjects.camera.backgroundColor = colorObjects.lightCameraColor;
                */
                // Use "Dark" color for Bomber here
                //colorObjects.bomber.color = colorObjects.darkBomberColor;
            }
            else if (shiftPhase == 1)
            {
                // "Dark" colors
                Debug.Log("PhaseSift: " + bulletTarget + "dark");
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