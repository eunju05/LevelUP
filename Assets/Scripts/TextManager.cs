using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public TextAsset data;
    private AllData datas;

    private void Awake()
    {
        datas = JsonUtility.FromJson<AllData>(data.text);

        foreach (var v in datas.TextScript)
        {
            print(v.content);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        
    }
}

[System.Serializable]
public class AllData 
{
    public TextData[] TextScript;
}

[System.Serializable]
public class TextData
{
    public int ID;
    public string name;
    public string content;
}