using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class PhaseShiftEnemy : MonoBehaviour
    {

        public SpriteRenderer enemyTarget;
        //TODO reminder: Have 2 sets of solid/transparent colors & then choose between them
        //TODO Followup reminder: Meaning, Bombers "chooses" between the 2 (ex: blue or red) & then sets their transparency afterwards
        public Color solidColor;
        public Color transparentColor;

        [SerializeField] private int transparentLayer;
        [SerializeField] private int solidLayer;

        [Range(0, 1)] public float transparentEnemyAlpha;
        private float _solidAlpha = 1;

        private bool transparentState;

        // Update is called once per frame
        void Update()
        {

        }
        
        public void RandomPhase()
        {
            transparentState = Random.value > .5f ? true : false;
            EnemyShiftChange();
        }
        /// <summary>
        /// "Shifts" between colors of the Bombers
        /// </summary>
        public void EnemyShiftChange()
        {
            transparentState = !transparentState;

            gameObject.layer = transparentState ? transparentLayer : solidLayer;
            enemyTarget.color = transparentState ? transparentColor : solidColor;
        }
    }
}