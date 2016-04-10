using UnityEngine;
using System.Collections;

public class CRandomMovement : MonoBehaviour {

    Vector3 velocity;
    
	// Use this for initialization
	void Start () {
        float rnd = UnityEngine.Random.Range(3, 7);
        int direction = UnityEngine.Random.Range(0, 1);
        if (direction == 0)
        {
            rnd *= -1.0f;
        }

        this.velocity = new Vector3(rnd, 0.0f, 0.0f);
    }


    void OnEnable()
    {
        StartCoroutine(routine_movement());
    }


    IEnumerator routine_movement()
    {
        float duration = UnityEngine.Random.Range(1.0f, 2.0f);
        float time = 0.0f;
        float direction = 1.0f;
        while (true)
        {
            transform.position += this.velocity * direction * Time.deltaTime;
            time += Time.deltaTime;

            if (time >= duration)
            {
                direction *= -1.0f;
                time = 0.0f;
            }

            yield return null;
        }
    }


	// Update is called once per frame
	void Update () {
        
	}
}
