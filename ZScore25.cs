using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZScore25 : MonoBehaviour
{
     
    
    // Start is called before the first frame update
    void DeductPoints ( int DamageAmount)
    {
        GlobalScore.CurrentScore += 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
