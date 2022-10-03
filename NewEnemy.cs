using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour
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
          this.GetComponent<NewZombieScript>().enabled = false;
          TheZombie.GetComponent<Animation>().Play("Z_FallingForward");
          EnemyHealth = 1;
  }
  }
  IEnumerator EndZombie()
  {
    yield return new WaitForSeconds(3);
    Destroy(gameObject); 
  }
 
}
