using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class PhaseShiftBullet : MonoBehaviour
    {
        public SpriteRenderer bulletTarget;
        public Color lightTargetColor;
        public Color darkTargetColor;

        public static PhaseShiftBullet Instance { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
     
        }
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
        }

        // Update is called once per frame
        void Update()
        {
            //ShiftChange();
            BulletShiftChange();
        }

        /// <summary>
        /// "Shifts" between colors
        /// </summary>
        public void BulletShiftChange()
        {
            //TODO Set the PhaseShift color changes in the other objects & "call" on them from here

            if (GameManager.Instance.shiftPhase == 0)
            {
                // "Light" colors
                bulletTarget.color = lightTargetColor;
            }
            else if (GameManager.Instance.shiftPhase == 1)
            {
                //bulletTarget.color = PhaseShiftPlayer.Instance.darkTargetColor;
            }
        }
    }

}