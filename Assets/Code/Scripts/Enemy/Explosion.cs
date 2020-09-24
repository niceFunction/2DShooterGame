using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    //TODO Explosion 1: Add more depth to the Explosion
    //TODO Explosion 2: i.e. Explosions can only affect Bombers that are solid

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
