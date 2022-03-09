using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLift : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    MainCharacter mc;
    void Start()
    {
        anim=GetComponent<Animator>();        
    }

    void NextLevel()
    {
        SceneManager.LoadScene("GiantBedroom");
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Player")
        {
            anim.SetBool("openDoor",true);
            mc.moveSpeed=0;
            Invoke("NextLevel",2.5f);
        }
    }
}
