using UnityEngine;
using System.Collections;

public class Shield : Piece {

	void OnTriggerEnter(Collider bolt)
	{
		
		Vector3 direction = (bolt.gameObject.GetComponent<LaserBolt>()).direction;
		Destroy (bolt.gameObject);
		if ((int)(this.transform.eulerAngles.y) == 0 && direction != new Vector3(0,0,1))
			Destroy(this.gameObject);
		else if ((int)(this.transform.eulerAngles.y) == 90 && direction != new Vector3(1,0,0))
			Destroy(this.gameObject);
		else if ((int)this.transform.eulerAngles.y == 180 && direction != new Vector3(0,0,-1))
			Destroy(this.gameObject);
		else if ((int)(this.transform.eulerAngles.y) == 270 && direction != new Vector3(-1,0,0))
			Destroy(this.gameObject);
		return;
	}
	
}
