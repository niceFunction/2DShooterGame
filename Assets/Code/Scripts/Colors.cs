using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class Colors : MonoBehaviour
    {
        [System.Serializable]
        public struct Objects
        {
            [Header("Player"), Tooltip("Changes the color of the 'Player' & 'Bullet'")]
            public SpriteRenderer player;
            public SpriteRenderer bullet;
            public Color lightPlayerColor;
            public Color darkPlayerColor;
            [Header("Bomber"), Tooltip("Changes the color of the 'Bomber'")]
            public SpriteRenderer bomber;
            public Color lightBomberColor;
            public Color darkBomberColor;

            [Header("Camera"), Tooltip("Changes the color of the Camera")]
            public Camera camera;
            public Color lightCameraColor;
            public Color darkCameraColor;
        }
    }
}