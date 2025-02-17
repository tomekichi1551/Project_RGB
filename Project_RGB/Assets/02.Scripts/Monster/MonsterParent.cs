﻿using System.Collections.Generic;
using UnityEngine;

#region Monster ENUM

//몬스터 고유번호.
public enum MonsterCode
{
    //부모는 그저 상속될 뿐. (존재는 해야함.)
    PARENT,

    //Walk Monster 101~199
    WM101 = 101, WM102, WM103, WM104, WM105,
    WM106, WM107, WM108, WM109, WM110,
    WM111, WM112, WM113,

    //Fly Monster 201~299
    FM201 = 201, FM202, FM203, FM204, FM205,

    //Boss Monster 301~399
    BM301 = 301, BM302, BM303, BM304, BM305,

    //Object (Monster) 401~499
    OM401 = 401, OM402, OM403, OM404, OM405,
    OM406,

    //Trap (Monster) 501~599
    TM501 = 501, TM502, TM503, TM504, TM505,
    TM506, TM507, TM508, TM509, TM510
}

//몬스터 상태.
public enum MonsterState
{
    IDLE,       //대기
    WALK,       //이동
    ATTACK,     //공격
    ATTACKED,   //피격
    DEAD        //죽음
}

#endregion

#region Monster Info DataBase

public class MonsterInfo
{

    //생성자
    public MonsterInfo(MonsterCode monstercode, bool isb, string name, MonsterState state,
                           int damage, int defense, int hp, int speed, int range,
                           int goldamount, int droprate, SpawnCode dropitemcode)
    {
        monsterCode = monstercode;
        isBoss = isb;
        monsterName = name;
        monsterState = state;

        monsterDamage = damage;
        monsterDefense = defense;
        monsterHp = hp;
        monsterSpeed = speed;
        monsterAttackRange = range;

        monsterDropGoldAmount = goldamount;
        monsterDropRate = droprate;
        monsterDropItemCode = dropitemcode;
    }

    public MonsterCode monsterCode;     //몬스터 코드
    public bool isBoss;                 //등급 (보스인지 판단)
    public string monsterName;          //이름
    public MonsterState monsterState = MonsterState.IDLE;   //상태

    public int monsterDamage;           //공격력
    public int monsterDefense;          //방어력
    public int monsterHp;               //체력
    public int monsterSpeed;            //이동속도
    public int monsterAttackRange;      //공격거리

    public int monsterDropGoldAmount;   //드랍 골드량
    public int monsterDropRate;         //드랍률 0~100%
    public SpawnCode monsterDropItemCode;  //드랍 아이템 (장비, 스킬, 아이템) 코드.
}

public class MonsterInfoList
{
    List<MonsterInfo> monsterInfoList = new List<MonsterInfo>();

