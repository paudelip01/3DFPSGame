using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinCollection : MonoBehaviour
{
    public int coinCollection = 0;
    [SerializeField] Text text ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void UpdateCoin(){
        coinCollection ++;
        text.text ="Coins:"+ coinCollection.ToString();
    }
}
