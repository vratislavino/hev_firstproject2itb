using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol : MonoBehaviour
{
    [SerializeField]
    private bool isPlayer;

    SymbolEnum currentSymbol;

    [SerializeField]
    private MeshRenderer quad;

    [SerializeField]
    private Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        ChangeSymbol(GenerateRandomSymbol());
        if(isPlayer) {
            StartCoroutine(ChangeSymbolRoutine());
        }
    }

    IEnumerator ChangeSymbolRoutine() {
        while (true) {
            yield return new WaitForSeconds(1);
            ChangeSymbol(GenerateRandomSymbol());
        }
    }

    private void ChangeSymbol(SymbolEnum newSymbol) {
        currentSymbol = newSymbol;
        quad.material = materials[(int)newSymbol];
    }

    private SymbolEnum GenerateRandomSymbol() {
        return (SymbolEnum) Random.Range(0, 3);
    }

    private void OnCollisionEnter(Collision collision) {
        if (!isPlayer) return;

        var enemy = collision.gameObject.GetComponent<Symbol>();
        if(enemy != null) {
            Debug.Log(currentSymbol + " : " + enemy.currentSymbol);

            // TODO: Dodìlat Beats v RPSExtensions, který bude vracet bool?
            /*
            if(currentSymbol.Beats(enemy)) {

            }
            */
        }
    }
}

public enum SymbolEnum
{
    Rock,
    Paper,
    Scissors
}
