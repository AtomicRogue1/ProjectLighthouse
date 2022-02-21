using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToGame : MonoBehaviour
{
    // [SerializeField]
    // Image LoadingScreen;
    public void LoadLevel()
    {
        Invoke("Play",1f);
    }
    public void Play()
    {
        SceneManager.LoadScene("Lobby");
    }
    // public void LoadingLevel()
    // {
    //     Invoke("Play",5f);
    //     float Velocity=0;
    //     float smoothTime=0.1f;
    //     float col;
    //     while(LoadingScreen.color.a!=1)
    //     {
    //         col=Mathf.SmoothDamp(LoadingScreen.color.a, 1, ref Velocity, smoothTime);
    //         LoadingScreen.color.a=col;
    //     }
    // }
}
