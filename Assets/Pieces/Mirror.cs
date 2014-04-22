
using System;
using UnityEngine;

public class Mirror : Piece
{


	public override string ToString ()
	{
		return "M";
	}

	void OnTriggerEnter(Collider collider)
	{
		LaserBolt bolt = collider.GetComponent<LaserBolt>();
		bolt.gameObject.transform.position = this.transform.position;
		Vector3 direction = bolt.direction;
		print(this.transform.eulerAngles.y);
		print (direction);
		print (bolt.direction);
		switch ((int)this.transform.eulerAngles.y)
		{
		case 0:
			print ("Case 0");
			if (direction == Vector3.left)
			{
				bolt.direction = new Vector3(0,0,-1);
			}
			else if (direction == Vector3.forward)
			{

				bolt.direction = new Vector3(1,0,0);
			}
			else
			{
				Destroy(bolt.gameObject);
				Destroy(this.gameObject);
			}
			break;
		case 90:
			if (direction == new Vector3(1,0,0))
			{
				bolt.direction = new Vector3(0,0,-1);
			}
			else if (direction == new Vector3(0,0,1))
			{
				bolt.direction = new Vector3(-1,0,0);
			}
			else
			{
				Destroy(bolt.gameObject);
				Destroy(this.gameObject);
			}
			break;
		case 180:
			if (direction == new Vector3(1,0,0))
			{
				bolt.direction = new Vector3(0,0,1);
			}
			else if (direction == new Vector3(0,0,-1))
			{
				bolt.direction = new Vector3(-1,0,0);
			}
			else
			{
				Destroy(bolt.gameObject);
				Destroy(this.gameObject);
			}
			break;
		case 270:
			if (direction == new Vector3(-1,0,0))
			{
				bolt.direction = new Vector3(0,0,1);
			}
			else if (direction == new Vector3(0,0,-1))
			{
				bolt.direction = new Vector3(1,0,0);
			}
			else
			{
				Destroy(bolt.gameObject);
				Destroy(this.gameObject);
			}
			break;
		default:
			Destroy(bolt.gameObject);
			Destroy(this.gameObject);
			break;
		}
	}
}


