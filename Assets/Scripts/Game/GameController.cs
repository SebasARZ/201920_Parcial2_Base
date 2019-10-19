using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    [SerializeField] private Vector2 minPos = Vector2.zero, maxPos = new Vector2(50f, 50f);
    public delegate void OnTaggedChange(string newTagged);

    [SerializeField] private Text text;

    private static GameController instance;

    public event OnTaggedChange onTaggedChange;

    [SerializeField]
    private float playTime = 60F;

    [SerializeField]
    private int playerCount = 4;

    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private bool instantiateHumanPlayer = true;

   

    private Dictionary<string, int> taggedScore = new Dictionary<string, int>();

    public string GetWinner()
    {
        return string.Empty;
    }
    public static GameController Instance {
        get { return instance; }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        text.gameObject.SetActive(false);

        onTaggedChange += UpdateTaggedScore;

        taggedScore.Clear();

        for (int i = 0; i < playerCount; i++)
        {
            

            string prefabPath = i == 0 && instantiateHumanPlayer ? "HumanPlayer" : "AIPlayer";

            Vector3 spawnPosition = new Vector3(Random.Range(minPos.x, maxPos.x), 1f, Random.Range(minPos.y, maxPos.y));
            GameObject playerInstance = Instantiate(Resources.Load<GameObject>(prefabPath), spawnPosition, Quaternion.identity);
            
            playerInstance.name = $"Player{i + 1}";
            playerInstance.tag = "Player";

            taggedScore.Add(playerInstance.name, 0);
            if (i == 3)
            {
                playerInstance.GetComponent<PlayerController>().IsTagged = true;
            }
            
        }

        Invoke("EndGame", playTime);
    }

    private void EndGame()
    {
        string winner = "";
        int count = 1000;
        for (int i = 0; i < playerCount; i++)
        {
            int value = taggedScore[$"Player{i + 1}"];
            if(value < count)
            {
                count = value;
                winner = $"Player{i + 1}";
            }
             
        }
        text.text = winner;
        text.gameObject.SetActive(true);
        onTaggedChange -= UpdateTaggedScore;
        
    }

    private void UpdateTaggedScore(string newTaggedPlayer)
    {
        taggedScore[newTaggedPlayer] += 1;
    }
    public void OnPlayerStateChange(string name)
    {
        if(onTaggedChange != null)
        {
            onTaggedChange(name);
        }
    }
}