    public MonsterInfoList()
    {
        // 몬스터 코드, 등급, 이름, 상태, 
        // 공격력, 방어력, 체력, 이동속도, 공격거리
        // 드랍골드량, 드랍률, 드롭 아이템

        //Walk Monsters
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WM101, false, "걷는 꽃", MonsterState.IDLE,
            20, 10, 5, 4, 0,
            51, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WM102, false, "뛰는 돌", MonsterState.IDLE,
            25, 10, 11, 5, 10,
            75, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WM103, false, "서 있는 나무", MonsterState.IDLE,
            20, 10, 12, 0, 10,
            50, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WM104, false, "불타는 돌", MonsterState.IDLE,
            10, 10, 200, 6, 10,
            50, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WM105, false, "불타는 전사", MonsterState.IDLE,
            10, 10, 200, 5, 5,
            50, 0, SpawnCode.NONE));
        //-------------------------------105
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WM106, false, "불타는 주술사", MonsterState.IDLE,
            10, 10, 200, 5, 20,
            50, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WM107, false, "하얀 곰", MonsterState.IDLE,
            10, 10, 200, 7, 10,
            50, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WM108, false, "얼음 펭귄", MonsterState.IDLE,
            10, 10, 200, 5, 35,
            50, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WM109, false, "하얀 눈사람", MonsterState.IDLE,
            10, 10, 200, 0, 10,
            50, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WM110, false, "무지개 장미", MonsterState.IDLE,
            10, 10, 200, 5, 10,
            50, 0, SpawnCode.NONE));
        //-------------------------------110
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WM111, false, "꽃 원예가", MonsterState.IDLE,
            10, 10, 200, 5, 10,
            50, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WM112, false, "신전 기사", MonsterState.IDLE,
            10, 10, 200, 5, 10,
            50, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.WM113, false, "신전 케로베로스", MonsterState.IDLE,
            10, 10, 200, 7, 10,
            50, 0, SpawnCode.NONE));


        //Fly Monsters
        monsterInfoList.Add(new MonsterInfo(MonsterCode.FM201, false, "불타는 참치", MonsterState.IDLE,
            10, 10, 100, 0, 10,
            100, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.FM202, false, "얼음 날치", MonsterState.IDLE,
            10, 10, 100, 0, 10,
            100, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.FM203, false, "무지개 새", MonsterState.IDLE,
            10, 10, 100, 7, 15,
            100, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.FM204, false, "꽃 구름", MonsterState.IDLE,
            10, 10, 100, 3, 10,
            100, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.FM205, false, "신전 순찰자", MonsterState.IDLE,
            10, 10, 100, 7, 10,
            100, 0, SpawnCode.NONE));
        //-------------------------------205


        //Boss Monsters
        monsterInfoList.Add(new MonsterInfo(MonsterCode.BM301, true, "습지의 여왕", MonsterState.IDLE,
            35, 10, 36, 0, 10,
            500, 100/*20*/, SpawnCode.W203));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.BM302, true, "타오르는 피닉스", MonsterState.IDLE,
            10, 10, 100, 5, 10,
            500, 5, SpawnCode.A003));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.BM303, true, "얼음 네시", MonsterState.IDLE,
            10, 10, 100, 7, 30,
            500, 10, SpawnCode.W105));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.BM304, true, "사자 해바리기", MonsterState.IDLE,
            10, 10, 100, 7, 10,
            500, 5, SpawnCode.W005));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.BM305, true, "빛의 정령", MonsterState.IDLE,
            10, 10, 100, 0, 10,
            500, 80, SpawnCode.NONE));
        //-------------------------------305


        //Object Monster
        monsterInfoList.Add(new MonsterInfo(MonsterCode.OM401, true, "자연의 열매", MonsterState.IDLE,
            10, 10, 10, 0, 0,
            500, 80, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.OM402, true, "불타는 꽃", MonsterState.IDLE,
            10, 10, 100, 0, 0,
            500, 80, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.OM403, true, "얼음덩어리", MonsterState.IDLE,
            10, 10, 100, 0, 0,
            500, 80, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.OM404, true, "구름초", MonsterState.IDLE,
            10, 10, 100, 0, 0,
            500, 80, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.OM405, true, "색의 정수", MonsterState.IDLE,
            10, 10, 100, 0, 0,
            500, 80, SpawnCode.NONE));
        //-------------------------------405
        monsterInfoList.Add(new MonsterInfo(MonsterCode.OM406, true, "부서지는 기둥", MonsterState.IDLE,
            10, 10, 100, 0, 10,
            500, 80, SpawnCode.NONE));


        //Trap Monster
        monsterInfoList.Add(new MonsterInfo(MonsterCode.TM501, false, "무는 악어", MonsterState.IDLE,
            10, 10, 100, 0, 10,
            101, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.TM502, false, "불타는 화염 토템", MonsterState.IDLE,
            10, 10, 100, 0, 5,
            150, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.TM503, false, "불타는 폭포 미끄럼틀", MonsterState.IDLE,
            10, 10, 200, 0, 3,
            50, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.TM504, false, "용암(즉사)", MonsterState.IDLE,
            10, 10, 200, 0, 3,
            50, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.TM505, false, "눈더미", MonsterState.IDLE,
            10, 10, 200, 0, 3,
            50, 0, SpawnCode.NONE));
        //-------------------------------505
        monsterInfoList.Add(new MonsterInfo(MonsterCode.TM506, false, "고드름", MonsterState.IDLE,
            10, 10, 200, 0, 14,
            50, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.TM507, false, "호수(대부분 즉사)", MonsterState.IDLE,
            10, 10, 200, 0, 3,
            50, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.TM508, false, "가시덩쿨", MonsterState.IDLE,
            10, 10, 200, 0, 3,
            50, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.TM509, false, "무너지는 기둥", MonsterState.IDLE,
            10, 10, 200, 0, 3,
            50, 0, SpawnCode.NONE));
        monsterInfoList.Add(new MonsterInfo(MonsterCode.TM510, false, "떨어지는 돌", MonsterState.IDLE,
            10, 10, 200, 0, 3,
            50, 0, SpawnCode.NONE));
        //-------------------------------510
    }

    public MonsterInfo MonsterDataLoadWithCode(MonsterCode mCode)
    {
        foreach (MonsterInfo mInfo in monsterInfoList)
        {
            if (mCode == mInfo.monsterCode)
            {
                return mInfo;
            }
        }
        return null;
    }

}

