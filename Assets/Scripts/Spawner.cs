using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    //El player
    public GameObject player;

    //El texto
    public TextMeshProUGUI texto;
    public static Spawner instance;
    
    private List<Color> colors = new List<Color>();
    public List<string> names = new List<string>();

    //Rango de X
    int xPosition;

    //Rango de Z
     int zPosition;

    //Cantidad de players
    int playerCount;
    
    
   


    // Start is called before the first frame update

    void Awake(){
        instance = this;
    }
    void Start()
    {
        colors.Add(Color.black);
        colors.Add(Color.blue);
        colors.Add(Color.cyan);
        colors.Add(Color.gray);
        colors.Add(Color.green);
        colors.Add(Color.white);
        colors.Add(Color.yellow);
        colors.Add(Color.magenta);
        colors.Add(Color.red);
        colors.Add(Color.grey);

        names.Add("Balardo");
        names.Add("Bitonga");
        names.Add("Viriato");
        names.Add("Canardo");
        names.Add("Torombolo");
        names.Add("Fibonazzi");
        names.Add("Fabio");
        names.Add("Babieca");
        names.Add("Dealer");
        names.Add("Bitongo");

        //Esta corrutina seguira funcionando hasta que llegue a 6 players.
        StartCoroutine(PlayerDrop());
    }

    //Sistema de spawn.
    //Mientras no llegue a 6 players se seguira spawneando entre esas zonas a y cada 5 segundos.
    IEnumerator PlayerDrop(){
        while (playerCount < 6){
            xPosition = Random.Range(1, 20);
            zPosition = Random.Range(1, 20);
            GameObject playerSpawned = Instantiate(player, new Vector3(xPosition, 1, zPosition), Quaternion.identity);
            int selectedColors = Random.Range(0, colors.Count);
            Debug.Log(colors.Count);
            texto.text = names[Random.Range(0, names.Count)];//.ToString();
            //int selectedNames = Random.Range(0, names.Count);
            playerSpawned.GetComponent<MeshRenderer>().material.color = colors[selectedColors];
            colors.RemoveAt(selectedColors);
            yield return new WaitForSeconds(5);
            playerCount += 1;   
            
        }
    }

}
