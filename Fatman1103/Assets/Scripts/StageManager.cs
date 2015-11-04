using UnityEngine;
using System.Collections;
using GameSystems;
using UnityEngine.UI;

public class StageManager : MonoBehaviour {

    //残タイム
    int outTime;

    //開始時間
    float startTime;

    //経過時間
    float parseTime;

    //現在のタイム
    private float nowTime;
    //テキスト用の分・秒
    private int minuts;
    private int seconds;

    //タイマーオブジェクト
    private GameObject timer;

    //ゲームの状態
    State state = new State();

    //シーンチェンジャー
    ScenChanger sc = new ScenChanger();

    //エネミー格納
    public GameObject[] enemys;

    //ボス格納
    public GameObject boss;

    //リザルトテロップ
    private GameObject resultTelop;

    //音
    public AudioClip[] audioSorce;
    private AudioSource audio;

    //Enemyやられたカウント
    public int count = 0;

	private int t ;

	// Waveプレハブを格納する
	public GameObject[] waves;
	
	// 現在のWave
	private int currentWave;

    void Start()
    {
        //タイマー関係
        startTime = Time.time;
        //制限時間
        outTime = 180;
        timer = GameObject.Find("Timer");

        //ゲームステート
        state.setState(GameState.Playing);

        //テロップ
        resultTelop = GameObject.Find("ResultTelop");
        resultTelop.SetActive(false);

        //音
        audio = GetComponent<AudioSource>();

        state.setState(GameState.Playing);

		enemyGeneration ();

		//EnemyWaveを呼び出す
		StartCoroutine ("enemyWave");
		/*
        for (int i = 0; i < enemys.Length; i++)
        {
            Vector3 enemyPos = new Vector3((float)i , (float)i +2 , (float)i + 2);
            Instantiate(enemys[i], enemyPos, transform.rotation);
        } 
        */
        
    }

    void Update()
    {
        //タイマー
        setTimer();

        //スポナー
        //Sporner();

        print(currentWave);
    }

    public void Counter(int i)
    {
        count += i;
        print("Count: " + count);
    } 
    
    void Sporner()
    {
        //Enemyが全部やられたら
        if(count == 5)
        {
            audio.Stop();
            //audio.clip = audioSorce[0];
            //audio.PlayOneShot(audioSorce[0]);
            Instantiate(boss, transform.position, transform.rotation);
            Counter(1);
        }        
        //Enemy全部とBossがやられたら
        if (count == 7)
        {
            setResult(true);
            StartCoroutine(telop());
        }

    }

    //タイマー書き換え
    void setTimer()
    {
        if (nowTime >= 0)
        {
            parseTime += Time.deltaTime;
            nowTime = outTime - parseTime;
            if (nowTime <= 0)
            {
                setResult(false);
                StartCoroutine(telop());
            }
            mathTime(nowTime);
            timer.GetComponent<Text>().text = "残タイム\r\n" + minuts + ":" + seconds;
        }
    }

    //タイマー計算
    void mathTime(float t)
    {
        if (t < 60)
        {
            minuts = 0;
            seconds = (int)t;
        }
        else
        {
            seconds = (int)t;
            seconds %= 60;
            minuts = ((int)t - seconds) / 60;
        }
    }

    //ポーズ状態の遷移
    public void setPause(bool p)
    {
        if(p == false)
        {
            //ポーズ中にする
            state.setState(GameState.Pausing);
        }
        else
        {
            //プレイ中にする
            state.setState(GameState.Playing);
        }
    }

    //リザルト状態の遷移
    public void setResult(bool c)
    {
        if(c == true)
        {
            //クリア
            int i = 0;
            while (i < 1)
            {
                audio.Stop();
                audio.clip = audioSorce[1];
                audio.Play();
                //audio.PlayOneShot(audioSorce[1]);
                i++;
            }
            state.setState(GameState.StageClear);
            resultTelop.GetComponent<Text>().text = "ステージクリア";
        }
        else
        {
            //ゲームオーバー
            int i = 0;
            while (i < 1)
            {
                audio.Stop();
                //audio.clip = audioSorce[2];
                audio.PlayOneShot(audioSorce[2]);
                i++;
            }
            state.setState(GameState.GameOver);
            resultTelop.GetComponent<Text>().text = "ゲームオーバー";
        }
    }

    //リザルトテロップ
    IEnumerator telop()
    {
        audio.loop = false;
        audio.PlayOneShot(audioSorce[0]);
        resultTelop.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        resultTelop.SetActive(false);
        sc.toResult();
    }

    
	private	IEnumerator enemyWave ()
	{
		// Waveが存在しなければコルーチンを終了する
		if (waves.Length == 0) {
			yield break;
			print("WAVE終了");
		}
		
		while (true) {

            // Waveを作成する
            GameObject wave = (GameObject)Instantiate (waves [currentWave], transform.position, Quaternion.identity);
            //GameObject wave = waves[currentWave];
            //w[currentWave].SetActive(true);
            wave.SetActive(true);
			
			// WaveをStageManagerの子要素にする
			wave.transform.parent = transform;
			print("敵の数"+wave.transform.childCount);
			 t =  t + wave.transform.childCount;
            // Waveの子要素のEnemyが全て削除されるまで待機する
            print("t: " + t);
			while (t > count) {
				yield return new WaitForEndOfFrame ();
			}

			print("すべて敵死んだ");
			// Waveの削除
			Destroy (wave);
            count = 0;

			// 格納されているWaveを全て実行したらステージクリア
			if (waves.Length <= ++currentWave) {
                print("hoge");
				setResult(true);
				StartCoroutine(telop());
			}
			
		}
	}
    GameObject[] w = new GameObject[4];
    GameObject sporner;
	void enemyGeneration(){
        int i = 0;
        //Instantiate(sporner, transform.position, transform.rotation);
		foreach (GameObject n in waves) {
			print(n);
			n.SetActive(false);
			Instantiate (n, transform.position, Quaternion.identity);
            //n.transform.parent = sporner.transform;
            w[i] = n;
            print("W: " + w[i]);
            i++;
		}
	}

}
