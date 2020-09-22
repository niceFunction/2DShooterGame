using SE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class PhaseShiftPlayer : MonoBehaviour
    {

        public SpriteRenderer playerTarget;
        public SE.Bullet bulletTarget;
        public Color lightTargetColor;
        public Color darkTargetColor;

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

        private void Update()
        {
            PlayerShiftChange();
        }

        /// <summary>
        /// "Shifts" between colors
        /// </summary>
        public void PlayerShiftChange()
        {
            if (SE.GameManager.Instance.shiftPhase == 0)
            {
                // "Light" colors
                playerTarget.color = lightTargetColor;
            }
            else if (GameManager.Instance.shiftPhase == 1)
            {
                // "Dark" colors
                playerTarget.color = darkTargetColor;
            }
        }
    }
}