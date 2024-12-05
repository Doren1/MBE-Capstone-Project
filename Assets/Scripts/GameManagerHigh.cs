using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerHigh : MonoBehaviour
{
    // high level에서의 GameManager
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;

    public static GameManagerHigh instance;

    public int currentScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI multiText;

    public float totalNotes=0;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHits;

    // create note automatically
    float currTime;
    bool stopNoteCreation = false;
    
    [SerializeField]
    private GameObject[] notePrefabs;
    [SerializeField]
    private Transform noteHolder;

    // result
    public GameObject resultsScreen1;
    public GameObject resultsScreen2;
    public TextMeshProUGUI percentHitText, rankText, finalScoreText;

    // 각 버튼의 히트 통계
    public float blueNormalHits, blueGoodHits, bluePerfectHits, blueMissedHits;
    public float redNormalHits, redGoodHits, redPerfectHits, redMissedHits;
    public float yellowNormalHits, yellowGoodHits, yellowPerfectHits, yellowMissedHits;
    public float greenNormalHits, greenGoodHits, greenPerfectHits, greenMissedHits;

    // 각 버튼 히트 통계를 위한 UI 텍스트 필드
    public TextMeshProUGUI BlueNormalHits, BlueGoodHits, BluePerfectHits, BlueMissedHits;
    public TextMeshProUGUI RedNormalHits, RedGoodHits, RedPerfectHits, RedMissedHits;
    public TextMeshProUGUI YellowNormalHits, YellowGoodHits, YellowPerfectHits, YellowMissedHits;
    public TextMeshProUGUI GreenNormalHits, GreenGoodHits, GreenPerfectHits, GreenMissedHits;

    public float blueTotalNotes, redTotalNotes, yellowTotalNotes, greenTotalNotes;

    public float blueNormalGoodPercent, bluePerfectPercent, blueMissedPercent;
    public float redNormalGoodPercent, redPerfectPercent, redMissedPercent;
    public float yellowNormalGoodPercent, yellowPerfectPercent, yellowMissedPercent;
    public float greenNormalGoodPercent, greenPerfectPercent, greenMissedPercent;

    public float maxMissedPercent;

    public TextMeshProUGUI fingerText; //약한 손가락 

    void Start()
    {
        instance = this;  // only one GameManager(for other scripts)

        scoreText.text = "점수: 0";
        currentMultiplier = 1;
    }

    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        } else{
            if(!theMusic.isPlaying && !resultsScreen1.activeInHierarchy) 
            {
                print("Show result screen");
                resultsScreen1.SetActive(true);

                //Calculate hit percentages for each button color
                float blueTotalNotes = blueNormalHits + blueGoodHits + bluePerfectHits + blueMissedHits;
                float blueNormalGoodPercent = (blueNormalHits + blueGoodHits) / blueTotalNotes * 100f;
                float bluePerfectPercent = bluePerfectHits / blueTotalNotes * 100f;
                float blueMissedPercent = blueMissedHits / blueTotalNotes * 100f;

                float redTotalNotes = redNormalHits + redGoodHits + redPerfectHits + redMissedHits;
                float redNormalGoodPercent = (redNormalHits + redGoodHits) / redTotalNotes * 100f;
                float redPerfectPercent = redPerfectHits / redTotalNotes * 100f;
                float redMissedPercent = redMissedHits / redTotalNotes * 100f;

                float yellowTotalNotes = yellowNormalHits + yellowGoodHits + yellowPerfectHits + yellowMissedHits;
                float yellowNormalGoodPercent = (yellowNormalHits + yellowGoodHits) / yellowTotalNotes * 100f;
                float yellowPerfectPercent = yellowPerfectHits / yellowTotalNotes * 100f;
                float yellowMissedPercent = yellowMissedHits / yellowTotalNotes * 100f;

                float greenTotalNotes = greenNormalHits + greenGoodHits + greenPerfectHits + greenMissedHits;
                float greenNormalGoodPercent = (greenNormalHits + greenGoodHits) / greenTotalNotes * 100f;
                float greenPerfectPercent = greenPerfectHits / greenTotalNotes * 100f;
                float greenMissedPercent = greenMissedHits / greenTotalNotes * 100f;

                // Display percentages in the results UI
                BlueNormalHits.text = blueNormalGoodPercent.ToString("F1") + "%";
                BluePerfectHits.text = bluePerfectPercent.ToString("F1") + "%";
                BlueMissedHits.text = blueMissedPercent.ToString("F1") + "%";

                RedNormalHits.text = redNormalGoodPercent.ToString("F1") + "%";
                RedPerfectHits.text = redPerfectPercent.ToString("F1") + "%";
                RedMissedHits.text = redMissedPercent.ToString("F1") + "%";

                YellowNormalHits.text = yellowNormalGoodPercent.ToString("F1") + "%";
                YellowPerfectHits.text = yellowPerfectPercent.ToString("F1") + "%";
                YellowMissedHits.text = yellowMissedPercent.ToString("F1") + "%";

                GreenNormalHits.text = greenNormalGoodPercent.ToString("F1") + "%";
                GreenPerfectHits.text = greenPerfectPercent.ToString("F1") + "%";
                GreenMissedHits.text = greenMissedPercent.ToString("F1") + "%";

                // Determine the button with the highest missed percentage
                float maxMissedPercent = Mathf.Max(blueMissedPercent, redMissedPercent, yellowMissedPercent, greenMissedPercent);
                string worstButtonColor = "";

                if (maxMissedPercent == blueMissedPercent) worstButtonColor = "검지";
                else if (maxMissedPercent == redMissedPercent) worstButtonColor = "중지";
                else if (maxMissedPercent == yellowMissedPercent) worstButtonColor = "약지";
                else if (maxMissedPercent == greenMissedPercent) worstButtonColor = "소지";

                // Display the worst button
                fingerText.text = worstButtonColor;

                float totalHit = normalHits + goodHits + perfectHits;
                float percentHit = (totalHit / totalNotes) * 100f;
                percentHitText.text = percentHit.ToString("F1") + "%";

                finalScoreText.text = currentScore.ToString();
                
            }
        }
        
        if(startPlaying && !stopNoteCreation)
        {
            // 음악 길이 가져오고 끝나기 5초 전에 노트 생성 중지
            float musicLength = theMusic.clip.length;
            if(musicLength-theMusic.time <= 5f) {
                print("stop note creation");
                stopNoteCreation = true;}

            // note 생성
            currTime += Time.deltaTime;

            if (currTime > 2f)
            {
                int prefabNumber = Random.Range(0,7);
                Quaternion rotation = Quaternion.identity; //기본 회전값은 0

                if (prefabNumber==4|prefabNumber==5|prefabNumber==6){
                    rotation = Quaternion.Euler(0,0,90);
                }

                if (prefabNumber==0|prefabNumber==4){
                    float newX = -1.5f, newY = 5f, newZ = 0f;
                    Vector3 spawnPosition = new Vector3(newX, newY, newZ);
                    GameObject musicNote = Instantiate(notePrefabs[prefabNumber], spawnPosition, rotation, noteHolder);
                    totalNotes++;

                }
                else if(prefabNumber==1|prefabNumber==3|prefabNumber==5){
                    float newX = 0, newY= 5, newZ = 0;
                    Vector3 spawnPosition = new Vector3(newX, newY, newZ);
                    GameObject musicNote = Instantiate(notePrefabs[prefabNumber], spawnPosition, rotation, noteHolder);
                    totalNotes++;
                }
                else if(prefabNumber==2|prefabNumber==6){
                    float newX = 1.5f, newY= 5, newZ = 0;
                    Vector3 spawnPosition = new Vector3(newX, newY, newZ);
                    GameObject musicNote = Instantiate(notePrefabs[prefabNumber], spawnPosition, rotation, noteHolder);
                    totalNotes++;
                }
                currTime = 0;
            }
        }
    }

    public void NoteHit()
    {
        if(currentMultiplier - 1 < multiplierThresholds.Length){
            multiplierTracker++;

            if(multiplierThresholds[currentMultiplier-1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }
        
        multiText.text = "보너스: x"+currentMultiplier;

        // currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "점수: "+ currentScore;
    }

    public void NormalHit(string buttonColor) 
    { 
        if (string.IsNullOrEmpty(buttonColor))
        {
            return;
        }   
        RegisterHit(buttonColor, "normal");

        currentScore += scorePerNote * currentMultiplier; 
        NoteHit(); 
        normalHits++; 
        RegisterHit(buttonColor, "normal"); 
    }

    public void GoodHit(string buttonColor) 
    { 
        currentScore += scorePerGoodNote * currentMultiplier; 
        NoteHit(); 
        goodHits++; 
        RegisterHit(buttonColor, "good"); 
    }

    public void PerfectHit(string buttonColor) 
    { 
        currentScore += scorePerPerfectNote * currentMultiplier; 
        NoteHit(); 
        perfectHits++; 
        RegisterHit(buttonColor, "perfect"); 
    }

    public void NoteMissed(string buttonColor) 
    { 
        currentMultiplier = 1; 
        multiplierTracker = 0; 
        missedHits++; 
        RegisterHit(buttonColor, "miss"); 
        multiText.text = "보너스: x" + currentMultiplier; 
    }

    public void RegisterHit(string buttonColor, string hitType)
    {
        switch (buttonColor)
        {
            case "blue":
                if (hitType == "normal") blueNormalHits++;
                else if (hitType == "good") blueGoodHits++;
                else if (hitType == "perfect") bluePerfectHits++;
                else blueMissedHits++;
                break;
            case "red":
                if (hitType == "normal") redNormalHits++;
                else if (hitType == "good") redGoodHits++;
                else if (hitType == "perfect") redPerfectHits++;
                else redMissedHits++;
                break;
            case "yellow":
                if (hitType == "normal") yellowNormalHits++;
                else if (hitType == "good") yellowGoodHits++;
                else if (hitType == "perfect") yellowPerfectHits++;
                else yellowMissedHits++;
                break;
            case "green":
                if (hitType == "normal") greenNormalHits++;
                else if (hitType == "good") greenGoodHits++;
                else if (hitType == "perfect") greenPerfectHits++;
                else greenMissedHits++;
                break;
        }
    }


}
