using SE;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{

    public class PhaseShiftCamera : MonoBehaviour
    {
        public Camera playerCamera;

        public Color lightTargetColor;
        public Color darkTargetColor;

        public static PhaseShiftCamera Instance { get; private set; }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            CameraShiftChange();
        }

        /// <summary>
        /// "Shifts" between colors
        /// </summary>
        public void CameraShiftChange()
        {
            //TODO Set the PhaseShift color changes in the other objects & "call" on them from here

            if (SE.GameManager.Instance.shiftPhase == 0)
            {
                // "Light" colors
                playerCamera.backgroundColor = darkTargetColor;    
            }
            else if (SE.GameManager.Instance.shiftPhase == 1)
            {
                // "Dark" colors
                playerCamera.backgroundColor = lightTargetColor;
            }
        }
    }

}