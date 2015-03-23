﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {

	public static List<GameController> savedGames = new List<GameController>();

	public static void Save() {
		savedGames.Add (GameController.current);
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/savedGames.fd"); // FD is for Folclorica Data
		bf.Serialize (file, SaveLoad.savedGames);
		file.Close ();
	}

	public static void Load() {
		if (File.Exists (Application.persistentDataPath + "/savedGames.fd")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/savedGames.fd", FileMode.Open);
			file.Close();
		}
	}

}