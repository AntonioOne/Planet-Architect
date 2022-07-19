using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Rule : MonoBehaviour {
	
	public bool flagBreak;
	
	public struct neigh
	{
		public int type;
		public int countMin;
		public int countMax;
		public neigh (int a, int b,int c)
		{
			type = a;
			countMin = b;
			countMax = c;
		}
	};
	public struct rule
	{
		public int type;
		public int typeEv;
		public List<neigh> contr;
		public rule (int a, int b, List<neigh> c)
		{
			type = a;
			typeEv = b;
			//Debug.Log ("Count of Contr = " + c.Count.ToString());
			contr = c;
			//Debug.Log ("Count of ContrAfter = " + contr.Count.ToString());
		}
		public rule (rule f)
		{
			type = f.type;
			typeEv = f.typeEv;
			contr = f.contr;
		}
	};
	
	
	public int i,j,t;
	public int st;
	public List<rule> Rules = new List<rule>();
	public List<neigh> ListTemp;
	
	public List<int> evolves(int x, int y,int z)
	{
		//Debug.Log("Count of contribution ib the begin = " + Rules[0].contr.Count.ToString());
		List<int> result = new List<int>();
		GameObject temp = GameObject.Find("Field1");
		FieldFill temp1 = temp.GetComponent<FieldFill>();
		Status temp2 = temp1.obArray[x,y,z].GetComponent<Status>();
		Status temp3;
		//if(flagBreak)
		//	Debug.Log("Status=" + temp2.status.ToString());
		for(int l = 0; l < Rules.Count; ++l)
		//Rules.ForEach(delegate(rule rT)
		{
			if(Rules[l].type == temp2.status)
			{
				bool flag = true;
			//	Debug.Log ("Count of contribution in cyrcle = " + Rules[l].contr.Count.ToString());
				for(int k = 0; k < Rules[l].contr.Count; ++k)
				//rT.contr.ForEach(delegate()
				{
					if(flagBreak)
						Debug.Log("Count of contributions = " + Rules[l].contr.Count.ToString());
					neigh tempNeigh = Rules[l].contr[k];
					//Debug.Log ("flag = "+flag.ToString());
					if(!flag)
						break;
					t = 0;
					
					//for (j = -1; j <= 1; ++j)
					for(i = 0; i < temp2.neighboors.Count;++i)
					{
						//for(i = -1; i <= 1; ++i)
						{
							//if(flagBreak)
								
								//Debug.Break();
						//	Debug.Log ("i=" + i.ToString()+" j=" +j.ToString());
							//if(x+i>=0 && x+i<temp1.count && y+j>=0 && y+j<temp1.count && (i!=0 || j!=0))
							
							{
								
								temp3 = temp1.obArray[(int)temp2.neighboors[i].x,(int)temp2.neighboors[i].y,(int)temp2.neighboors[i].z].GetComponent<Status>();
								if(flagBreak)Debug.Log ("x+i=" + (x+i).ToString() + " y+j=" + (y+j).ToString()+ " status=" + temp3.status.ToString());
								st = temp3.status;
								if(temp3.status == tempNeigh.type)
								{
									++t;
									if(flagBreak)Debug.Log ("t="+t.ToString());
								}
								if(t > tempNeigh.countMax)
								{
									flag = false;
									break;
								}
							}
						}
						if(!flag)
							break;
					}
					if(t < tempNeigh.countMin)
						flag = false;
					if(t > tempNeigh.countMax)
						flag = false;
				}
				if(flag)
					if(result.IndexOf (Rules[l].typeEv) == -1)
						result.Add (Rules[l].typeEv);
			}
		}
		return result;
	}
	
	
	void Start () {
		//neigh neighStr;
		//rule ruleStr;
		ListTemp = new List<neigh>();
		flagBreak = false;
		
		//пример создания правила
		//0 -> 1, если вокруг есть хотя бы одна еденица
		ListTemp.Add(new neigh(1,1,8));
		Rules.Add(new rule(0,1,ListTemp));
		ListTemp = new List<neigh>();
		
		ListTemp.Add(new neigh(2,1,8));
		Rules.Add(new rule(1,2,ListTemp));
		ListTemp = new List<neigh>();
		
		ListTemp.Add(new neigh(3,1,8));
		Rules.Add(new rule(2,3,ListTemp));
		ListTemp = new List<neigh>();
		
		
		ListTemp.Add(new neigh(0,0,1));
		Rules.Add(new rule(3,0,ListTemp));
		ListTemp = new List<neigh>();
		
		//Заготовка для правила копировать и изменять все, что в /* */
		// a - требуемый тип соседа. b - минимальное количество соседей этого типа для апгрейда. c - максимальное .... d - тип, из которого тайл эволюционирует, e - конечный тип тайла.
		/*
		ListTemp = new List<neigh>();
		
		ListTemp.Add(new neigh(a,b,c));
		//...
		Rules.Add(new rule(d,e,ListTemp));
		ListTemp = new List<neigh>();
		*/
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
