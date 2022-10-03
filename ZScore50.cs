using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZScore50 : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void DeductPoints ( int DamageAmount)
    {
        GlobalScore.CurrentScore += 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
