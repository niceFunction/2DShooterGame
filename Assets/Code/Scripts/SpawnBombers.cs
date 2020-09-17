using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class SpawnBombers : MonoBehaviour
    {
        public Bomber bomber;
        public PlayerInput playerInput;
        public Camera camera;
        [Range(1, 1000)]
        public int spawnCount;
        public float padding;

        private Bomber[] _bombers;
        // Start is called before the first frame update
        void Start()
        {
            /*
                DESIGN BOMBER SPAWNING SYSTEM
                1. Start game by spawning a x number of enemies
                2. Spawn an additional enemy after x seconds
                3. Limit amount of certain enemy types on screen
                4. Spawn a new enemy after an old enemy has died
                5. NOT NECESSARY: When enemy is within a certain distance from player, increase speed
                6. NOT NECESSARY: Additionally, make the enemy explode with X seconds
            */
            /*
            _bombers = new Bomber[spawnCount];
            for (int i = 0; i < spawnCount; i++)
            {
                var position = GetRandomOffScreenPosition();

                _bombers[i] = Instantiate(bomber, position, Quaternion.identity);
                _bombers[i].playerTarget = playerInput.transform;
            }
            */
            //Debug.Break();
            CreateBombers();
        }

        // Update is called once per frame
        void Update()
        {
         
        }

        private void CreateBombers()
        {
            _bombers = new Bomber[spawnCount];
            for (int i = 0; i < spawnCount; i++)
            {
                var position = GetRandomOffScreenPosition();

                _bombers[i] = Instantiate(bomber, position, Quaternion.identity);
                _bombers[i].playerTarget = playerInput.transform;
            }
        }

        private Vector2 GetRandomOffScreenPosition()
        {
            var position = new Vector2();
            var axis = Random.Range(0, 4);

            switch (axis)
            {
                // Y Zero
                case 0:
                    position.y = -padding;
                    position.x = Random.Range(0, Screen.width);
                    break;

                // Y Screen Height
                case 1:
                    position.y = Screen.height + padding;
                    position.x = Random.Range(0, Screen.width);
                    break;

                // X Zero
                case 2:
                    position.y = Random.Range(0, Screen.height);
                    position.x = -padding;
                    break;

                // X Maximum
                case 3:
                    position.y = Random.Range(0, Screen.height);
                    position.x = Screen.width + padding;
                    break;
            }

            position = camera.ScreenToWorldPoint(position);

            return position;
        }
    }
}
