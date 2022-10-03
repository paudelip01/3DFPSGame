using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour
{
    // Start is called before the first frame update
public GameObject ThePlayer;

void  Update ()
    {

    transform.LookAt(ThePlayer.transform);
    }
}
