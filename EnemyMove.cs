using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ThePlayer;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public int MoveTrigger;

    // Update is called once per frame
    void Update()
    {
        if (MoveTrigger == 1){
        EnemySpeed = 0.02f;
        transform.position = Vector3.MoveTowards(transform.position, ThePlayer.transform.position, EnemySpeed);    
    }
    }
}
