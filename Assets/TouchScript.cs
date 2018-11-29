using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;
    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;
    int leftFrigerId = 0;
    int rightFrigerId = 0;
    // Use this for initialization
    void Start()
    {
        this.myHingeJoint = GetComponent<HingeJoint>();
        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

        Debug.Log("Screen Width : " + Screen.width);
    }

    // Update is called once per frame
    void Update()   {
        Debug.LogFormat("タッチ数:{0}", Input.touchCount);
        for (int i = 0; i < Input.touchCount; i++)
        {
            var id = Input.touches[i].fingerId;
            var pos = Input.touches[i].position;
            Debug.LogFormat("{0} - x:{1}, y:{2}", id, pos.x, pos.y);

            if (Input.touches[i].phase == TouchPhase.Began){

                if (pos.x < Screen.width / 2 && tag == "LeftFripperTag"){
                    leftFrigerId = id;
                    SetAngle(flickAngle);
                }
                if (pos.x > Screen.width / 2 && tag == "RightFripperTag"){
                    rightFrigerId = id;
                    SetAngle(flickAngle);
                }
            }else if(Input.touches[i].phase == TouchPhase.Ended) {
                if( id == leftFrigerId && tag == "LeftFripperTag") {
                    SetAngle(defaultAngle);
                }else if( id == rightFrigerId && tag == "RightFripperTag") {
                    SetAngle(defaultAngle);
                }
            }
        }
    }
    public void SetAngle(float angle)
    {
        //フリッパーの傾きを設定
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}