using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    private List<GameObject> list_plates = new();
    public GameObject prefab_plate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GeneratePlate()
    {
        GameManager.instance.ClearChild(gameObject);
        list_plates.Clear();
        for(int i = GameManager.instance.countPlate; i > 0 ;i--)
        {
            PushPlate(i);
        }

    }

    public void PushPlate(int size) //size为1代表最小的盘子
    {
        GameObject t_plate = Instantiate(prefab_plate, gameObject.transform);
        float y = -0.5f * GameManager.instance.heightColumn + (list_plates.Count + 0.5f) * GameManager.instance.heightPlate;
        t_plate.GetComponent<RectTransform>().localPosition = new Vector2(0,y);
        float width = GameManager.instance.minWidthPlate + (GameManager.instance.maxWidthPlate - GameManager.instance.minWidthPlate) /
                                                            (GameManager.instance.countPlate - 1) * (size - 1);
        t_plate.GetComponent<RectTransform>().sizeDelta = new Vector2(width, GameManager.instance.heightPlate);
        t_plate.SetActive(true);
        t_plate.GetComponent<Plate>().size = size;
        t_plate.GetComponent<Plate>().text_size.text = size.ToString();
        list_plates.Add(t_plate);
        //TODO 播放放入盘子的动画 改变盘子状态
    }

    public int PopPlate()
    {
        GameObject t_plate = list_plates[^1];
        int size = t_plate.GetComponent<Plate>().size;
        list_plates.Remove(t_plate);
        //TODO 播放取出盘子的动画 改变盘子状态
        Destroy(t_plate);
        return size;
    }
}
