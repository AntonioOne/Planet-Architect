using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Status : MonoBehaviour {
	public int status;
	public int oldStatus;
	public Vector3 coords;
	public GameObject tileObject;
	//public bool bTileClicked;
	public bool highlighted;
	public List<Vector3> neighboors;//координаты в массиве соседских тайлов
	void Start () {		
		//Debug.Log(bTileClicked.ToString());
		//neighboors = new List<Vector3>();
		oldStatus = -1;
		ActivList = gameObject.GetComponentsInChildren<Activation>();
		foreach (Activation obj in ActivList)
		{
			obj.parentStatus = this.GetComponent<Status>();
			//obj.TileStatus = status;//передаем информацию о текущем статусе
			//obj.coords = coords;
			//obj.highlighted = highlighted;
		}
		
	}
	
	
	
	
	
	public void OnMouseDown() {
		//Debug.Log ("Hi!");
		//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		GameObject cam =  GameObject.Find("Camera");
		ArcballCamera tempAC = cam.GetComponent<ArcballCamera>();
		tempAC.bTileClicked = true;//блокируем вращение камеры
		
		
	}
	
	public void OnMouseUp()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);//луч для определения, где была отпущена мышка
		Physics.Raycast(ray,out hit);//определем...
		//Debug.Log (transform.position.ToString());
		//Debug.Log((hit.transform.position == transform.position).ToString());
		GameObject tempMenu = GameObject.Find("Menu");
		MenuShow tempMS = tempMenu.GetComponent<MenuShow>();//обращаемся к меню. Мало ли. может пригодится
		if(hit.transform.position == transform.position)///Если мышка была отпущена над этим тайлом
		{
			Debug.Log ("Count of neighboors = " + neighboors.Count.ToString());//пусть эото пока останется здесь
			List<int> evolv = new List<int>();//список возможных "эволюций"
			if(tempMS._showMenu && tempMS.x==(int)coords.x && tempMS.y==(int)coords.y && tempMS.z ==(int)coords.z)//проверка на то, что уже отображается меню этого тайла
				tempMS._showMenu = false;//отключаем тогда меню
			else
			{
				tempMS._showMenu = true;//иначе показываем его меню, так как до этого отображалось меню другого тайла
				tempMS.x=(int)coords.x;
				tempMS.y=(int)coords.y;
				tempMS.z=(int)coords.z;
			}
			if(tempMS._showMenu)
			{
				GameObject temp = GameObject.Find("Rules");
				Rule tempRule = temp.GetComponent<Rule>();
				evolv = tempRule.evolves((int)coords.x,(int)coords.y,(int)coords.z);//составляем список возможных эволюций
				tempMS.upgrade = evolv;//и передаем его в компонент меню
			}
		}
		else
		{
			tempMS._showMenu = false;//здесь будет обработка перемещения тайлов
		}
		
		//Здесь была информация о эволюциях, выводимая в консоль. Пусть пока побудет здесь. Вдруг пригодится?
		//Debug.Log("Status = " + status.ToString());
		/*for(int i = 0; i < evolv.Count; ++i){
			Debug.Log("->" + evolv[i].ToString());
			//Debug.Log(bTileClicked.ToString());
		}
		if(evolv.Count == 0)
			Debug.Log("No any update available");*/
	}
	
	//Пытаемся получить доступ к дочерним объектам
	public Activation [] ActivList;
	// Update is called once per frame
	void Update () {
		//foreach (Activation obj in ActivList)
		//{
		//	obj.TileStatus = status;//передаем информацию о текущем статусе
			//obj.coords = coords;//эта строчка понадобится позже
		//	obj.highlighted = highlighted;//и информацию о том, является ли тайл подсвеченным
		//}
	}
} 