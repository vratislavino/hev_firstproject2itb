using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol : MonoBehaviour
{
    [SerializeField]
    private bool isPlayer;

    public bool IsPlayer => isPlayer;

    SymbolEnum currentSymbol;

    public SymbolEnum CurrentSymbol => currentSymbol;

    [SerializeField]
    private MeshRenderer quad;

    [SerializeField]
    private Material[] materials;

    [SerializeField]
    private ParticleSystem bloodParticles;

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

            var wouldWin = currentSymbol.Beats(enemy.currentSymbol);
            if(wouldWin.HasValue) {
                if(wouldWin.Value) {
                    var parts = Instantiate(bloodParticles, enemy.transform.position, Quaternion.Euler(-90, 0, 0));
                    parts.Emit(100);
                    Destroy(parts.gameObject, 2f);
                    Destroy(enemy.gameObject);
                }
            }
        }
    }
}

public enum SymbolEnum
{
    Rock,
    Paper,
    Scissors
}
