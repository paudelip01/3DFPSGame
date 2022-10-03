using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalHealth : MonoBehaviour
{
    public static int PlayerHealth= 10;
    public int InternalHealth;
    public GameObject HealthDisplay;
    public GameObject GameOver;
    [SerializeField] GameInfoSaver gameInfoSaver;
   int totalCoin = 0;
   Player player;
   void Start(){
       player = gameInfoSaver.ReadPlayerFile();
            totalCoin = player.TotalCoins();

   }
    // Update is called once per frame
    void Update()
    {
        InternalHealth = PlayerHealth;
        HealthDisplay.GetComponent<Text>().text= "Health" + PlayerHealth;

        if (PlayerHealth == 0)
        {
            Time.timeScale = 0;
            GameOver.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            gameInfoSaver.SaveInfo(new Player(FindObjectOfType<GlobalScore>().InternalScore,totalCoin + FindObjectOfType<CoinCollection>().coinCollection,player.Gun1(),player.Gun2(),player.Gun3(),player.Gun4()));
        }
    }
}
