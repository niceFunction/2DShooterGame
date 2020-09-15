using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


namespace SE
{
    public class ShipMovement : MonoBehaviour
    {
        [NonSerialized] public Vector2 shipInput;
        private float _moveHorizontal;

        private float _moveVertical;
        private Transform _transform;

        [Tooltip("Maximum speed that the ship can reach"), Range(0.01f, 100f)]
        public float maxSpeed;
        [Tooltip("How fast can the ship accelerate"), Range(0.01f, 250f)]
        public float baseAcceleration = 50f;
        [Tooltip("How much will the ship decelerate?"), Range(1f, 50f)]
        public float decelerationRate = 10f;

        /*
        [Header("Speed & Acceleration"), Tooltip("Maximum speed that the ship can reach"), Range(0.01f, 100f)]
        public float maxSpeed = 10f;
        [Tooltip("How fast can the ship accelerate"), Range(0.01f, 250f)]
        public float baseAcceleration = 50f;
        [Tooltip("How much time will pass until the ship accelerates?"), Range(0.001f, 0.5f)]
        public float accelerationDelay = 0.001f;
        [Tooltip("How much will the ship decelerate?"), Range(1f, 50f)]
        public float decelerationRate = 10f;
        
        [Header("Rotation"), Tooltip("How fast can the ship rotate?"), Range(1f, 200f)]
        public float baseRotationAcceleration = 50f;
        [Tooltip("Minimum allowed speed to make the ship rotate"), Range(0f, 1f)]
        public float minimumRotationTolerence = 0.1f;
        [Tooltip("How fast can the ship rotate?"), Range(1f, 50f)]
        public float maximumRotationSpeed = 5f;

        [NonSerialized] public Vector2 shipInput;
        [NonSerialized] public float maxReverseSpeed;
        [NonSerialized] public float forwardSpeed;
        [NonSerialized] public float desiredForwardSpeed;
        
        [NonSerialized] public float rotationSpeed;
        [NonSerialized] public float desiredRotationSpeed;

        private Rigidbody2D _shipBody;
        private Transform _transform;
        private float _initialDrag = 0f;

        public bool IsDecelerating { get; set; } = false;
        */
        private void Awake()
        {
            //_shipBody = GetComponent<Rigidbody2D>();
            _moveHorizontal = Input.GetAxisRaw("Horizontal");
            _transform = transform;
            //maxReverseSpeed = maxSpeed;
        }

        private void Update()
        {
            float moveInput = Input.GetAxisRaw("Horizontal");
            shipInput.x = Mathf.MoveTowards(shipInput.x, maxSpeed * moveInput, 
                baseAcceleration * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            /*
            if (shipInput.sqrMagnitude > 1f)
            {
                shipInput.Normalize();
            }

            if (IsDecelerating)
            {
                _shipBody.drag = Mathf.Lerp(_shipBody.drag, 
                    _shipBody.drag * decelerationRate, Time.deltaTime);
            }
            else
            {
                _shipBody.drag = _initialDrag;
                MoveShip();
            }

            Rotation();
            */
        }

        private void MoveShip()
        {

            
            /*
            desiredForwardSpeed = shipInput.y * (shipInput.y > 0f ? maxSpeed : maxReverseSpeed);

            
            forwardSpeed = Mathf.MoveTowards(forwardSpeed, desiredForwardSpeed, 
                baseAcceleration * Time.deltaTime);
            _shipBody.AddForce(_transform.right * forwardSpeed, ForceMode2D.Force);
            */

        }

        private void Rotation()
        {
            /*
            desiredRotationSpeed = shipInput.x * -maximumRotationSpeed;
            rotationSpeed = Mathf.MoveTowards(rotationSpeed, desiredRotationSpeed, baseRotationAcceleration * Time.deltaTime);
            _shipBody.AddTorque(rotationSpeed);
            */
        }

    }
}

