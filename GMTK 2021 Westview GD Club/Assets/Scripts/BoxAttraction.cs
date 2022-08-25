using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAttraction : MonoBehaviour
{
    private bool isAttracting;
    public float power;
    public Transform boxes;
    //public Transform box2;
    //public Transform box3;
    public Transform player;
    public float attract;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAttracting == false)
        {
            isAttracting = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isAttracting == true)
        {
            isAttracting = false;
        }
    }
    void FixedUpdate()
    {
        if(isAttracting)
        {
            boxes.position = Vector2.MoveTowards(boxes.position, player.position, attract * power * Time.deltaTime);
        }
    }
}
