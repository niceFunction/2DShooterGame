using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class Bomber : MonoBehaviour
    {
        public Transform playerTarget;
        [Range(1f, 100f)]
        public float bomberSpeed = 5f;

        private Rigidbody2D _bomberBody;
        private Vector2 _bomberMovement;

        // Start is called before the first frame update
        void Start()
        {
            _bomberBody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            TargetPlayer();
        }

        private void FixedUpdate()
        {
            MoveBomber(_bomberMovement);
        }

        private void TargetPlayer()
        {
            Vector3 direction = playerTarget.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            _bomberBody.rotation = angle;
            direction.Normalize();
            _bomberMovement = direction;
        }

        private void MoveBomber(Vector2 direction)
        {
            _bomberBody.MovePosition((Vector2)transform.position + 
                (direction * bomberSpeed * Time.deltaTime));
        }
    }
}
