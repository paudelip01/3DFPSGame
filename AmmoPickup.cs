﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour 
{
     public AudioSource AmmoPickupSound;
    void OnTriggerEnter(Collider other)
    {   
        AmmoPickupSound.Play();
         if (GlobalAmmo.LoadedAmmo == 0)
        {
            GlobalAmmo.LoadedAmmo += 50;
            this.gameObject.SetActive(false);
        }
        else
        {
            GlobalAmmo.CurrentAmmo += 50;
            this.gameObject.SetActive(false);
        }
    }
}