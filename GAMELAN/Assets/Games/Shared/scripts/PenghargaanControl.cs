using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenghargaanControl : MonoBehaviour
{

    public GameObject penghargaanContainer;
    public GameObject penghargaanContentContainer;
    public GameObject penghargaanEarn;
    public GameObject penghargaanEarnUI;
    public GameObject penghargaanPrefab;
    private bool isShown = false;
    private float dx;
    private float dy;
    private int mod = 4;
    // Use this for initialization
    void Start()
    {
        dx = penghargaanPrefab.GetComponent<Image>().rectTransform.rect.width;
        dx += dx / 2;
        dy = penghargaanPrefab.GetComponent<Image>().rectTransform.rect.height;
        dy += dy / 2;
        layoutPenghargaan();
        showPenghargaan();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isShown)
        {
            showPenghargaan();
        }
    }

    public void open()
    {
        penghargaanContainer.SetActive(true);
    }

    public void close()
    {
        penghargaanContainer.SetActive(false);
    }
    public void showPenghargaan()
    {
        PenghargaanController pc = PenghargaanController.self;
        Penghargaan p = pc.getEarnedPenghargaan();
        if (p != null)
        {
            Debug.Log(p.name);
            Image image = penghargaanEarnUI.GetComponent<Image>();
            Sprite s = Resources.Load<Sprite>("Penghargaan/Gambar/" + p.imageName);
            image.sprite = s;
            penghargaanEarn.SetActive(true);
        }
        else
        {
            penghargaanEarn.SetActive(false);
            Destroy(penghargaanEarn);
            isShown = true;
        }
    }

    void layoutPenghargaan()
    {
        PenghargaanContainer pc = PenghargaanContainer.self;
        AccountContainer ac = AccountContainer.self;
        int index = 0;
        foreach (Penghargaan p in pc.penghargaans)
        {
            Transform a = Instantiate(penghargaanPrefab.transform, penghargaanContentContainer.transform);
            a.localPosition += new Vector3((index % 4) * dx, (index / 4) * dy * -1, 0);
            //a.localPosition = new Vector3(oriX + (index % 5) * dx, oriY + (index / 5) * dy, 0);
            a.gameObject.name = p.name;
            a.gameObject.SetActive(true);
            index++;

            if (ac.currentAccount.getPenghargaan(p))
            {
                a.GetComponent<Image>().sprite = Resources.Load<Sprite>("Penghargaan/Gambar/" + p.imageName);
            }
        }
    }
}
