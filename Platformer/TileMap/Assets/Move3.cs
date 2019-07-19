using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move3 : MonoBehaviour
{
     private Vector2 pos1 = new Vector2(8,0);
    private Vector2 pos2 = new Vector2(6,0);
    public float speed = 1.0f;
 
     void Update() {
         transform.position = Vector2.Lerp (pos1, pos2, Mathf.PingPong(Time.time*speed, 1.0f));
     }
}
