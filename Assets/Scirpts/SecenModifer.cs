using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;
public class SecenModifer : MonoBehaviour
{
    public string m_Scene = "3D_Viewer";

    public GameObject m_MyGameObject;
    
    void Start()
    {
        //DontDestroyOnLoad(m_MyGameObject);
        LoadYourAsyncScene();   
        SceneManager.activeSceneChanged += onSceneChanged;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadYourAsyncScene()
    {
        // Set the current Scene to be able to unload it later
      
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(m_Scene);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(m_MyGameObject, SceneManager.GetSceneByName(m_Scene));
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    }

    void onSceneChanged(Scene from, Scene to)
    {

        DontDestroyOnLoad(m_MyGameObject);
        Instantiate(videoController.model, SceneManager.GetActiveScene().GetRootGameObjects()[0].transform, true);
    }
}
