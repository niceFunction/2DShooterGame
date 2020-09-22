using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class PhaseShiftEnemy : MonoBehaviour
    {

        public SpriteRenderer enemyTarget;
        public Color lightTargetColor;
        public Color darkTargetColor;

        [Range(0, 1)]
        public float transparentEnemyAlpha;
        private float _solidAlpha = 1;

        // Update is called once per frame
        void Update()
        {
            EnemyShiftChange();
        }

        /// <summary>
        /// "Shifts" between colors of the Bombers
        /// </summary>
        public void EnemyShiftChange()
        {
            if (SE.GameManager.Instance.shiftPhase == 0)
            {
                // Use "Light" colors
                enemyTarget.color = darkTargetColor;
            }
            else if (SE.GameManager.Instance.shiftPhase == 1)
            {
                // "Dark" colors
                enemyTarget.color = lightTargetColor;
            }
        }
    }
}