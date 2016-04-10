using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(CBezier))]
public class CLaserRenderer : MonoBehaviour {

    // 노드 개수가 많을수록 부드러운 곡선이 됨.
	[SerializeField]
	int node_count;

	LineRenderer line_renderer;
	CBezier bezier;

	void Awake()
	{
		this.line_renderer = gameObject.GetComponent<LineRenderer> ();
		this.bezier = gameObject.GetComponent<CBezier> ();
		set_vertex_count (node_count + 1);
	}


	void set_vertex_count(int count)
	{
		this.line_renderer.SetVertexCount (count);
	}


	// Update is called once per frame
	void Update () {
		for (int i = 0; i <= node_count; ++i)
		{
			Vector3 to = this.bezier.bezier(i / (float)node_count);
			this.line_renderer.SetPosition (i, to);
		}
	}
}
