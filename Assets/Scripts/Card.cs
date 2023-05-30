using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rotatetor))]
public class Card : MonoBehaviour
{
    private Rigidbody rb;
    private BoxCollider collider;
    private Rotatetor rotatetor;
    private void Start()
    {
        rb=GetComponent<Rigidbody>(); 
        collider=GetComponent<BoxCollider>();   
        rotatetor=GetComponent<Rotatetor>();
        rotatetor.speed = 1+(InputManager.instance.Level/10f);
    }
    public void Rotate()
    {
        rotatetor.rotate=true;
        rb.useGravity = false;
        collider.enabled = false;
        rotatetor.enabled = true;
    }
    public void Freeze()
    {
        rotatetor.rotate = false;
        rb.useGravity=true;
        collider.enabled = true;
        rotatetor.enabled = false;
    }
    public void MakeKinematic()
    {
        rb.isKinematic=true;
       
    }
}
