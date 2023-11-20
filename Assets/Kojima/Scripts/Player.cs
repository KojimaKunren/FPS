using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    string name; //プレイヤー名

    int hp; //プレイヤーの体力

    const int MAXHP = 100; //プレイヤーの体力最大値
    int score; //スコア格納用
    [SerializeField] private float speed; //プレイヤーの動く速度

    float initSpeed; //初期速度の保存用
    [SerializeField] private float jumpPower; //プレイヤーのジャンプ力
    float initJumpPower; //初期ジャンプ力の保存用
    [SerializeField] private float sensivytivy; //水平の感度（マウスHorizontal感度）

    [SerializeField] private float speedRotation; //プレイヤーの回転速度


    Vector3 playerPosition; //プレイヤーの位置取得用

    Vector3 playerRotation = Vector3.zero; //プレイヤーの向き取得(初期位置を0，0，0に設定)
    Vector3 playerScale; //プレイヤーのサイズ取得用


    float positionX; //プレイヤーのX位置
    float positionZ; //プレイヤーのz位置

    float rotationX; //プレイヤーのx回転
    float scaleY; //プレイヤーのyサイズ

    float offsetZ; //プレイヤーと視点カメラの差
    Rigidbody rb; //RigidBody Component 取得用

    Bullet bulletAtk; //バレットの攻撃力取得用

    int healHp; //Hp回復用

    public GameObject playerCamera; //視点カメラの取得用

    Vector3 cameraPosition; //視点カメラの位置取得用

    bool isDead; //生死判定

    bool isJump; //ジャンプの判定

    bool isCrouch; //しゃがみ判定

    bool isForcus; //フォーカス判定

    bool cursorLock; //カーソル固定判定

    Animator animator; //アニメーター

    void Start()
    {
        animator = GetComponent<Animator>(); //アニメーターコンポーネントの取得
        rb = GetComponent<Rigidbody>(); //リジッドボディコンポーネントの取得

        SetName("Player1"); //プレイヤー名の取得...Player1仮置き
        hp = MAXHP; //HP最大値を代入
        score = 00000; //スコアを代入
        initSpeed = speed; //スピードの初期値を保存
        initJumpPower = jumpPower; //ジャンプ力の初期値を保存

        playerPosition = transform.localPosition; //プレイヤーの初期位置を保存
        playerScale = transform.localScale; //プレイヤーの初期サイズを保存
        scaleY = playerScale.y; //プレイヤーのY縦初期サイズを保存

        cameraPosition = playerCamera.transform.position; //視点カメラの初期位置を保存
        offsetZ = transform.position.z - playerCamera.transform.position.z; //プレイヤーとカメラの差を保存

        isDead = false; //生死判定をFalseに
        isJump = false; //ジャンプ判定をFalseに
        isCrouch = false; //しゃがみ判定をFalseに
        isForcus = false; //フォーカス判定をFalseに

        cursorLock = true; //カーソルを固定
        animator.SetFloat("MotionSpeed", 1.0f); //アニメーターのwalk基本値を設定
    }

    void Update()
    {
        positionX = Input.GetAxis("Horizontal"); //入力の水平値を取得
        positionZ = Input.GetAxis("Vertical"); //入力の垂直値を取得
        rotationX += Input.GetAxis("Mouse X") * speedRotation; //マウスの水平値を取得（プレイヤー回転用）
        playerRotation = new Vector3(0.0f, rotationX, 0.0f); //プレイヤーの横回転値を取得
        transform.rotation = Quaternion.Euler(playerRotation); //プレイヤーの横回転を実行

        //ジャンプ
        if (Input.GetKeyDown("space") && !isJump)
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;
            animator.SetBool("Jump", true);
        }

        //しゃがみ
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouching();
        }

        //フォーカス
        if (Input.GetMouseButtonDown(1))
        {
            ForcusAim();
        }

        //カーソルロックを実行
        UpdateCursorLock();

        //生死判定
        IsDead();
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * speed * positionZ, ForceMode.VelocityChange); //プレイヤーの前後移動
        rb.AddForce(transform.right * speed * positionX, ForceMode.VelocityChange); //プレイヤーの横移動
        animator.SetFloat("Speed", speed); //移動アニメーションのスピードを取得

    }

    //プレイヤー名取得用
    public String GetName()
    {
        return this.name;
    }

    //プレイヤー名代入用
    public void SetName(string name)
    {
        this.name = name;
    }

    //HP取得用
    public int GetHp()
    {
        return this.hp;
    }

    public int GetMAXHP()
    {
        return Player.MAXHP;
    }

    //スコア取得用
    public int GetScore()
    {
        return this.score;
    }

    //GameOver判定
    public bool IsDead()
    {
        if (hp <= 0)
        {
            isDead = true;
        }

        return isDead;
    }

    //カーソルの非表示、中央固定
    public void UpdateCursorLock()
    {
        //ESCキーでカーソルロックを解除
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        //左クリックでカーソルロック
        else if (Input.GetMouseButton(0))
        {
            cursorLock = true;
        }

        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //コライダー接触処理
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "OBJ")
        {
            isJump = false;
            animator.SetBool("Jump", false);
            animator.SetBool("Grounded", true);
        }

        //スコア獲得用処理
        // if (other.gameObject.tag == "Score")
        // {
        //     score += other.gameObject.score;
        // }

        //リカバリーアイテム獲得処理
        // if(other.gameObject.tag == "Heal"){
        //     healHp = other.gameObject.GetComponent<HealObj>().HealHP;
        //     hp = healHp;
        // }

    }

    //ダメージ処理
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {
            bulletAtk = other.gameObject.GetComponent<Bullet>();
            hp -= bulletAtk.attack;
        }
    }

    //しゃがみ
    private void Crouching()
    {
        if (!isCrouch)
        {
            playerScale.y = scaleY / 2.0f;
            transform.localScale = playerScale;
            speed = initSpeed * 0.7f;
            float cameraPositionY = cameraPosition.y / 1.5f;
            float cameraPositionZ = this.transform.position.z + 0.5f;
            playerCamera.transform.position = new Vector3(playerCamera.transform.position.x, cameraPositionY, cameraPositionZ);
            isCrouch = true;
        }
        else
        {
            playerScale.y = scaleY;
            transform.localScale = playerScale;
            speed = initSpeed;
            float cameraPositionY = cameraPosition.y;
            float cameraPositionZ = this.transform.position.z - offsetZ;
            playerCamera.transform.position = new Vector3(playerCamera.transform.position.x, cameraPositionY, cameraPositionZ);
            isCrouch = false;
            animator.SetFloat("Speed", speed);
        }

    }

    //フォーカス
    private void ForcusAim()
    {
        if (!isForcus)
        {
            jumpPower = initJumpPower * 0.5f;
            speed = initSpeed * 0.8f;
            sensivytivy *= 0.6f;
            float cameraPositionZ = transform.position.z + offsetZ + 5.0f;
            playerCamera.transform.position = new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y, cameraPositionZ);
            isForcus = true;
        }
        else
        {
            jumpPower = initJumpPower;
            speed = initSpeed;
            sensivytivy *= 0.8f;
            playerCamera.transform.position = new Vector3(playerCamera.transform.position.x, playerCamera.transform.position.y, transform.position.z + offsetZ);
            isForcus = false;
        }
    }

    //アニメーションエラー対応用
    private void OnFootstep()
    {

    }

    //アニメーションエラー対応用
    private void OnLand()
    {

    }

}
