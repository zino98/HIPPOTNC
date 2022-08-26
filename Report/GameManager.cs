using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CHARACTERTYPE
{
    _none = -1,
    john,
    ted,
    anya,
    zoe,
    lilith,
    andrew,
    melissa
}
public  class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [System.Serializable]
    public struct CharacterData
    {
        public string name;
        public int hp;
        public int mp;
        public int damage;
        public int armor;
    }

    [SerializeField] private CharacterData[] characterData;
    [SerializeField] private CHARACTERTYPE[] characters;
    //private CHARACTERTYPE[] characters;
    private CharacterData[] currentCharacters;

    private void Awake()
    {
        instance = this;
        currentCharacters = new CharacterData[characters.Length];
        for(int i = 0; i < currentCharacters.Length; i++)
        {
            currentCharacters[i] = characterData[(int)characters[i]];
        }
    }

    private void Start()
    {
        CSVManager.AppendToReport(GetReportLine());
        Debug.Log("Send Successfully!");
    }

    string[] GetReportLine()
    {
        string[] returnable = new string[5];
        returnable[0] = currentCharacters[0].name + " " + currentCharacters[1].name;
        returnable[1] = currentCharacters[0].hp.ToString();
        returnable[2] = currentCharacters[0].mp.ToString();
        returnable[3] = currentCharacters[0].damage.ToString();
        returnable[4] = currentCharacters[0].armor.ToString();

        return returnable;
    }
}
