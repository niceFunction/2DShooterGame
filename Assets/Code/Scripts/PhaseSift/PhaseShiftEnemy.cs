using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class PhaseShiftEnemy : MonoBehaviour
    {
        public SpriteRenderer enemyTarget;
        public Color solidColor;
        public Color transparentColor;

        [SerializeField] private int _transparentLayer;
        [SerializeField] private int _solidLayer;

        private bool _transparentState;
        
        /// <summary>
        /// Randomizes if the Bomber enemy will be "Transparent" or "Solid"
        /// </summary>
        public void RandomPhase()
        {
            _transparentState = Random.value > .5f ? true : false;
            EnemyShiftChange();
        }

        /// <summary>
        /// "Shifts" between colors of the Bombers
        /// </summary>
        public void EnemyShiftChange()
        {
            _transparentState = !_transparentState;

            gameObject.layer = _transparentState ? _transparentLayer : _solidLayer;
            enemyTarget.color = _transparentState ? transparentColor : solidColor;
        }
    }
}