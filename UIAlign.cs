using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIAlign : MonoBehaviour 
{
    public enum AlignType
    {
        UpperLeft,
        UpperCenter,
        UpperRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        LowerLeft,
        LowerCenter,
        LowerRight,
    }
    public enum HorizonalAlign
    {
        None,
        Left,
        Center,
        Right,
    }
    public enum VertialAlign
    {
        None,
        Upper,
        Middle,
        Lower,
    }

    public HorizonalAlign horizonal = HorizonalAlign.None;
    public VertialAlign vertial = VertialAlign.None;
    public float cellWidth = 200;
    public float cellHeight = 200f;
    public float spaceX = 0f;
    public float spaceY = 0f;
    public bool rePosition = false;

    private Transform m_transform;

	// Use this for initialization
	void Start () 
	{
        m_transform = transform;
        rePosition = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (rePosition)
            reposion();
	}

    void reposion()
    {
        if (rePosition == false)
            return;
        List<Transform> activeTransform = new List<Transform>();
        for( int i=0; i<m_transform.childCount;i++)
        {
            Transform tran = m_transform.GetChild(i);
            if (tran.gameObject.activeSelf)
                activeTransform.Add(tran);
        }
        int childCount = activeTransform.Count;
        for (int i = 0; i < childCount; i++)
        {
            Transform childTran = activeTransform[i];
            float x = childTran.localPosition.x;
            float y = childTran.localPosition.y;
            float z = childTran.localPosition.z;

            if( horizonal == HorizonalAlign.Left)
            {
                x = i * (cellWidth + spaceX);
            }
            else if( horizonal == HorizonalAlign.Center)
            {
                x = (i - (childCount - 1) / 2.0f) * (cellWidth + spaceX);
            }
            else if( horizonal == HorizonalAlign.Right)
            {
                x = (childCount - 1 - i) * (cellWidth + spaceX);
            }

            if( vertial==VertialAlign.Lower)
            {
                y = i * (cellHeight + spaceY);
            }
            else if( vertial==VertialAlign.Middle)
            {
                y = (i - (childCount - 1) / 2.0f) * (cellHeight + spaceY);
            }
            else if( vertial==VertialAlign.Upper)
            {
                y = (childCount - 1 - i) * (cellWidth + spaceY);
            }
            childTran.localPosition = new Vector3(x, y, z);
        }

        rePosition = false;
    }
}
