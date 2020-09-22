using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    /// <summary>
    /// Shifts color, matches color with the "PhaseShiftPlayer"
    /// </summary>
    public class PhaseShiftBullet : MonoBehaviour
    {
        public SpriteRenderer bulletTarget;

        // Update is called once per frame
        void Update()
        {
            BulletShiftChange();
        }

        /// <summary>
        /// "Shifts" between colors
        /// </summary>
        public void BulletShiftChange()
        {
            if (GameManager.Instance.shiftPhase == 0)
            {
                // "Light" colors
                bulletTarget.color = SE.PhaseShiftPlayer.Instance.lightTargetColor;
            }
            else if (GameManager.Instance.shiftPhase == 1)
            {
                // "Dark" colors
                bulletTarget.color = SE.PhaseShiftPlayer.Instance.darkTargetColor;
            }
        }
    }
}