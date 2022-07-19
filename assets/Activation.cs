using UnityEngine;
using System.Collections;

public class Activation : MonoBehaviour {
	public Status parentStatus;
	public int TileStatus;
	public int number;
	//public GameObject parentObject;
	public bool highlighted;
	
	public Vector3 coords;
	void OnMouseDown()
	{
		//GameObject tempField = GameObject.Find("Field1");
		//FieldFill tempFieldFill = tempField.GetComponent<FieldFill>();
		//Status tempStatus =   tempFieldFill.obArray[(int)coords.x,(int)coords.y,(int)coords.z].GetComponent<Status>();
		parentStatus.OnMouseDown();//запуск функции из родительского объекта
	}
	
	void OnMouseUp()
	{
		//GameObject tempField = GameObject.Find("Field1");
		//FieldFill tempFieldFill = tempField.GetComponent<FieldFill>();
		//Status tempStatus =   tempFieldFill.obArray[(int)coords.x,(int)coords.y,(int)coords.z].GetComponent<Status>();
		parentStatus.OnMouseUp();//запуск функции из родительского объекта
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//this.renderer.enabled = (parentStatus.status == number);//если этот объект - не тот, который нужен, не прорисовываем его
		if(parentStatus.highlighted)
					this.GetComponent<Renderer>().material.color = Color.white;//подсветка
				else
					this.GetComponent<Renderer>().material.color = Color.gray;//нет подсветки
	}
}
