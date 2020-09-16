using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class Shooting : MonoBehaviour
    {
        public Transform weaponPoint;
        public GameObject bulletPrefab;

        public float bulletForce = 20f;

        // Update is called once per frame
        void Update()
        {
            FireWeapon();
        }

        private void FireWeapon()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                BulletFired();
            }
        }

        private void BulletFired()
        {
           GameObject bullet = Instantiate(bulletPrefab, weaponPoint.position, weaponPoint.rotation);

           Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
           bulletBody.AddForce(weaponPoint.right * bulletForce, ForceMode2D.Impulse);
        }
    }
}