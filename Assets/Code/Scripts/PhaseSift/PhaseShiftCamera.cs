using SE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{

    public class PhaseShiftCamera : MonoBehaviour
    {
        public Color lightTargetColor;
        public Color darkTargetColor;

        public static PhaseShiftCamera Instance { get; private set; }

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

        }

        /// <summary>
        /// "Shifts" between colors
        /// </summary>
        public void CameraShiftChange()
        {
            //TODO Set the PhaseShift color changes in the other objects & "call" on them from here

            if (GameManager.Instance.shiftPhase == 0)
            {
                // "Light" colors
                GameManager.Instance.playerCamera.backgroundColor = lightTargetColor;
            }
            else if (GameManager.Instance.shiftPhase == 1)
            {
                // "Dark" colors
                GameManager.Instance.playerCamera.backgroundColor = darkTargetColor;
            }
        }
    }

}