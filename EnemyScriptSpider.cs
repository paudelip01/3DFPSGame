using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptSpider : MonoBehaviour
{
    // Start is called before the first frame update
     public int EnemyHealth = 15;
     public GameObject TheSpider;

    void DeductPoints (int DamageAmount) 
{
        EnemyHealth -= DamageAmount;
 }

    // Update is called once per frame
    void Update () 
  {
        if (EnemyHealth <= 0) {
          FindObjectOfType<CoinCollection>().UpdateCoin();
          this.GetComponent<SpiderFollow>().enabled = false;
          TheSpider.GetComponent<Animation>().Play("die");
          EnemyHealth = 1;
          StartCoroutine(EndZombie());
  }
  }
  IEnumerator EndZombie()
  {
    yield return new WaitForSeconds(1);
    Destroy(gameObject); 
  }
 
}
