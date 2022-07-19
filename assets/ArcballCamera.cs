using UnityEngine;
using System.Collections;

public class ArcballCamera : MonoBehaviour {
	
	public float radius = 10.0f,
                minRadius=1.5f,
                maxRadius=20.0f,
                scale = 0.002f,
				speed = 10f;
        public GameObject target;
        private float targetRadius = 10.0f,
                mouseX=0.0f,
                mouseZ=0.0f;
        private Vector3 up = new Vector3 (0.0f, 1.0f, 0.0f),
                right = new Vector3 (0.0f, 0.0f, 1.0f),
                newPosition = Vector3.zero;
	// Use this for initialization
	public Vector3 targetVector;
	void Start () {
		this.transform.position = new Vector3 (0f, 0.0f, radius);
		targetRadius = radius;
	}
	public bool bTileClicked;
	// Update is called once per frame
	void Update () {
	 		newPosition = transform.position;
		
			//GameObject tile = GameObject.Find("Tile");
			//Status st = tile.GetComponent<Status>();
			
			//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//RaycastHit hit;
				if(!Input.GetMouseButton (0) && bTileClicked)
					bTileClicked = false;
                if (Input.GetMouseButton (0) && /*!Physics.Raycast(ray) &&*/ (bTileClicked == false)) 
					{
                        mouseX=Input.GetAxis ("Mouse X");
                        mouseZ=Input.GetAxis ("Mouse Y");
					}
                 else {
                        mouseX=Mathf.Lerp(mouseX, 0.0f, 0.2f);
                        mouseZ=Mathf.Lerp(mouseZ, 0.0f, 0.2f);
                }
                       
                newPosition += right * mouseX * radius/speed
                        + up * mouseZ * -radius/speed;
                newPosition.Normalize ();
                right = Vector3.Cross (up, newPosition);
                up = Vector3.Cross (newPosition, right);
               
                right.Normalize();
                up.Normalize();
               
                if (Input.GetAxis ("Mouse ScrollWheel") > 0.0f) {
                        targetRadius = Mathf.Max(targetRadius/1.1f, minRadius);
                } else if (Input.GetAxis ("Mouse ScrollWheel") < 0.0f) {
                        targetRadius = Mathf.Min(targetRadius*1.1f, maxRadius);
                }
                radius = Mathf.Lerp (radius, targetRadius, 0.1f);
                newPosition.Normalize();
                transform.position = newPosition * radius;
               
               
                transform.LookAt (new Vector3 (0.0f, 0.0f, 0.0f), up);
				//transform.LookAt(targetVector,up);
	}
}
