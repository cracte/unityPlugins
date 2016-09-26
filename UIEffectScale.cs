using UnityEngine;
using System.Collections;

public class UIEffectScale : MonoBehaviour 
{

	// Use this for initialization
    void Awake()
    {
        float scale = ((float)Screen.width / (float)Screen.height) / (16.0f / 9.0f);

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform particleTransform = transform.GetChild(i);
            particleTransform.GetChild(0).particleSystem.startSize *= scale;
        }
    }
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
