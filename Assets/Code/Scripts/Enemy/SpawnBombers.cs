using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SE
{
    public class SpawnBombers : MonoBehaviour
    {

        //TODO add PhaseShift on everything that's going to change color: Player, Bomber, Bullet, Camera
        //TODO Call on PhaseShift from here (SpawnBombers)

        [Header("Enemy Bomber")]
        public Bomber bomber;
        [Header("Player")]
        public PlayerInput playerInput;
        public Camera playerCamera;
        public float padding;

        [SerializeField, Tooltip("How many Bombers will spawn at the Start?"), Range(1, 100), Header("Bomber")]
        private int _initialSpawnAmount = 50;
        [SerializeField, Tooltip("How much time until a new Bomber spawns?")]
        private float _spawnTimer;
        [SerializeField, Tooltip("When 'Spawn Timer' has reached 0,\n " +
            "'what's the maximum allowed Bombers that can spawn?"), Range(1, 25)]
        private int _spawnAmount;
        [SerializeField, Tooltip("Maximum amount of 'Bombers' allowed"), Range(1, 100)]
        private int _maximumSpawnAmount;

        private float _resetSpawnTimer;
        private float _spawnChance;
        private float _spawnChanceValue = 0.2f;
        private Bomber[] _bombers;
        private List<Bomber> _bombersList = new List<Bomber>();

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
                3. SOLVED (kinda?)Limit amount of certain enemy types on screen
                5. NOT NECESSARY: When enemy is within a certain distance from player, increase speed
                6. NOT NECESSARY: Additionally, make the enemy explode with X seconds
            */
            _resetSpawnTimer = _spawnTimer;

            CreateBombersAtStart();
        }

        // Update is called once per frame
        void Update()
        {
            LimitBombers(); //TODO Find a way where you can remove Bombers without issues

            if (GameObject.FindGameObjectsWithTag("Enemy").Length < _maximumSpawnAmount)
            {
                //Debug.Log("COROUTINE STARTED");
                StartCoroutine(SpawnBombersOverTime());
            }
            else if (GameObject.FindGameObjectsWithTag("Enemy").Length > _maximumSpawnAmount)
            {
                Debug.Log("COROUTINE STOPPED");
                StopCoroutine(SpawnBombersOverTime());
            }
        }

        private void OnGUI()
        {
            #if UNITY_EDITOR
            GUILayout.Label("Bomber length: " + _bombersList.Count.ToString());

            #endif
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
                
                var phaseShift = _bombers[i].GetComponent<PhaseShiftEnemy>();
                phaseShift.RandomPhase();
            }
            _bombersList.AddRange(_bombers);
        }

        /// <summary>
        /// Spawns a new bomber, happens in "Bomber" script
        /// </summary>
        public void SpawnAnotherBomberOnDeath(Bomber deadBomber)
        {
            _bombersList.Remove(deadBomber);

            if (_bombersList.Count > _maximumSpawnAmount)
                return;

            _spawnChance = Random.Range(0, 2);
            // Makes it so that Bombers don't spawn every single time
            if (_spawnChance < _spawnChanceValue)
            {
                var position = GetRandomOffScreenPosition();
                var newBomber = Instantiate(bomber, position, Quaternion.identity);
                newBomber.playerTarget = playerInput.transform;

                var phaseShift = newBomber.GetComponent<PhaseShiftEnemy>();
                phaseShift.RandomPhase();
                _bombersList.Add(newBomber);
            }
        }

        IEnumerator SpawnBombersOverTime()
        {
            _spawnTimer = _spawnTimer - Time.deltaTime;

            if (_spawnTimer <= 0)
            {
                _bombers = new Bomber[_spawnAmount];
                for (int i = 0; i < Random.Range(0, _spawnAmount); i++)
                {
                    if (_bombersList.Count > _maximumSpawnAmount)
                        break;

                    var position = GetRandomOffScreenPosition();
                    _bombers[i] = Instantiate(bomber, position, Quaternion.identity);
                    _bombers[i].playerTarget = playerInput.transform;
                    //Debug.Log("SPAWNED: " + i + " BOMBERS");

                    var phaseShift = _bombers[i].GetComponent<PhaseShiftEnemy>();
                    phaseShift.RandomPhase();

                    _spawnTimer = _resetSpawnTimer;
                    _bombersList.Add(_bombers[i]);
                }
            }
            yield return new WaitForSeconds(_spawnTimer);
        }

        /// <summary>
        /// Decide what "phase" Bombers spawn in as
        /// </summary>
        public void LimitBombers()
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length > _maximumSpawnAmount)
            {
                //Debug.Log("ABOVE MAXIMUM ALLOWED BOMBERS!");

                
            }
        }

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

            position = playerCamera.ScreenToWorldPoint(position);
            return position;
        }
    }
}
