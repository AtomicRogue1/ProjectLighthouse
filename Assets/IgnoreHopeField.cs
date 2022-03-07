using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreHopeField : MonoBehaviour
{
    [SerializeField]
    Transform HopeField;

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreCollision(HopeField.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
