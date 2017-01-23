//From www.freetimedev.com
//Written by Dani van der Werf
using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveFile : MonoBehaviour 
{
	//private PlayerHealth playerHealth;
	private void Start()
	{
		setReferences ();
	}

	private void setReferences()
	{
		//playerHealth = FindObjectOfType<PlayerHealth> ();
	}

	public void save(int slotIndex)
	{
		//create a new instance of the BinaryFormatter class, to serialize your stream in binary 
		BinaryFormatter binary = new BinaryFormatter ();
		//Make a new FileStream class, which allows you to read and write files
		FileStream fStream=File.Create(Application.persistentDataPath+"/saveFile"+slotIndex+".dat");
		//Make a new instance of our SaveManager script
		SaveManager saver = new SaveManager();

		//Set the values from the SaveManager to the values you want to save
		//saver.setplayerHealth = playerHealth.setMaxHealth;

		//Serialize the stream
		binary.Serialize(fStream, saver);
		//And close it off
		fStream.Close();
	}
}