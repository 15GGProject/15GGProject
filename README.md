# 15GGProject

# 🎮 공룡 런

스페이스 바 : 점프
왼쪽 컨트롤 : 슬라이드
G : 캐릭터 속성 바꾸기
좌클릭 : 해당 에임으로 투사체 발사(공격)

게임 소개 : 각 스테이지에 등장하는 **장애물과 구조물을 피하며 점수를 획득하는 게임**이다. 

- 속도 감소 아이템, 체력 회복 아이템을 활용하여 게임을 진행할 수 있다. 
- 캐릭터와 장애물에 불 혹은 얼음의 속성이 부여된다. 캐릭터는 반대 속성의 장애물에 피격될 시 데미지를 입는다.
- 캐릭터가 장애물에게 공격을 하면 장애물이 파괴된다. 장애물은 종류에 따라 체력이 다르다.

# 🛠️ 개발환경

- `Unity 2022.3.17f`
- `C#`
- `GitHub`

# 📂 프로젝트 구조

```
15GG_Project/
├── Prefabs/                     # 프리팹 리소스 폴더
│   ├── 0514Test/                # 테스트용 프리팹 모음
│   ├── Maps/
│   │   ├── Bridge01
│   │   ├── Map01~11
│   ├── Obstacle/
│   ├── item/                    # 장애물 프리팹을 담은 폴더
│   │   ├── Item_Heal.prefab
│   │   ├── Item_Score.prefab
│   │   └── Item_Heal.prefab
│
├── Scripts/                     # 스크립트
│   ├── Data/                    # 데이터 관련 구조체, enum
│   │   ├── ItemDate.cs
│   │   └── ItemType.cs
│
│   ├── Item/                    # 아이템 관련 클래스
│   │   ├── BaseItem.cs          # 아이템 추상 클래스
│   │   ├── SpeedItem.cs         # 속도 증가 아이템
│   │   ├── HealItem.cs          # 체력 회복 아이템
│   │   └── ScoreItem.cs         # 점수 증가 아이템
│
│   ├── Ui/                      # UI 관련 스크립트
│   │   ├── GameOver_UI.cs
│   │   ├── HomeUI.cs
│   │   ├── IngameUI.cs
│   │   └── MenuUI.cs
│
│   ├── Camera/
│   │   └── FollowCamera.cs      # 플레이어 추적 카메라
│
│   ├── Util/
│   │   └── GameEnum.cs          # 아이템 타입 등 열거형 정의
│
│   ├── Core & 기능별 스크립트
│   │   ├── BaseController.cs    # 플레이어 기반 추상 스크립트
│   │   ├── Bglooper.cs          # 배경 루프 스크립트
│   │   ├── Bullet.cs            # 발사체
│   │   ├── Elemental.cs         # 속성 변경
│   │   ├── FollowCamera.cs      # 카메라 추적
│   │   ├── FollowObstacleSpn.cs # 장애물 스폰
│   │   ├── GamaManager.cs       # 게임 상태 관리(싱글턴)
│   │   ├── Map.cs
│   │   ├── Obstacle.cs
│   │   ├── ObstacleHandler.cs
│   │   ├── ObstacleSpawner.cs
│   │   ├── Player.cs
│   │   ├── PoolManager.cs
│   │   ├── Score.cs
│   │   ├── StartButton.cs
│
├── Scenes/
│   ├── Main.unity               # 메인 게임 씬
│   └── InGame.unity             # 인게임 진행 씬
```
# 🎯 주요 기능

- 캐릭터 이동 및 점프 구현
- 속도/체력/점수 아이템 획득 처리
- 장애물 충돌 시 반응 및 속성 상성 처리
- 게임 UI (점수, 체력 등) 실시간 표시
- 배경 루프 및 맵 구성

# 📌 게임 예시 화면

## 🎮 게임 플레이 영상

[![게임 플레이 썸네일](https://img.youtube.com/vi/8fxAkkarwG0/0.jpg)](https://youtu.be/8fxAkkarwG0)



