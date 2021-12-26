using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class back_btn : MonoBehaviour
{
    // Start is called before the first frame update
    public int SceneIndex = 0;

    // Update is called once per frame

    public void OnPointerClick(PointerEventData e)
    {
        Scene scene = SceneManager.GetActiveScene();
        //Debug.Log("current scene name = " + scene.name + "and scene index = " + scene.buildIndex);

        SceneManager.LoadScene(SceneIndex);
    }
}
