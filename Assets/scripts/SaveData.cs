using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    // create Level object
    public Level level = new Level();

    
   

    // function to save to json file
    public void SaveToJson()
    {
        // save level name as current level name
        level.setLevelName(SceneManager.GetActiveScene().name);



        string levelData = JsonUtility.ToJson(level);
        // define file path for data to be saved to
        string filePath = Application.persistentDataPath + "/LevelData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, levelData);
        Debug.Log("Save file created");
    }

    // retrieve data from json file
    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/LevelData.json";
        string levelData = System.IO.File.ReadAllText(filePath);
        level = JsonUtility.FromJson<Level>(levelData);
        try
        {
            // load scene by level name stored in json file
            SceneManager.LoadScene(level.levelName);
        }
        catch
        {
            Debug.Log("There was an issue loading the saved level");
            //Debug.Log(levelData);
            //Debug.Log(level.levelName);
        }

        Debug.Log("Data loaded successfully");
    }


}






[System.Serializable]
public class Level
{
    public string levelName;
    public int totalBerries;


    public void setLevelName(string levelName)
    {
        this.levelName = levelName;

    }

    public void setTotalBerries(int total)
    {
        this.totalBerries = total;
    }
   
}

