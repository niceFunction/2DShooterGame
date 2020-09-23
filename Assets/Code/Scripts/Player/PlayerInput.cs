using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// SE = Samuel Einheri
namespace SE
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerInput : MonoBehaviour
    {
        public float maxSpeed;

        public float acceleration;

        public float deceleration;

        private Rigidbody2D _shipBody;
        [SerializeField] private Vector2 _shipInput;
        
        private Vector2 _mousePosition;
        private Vector2 _lookDirection;

        private float _shipHorizontal;
        private float _shipVertical;


        private void Awake()
        {
            _shipBody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {

        }

        private void Update()
        {
            
            _shipInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Input.GetButtonDown("Shift"))
            {
                SE.GameManager.Instance.ChangePhase();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                FindObjectOfType<AudioManager>().Play("PlayerFire");
                Shooting.Instance.BulletFired();
            }

        }

        // Update is called once per frame
        void FixedUpdate()
        {
            MoveShip(_shipInput);
            RotateShip();
        }

        void MoveShip(Vector2 direction)
        {
            _shipBody.velocity = direction * maxSpeed;
        }

        void RotateShip()
        {
            //_mousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);
            _lookDirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}

