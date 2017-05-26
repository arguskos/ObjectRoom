using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


[System.Serializable]
public class DataSaver
{
	public bool UsePhyics;//{ get; set; }
	public float PosX;// { get; set; }
	public float PosY;
	public float PosZ;

	public float RotX;// { get; set; }
	public float RotY;
	public float RotZ;
	public float RotW;

	public int ID;
	[System.NonSerialized]
	public GameObject Rep;
	public DataSaver(bool usePhyics, int id, GameObject rep)
	{
		UsePhyics = usePhyics;
		Rep = rep;
		UpdatePosRot();
		ID = id;
	}

	public Vector3 GetPos()
	{
		return new Vector3(PosX,PosY,PosZ);
	}

	public void SetPos(Vector3 pos)
	{
		PosX = pos.x;
		PosY = pos.y;
		PosZ = pos.z;


	}

	public void UpdatePosRot()
	{
		// PosX = Rep.transform.position.x;
		// PosY = Rep.transform.position.y;
		// PosZ = Rep.transform.position.z;


		RotX = Rep.transform.rotation.x;
		RotY = Rep.transform.rotation.y;
		RotZ = Rep.transform.rotation.z;
		RotW = Rep.transform.rotation.w;
	}
	public void SetRot(Quaternion rot)
	{
		RotX = rot.x;
		RotY = rot.y;
		RotZ = rot.z;
		RotW = rot.w;

	}
	public Quaternion GetRot()
	{
		return new Quaternion(RotX, RotY, RotZ,RotW);
	}
}
public class Grid : MonoBehaviour
{
	private readonly List<KeyCode> _keyCodes = new List<KeyCode>();
	private PrebsList _prefabsList;

	public int Cols = 4;

	//public GameObject[] Prefabs;
	//public GameObject[] PrefabsPhysics;
	//public GameObject[] PrefabsGrid;
	//public List<List<KeyValuePair<int, GameObject>>> Objects = new List<List<KeyValuePair<int, GameObject>>>();
	public List<DataSaver> Objects2= new List<DataSaver>(); 
	public int Rows = 6;
	public float Size;
	public int StartIndexHeight;

	public int StartIndexWidth;

	// Use this for initialization
	private void Start()
	{
		_keyCodes.Add(KeyCode.Q);
		_keyCodes.Add(KeyCode.W);
		_keyCodes.Add(KeyCode.E);

		_keyCodes.Add(KeyCode.R);
		_keyCodes.Add(KeyCode.A);
		_keyCodes.Add(KeyCode.S);

		_keyCodes.Add(KeyCode.D);
		_keyCodes.Add(KeyCode.F);
		_keyCodes.Add(KeyCode.Z);

		_keyCodes.Add(KeyCode.X);
		_keyCodes.Add(KeyCode.C);
		_keyCodes.Add(KeyCode.V);

		_keyCodes.Add(KeyCode.T);
		_keyCodes.Add(KeyCode.Y);
		_keyCodes.Add(KeyCode.U);
		_keyCodes.Add(KeyCode.I);


		_keyCodes.Add(KeyCode.G);
		_keyCodes.Add(KeyCode.H);
		_keyCodes.Add(KeyCode.J);
		_keyCodes.Add(KeyCode.K);

		_keyCodes.Add(KeyCode.B);
		_keyCodes.Add(KeyCode.N);
		_keyCodes.Add(KeyCode.M);
		_keyCodes.Add(KeyCode.Comma);


		_prefabsList = PrebsList.Instance;
		//InitGrid();
		if (Objects2==null)
		{
			Objects2= new List<DataSaver>();
		}
		//foreach (var list in Objects)
		//{
		//	foreach (var rods in list)
		//	{
		//		if (rods.Value.GetComponent<RodsBase>())
		//		{
		//			rods.Value.GetComponent<RodsBase>().Init();
		//		}
		//	}
		//}
		CreateSaved();	
		foreach (var list in Objects2)
		{
			
				if ( list.Rep.GetComponent<RodsBase>())
				{
					list.Rep.GetComponent<RodsBase>().Init();
				}
			
		}
	}

	//public  void InitGrid()
	//{
	//	var grid = GameObject.FindGameObjectWithTag("DeleteOnKey");
	//	print(grid.transform.childCount + " " + Rows * Cols);
	//	if (Objects.Count == 0)
	//	{
	//		for (var i = 0; i < Rows; i++)
	//		{
	//			//Objects.Add(new List<KeyValuePair<int, GameObject>>());
	//			for (var jIndex = 0; jIndex < Cols; jIndex++)
	//			{
	//			//	Objects[i].Add(new KeyValuePair<int, GameObject>(0,
	//				//	grid.transform.GetChild(i * Cols + jIndex).gameObject));
	//			}
	//		}
	//	}
	//}

	private GameObject  CreateObject( int id,Vector3 pos,Quaternion rot)
	{
		var obj = Instantiate(_prefabsList.GetPrefabs()[id], pos,rot);
		//obj.transform.parent = temp.transform;
		//\Objects[i].Add(new KeyValuePair<int, GameObject>(0, obj));
		//Objects2.Add(new DataSaver(true, 0, obj));

		return obj;
	}

