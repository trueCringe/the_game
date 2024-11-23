using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMananger : MonoBehaviour
{
  public List<GameObject> chekpoints;
    public int nextchekpointindex = 0;
    public int complitetcyrcals = 0;
    public TextMeshProUGUI roundstext;
    public GameObject winPanel;

    void Start()
    {
        roundstext.text = "rounds: " + complitetcyrcals.ToString();
        winPanel.gameObject.SetActive(false); 
    }

    public void ChekpointEnd(GameObject chek)
    {
        if (chekpoints[nextchekpointindex] == chek)
        {
            chek.GetComponent<Renderer>().material.color = Color.magenta;
            nextchekpointindex++;// ++ == += 1 
            Debug.Log(nextchekpointindex);
        }
    }

    public void FinishEnd(GameObject finish)
    {
        if (nextchekpointindex == chekpoints.Count)
        {
            finish.GetComponent<Renderer>().material.color = Color.red;
            complitetcyrcals += 1;
            roundstext.text = "rounds: " + complitetcyrcals.ToString();
            Debug.Log("kpygov:" + complitetcyrcals);
            StartCoroutine(ResetWait(0.5f, finish));
            if (complitetcyrcals >= 3)
            {
                Debug.Log("u won");
                winPanel.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    private void Resetchecks(GameObject finish)
    {
        nextchekpointindex = 0;
        Color32 purple = new Color32(104, 0, 250, 255);
        finish.GetComponent<Renderer>().material.color = purple;
        foreach (GameObject chek in chekpoints)
        {
            chek.GetComponent<Renderer>().material.color = Color.green;
        }
    }
    IEnumerator ResetWait(float time,GameObject finish)
    {
        yield return new WaitForSeconds(time);
        Resetchecks(finish);
    }
}
