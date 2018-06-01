using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenghargaanController : MonoBehaviour {
    public static PenghargaanController self;
    private PenghargaanContainer PC;
    private AccountContainer AC;
    private List<Penghargaan> toBeAdded = new List<Penghargaan>();
	void Awake () {
        load();
        Destroy(this);
	}
    public void tambahPenghargaan(string nama) {
        Penghargaan p = PenghargaanContainer.self.getPenghargaan(nama);
        if (p != null)
        {
            if (AC.currentAccount.addPenghargaan(p))
            {
                toBeAdded.Add(p);
                Debug.Log("Success menambahkan penghargaan "+p.name);
            } 
        }
    }
    public Penghargaan getEarnedPenghargaan() {
        if (toBeAdded.Count > 0)
        {
            Penghargaan ret = toBeAdded[0];
            toBeAdded.RemoveAt(0);
            Debug.Log("success retrive penghargaan " + ret.name);
            return ret;
        }
        else {
            Debug.Log("failed retrive penghargaan ");
            return null;
        }
    }
    public static PenghargaanController load() {
        if (self == null)
        {
            self = new PenghargaanController();
            self.AC = AccountContainer.load();
            self.PC = PenghargaanContainer.load();
            return self;

        }
        else
        {
            return self;
        }
    }
}
