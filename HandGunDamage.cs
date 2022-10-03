using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using  UnityEngine.UI;


public class HandGunDamage : MonoBehaviour
{
    // Start is called before the first frame update
   public int DamageAmount;
   public float TargetDistance;
   public float AllowedRange = 15.0f;
   public RaycastHit hit;
   public GameObject TheBullet;
   public GameObject TheBlood;
   public GameObject TheBloodGreen;

   public bool weaponLock = true; 
    Gun player;
    void Start()
    {
        DamageAmount = 5;
           string path = Application.persistentDataPath + "/"+transform.name+".sav";
       // soundController = FindObjectOfType<SoundController>();
        if (File.Exists(path))
        {

            using (FileStream stream = File.Open(path, FileMode.Open))
            {

                BinaryFormatter formatter = new BinaryFormatter();
                player = (Gun)formatter.Deserialize(stream);
                
            }
        }
           
        else
        {
           // firstGame = true;
            player = new Gun(true);
            SaveInfo(player);
            //Kinesi chai SaveInfo(new Gun(false))
        }
        if(!player.IsLocked())
        weaponLock = false;
    }
    public void SaveInfo(Gun player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/"+transform.name+".sav";
        using (FileStream stream = File.Open(path, FileMode.Create))
        {

            formatter.Serialize(stream, player);
           
        }
    }
    // Update is called once per frame
       void Update () {
  
     if(GlobalAmmo.LoadedAmmo >= 1){
    if(Input.GetButtonDown("Fire1")) {
                RaycastHit Shot;

         if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Shot)) {
                TargetDistance = Shot.distance;

             if (TargetDistance < AllowedRange) {
                 

                if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward),out hit))
                {
                    if (hit.transform.tag == "Zombie")
                    {
                        Instantiate(TheBlood, hit.point, Quaternion.identity);
                    }

                    if (hit.collider.tag == "ZombieHead")
                    {
                        DamageAmount =10;
                        Instantiate(TheBlood, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                    }

                     if (hit.transform.tag == "Spider")
                    {
                        Instantiate(TheBloodGreen, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                    }

                    if (hit.transform.tag == "Untagged")
                    {   
                    Instantiate(TheBullet, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                }
                }
                Shot.transform.SendMessage("DeductPoints", DamageAmount);
                DamageAmount=5;

                 }
             }
         }
     }
 }


}
