using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Start_btn : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update

    public int SceneIndex = 1;
    
    public void OnPointerClick(PointerEventData e)
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("current scene name = " + scene.name + "and scene index = " + scene.buildIndex);
        coin_events.scores = 0;
        SceneManager.LoadScene(SceneIndex);
    }
}
