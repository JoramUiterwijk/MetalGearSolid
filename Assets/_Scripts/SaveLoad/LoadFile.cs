//From www.freetimedev.com
//Written by Dani van der Werf
using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class LoadFile : MonoBehaviour 
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

	public void load(int slotIndex)
	{
		//Check if the file that you are trying to load exists
		if (File.Exists (Application.persistentDataPath + "/saveFile" + slotIndex + ".dat"))
		{
			//Create a new instance of the BinaryFormatter to deserialize the stream
			BinaryFormatter binary = new BinaryFormatter ();
			//Open the filestream to the file we saved
			FileStream fStream = File.Open (Application.persistentDataPath + "/saveFile" + slotIndex + ".dat", FileMode.Open);
			//Deserialize the class with properties we saved
			SaveManager saver = (SaveManager)binary.Deserialize (fStream);
			//Close the stream 
			fStream.Close ();

			//Set the values of back to scripts
			//playerHealth.setMaxHealth = saver.setplayerHealth;
		} 
		else
		{
			print ("Savefile does not exist yet");
		}
	}
}