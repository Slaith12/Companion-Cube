using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class StartGame : MonoBehaviour
{

    //public UnityEvent ButtonClick;

    //void Awake()
    //{
        //if(ButtonClick == null)
        //{
            //ButtonClick = new UnityEvent();a test hi mmm
       // }
    //}

    void OnMouseUp()
    {
        SceneManager.LoadScene("Scenes/Level 1");
    }

    //extra comment

}
