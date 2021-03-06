﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;
    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

	// Use this for initialization
	void Start () {
        this.myHingeJoint = GetComponent<HingeJoint>();
        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
	}
	
	// Update is called once per frame
	void Update () {
        //左矢印キーを押したとき左フリッパーを動かす
		if(Input.GetKeyDown(KeyCode.LeftArrow)&& tag == "LeftFripperTag") {
            SetAngle(flickAngle);
        }
        //右矢印キーを押したとき右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow)&& tag == "RightFripperTag") {
            SetAngle(flickAngle);
        }
        //矢印キーを離したときフリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow)&& tag == "LeftFripperTag") {
            SetAngle(defaultAngle);  
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)&& tag == "RightFripperTag") {
            SetAngle(defaultAngle);
        }
	}
    public void SetAngle(float angle) {
        //フリッパーの傾きを設定
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
