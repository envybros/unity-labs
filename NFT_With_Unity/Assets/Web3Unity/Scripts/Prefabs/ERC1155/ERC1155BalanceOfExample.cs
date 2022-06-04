using System.Collections;
using System.Numerics;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ERC1155BalanceOfExample : MonoBehaviour
{
    public GameObject Sphere;
    
    async void Start()
    {
        string chain = "ethereum";
        string network = "rinkeby";
        string contract = "0x495f947276749Ce646f68AC8c248420045cb7b5e";
        string account = PlayerPrefs.GetString("Account");
        string tokenId = "83484095403942972080560959395318884959963213561662847513049032258614466707457";

        BigInteger balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, tokenId);
        print(balanceOf);

        if (balanceOf > 0)
        {
            Sphere.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
    }
}
