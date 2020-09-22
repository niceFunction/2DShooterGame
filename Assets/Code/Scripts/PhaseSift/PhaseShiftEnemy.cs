using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class PhaseShiftEnemy : MonoBehaviour
    {

        public SpriteRenderer enemyTarget;
        public Color solidColor; //light
        public Color transparentColor; // dark

        [SerializeField] private int transparentLayer;
        [SerializeField] private int solidLayer;

        [Range(0, 1)] public float transparentEnemyAlpha;
        private float _solidAlpha = 1;

        private bool transparentState;

        // Update is called once per frame
        void Update()
        {
            //EnemyShiftChange();
        }
        
        //TODO a
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
            //TODO Ensure that the "transparency" layer mask works as intended
            gameObject.layer = transparentState ? transparentLayer : solidLayer;
            enemyTarget.color = transparentState ? solidColor : transparentColor;
            /*
            //GameManager.Instance.enemyShiftPhase = Random.Range();
            if (SE.GameManager.Instance.shiftPhase == 0)
            {
                // Use "Light" colors
                enemyTarget.color = darkTargetColor;
                gameObject.layer = 8;
            }
            else if (SE.GameManager.Instance.shiftPhase == 1)
            {
                // "Dark" colors
                enemyTarget.color = lightTargetColor;
                gameObject.layer = 9;
            }
            */
        }
    }
}