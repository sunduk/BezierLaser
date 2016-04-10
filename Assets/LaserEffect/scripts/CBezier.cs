using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CBezier : MonoBehaviour {

    [SerializeField]
    Transform[] points;
	public Transform[] Points
	{
		get
		{
			return this.points;
		}
	}


	// Update is called once per frame
	void Update () {
        int count = 20;
        Vector3 prev_pos = this.points[0].position;
        for (int i = 0; i <= count; ++i)
        {
            Vector3 to = bezier(i / (float)count);
            Debug.DrawLine(prev_pos, to);

            prev_pos = to;
        }
	}


	public Vector3 bezier(float t)
	{
		if (this.points.Length == 3)
		{
			return bezier2 (t);
		}
		else if (this.points.Length == 4)
		{
			return bezier3 (t);
		}

		return Vector3.zero;
	}


    public Vector3 bezier2(float t)
    {
        Vector3 a = this.points[0].position;
        Vector3 b = this.points[1].position;
        Vector3 c = this.points[2].position;

        Vector3 aa = a + (b - a) * t;
        Vector3 bb = b + (c - b) * t;
        return aa + (bb - aa) * t;
    }


    Vector3 bezier3(float t)
    {
        Vector3 a = this.points[0].position;
        Vector3 b = this.points[1].position;
        Vector3 c = this.points[2].position;
        Vector3 d = this.points[3].position;

        Vector3 aa = a + (b - a) * t;
        Vector3 bb = b + (c - b) * t;
        Vector3 cc = c + (d - c) * t;

        Vector3 aaa = aa + (bb - aa) * t;
        Vector3 bbb = bb + (cc - bb) * t;
        return aaa + (bbb - aaa) * t;
    }
}
