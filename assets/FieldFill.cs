using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FieldFill : MonoBehaviour {
	public List<Texture> textureList;
	public GameObject thePrefab;
	public List<GameObject> objectList;
	//public GameObject thePrefab2;
	public int count;
	GameObject cam = null;
	public bool useTextures;
	//int[,] array;
	//GameObject [,] obArray;
	//GameObject instance;
	public GameObject [,,] obArray;
	int i,j;
	int CountOfTypes;
	
	
	void Addneighs(Status st)
	{
		Vector3 tempVect = new Vector3(0,0,0);
		//if(st.coords.x != 0f && st.coords.x != count-1)
	//		if(st.coords.y != 0f && st.coords.y != count-1)
		{
			#region Neighs
			#region Z0Ready
			if(st.coords.z == 0f)
			{
				if(st.coords.x + 1 < count)
				{
					st.neighboors.Add(st.coords + new Vector3(1,0,0));
					if(st.coords.y + 1 < count)
						st.neighboors.Add(st.coords + new Vector3(1,1,0));
					else
					{
						st.neighboors.Add(st.coords + new Vector3(1,0,4));
					}
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(st.coords + new Vector3(1,-1,0));
					else
					{
						st.neighboors.Add(st.coords + new Vector3(1,count-1,5));
					}
				}
				else
				{
					tempVect = new Vector3(count-1-st.coords.y,count-1,3);
					st.neighboors.Add(tempVect);
					if(st.coords.y + 1 < count)
						st.neighboors.Add(tempVect + new Vector3(-1,0,0));
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(tempVect + new Vector3(1,0,0));
				}
				
				if(st.coords.x - 1 >= 0)
				{
					
					st.neighboors.Add(st.coords + new Vector3(-1,0,0));
					if(st.coords.y + 1 < count)
						st.neighboors.Add(st.coords + new Vector3(-1,1,0));
					else
					{
						st.neighboors.Add(st.coords + new Vector3(-1,0,4));
					}
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(st.coords + new Vector3(-1,-1,0));
					else
					{
						st.neighboors.Add(st.coords + new Vector3(-1,count-1,5));
					}
				}
				else
				{
					tempVect = new Vector3(count-1-st.coords.y,count-1,2);
					st.neighboors.Add(tempVect);
					if(st.coords.y + 1 < count)
						st.neighboors.Add(tempVect + new Vector3(-1,0,0));
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(tempVect + new Vector3(1,0,0));
				}
				
				if(st.coords.y + 1 < count)
					st.neighboors.Add(st.coords + new Vector3(0,1,0));
				else
					{
						st.neighboors.Add(st.coords + new Vector3(0,0,4));
					}
				if(st.coords.y - 1 >= 0)
					st.neighboors.Add(st.coords + new Vector3(0,-1,0));
				else
					{
						st.neighboors.Add(st.coords + new Vector3(0,count-1,5));
					}
			}
			#endregion
			#region Z1Ready
			if(st.coords.z == 1f)
			{
				if(st.coords.x + 1 < count)
				{
					st.neighboors.Add(st.coords + new Vector3(1,0,0));
					if(st.coords.y + 1 < count)
						st.neighboors.Add(st.coords + new Vector3(1,1,0));
					else
					{
						st.neighboors.Add(st.coords + new Vector3(1,-(count - 1),3));
					}
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(st.coords + new Vector3(1,-1,0));
					else
					{
						st.neighboors.Add(st.coords + new Vector3(1,0,4));
					}
				}
				else
				{
					tempVect = new Vector3(count-1-st.coords.y,0,3);
					st.neighboors.Add(tempVect);
					if(st.coords.y + 1 < count)
						st.neighboors.Add(tempVect + new Vector3(-1,0,0));
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(tempVect + new Vector3(1,0,0));
				}
				
				if(st.coords.x - 1 >= 0)
				{
					st.neighboors.Add(st.coords + new Vector3(-1,0,0));
					if(st.coords.y + 1 < count)
						st.neighboors.Add(st.coords + new Vector3(-1,1,0));
					else
					{
						st.neighboors.Add(st.coords + new Vector3(-1,-(count - 1),3));
					}
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(st.coords + new Vector3(-1,-1,0));
					else
					{
						st.neighboors.Add(st.coords + new Vector3(-1,0,4));
					}
				}
				else
				{
					tempVect = new Vector3(count-1-st.coords.y,0,2);
					st.neighboors.Add(tempVect);
					if(st.coords.y + 1 < count)
						st.neighboors.Add(tempVect + new Vector3(-1,0,0));
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(tempVect + new Vector3(1,0,0));
				}
				
				if(st.coords.y + 1 < count)
					st.neighboors.Add(st.coords + new Vector3(0,1,0));
				else
					{
						st.neighboors.Add(st.coords + new Vector3(0,-(count - 1),3));
					}
				if(st.coords.y - 1 >= 0)
					st.neighboors.Add(st.coords + new Vector3(0,-1,0));
				else
					{
						st.neighboors.Add(st.coords + new Vector3(0,0,4));
					}
			}
			#endregion
			#region Z2
			if(st.coords.z == 2f)
			{
				if(st.coords.x + 1 < count)
				{
					st.neighboors.Add(st.coords + new Vector3(1,0,0));
					if(st.coords.y + 1 < count)
						st.neighboors.Add(st.coords + new Vector3(1,1,0));
					else
					{
						//st.neighboors.Add(st.coords + new Vector3(1,0,4));
					}
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(st.coords + new Vector3(1,-1,0));
					else
					{
						//st.neighboors.Add(st.coords + new Vector3(1,count-1,5));
					}
				}
				else
				{
					/*tempVect = new Vector3(count-1-st.coords.y,count-1,3);
					st.neighboors.Add(tempVect);
					if(st.coords.y + 1 < count)
						st.neighboors.Add(tempVect + new Vector3(-1,0,0));
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(tempVect + new Vector3(1,0,0));*/
				}
				
				if(st.coords.x - 1 >= 0)
				{
					
					st.neighboors.Add(st.coords + new Vector3(-1,0,0));
					if(st.coords.y + 1 < count)
						st.neighboors.Add(st.coords + new Vector3(-1,1,0));
					else
					{
					//	st.neighboors.Add(st.coords + new Vector3(-1,0,4));
					}
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(st.coords + new Vector3(-1,-1,0));
					else
					{
					//	st.neighboors.Add(st.coords + new Vector3(-1,count-1,5));
					}
				}
				else
				{
					/*tempVect = new Vector3(count-1-st.coords.y,count-1,2);
					st.neighboors.Add(tempVect);
					if(st.coords.y + 1 < count)
						st.neighboors.Add(tempVect + new Vector3(-1,0,0));
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(tempVect + new Vector3(1,0,0));*/
				}
				
				if(st.coords.y + 1 < count)
					st.neighboors.Add(st.coords + new Vector3(0,1,0));
				else
					{
						//st.neighboors.Add(st.coords + new Vector3(0,0,4));
					}
				if(st.coords.y - 1 >= 0)
					st.neighboors.Add(st.coords + new Vector3(0,-1,0));
				else
					{
						//st.neighboors.Add(st.coords + new Vector3(0,count-1,5));
					}
			}
			#endregion
			#region Z3
			if(st.coords.z == 3f)
			{
				if(st.coords.x + 1 < count)
				{
					st.neighboors.Add(st.coords + new Vector3(1,0,0));
					if(st.coords.y + 1 < count)
						st.neighboors.Add(st.coords + new Vector3(1,1,0));
					else
					{
						//st.neighboors.Add(st.coords + new Vector3(1,0,4));
					}
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(st.coords + new Vector3(1,-1,0));
					else
					{
						//st.neighboors.Add(st.coords + new Vector3(1,count-1,5));
					}
				}
				else
				{
					/*tempVect = new Vector3(count-1-st.coords.y,count-1,3);
					st.neighboors.Add(tempVect);
					if(st.coords.y + 1 < count)
						st.neighboors.Add(tempVect + new Vector3(-1,0,0));
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(tempVect + new Vector3(1,0,0));*/
				}
				
				if(st.coords.x - 1 >= 0)
				{
					
					st.neighboors.Add(st.coords + new Vector3(-1,0,0));
					if(st.coords.y + 1 < count)
						st.neighboors.Add(st.coords + new Vector3(-1,1,0));
					else
					{
					//	st.neighboors.Add(st.coords + new Vector3(-1,0,4));
					}
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(st.coords + new Vector3(-1,-1,0));
					else
					{
					//	st.neighboors.Add(st.coords + new Vector3(-1,count-1,5));
					}
				}
				else
				{
					/*tempVect = new Vector3(count-1-st.coords.y,count-1,2);
					st.neighboors.Add(tempVect);
					if(st.coords.y + 1 < count)
						st.neighboors.Add(tempVect + new Vector3(-1,0,0));
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(tempVect + new Vector3(1,0,0));*/
				}
				
				if(st.coords.y + 1 < count)
					st.neighboors.Add(st.coords + new Vector3(0,1,0));
				else
					{
						//st.neighboors.Add(st.coords + new Vector3(0,0,4));
					}
				if(st.coords.y - 1 >= 0)
					st.neighboors.Add(st.coords + new Vector3(0,-1,0));
				else
					{
						//st.neighboors.Add(st.coords + new Vector3(0,count-1,5));
					}
			}
			#endregion
			#region Z4
			if(st.coords.z == 4f)
			{
				if(st.coords.x + 1 < count)
				{
					st.neighboors.Add(st.coords + new Vector3(1,0,0));
					if(st.coords.y + 1 < count)
						st.neighboors.Add(st.coords + new Vector3(1,1,0));
					else
					{
						//st.neighboors.Add(st.coords + new Vector3(1,0,4));
					}
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(st.coords + new Vector3(1,-1,0));
					else
					{
						//st.neighboors.Add(st.coords + new Vector3(1,count-1,5));
					}
				}
				else
				{
					/*tempVect = new Vector3(count-1-st.coords.y,count-1,3);
					st.neighboors.Add(tempVect);
					if(st.coords.y + 1 < count)
						st.neighboors.Add(tempVect + new Vector3(-1,0,0));
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(tempVect + new Vector3(1,0,0));*/
				}
				
				if(st.coords.x - 1 >= 0)
				{
					
					st.neighboors.Add(st.coords + new Vector3(-1,0,0));
					if(st.coords.y + 1 < count)
						st.neighboors.Add(st.coords + new Vector3(-1,1,0));
					else
					{
					//	st.neighboors.Add(st.coords + new Vector3(-1,0,4));
					}
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(st.coords + new Vector3(-1,-1,0));
					else
					{
					//	st.neighboors.Add(st.coords + new Vector3(-1,count-1,5));
					}
				}
				else
				{
					/*tempVect = new Vector3(count-1-st.coords.y,count-1,2);
					st.neighboors.Add(tempVect);
					if(st.coords.y + 1 < count)
						st.neighboors.Add(tempVect + new Vector3(-1,0,0));
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(tempVect + new Vector3(1,0,0));*/
				}
				
				if(st.coords.y + 1 < count)
					st.neighboors.Add(st.coords + new Vector3(0,1,0));
				else
					{
						//st.neighboors.Add(st.coords + new Vector3(0,0,4));
					}
				if(st.coords.y - 1 >= 0)
					st.neighboors.Add(st.coords + new Vector3(0,-1,0));
				else
					{
						//st.neighboors.Add(st.coords + new Vector3(0,count-1,5));
					}
			}
			#endregion
			#region Z5
			if(st.coords.z == 5f)
			{
				if(st.coords.x + 1 < count)
				{
					st.neighboors.Add(st.coords + new Vector3(1,0,0));
					if(st.coords.y + 1 < count)
						st.neighboors.Add(st.coords + new Vector3(1,1,0));
					else
					{
						//st.neighboors.Add(st.coords + new Vector3(1,0,4));
					}
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(st.coords + new Vector3(1,-1,0));
					else
					{
						//st.neighboors.Add(st.coords + new Vector3(1,count-1,5));
					}
				}
				else
				{
					/*tempVect = new Vector3(count-1-st.coords.y,count-1,3);
					st.neighboors.Add(tempVect);
					if(st.coords.y + 1 < count)
						st.neighboors.Add(tempVect + new Vector3(-1,0,0));
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(tempVect + new Vector3(1,0,0));*/
				}
				
				if(st.coords.x - 1 >= 0)
				{
					
					st.neighboors.Add(st.coords + new Vector3(-1,0,0));
					if(st.coords.y + 1 < count)
						st.neighboors.Add(st.coords + new Vector3(-1,1,0));
					else
					{
					//	st.neighboors.Add(st.coords + new Vector3(-1,0,4));
					}
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(st.coords + new Vector3(-1,-1,0));
					else
					{
					//	st.neighboors.Add(st.coords + new Vector3(-1,count-1,5));
					}
				}
				else
				{
					/*tempVect = new Vector3(count-1-st.coords.y,count-1,2);
					st.neighboors.Add(tempVect);
					if(st.coords.y + 1 < count)
						st.neighboors.Add(tempVect + new Vector3(-1,0,0));
					if(st.coords.y - 1 >= 0)
						st.neighboors.Add(tempVect + new Vector3(1,0,0));*/
				}
				
				if(st.coords.y + 1 < count)
					st.neighboors.Add(st.coords + new Vector3(0,1,0));
				else
					{
						//st.neighboors.Add(st.coords + new Vector3(0,0,4));
					}
				if(st.coords.y - 1 >= 0)
					st.neighboors.Add(st.coords + new Vector3(0,-1,0));
				else
					{
						//st.neighboors.Add(st.coords + new Vector3(0,count-1,5));
					}
			}
			#endregion
			#endregion
		}
	}
	
	Status someScript;
//	GameObject bb;
	// Use this for initialization
	void Start () {
		CountOfTypes = Mathf.Max (textureList.Count,objectList.Count) ;
		//array = new int[count, count];
		obArray = new GameObject[count, count,6];
		//obArray = new GameObject[count,count];
		cam =  GameObject.Find("Camera");
		ArcballCamera tempAC = cam.GetComponent<ArcballCamera>();
		tempAC.radius = Mathf.Max( 2*count,2);
		tempAC.minRadius = Mathf.Max( count * 1.3f,1.3f);
		tempAC.maxRadius = Mathf.Max( 3*count,3);
		Transform trans = cam.GetComponent<Transform>();
		//float x = count ;
		trans.position = new Vector3(0,0,2*count);
 		float t = count / 2f;
		//instance = new GameObject();
		for(i = 0; i < count; ++i)
			for(j = 0; j < count; ++j)
		{			
			 //instance = Instantiate(thePrefab,new Vector3(i,j,0),new Quaternion(0,0,0,0)) as GameObject;
			obArray[i,j,0] = Instantiate(thePrefab,new Vector3((float)(count-1)/2-i,-(float)(count-1)/2+j,t),Quaternion.Euler(180,0,180)) as GameObject;
			someScript = obArray[i,j,0].GetComponent<Status>();
      		someScript.status = Random.Range(0,CountOfTypes);//array[i,j];
			someScript.coords = new Vector3(i,j,0);
			Addneighs(someScript);
			
			
			obArray[i,j,1] = Instantiate(thePrefab,new Vector3((float)(count-1)/2-i,-(float)(count-1)/2+j,-t),Quaternion.Euler(0,0,180)) as GameObject;
			someScript = obArray[i,j,1].GetComponent<Status>();
      		someScript.status = Random.Range(0,CountOfTypes);//array[i,j];
			someScript.coords = new Vector3(i,j,1);
			Addneighs(someScript);
			
			obArray[i,j,2] = Instantiate(thePrefab,new Vector3(t,(float)(count-1)/2-i,-(float)(count-1)/2+j),Quaternion.Euler(180,90,180)) as GameObject;
			someScript = obArray[i,j,2].GetComponent<Status>();
			someScript.status = Random.Range(0,CountOfTypes);//array[i,j];
			someScript.coords = new Vector3(i,j,2);
			Addneighs(someScript);
			
			obArray[i,j,3] = Instantiate(thePrefab,new Vector3(-t,(float)(count-1)/2-i,-(float)(count-1)/2+j),Quaternion.Euler(0,90,0)) as GameObject;
			someScript = obArray[i,j,3].GetComponent<Status>();
			someScript.status = Random.Range(0,CountOfTypes);//array[i,j];
			someScript.coords = new Vector3(i,j,3);
			Addneighs(someScript);
			
			obArray[i,j,4] = Instantiate(thePrefab,new Vector3((float)(count-1)/2-i,t,-(float)(count-1)/2+j),Quaternion.Euler(90,0,0)) as GameObject;
			someScript = obArray[i,j,4].GetComponent<Status>();
      		someScript.status = Random.Range(0,CountOfTypes);//array[i,j];
			someScript.coords = new Vector3(i,j,4);
			Addneighs(someScript);
			
			obArray[i,j,5] = Instantiate(thePrefab,new Vector3((float)(count-1)/2-i,-t,-(float)(count-1)/2+j),Quaternion.Euler(270,0,0)) as GameObject;
			someScript = obArray[i,j,5].GetComponent<Status>();
      		someScript.status = Random.Range(0,CountOfTypes);//array[i,j];
			someScript.coords = new Vector3(i,j,5);
			Addneighs(someScript);
			//obArray[i,j,5] = thePrefab2;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		//if(useTextures)
		for(i = 0; i < count; ++i)
			for(j = 0; j < count; ++j)
				for(int k = 0; k < 6; ++k)
		{
			someScript = obArray[i,j,k].GetComponent<Status>();
			//obArray[i,j,k].renderer.material.mainTexture = textureList[someScript.status];
					
			if(someScript.oldStatus!=someScript.status)
					{
						Debug.Log ((someScript.oldStatus!=someScript.status).ToString());
						Destroy(someScript.tileObject);
						someScript.tileObject = Instantiate(objectList[someScript.status],obArray[i,j,k].transform.position,obArray[i,j,k].transform.rotation) as GameObject;
						Activation tempAct = someScript.tileObject.GetComponent<Activation>();
						tempAct.parentStatus = someScript;
						someScript.oldStatus = someScript.status;
					}
	//		if(someScript.highlighted)
	//				obArray[i,j,k].renderer.material.color = Color.white;
	//			else
//					obArray[i,j,k].renderer.material.color = Color.gray;
			//obArray[i,j,k].transform.localScale = new Vector3(1,1,(float)(0.2 + someScript.status*0.2));
		}
	}
}
