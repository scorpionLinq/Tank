﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int nBulletType; //子弹类型 1、角色 2、敌人
    private int nSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        //transform.gameObject.SendMessage("SetBulletType", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * nSpeed * Time.deltaTime, Space.Self);
    }

    public void SetPalyerType()
    {
        SetBulletType(1);
    }

    private void SetBulletType(int n)
    {
        //Debug.Log("SetBulletType: " + n);
        nBulletType = n;
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Player":
                if (nBulletType == 2)
                {
                    collision.SendMessage("Dead");
                    Destroy(transform.gameObject);
                }
                break;
            case "Enemy":
                if (nBulletType == 1)
                {
                    collision.SendMessage("Dead");
                    Destroy(transform.gameObject);
                }
                break;
            case "Brick":
                if (nBulletType == 1)
                {
                    collision.SendMessage("Dead");
                }
                Destroy(transform.gameObject);
                break;
            case "Icon":
                if (nBulletType == 1)
                {
                    collision.SendMessage("Dead");
                }
                Destroy(transform.gameObject);
                break;
            case "Grass":
                break;
            case "River":
                break;
            default:
                break;
        }
    }
}