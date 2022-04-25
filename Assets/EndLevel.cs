using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    LeverScript leverAttached;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(leverAttached.isActivated)
        {
            rb2d.velocity=new Vector2(0,moveSpeed);
            Invoke("EndGame",5f);
        }
    }

    void EndGame()
    {
        SceneManager.LoadScene("EndScreen");
    }
}
