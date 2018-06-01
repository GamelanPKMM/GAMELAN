using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenghargaanControl : MonoBehaviour {

    public GameObject penghargaanContainer;
    public GameObject penghargaanContentContainer;
    public GameObject penghargaanEarn;
    public GameObject penghargaanEarnUI;
    public GameObject penghargaanPrefab;
    private bool isShown = false;
    private float oriX = 250F;//-260F;
    private float oriY = 300F;//765F;
    private float dx = 100;
    private float dy = -80;
    private float mod = 5;
	// Use this for initialization
	void Start () {
        layoutPenghargaan();
        showPenghargaan();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0) && !isShown)
        {
            showPenghargaan();
        }
    }

    public void open() {
        penghargaanContainer.SetActive(true);
    }

    public void close() {
        penghargaanContainer.SetActive(false);
    }
    public void showPenghargaan() {
        PenghargaanController pc = PenghargaanController.self ;
        Penghargaan p = pc.getEarnedPenghargaan();
        if (p != null)
        {
            Debug.Log(p.name);
            Image image = penghargaanEarnUI.GetComponent<Image>();
            Sprite s = Resources.Load<Sprite>("Penghargaan/Gambar/" + p.imageName);
            image.sprite = s;
            penghargaanEarn.SetActive(true);
        }
        else {
            penghargaanEarn.SetActive(false);
            Destroy(penghargaanEarn);
            isShown = true;
        }
    }

    void layoutPenghargaan() {
        PenghargaanContainer pc = PenghargaanContainer.self;
        AccountContainer ac = AccountContainer.self;
        int index = 0;
        foreach (Penghargaan p in pc.penghargaans) {
            Transform a = Instantiate(penghargaanPrefab.transform, new Vector3(0,0,0), Quaternion.identity, penghargaanContentContainer.transform);
            a.position =  new Vector3(oriX + (index % 4) * dx, oriY + (index / 4) * dy, 0);
            //     a.localPosition = new Vector3(oriX + (index % 5) * dx, oriY + (index / 5) * dy, 0);
            a.gameObject.name = p.name;
            a.gameObject.SetActive(true);
            
            if (ac.currentAccount.getPenghargaan(p)) {
                a.GetComponent<Image>().sprite = Resources.Load<Sprite>("Penghargaan/Gambar/" + p.imageName);
            }
            index++;
        }
    }
}
