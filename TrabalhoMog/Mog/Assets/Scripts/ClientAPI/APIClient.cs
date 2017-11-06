using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.Networking;
 
 public class APIClient : MonoBehaviour
 {
     const string url = "http://localhost:55876/API/Item";
 
     // Use this for initialization
     void Start()
     {
         StartCoroutine(GetItensAPI());
     }
 
     IEnumerator GetItensAPI()
     {
         //UnityWebRequest request = UnityWebRequest.Get(url + "/1");
         UnityWebRequest request = UnityWebRequest.Get(url);
 
         yield return request.Send();
 
         if (request.isNetworkError || request.isHttpError)
         {
             Debug.Log(request.error);
         }
         else
         {
             string strRespostaServidor = request.downloadHandler.text;
             Debug.Log(strRespostaServidor);
 
             byte[] result = request.downloadHandler.data;
 
             //Item meuItem = JsonUtility.FromJson<Item>(strRespostaServidor);
             //ImprimirItem(meuItem);
 
             //*ListaItens listaItensServidor = new ListaItens();
             //*JsonUtility.FromJsonOverwrite(strRespostaServidor, listaItensServidor);
 
             Item[] teste = JsonHelper.getJsonArray<Item>(strRespostaServidor);
 
             foreach (Item i in teste)
             {
                 ImprimirItem(i);
             }
         }
     }
 
     void ImprimirItem(Item i)
     {
         Debug.Log("====== Dados objeto ======= ");
         Debug.Log("ID: " + i.ItemID);
         Debug.Log("Nome: " + i.Nome);
         Debug.Log("Descrição: " + i.Descricao);
 
     }
 }
