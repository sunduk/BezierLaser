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
            // 베지어 곡선의 마지막 점을 타겟위치로 갱신하여 계속 따라다니게 함.
            end_point.position = this.enemies [target].position;

            // 3초가 지나면 타겟 변경.
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
