using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldAxes : MonoBehaviour
{
	private float size = 10.0f;

	void DrawAxes ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine(Vector3.right * size, Vector3.zero);

		Gizmos.color = Color.green;
		Gizmos.DrawLine(Vector3.up * size, Vector3.zero);

		Gizmos.color = Color.blue;
		Gizmos.DrawLine(Vector3.forward * size, Vector3.zero);
		Gizmos.color = Color.white;
	}
}


//  public static void DrawLine(Vector3 p1, Vector3 p2, float width)
//  {
//      int count = Mathf.CeilToInt(width); // how many lines are needed.
//      if(count ==1)
//          Gizmos.DrawLine(p1,p2);
//      else
//      {
//          Camera c = Camera.current;
//          if (c == null)
//          {
//              Debug.LogError("Camera.current is null")
//              return;
//          }
//          Vector3 v1 = (p2 - p1).normalized; // line direction
//          Vector3 v2 = (c.position - p1).normalized; // direction to camera
//          Vector3 n = Vector3.Cross(v1,v2); // normal vector
//          for(int i = 0; i < count; i++)
//          {
//              Vector3 o = n* width ((float)i/(count-1) - 0.5f);
//              Gizmos.DrawLine(p1+o,p2+o);
//          }
//      }
//  }