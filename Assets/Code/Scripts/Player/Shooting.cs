﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SE
{
    public class Shooting : MonoBehaviour
    {
        public Transform weaponPoint;
        public GameObject bulletPrefab;

        public float bulletForce = 20f;

        public static Shooting Instance { get; private set; }

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

        public void FireWeapon()
        {
            BulletFired();
        }

        public void BulletFired()
        {
           GameObject bullet = Instantiate(bulletPrefab, weaponPoint.position, weaponPoint.rotation);

           Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
           bulletBody.AddForce(weaponPoint.right * bulletForce, ForceMode2D.Impulse);
        }
    }
}