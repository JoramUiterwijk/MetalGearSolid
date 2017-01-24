using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveProperties : MonoBehaviour 
{
	//Create references to the scripts you want to save data from
	private volumeUI volume;

	private void Start()
	{
		//make the references to the scripts
		volume = GameObject.FindObjectOfType<volumeUI>();
	}

	public void Save()
	{
		//create a new instance of the BinaryFormatter class, to serialize your stream in binary 
		BinaryFormatter binary = new BinaryFormatter ();

		//Make a new FileStream class, which allows you to read and write files
		FileStream fStream=File.Create(Application.persistentDataPath+"/MetalGearSolidData.dat");

		//Make a new instance of our SaveManager script
		SaveManager saver = new SaveManager();

		//Set the values from the SaveManager to the values you want to save
		saver.Volume = volume.GetVolume;

		//Serialize the stream
		binary.Serialize(fStream, saver);

		//And close it off
		fStream.Close();
	}
}