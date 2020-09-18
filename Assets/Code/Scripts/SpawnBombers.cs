using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class SpawnBombers : MonoBehaviour
    {
        [Header("Player")]
        public Bomber bomber;
        public PlayerInput playerInput;
        public Camera camera;
        //[Range(1, 1000)]
        //public int spawnCount;
        public float padding;

        [SerializeField, Tooltip("How many Bombers will spawn at the Start?"), Range(1, 100), Header("Bomber")]
        private int _initialSpawnAmount = 50;
        [SerializeField, Tooltip("How much time until a new Bomber spawns?")]
        private float _spawnTimer;
        [SerializeField, Tooltip("When 'Spawn Timer' has reached 0,\n " +
            "'what's the maximum allowed Bombers that can spawn?"), Range(1, 25)]
        private int _spawnAmount;

        private float _resetSpawnTimer;
        private float _spawnChance;
        private float _spawnChanceValue = 0.2f;
        private Bomber[] _bombers;

        private IEnumerator _coroutine;

        public static SpawnBombers Instance { get; private set; }

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
            _resetSpawnTimer = _spawnTimer;

            CreateBombersAtStart();
        }

        // Update is called once per frame
        void Update()
        {
            //SpawnBombersOverTime();
            StartCoroutine(SpawnBombersOverTime());
        }

        /// <summary>
        /// Create a bunch of Bombers in the beginning
        /// </summary>
        private void CreateBombersAtStart()
        {
            _bombers = new Bomber[_initialSpawnAmount];
            for (int i = 0; i < _initialSpawnAmount; i++)
            {
                var position = GetRandomOffScreenPosition();

                _bombers[i] = Instantiate(bomber, position, Quaternion.identity);
                _bombers[i].playerTarget = playerInput.transform;
            }
        }

        /// <summary>
        /// Spawns a new bomber, happens in "Bomber" script
        /// </summary>
        public void SpawnAnotherBomberOnDeath()
        {
            _spawnChance = Random.Range(0, 2);

            // Makes it so that Bombers don't spawn every single time
            if (_spawnChance < _spawnChanceValue)
            {
                Debug.Log("A BOMBER DIED, NEW BOMBER SPAWNED!");
                var position = GetRandomOffScreenPosition();
                Instantiate(bomber, position, Quaternion.identity);
                bomber.playerTarget = playerInput.transform;
            }
        }

        IEnumerator SpawnBombersOverTime()
        {
            _spawnTimer = _spawnTimer - Time.deltaTime;

            if (_spawnTimer <= 0)
            {
                Debug.Log("SPAWNTIMER REACHED 0!");
                _bombers = new Bomber[_spawnAmount];
                for (int i = 0; i < Random.Range(0, _spawnAmount); i++)
                {
                    //TODO consider if new Bombers should spawn a single or multiple Bomber(s)
                    var position = GetRandomOffScreenPosition();
                    //Instantiate(bomber, position, Quaternion.identity);
                    //bomber.playerTarget = playerInput.transform;
                    _bombers[i] = Instantiate(bomber, position, Quaternion.identity);
                    _bombers[i].playerTarget = playerInput.transform;
                    Debug.Log("SPAWNED: " + i + " BOMBERS");
                    _spawnTimer = _resetSpawnTimer;
                }
            }

            yield return new WaitForSeconds(_spawnTimer);
        }

        /// <summary>
        /// Spawns Bomber(s) over time
        /// </summary>
        /*
        public void SpawnBombersOverTime()
        {

            _spawnTimer = _spawnTimer - Time.deltaTime;

            if (_spawnTimer <= 0)
            {
                Debug.Log("SPAWNTIMER REACHED 0!");
                _bombers = new Bomber[_spawnAmount];
                for (int i = 0; i < Random.Range(0, _spawnAmount); i++)
                {
                    //TODO consider if new Bombers should spawn a single or multiple Bomber(s)
                    var position = GetRandomOffScreenPosition();
                    //Instantiate(bomber, position, Quaternion.identity);
                    //bomber.playerTarget = playerInput.transform;
                    _bombers[i] = Instantiate(bomber, position, Quaternion.identity);
                    _bombers[i].playerTarget = playerInput.transform;
                    Debug.Log("SPAWNED: " + i + " BOMBERS");
                    _spawnTimer = _resetSpawnTimer;
                }
            }
        }
*/
        /// <summary>
        /// Get position(s) outside of the viewable screen
        /// </summary>
        /// <returns></returns>
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
