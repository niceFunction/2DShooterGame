﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        SE.Bomber enemy = hitInfo.GetComponent<SE.Bomber>();
        if(enemy != null)
        {
            //Debug.Log("Enemy entered");
            enemy.DestroyBomber();
        }
    }
}
