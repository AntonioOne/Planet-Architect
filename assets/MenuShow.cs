using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MenuShow : MonoBehaviour {
	public bool _showMenu;
	public int x,y,z;
	// Use this for initialization
	//List<Rect> Rects;
	//List<label> labels;
	void Start () {
		_showMenu = false;
	//	Rects = new List<Rect>();
	//	labels = new List<label>();
	}
	
	public List<int> upgrade;
	Vector3 _position;
	public void OnGUI()
    {
		
		GameObject tempRules = GameObject.Find("Rules");
		Rule tRule = tempRules.GetComponent<Rule>();
		//tRule.flagBreak = true;
		Rect rect = new Rect(100,20,50,20);
		//if(GUI.Button(rect,"Debug"))
		//{
		//	tRule.flagBreak = !tRule.flagBreak;
		//}
		
        // если следует отобразить имя
        if (_showMenu)
        {
			GameObject tempField = GameObject.Find("Field1");
			FieldFill tempFieldFill = tempField.GetComponent<FieldFill>();
			Status tempStatus = tempFieldFill.obArray[x,y,z].GetComponent<Status>();
			_position = Camera.main.WorldToScreenPoint(tempFieldFill.obArray[x,y,z].transform.position);
			_position.y = Screen.height - _position.y - 10;
			_position.x -= 25;
            // считаем позицию
			for(int i = 0; i < upgrade.Count; ++i)
			{
            	rect = new Rect(_position.x, _position.y, 50f, 20f);
 			//	Rects.Add(rect);
				_position.y += 30f;
            	// создаем стиль с выравниванием по центру
           		//GUIStyle label = new GUIStyle(GUI.skin.label);
				
				if(GUI.Button(rect,upgrade[i].ToString()))
				{
					/*GameObject tempField = GameObject.Find("Field1");
					FieldFill tempFieldFill = tempField.GetComponent<FieldFill>();
					Status tempStatus = tempFieldFill.obArray[x,y,0].GetComponent<Status>();*/
					tempStatus.status = upgrade[i];
					_showMenu = false;
				}
				
            	//label.alignment = TextAnchor.MiddleCenter;
 				
				//labels.Add(label);
            	// выводим имя объекта с созданным стилем, чтобы имя было выведено по центру
            	//GUI.Label(rect, upgrade[i], label);
			}
			//_position.x -= 50;
			_position.y += 10;
			rect = new Rect(_position.x, _position.y, 50f, 20f);
			GUI.Label(rect,"(" + x.ToString() + "," +y.ToString() + "," +z.ToString() + "," + ")");
        }
		rect = new Rect(0,0,100,20);
		GUI.Label(rect,Time.deltaTime.ToString());
    }
	// Update is called once per frame
	void Update () {
		GameObject tempField = GameObject.Find("Field1");
		FieldFill tempFieldFill = tempField.GetComponent<FieldFill>();
		Status tempStatus = tempFieldFill.obArray[x,y,z].GetComponent<Status>();
			
			for(int i = 0; i < tempFieldFill.count; ++i)
				for(int j = 0; j < tempFieldFill.count; ++j)
					for(int k = 0; k < 6; ++k)
			{
				tempStatus = tempFieldFill.obArray[i,j,k].GetComponent<Status>();
				tempStatus.highlighted = false;
				//obArray[i,j,k].transform.localScale = new Vector3(1,1,(float)(0.2 + someScript.status*0.2));
			}
			tempStatus = tempFieldFill.obArray[x,y,z].GetComponent<Status>();
			if(_showMenu)
			for(int i = 0; i < tempStatus.neighboors.Count; ++i)
			{
				Status tempNeigh = tempFieldFill.obArray[(int)tempStatus.neighboors[i].x,(int)tempStatus.neighboors[i].y,(int)tempStatus.neighboors[i].z].GetComponent<Status>();
				tempNeigh.highlighted = true;
			}
		
	}
}
