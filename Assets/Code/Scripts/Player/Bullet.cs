using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SE
{
    public class Bullet : MonoBehaviour
    {

        private void Start()
        {

        }

        private void Update()
        {
            Destroy(gameObject, 5f);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {

        }

        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            SE.Bomber enemy = hitInfo.GetComponent<SE.Bomber>();
            if (enemy != null)
            {
                Debug.Log("Hit Enemy Bomber");
                enemy.DestroyBomber();
                Destroy(this.gameObject);
            }
        }
    }
}