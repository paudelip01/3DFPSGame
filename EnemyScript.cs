using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
     public int EnemyHealth = 10;
     public GameObject TheZombie;
    CoinCollection coinCollection;
    void DeductPoints (int DamageAmount) 
{
        EnemyHealth -= DamageAmount;
 }

    // Update is called once per frame
    void Update () 
  {
        if (EnemyHealth <= 0) {
          FindObjectOfType<CoinCollection>().UpdateCoin();
          this.GetComponent<ZombieFollow>().enabled = false;
          TheZombie.GetComponent<Animation>().Play("Dying");
          EnemyHealth = 1;
          StartCoroutine(EndZombie());
  }
  }
  IEnumerator EndZombie()
  {
    yield return new WaitForSeconds(1.5f);
    Destroy(gameObject); 
  }
 
}