	public void ClearObjectList()
	{
		foreach (var obj in Objects2)
		{
			DestroyImmediate(obj.Rep);
		}
		Objects2.Clear();
	}
	public void CreateGrid()
	{
		Objects2.Clear();
			
		var temp = new GameObject("temp");
		temp.tag = "DeleteOnKey";
		//if (Objects == null)
		//	Objects = new List<List<KeyValuePair<int, GameObject>>>();
		if (_prefabsList == null)
			_prefabsList = FindObjectOfType<PrebsList>();
		int id = 0;
		Vector3 rot = Quaternion.identity.eulerAngles;
		for (var i = 0; i < Rows; i++)
		{
			//Objects.Add(new List<KeyValuePair<int, GameObject>>());
			for (var j = 0; j < Cols; j++)
			{
				if (_prefabsList.UsePhysics)
				{
					if (i == StartIndexWidth && j == StartIndexHeight)
					{
						id = 0;
					}
					else
					{

						id = Random.Range(1,3);
						//if (id==1)
							//rot =new Vector3(0, Random.Range(0, 360), 0);
					}
				}

				else
				{
					id = 2;
					//Objects[i].Add(new KeyValuePair<int, GameObject>(1, obj));
				}
				var obj = CreateObject(id, new Vector3(i * Size, 0, j * Size), Quaternion.identity);
				obj.transform.eulerAngles = rot;
				obj.transform.parent = temp.transform;
				Objects2.Add(new DataSaver(_prefabsList.UsePhysics, id, obj));

			}
		}
	}

	public void CreateSaved()
	{
		Load();
		var temp = new GameObject("temp");
		temp.tag = "DeleteOnKey";
		//if (Objects == null)
		//	Objects = new List<List<KeyValuePair<int, GameObject>>>();
		if (_prefabsList == null)
			_prefabsList = FindObjectOfType<PrebsList>();
		int id = 0;
		Vector3 rot = Quaternion.identity.eulerAngles;
		for ( int i =0 ; i<Objects2.Count;i++)
		{

			Objects2[i].Rep =CreateObject(Objects2[i].ID, Objects2[i].GetPos(), Objects2[i].GetRot());
			Objects2[i].Rep.transform.parent = temp.transform;
			// if (i/Rows== StartIndexWidth&& i%Cols==StartIndexHeight)
			// {
			// 	print(string.Format("{0} ___ {1}",i/Rows,i%Cols));
			// 	Objects2[i].Rep.GetComponent<LaserPhysics>().Activated=true;	
			// }
			//TODO UNHARDCODE
			if (i==0)
			{
				Objects2[i].Rep.GetComponent<LaserPhysics>().Activated=true;	
			}
		}
	}

	public void UpdateVaribles()
	{
		for (int i = 0; i < Objects2.Count; i++)
		{
			Objects2[i].UpdatePosRot();
			//Objects2[i].SetRot(Objects2[i].GetRot());
		}


	}

	public void EditorLoad()
	{
		CreateSaved();
	}

	public void CicleEditor(int index)
	{
		//Objects2[index]		//Objects2[index]
		Objects2[index].ID++;
		Objects2[index].ID %= GameObject.FindObjectOfType<PrebsList>().GetPrefabs().Length;
		Vector3 pos = Objects2[index].GetPos();
		Quaternion rot = Objects2[index].GetRot();
		


		if (Objects2[index].Rep!=null)
		{
			Destroy(Objects2[index].Rep);
		}
		Objects2[index].Rep=CreateObject(Objects2[index].ID, pos, rot);
		Objects2[index].Rep.transform.parent = GameObject.FindGameObjectWithTag("DeleteOnKey").transform;
	}
	public void Save()
	{
		print("save");
		UpdateVaribles();
		string path = Application.dataPath + "/" + "level" + (0).ToString() + ".txt";
		FileStream fs = new FileStream(path, FileMode.Create);
		BinaryFormatter bf = new BinaryFormatter();
		bf.Serialize(fs, Objects2);
		fs.Close();
	}

	public void Load()
	{
		Objects2.Clear();
		
		string path = Application.dataPath + "/" + "level" + (0).ToString() + ".txt";

		print(path);

		if (File.Exists(path))
		{
			FileStream reader = new FileStream(path, FileMode.Open);
			BinaryFormatter bf = new BinaryFormatter();
			Objects2 = bf.Deserialize(reader) as List<DataSaver>;
			reader.Close();



		}
	}

	
	public void OnButtonPress(int i)
	{
		var w = i / Cols;
		var h = i % Cols;
	
		//print(Objects.Count);
		Selected.Instance.transform.position = Objects2[i].Rep.transform.position;

		if (Objects2[i].Rep.GetComponent<RodsBase>())
		{

			Objects2[i].Rep.GetComponent<RodsBase>().Toggle();
		}
	}

	// Update is called once per frame
	private void Update()
	{
		for (var i = 0; i < _keyCodes.Count; i++)
			if (Input.GetKeyDown(_keyCodes[i]))
				OnButtonPress(i);
	}
}