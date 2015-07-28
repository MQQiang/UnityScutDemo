using UnityEngine;
using System.Collections;

public class TestOrder : MonoBehaviour {


    void Awake()
    {
        Debug.Log(this.name + "Awake");
    }
	// Use this for initialization
	void Start () {
		Debug.Log(this.name + "Start");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(this.name + "Update");
	}

	void LateUpdate()
	{
		Debug.Log(this.name + "LateUpdate");
	}
}
