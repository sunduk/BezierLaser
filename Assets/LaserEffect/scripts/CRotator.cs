using UnityEngine;
using System.Collections;

public class CRotator : MonoBehaviour {

    float angle;


	// Use this for initialization
	void Start () {
        this.angle = UnityEngine.Random.Range(45.0f, 90.0f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, 1), this.angle * Time.deltaTime);
	}
}
