using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    
    private GameObject scoreText;
    int a = 0;            
    int b = 0;
    int c = 0;
    int d = 0;
	// Use this for initialization
	void Start () {
        this.scoreText = GameObject.Find("ScoreText");
		
	}
	
	// Update is called once per frame
	void Update () {
        this.scoreText.GetComponent<Text>().text = "Score"+(a+b+c+d);
             
	}
    private void OnCollisionEnter(Collision other){
       
       if(other.gameObject.tag =="SmallStarTag")     {　　　　　//SmallStarにあたると１加算
            this.a += 1;　
        }else if(other.gameObject.tag=="LargeStarTag" ) {　　　 //LargeStarにあたると２０加算　
            this.b += 20;
        }else if(other.gameObject.tag == "SmallCloudTag") {　　 //SmallCloudにあたると４０加算
            this.c += 40;
        }else if(other.gameObject.tag == "LargeCloudTag") {　　 //LargeCloudにあたると１００加算
            this.d += 100;
        }else {
        }
       

        }
    
}
