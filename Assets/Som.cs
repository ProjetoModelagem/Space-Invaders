using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Som : MonoBehaviour
{
    public AudioSource source;
    
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D (Collision2D coll) {
        source.Play();
    }

}
