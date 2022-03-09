using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsequenceCam : MonoBehaviour
{
    public bool ActivateCinematic;
    [SerializeField]
    float duration;
    [SerializeField]
    float destroyCamIn;
    [SerializeField]
    GameObject consequenceCam;
    [SerializeField]
    GameObject currentCam;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        ActivateCinematic=false;
    }

    void PlayCinematic()
    {
        if(ActivateCinematic==true)
        {
            anim.Play("SequenceBegin");
            Invoke("EndCinematic",duration);
        }
    }
    void EndCinematic()
    {
        anim.Play("SequenceOver");
        ActivateCinematic=false;
        Destroy(gameObject,destroyCamIn);
        Destroy(consequenceCam,destroyCamIn);
    }

    void Update()
    {
        PlayCinematic();
        if(ActivateCinematic)
        {
        consequenceCam.SetActive(true);
        currentCam.SetActive(false);
        }
        else
        {
        consequenceCam.SetActive(false);
        currentCam.SetActive(true);
        }
    }

}
