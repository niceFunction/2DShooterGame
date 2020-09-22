using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class GameManager : MonoBehaviour
    {
        [HideInInspector]
        public int shiftPhase = 0;

        public SpriteRenderer playerSprite;
        public Camera playerCamera;

        public static GameManager Instance { get; private set; }

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
        /// Changes the colors of intended objects where 0 is "Light" & 1 is "Dark, Intended objects updates themselves.
        /// </summary>
        public void ChangePhase()
        {
            if (shiftPhase == 0)
            {
                Debug.Log("PhaseShift: " + shiftPhase + " light");
                shiftPhase = 1;
            }
            else
            {
                Debug.Log("PhaseShift: " + shiftPhase + " dark");
                shiftPhase = 0;
            }
        }
    }
}