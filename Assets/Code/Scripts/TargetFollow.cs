using UnityEngine;

namespace SE
{
    public class TargetFollow : MonoBehaviour
    {

        public Transform followTarget;
        [Range(0f, 1f)]
        public float smoothTime;

        public Vector3 offset = new Vector3(0f, 0f, -15f);

        private Transform _transform;
        private Vector3 _velocity;

        // Start is called before the first frame update
        void Start()
        {
            _transform = transform;
            _transform.position = followTarget.position + offset;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            Vector3 targetPosition = followTarget.TransformPoint(offset);
            _transform.position = Vector3.SmoothDamp(_transform.position, targetPosition, ref _velocity, smoothTime);
        }
    }
}
