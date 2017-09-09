using UnityEngine;
using System.Collections;

public class EnemyIA : MonoBehaviour {
    public Transform target;
    public int runSpeed;
    public int ratationSpeed;
	public int maxDistance;

    private Transform myTransform;

    void Awake() {
        myTransform = transform;
    }
	// Use this for initialization
	void Start () {
        GameObject go = GameObject.FindGameObjectWithTag("Player");

        target = go.transform;

		maxDistance = 0;

	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawLine(target.transform.position, myTransform.position, Color.yellow);

        //Look at target
        myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position - myTransform.position), ratationSpeed * Time.deltaTime);

		if (Vector3.Distance (target.position, myTransform.position) > maxDistance) {
			//Run towards target
			myTransform.position += myTransform.forward * runSpeed * Time.deltaTime;
		}
	}
}
