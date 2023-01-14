using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSc : MonoBehaviour
{
   static public bool Active;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Disk")
        {
            Active = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Disk")
        {
            Active = false;
        }
    }
}
