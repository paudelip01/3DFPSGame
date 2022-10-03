using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewZombieScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ThePlayer;
    public float TargetDistance;
    public float AllowedRange = 1000;
    public GameObject TheEnemy;
    public float EnemySpeed;
    public int AttackTrigger;
    public RaycastHit Shot;
    public int IsAttacking;
    public GameObject ScreenFlash;
    public AudioSource Hurt01;
    public AudioSource Hurt02;
    public AudioSource Hurt03;
    public int PainSound;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(ThePlayer.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection (Vector3.forward),out Shot))
        {
            TargetDistance = Shot.distance;
            if (TargetDistance < AllowedRange)
            {
                EnemySpeed= 0.05f;

                if (AttackTrigger == 0)
                {
                    TheEnemy.GetComponent<Animation>().Play("Z_Walk");
                    transform.position = Vector3.MoveTowards (transform.position, ThePlayer.transform.position, Time.deltaTime);    
                }
            }
            else {
                EnemySpeed = 0;
                TheEnemy.GetComponent<Animation>().Play("Z_Idle");
            }

        }

        if (AttackTrigger == 1)
        {
            if (IsAttacking == 0)
            {
                StartCoroutine(EnemyDamage());
            }
            EnemySpeed = 0;
            TheEnemy.GetComponent<Animation>().Play("Z_Attack");
        }
    }

    void OnTriggerEnter()
    {
        AttackTrigger = 1;
    }

    void OnTriggerExit()
    {
        AttackTrigger = 0;
    }

    IEnumerator EnemyDamage()
    {
        IsAttacking = 1;
        PainSound = Random.Range(1,4);
        yield return new WaitForSeconds(0.4f);
        ScreenFlash.SetActive (true);
        GlobalHealth.PlayerHealth -= 2;
        if (PainSound == 1)
        {
            Hurt01.Play();
        }

        if (PainSound == 2)
        {
            Hurt02.Play();
        }

        if (PainSound == 3)
        {
            Hurt03.Play();
        }

        yield return new WaitForSeconds(0.05f);
        ScreenFlash.SetActive(false);
        yield return new WaitForSeconds(0.75f);
        IsAttacking = 0;
    }
}