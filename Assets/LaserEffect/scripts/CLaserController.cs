using UnityEngine;
using System.Collections;

public class CLaserController : MonoBehaviour {

	[SerializeField]
	Transform[] enemies;

	CBezier bezier;


	void Start()
	{
		this.bezier = GetComponentInChildren<CBezier> ();
	}


	void OnEnable()
	{
		StartCoroutine (routine_shoot ());
	}


	IEnumerator routine_shoot()
	{
		yield return new WaitForSeconds (1.0f);

        Transform end_point = this.bezier.Points[this.bezier.Points.Length - 1];

        float prev_time = Time.time;
		int target = 0;
		while (true)
		{
            // Follow the target.
            end_point.position = this.enemies [target].position;

            // Change the target after 3 seconds.
            if (Time.time - prev_time > 3.0f)
            {
                prev_time = Time.time;
                ++target;

                if (target >= this.enemies.Length)
                {
                    target = 0;
                }
            }
			yield return null;
		}
	}
}
