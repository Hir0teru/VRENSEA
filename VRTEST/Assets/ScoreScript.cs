using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour {
    public static ScoreScript instance;
    public int score;
    public int maxScore;
    // Use this for initialization
    void Start () {
        score = 0;
        maxScore = 4;
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
