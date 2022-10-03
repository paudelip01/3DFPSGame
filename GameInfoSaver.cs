using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using  UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameInfoSaver : MonoBehaviour
{
    Player player;
    [SerializeField] Text HighScore;
    [SerializeField] Text TotalCoin;
    [SerializeField] ShopManager shopManager;
    [SerializeField] bool game = false;
    int gunCost = 1;
    // Start is called before the first frame update
    void Start(){
        string path = Application.persistentDataPath + "/player.sav";
       // soundController = FindObjectOfType<SoundController>();
        if (File.Exists(path))
        {

            using (FileStream stream = File.Open(path, FileMode.Open))
            {

                BinaryFormatter formatter = new BinaryFormatter();
                player = (Player)formatter.Deserialize(stream);
                
            }
        }
           
        else
        {
           // firstGame = true;
            player = new Player(0,0,true,false,false,false);
            SaveInfo(player);
        }
        if(!game){

HighScore.text = player.HighSco().ToString();TotalCoin.text ="Coins:"+ player.TotalCoins().ToString();

        }
    }
  public void SaveInfo(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sav";
        using (FileStream stream = File.Open(path, FileMode.Create))
        {

            formatter.Serialize(stream, player);
           
        }
    }
    public void BuyGun(){
        if(!shopManager.noBought){
 shopManager.currentGun.transform.SetParent(null);
        DontDestroyOnLoad(shopManager.currentGun);
        SceneManager.LoadScene(1);
        return;
        }
       
        gunCost = shopManager.changeGun * 10 + 10;
        if(player.TotalCoins()>gunCost){

            switch (shopManager.changeGun+1){
                case 1:
                if(player.Gun1()) return;
                SaveInfo(new Player(player.HighSco(),player.TotalCoins()-gunCost,true,player.Gun2(),player.Gun3(),player.Gun4()));
                break;

                case 2:
                if(player.Gun2()) return;
                print("Bought");
               
                SaveInfo(new Player(player.HighSco(),player.TotalCoins()-gunCost,player.Gun1(),true,player.Gun3(),player.Gun4()));
                break;

                case 3:
                if(player.Gun3()) return;
                SaveInfo(new Player(player.HighSco(),player.TotalCoins()-gunCost,player.Gun1(),player.Gun2(),true,player.Gun4()));
                break;

                case 4:
                if(player.Gun4()) return;
                SaveInfo(new Player(player.HighSco(),player.TotalCoins()-gunCost,player.Gun1(),player.Gun2(),player.Gun3(),true));
                break;

            }
            TotalCoin.text ="Coins:"+  (player.TotalCoins()-gunCost).ToString();
                shopManager.player = ReadPlayerFile();
                player = ReadPlayerFile();
                shopManager.CheckInfo();

        }
    }
     public Player ReadPlayerFile()
    {
        string path = Application.persistentDataPath + "/player.sav";
        if (File.Exists(path))
            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (Player)formatter.Deserialize(stream);
            }
        else
        {
            return null;
        }
    }
}