#endregion

public class MonsterParent : MonoBehaviour
{
    public Quest quest;                 //퀘스트   ///Awake에서 quest 찾아서 넣어두기. (Chapter 소환으로 새로 소환되는 몬스터 + 보스가 소환하는 몬스터를 위해서)

    public MonsterCode myMonsterCode;   //고유코드 (Inspector)
    public MonsterInfo myMonsterInfo;   //이 몬스터의 정보

    public GameObject DropGoldObject;   //드랍 골드 오브젝트 (Inspector)
    public Animator myMonsterAnimator;  //애니메이터
    public Rigidbody2D myMonsterRigid;  //리지드바디

    public GameObject PlayerObject;     //현재 이 맵의 Player 오브젝트 (Find)
    public DungeonManager dungeonManager;      //현재 이 맵의 DungeonManager (Find)

    public Vector2 pPosXY;
    public Vector2 mPosXY;
    public int isLRM;
    public int isUDM;

    public bool attackOrder;            //공격해라 (명령)
    public bool isAttacking;            //공격중인가? (판단)
    public float attackingRunTime;      //애니메이션 실행 시간
    public bool isDamaged;              //데미지 입었는가? (피격 상태 판단)
    public bool alreadyDropObjects;     //이미 물건들을 떨궜는가?

    #region Awake And Start

    public void Awake()
    {
        //Awake에서 quest 찾아서 넣어두기. (모든 코드에서 실행되도록...)
        PlayerObject = GameObject.Find("Player");
        dungeonManager = GameObject.Find("DungeonManager").GetComponent<DungeonManager>();
        quest = GameObject.Find("DungeonCanvas").GetComponent<Quest>();

        if (myMonsterCode != MonsterCode.PARENT)                                            //부모 일 경우 정보 불러오지 않음
        {
            MonsterInfoList monsterInfoDataBase = new MonsterInfoList();                    //메모리 절약을 위해 전역변수가 아닌 1회성 지역변수로 사용.
            myMonsterAnimator = GetComponent<Animator>();
            myMonsterRigid = GetComponent<Rigidbody2D>();
            myMonsterInfo = monsterInfoDataBase.MonsterDataLoadWithCode(myMonsterCode);

            Invoke("CheckPlayerCloserEnoughToMove", 0.4f);

            //Debug.Log(myMonsterInfo.monsterHp + "HP" + myMonsterInfo.monsterName);        //Debug log 몬스터확인.
        }

        if (((int)MonsterCode.FM201 <= (int)myMonsterCode) && ((int)myMonsterCode <= (int)MonsterCode.FM205))
        {
            myMonsterRigid.gravityScale = 0f;                                               //FlyMonster는 전부 중력0
        }

        AnimationStateSet(MonsterState.IDLE);

    }

