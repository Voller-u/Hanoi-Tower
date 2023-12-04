using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    

    
    private List<GameObject> list_columns = new();
    public GameObject prefab_column;
    public GameObject panel_column;
    [Header("柱子参数")]
    public float intervalColumn = 300f;
    public float heightColumn = 750f;
    public float widthColumn = 30f;

    [Header("盘子参数")]
    public int countPlate = 3;
    [HideInInspector]
    public float heightPlate;
    [HideInInspector]
    public float maxWidthPlate;
    [HideInInspector]
    public float minWidthPlate;
    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            GenerateColumn();
        }
    }

    void GenerateColumn()
    {
        heightPlate = heightColumn / (countPlate + 1.5f);
        maxWidthPlate = intervalColumn * 0.8f;
        minWidthPlate = intervalColumn * 0.2f;

        list_columns.Clear();
        ClearChild(panel_column);
        float x0 = intervalColumn * -0.5f;
        for(int i=0;i<3;i++)
        {
            GameObject t_column = Instantiate(prefab_column,panel_column.transform);
            t_column.GetComponent<RectTransform>().localPosition = new Vector2(x0 + (i+1)* intervalColumn, heightColumn/2);
            t_column.GetComponent<RectTransform>().sizeDelta = new Vector2(widthColumn, heightColumn);
            t_column.SetActive(true);
            list_columns.Add(t_column);
        }
        list_columns[0].GetComponent<Column>().GeneratePlate();
    }

    public void ClearChild(GameObject p)
    {
        for (int i = 0; i < p.transform.childCount; i++)
            if(p.transform.GetChild(i).gameObject.activeSelf)
                Destroy(p.transform.GetChild(i).gameObject);
    }
}
