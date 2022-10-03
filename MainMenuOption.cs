using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOption : MonoBehaviour
{
    [SerializeField] GameObject Shop;
    [SerializeField] GameObject noShop;
    [SerializeField] GameObject shopCanvas;
    [SerializeField] ShopManager shopManager;
    bool isShop = false;
  

    public void CreditScene()
    {
        SceneManager.LoadScene(2);
    }

public void Quit(){
    Application.Quit();
}
    public void ShopScene()
    {
        isShop = !isShop;
        if(isShop){
            Shop.SetActive(true);
            noShop.SetActive(false);
            shopCanvas.SetActive(true);
        }else{
            Shop.SetActive(false);
            noShop.SetActive(true);
            shopCanvas.SetActive(false);

        }
       
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
