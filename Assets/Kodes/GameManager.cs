using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Cars;
    [SerializeField]
    private int ID = -1;
    private Text CarName;

    private GameObject[] ParkZone;
    public Material Red;
    public Material Green;

    private void Awake()
    {
        Red = Resources.Load<Material>("Materyal/Red");
        Green = Resources.Load<Material>("Materyal/Green");
    }
    void Start()
    {
        CarName =  GameObject.Find("CarName").GetComponent<Text>();
        ID = -1;
        ParkZone = GameObject.FindGameObjectsWithTag("Zone");
        Missons();
       
    }

    // Araba seçme kısmı value bir ileri sıfır geri dogru..
    public void ButtonClikt(int value)
    {

        if (value == 1)
        {
            if (ID < Cars.Length -1)
            {
                ID++;
            }
            if (ID > 0) // eger birinci arabadan büyük ise..
            {
                Cars[ID -1].SetActive(false);
            }
        }
        else
        {
            if (ID > 0)
            {
                ID--;

                Cars[ID + 1].SetActive(false);
            }
        }
        if(ID != -1)
        {
            CarActive(ID); // aracı aktif etmek için..
        }
        
    }

    void CarActive(int index)
    {
        Cars[index].SetActive(true);
        Camera.main.GetComponent<CameraFlow>().Player = Cars[index].transform;
        CarName.text = Cars[index].name;
    }

    public void Missons()
    {

        int value = Random.Range(1, 20);

        for (int i = 0; i < ParkZone.Length; i++) // tüm park konumlarını kapattık
        {
            ParkZone[i].GetComponent<MeshRenderer>().material = Red;
            ParkZone[i].tag = "Death";
        }
        ParkZone[value].tag = "Zone";
        ParkZone[value].GetComponent<MeshRenderer>().material = Green;
        //Debug.Log("Toplam 1 Adet boş yer var her seferinde...");


    }


}