    public void CheckPlayerCloserEnoughToMove()
    {
        //플레이어와 몬스터 각각의 x,y값
        pPosXY = new Vector2(PlayerObject.transform.position.x, PlayerObject.transform.position.y);
        mPosXY = new Vector2(this.transform.position.x, this.transform.position.y);

        if (Mathf.Sqrt(((pPosXY.x - mPosXY.x) * (pPosXY.x - mPosXY.x)) + ((pPosXY.y - mPosXY.y) * (pPosXY.y - mPosXY.y))) < 30f)
        {
            Invoke("MyStart", 0.001f);
            return;
        }

        Invoke("CheckPlayerCloserEnoughToMove", 0.4f);
    }

    public virtual void MyStart()
    {
        //Start에 있어야하는 것을 조건하에 직접 실행시킴.
    }

    #endregion

    #region About Animation

    public void AnimationStateSet(MonsterState nowState)
    {
        //Debug.Log("nowState:" + nowState);
        myMonsterInfo.monsterState = nowState;

        myMonsterAnimator.SetBool(MonsterState.IDLE.ToString(), false);
        myMonsterAnimator.SetBool(MonsterState.WALK.ToString(), false);
        myMonsterAnimator.SetBool(MonsterState.ATTACK.ToString(), false);
        myMonsterAnimator.SetBool(MonsterState.ATTACKED.ToString(), false);
        myMonsterAnimator.SetBool(MonsterState.DEAD.ToString(), false);

        if (nowState == MonsterState.IDLE)
        {
            //Debug.Log(MonsterState.IDLE.ToString() + ":true");
            myMonsterAnimator.SetBool(MonsterState.IDLE.ToString(), true);
        }
        if (nowState == MonsterState.WALK)
        {
            //Debug.Log(MonsterState.WALK.ToString() + ":true");
            myMonsterAnimator.SetBool(MonsterState.WALK.ToString(), true);
        }
        if (nowState == MonsterState.ATTACK)
        {
            //Debug.Log(MonsterState.ATTACK.ToString() + ":true");
            myMonsterAnimator.SetBool(MonsterState.ATTACK.ToString(), true);
        }
        if (nowState == MonsterState.ATTACKED)
        {
            //Debug.Log(MonsterState.ATTACKED.ToString() + ":true");
            myMonsterAnimator.SetBool(MonsterState.ATTACKED.ToString(), true);
        }
        if (nowState == MonsterState.DEAD)
        {
            //Debug.Log(MonsterState.DEAD.ToString() + ":true");
            myMonsterAnimator.SetBool(MonsterState.DEAD.ToString(), true);
        }
    }

    #endregion

    #region MonsterHitWeapon

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Skill") //Skill만 하면 되나?
        {
            Debug.Log("OnCollision / SKill에 맞았어요");
            //MonsterHitWeapon(PlayerObject.GetComponent<PlayerStatus>().power);  //플레이어 데미지만 가져옴
            MonsterHitWeapon(collision.gameObject.GetComponent<SkillEffect.PiercingSpear>().power); //스킬 고유 데미지
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Skill") //Skill만 하면 되나?
        {
            Debug.Log("OnTrigger / SKill에 맞았어요");
            //MonsterHitWeapon(PlayerObject.GetComponent<PlayerStatus>().power);  //플레이어 데미지만 가져옴
            MonsterHitWeapon(collision.gameObject.GetComponent<SkillEffect.PiercingSpear>().power); //스킬 고유 데미지
        }
    }

