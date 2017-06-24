using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentEffect : MonoBehaviour {

	public Vector3 startPosition = new Vector3(0, 0, 0);
	public Vector3 stopPosition = new Vector3(10f, 0, 0);
	public Vector3 direction = new Vector3(1, 0, 0);
	public float minSpeed = 0.03f;
	public float maxSpeed = 0.05f;

	public int objectPoolSize = 5;

	public GameObject[] assets;

	private GameObject[] objectPool;
	private Vector3[] speeds;

	void Start () 
	{
		objectPool = new GameObject[objectPoolSize];
		speeds = new Vector3[objectPoolSize];

		for(int i = 0; i < objectPool.Length; i++)
		{
			GameObject toInstantiate = Instantiate(assets[Random.Range(0, assets.Length)], this.gameObject.transform);
			objectPool[i] = toInstantiate;
			speeds[i] = direction * Random.Range(minSpeed, maxSpeed);
		}
	}
	

	void Update () 
	{
		for(int i = 0; i < objectPool.Length; i++)
		{
			Transform temp = objectPool[i].transform;
			temp.Translate(speeds[i]);

			if(temp.position.x > stopPosition.x)
			{
				temp.position = startPosition;
			}
		}	
	}
}
