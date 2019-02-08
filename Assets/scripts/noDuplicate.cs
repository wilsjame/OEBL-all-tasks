/* Attach to the main scene's MixedRealityCameraParent to prevent duplication
 * if returning to main from a different scene. */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class noDuplicate : MonoBehaviour {

     static noDuplicate instance;
    
     Scene m_Scene;
     
     private void Update()
     {

	 // Use scene's camera.
	 // Return the current active scene in order to get the current scene's name
	 m_Scene = SceneManager.GetActiveScene();
	 if (m_Scene.name != "main")
	 {
		 Debug.Log("Trace");
		 Destroy(this.gameObject);
	 }

     }
     
    
     void Awake()
     {

	 // Remove duplicate camera if returning to the main scene.
         if(instance == null)
         {    
             instance = this; // In first scene, make us the singleton.
             DontDestroyOnLoad(gameObject);
         }
         else if(instance != this)
             Destroy(gameObject); // On reload, singleton already set, so destroy duplicate.
     } 
}