    public virtual void MonsterHitWeapon(int power)
    {
        Debug.Log("맞았음");
        isDamaged = true;
        AnimationStateSet(MonsterState.ATTACKED);
        myMonsterInfo.monsterHp -= power;//bW.power;
                                         //맞고 밀려남
        int dirt = (gameObject.transform.position.x - PlayerObject.transform.position.x > 0) ? 1 : -1;
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(dirt, 1) * 6, ForceMode2D.Impulse);

        //Player의 무기/스킬/함정에 접촉 처리.
        //데미지 만큼 myMonsterInfo.monsterHp 깎음
        //자폭 몬스터 있나?..
        //Base_Weapon bW = col.gameObject.GetComponent<Base_Weapon>();
        if (myMonsterInfo.monsterHp > 0)
        {
            Invoke("ResetIsAttacked", 1f);
        }
        else
        {
            //중복방지
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            //Debug.Log(name + "Dead");
            myMonsterInfo.monsterHp = 0;
            DeadProcess();
        }
    }

    public void ResetIsAttacked()
    {
        isDamaged = false;
        //공격받은 애니메이션 끝남
        AnimationStateSet(MonsterState.IDLE);
    }

    #endregion

    #region About Dead

    public void DropGoldAndItems()
    {
        if (!alreadyDropObjects)
        {
            alreadyDropObjects = true;
            //-----------------------------------골드 드랍-----------------------------------
            DroppedGoldOrCrystal gold = Instantiate(DropGoldObject).GetComponent<DroppedGoldOrCrystal>();

            int mDropGold = myMonsterInfo.monsterDropGoldAmount;
            gold.GoldAmount = Random.Range((int)(mDropGold * 0.7), (int)(mDropGold * 1.2));                      // (몬스터 골드량의 70%) ~ (몬스터의 골드량 120%)을 전달 함.
            gold.name = myMonsterInfo.monsterName + " 드롭 골드량:" + gold;

            int ranX = Random.Range(-100, 101);     //min ~ max-1
            int ranY = Random.Range(100, 201);      //min ~ max-1
            gold.transform.position = GetComponent<Transform>().position;
            gold.GetComponent<Rigidbody2D>().AddForce(new Vector3(ranX, ranY, 0));              //위 방향으로 랜덤 발사

            //-------------------------보스일 때 확률적으로 아이템 드랍 & 크리스탈 드랍-------------------------
            if (myMonsterInfo.isBoss)
            {
                if (Random.Range(0, 101)/*0~100*/ <= myMonsterInfo.monsterDropRate)
                {
                    DropItem();
                }
                if (Random.Range(0, 101) <= 30)    //30% 확률
                {

                }
            }
        }
    }

    public virtual void DropItem() //Only Boss!
    {
        //어떤 식으로든 아이템에게 아이템 달라고 요청. 그 후 생성 및 뿌림.

        //----------------아래 이야기는 보류----------------
        //아이템 클래스에게 MonsterCode를 넘김 
        //아이템 클래스에서 그 MonsterCode에 맞는 아이템을 뿌림. (아이템이 MonsterCode 소지하고 있음.)
    }

    public void DeadProcess()
    {
        //죽는 애니메이션과 동시에 아이템 드롭. 그 후 사라짐
        AnimationStateSet(MonsterState.DEAD);
        DropGoldAndItems();
        //퀘스트에 해당하는 몬스터 일 시
        quest.QuestMonsterCheck(myMonsterCode);
        //만약 OM, TM이 아니라면 (일반몹이라면)
        if ((int)myMonsterCode < (int)MonsterCode.OM401)
            dungeonManager.MonsterDestroyProcessing(myMonsterCode);
        Invoke("Dead", 2f);
    }

    public void Dead()
    {
        //몬스터가 다 죽었을 때 문이 열리도록 하는 친구에게 보고하기.
        //Quest 쪽에도 알려주기.
        //펑!하고 사라져야함.(Effect)

        Destroy(this.gameObject);
    }

    #endregion
}
