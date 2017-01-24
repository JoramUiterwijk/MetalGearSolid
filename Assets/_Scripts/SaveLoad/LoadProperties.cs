//From www.freetimedev.com
//Written by Dani van der Werf
using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadProperties : MonoBehaviour 
{
	//Create references to the scripts you are going to load data to
	private Value values;

	private void Awake()
	{
		values = GetComponent<Value> ();
		Load ();
	}

	public void Load()
	{
		//Check if the file that you are trying to load exists
		if (File.Exists (Application.persistentDataPath + "/MetalGearSolidData.dat"))
		{
			//Create a new instance of the BinaryFormatter to deserialize the stream
			BinaryFormatter binary = new BinaryFormatter ();

			//Open the filestream to the file we saved
			FileStream fStream = File.Open (Application.persistentDataPath + "/MetalGearSolidData.dat", FileMode.Open);

			//Deserialize the class with properties we saved
			SaveManager saver = (SaveManager)binary.Deserialize (fStream);

			//Close the stream 
			fStream.Close ();

			//Set the values of YOUR OWN scripts to the value you saved 
			values.Volume = saver.Volume;
		} 
	}
}