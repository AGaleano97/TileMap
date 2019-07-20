using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move8 : MonoBehaviour
{
     private Vector2 pos1 = new Vector2(58,-2);
    private Vector2 pos2 = new Vector2(55,-2);
    public float speed = 1.0f;
 
     void Update() {
         transform.position = Vector2.Lerp (pos1, pos2, Mathf.PingPong(Time.time*speed, 1.0f));
     }
}
