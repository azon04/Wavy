using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Animal_spirit : Powerups
{

    bool active;
    int pathcnt = 0;
    Transform[] path1 = new Transform[2];
    int timer = 0;
    // Use this for initialization
    void Start()
    {
        active = false;
        path1[0] = GameObject.FindGameObjectsWithTag("Path1")[0].transform.GetChild(0).transform;
        path1[0].GetChild(0).gameObject.SetActive(false);
        path1[1] = GameObject.FindGameObjectsWithTag("Path1")[0].transform.GetChild(1).transform;
        path1[1].GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {

            float speed = 0.1f;
            Vector3 dir = Vector3.Normalize(path1[pathcnt].position - this.transform.position);
            float a = Math.Abs(path1[pathcnt].position.z - this.transform.position.z);
            if (Math.Abs(path1[pathcnt].position.x - this.transform.position.x) > 0.1 || Math.Abs(path1[pathcnt].position.z - this.transform.position.z) > 0.1)
            {
                this.transform.position += dir * speed;
            }
            else
            {
                timer++;
                if (timer < 500)
                {
                    path1[pathcnt].GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    path1[0].GetChild(0).gameObject.SetActive(false);
                    path1[1].GetChild(0).gameObject.SetActive(false);
                }
                if (pathcnt < path1.Length - 1)
                    pathcnt++;
                
            }
        }
    }

    protected override void Awake()
    {

    }

    protected override void OnTriggerEnter(Collider Collide)
    {
        //float speed = 0.001f;
        if (Collide.gameObject.tag == "Player")
        {
            active = true;
        }

    }

}