# 15GGProject

공룡 런

스페이스 바 : 점프
왼쪽 컨트롤 : 슬라이드
G : 캐릭터 속성 바꾸기
좌클릭 : 해당 에임으로 투사체 발사(공격)

게임 소개 : 각 스테이지에 등장하는 장애물과 구조물을 피하며 점수를 획득하는 게임이다. 

- 속도 감소 아이템, 체력 회복 아이템을 활용하여 게임을 진행할 수 있다. 
- 캐릭터와 장애물에 불 혹은 얼음의 속성이 부여된다. 캐릭터는 반대 속성의 장애물에 피격될 시 데미지를 입는다.
- 캐릭터가 장애물에게 공격을 하면 장애물이 파괴된다. 장애물은 종류에 따라 체력이 다르다.

개발환경

- Unity 2022.3.17f
- C#
- GitHub

프로젝트 구조

15GG_Project/

<pre><code>15GG_Project/ ├── Prefabs/ # 프리팹 리소스 폴더 │ ├── 0514Test/ # 테스트용 프리팹 모음 │ ├── Maps/ # 맵 프리팹 모음 │ │ ├── Bridge01 │ │ └── Map01~11 │ ├── Obstacle/ # 장애물 프리팹 폴더 │ └── Item/ # 아이템 프리팹 폴더 │ ├── Item_Heal.prefab │ ├── Item_Score.prefab │ └── Item_Speed.prefab │ ├── Scripts/ # 스크립트 폴더 │ ├── Data/ # 데이터 구조체, enum │ │ ├── ItemDate.cs │ │ └── ItemType.cs │ └── Item/ # 아이템 관련 클래스 │ ├── BaseItem.cs # 아이템 추상 클래스 │ ├── SpeedItem.cs # 속도 증가 아이템 │ ├── HealItem.cs # 체력 회복 아이템 │ └── ScoreItem.cs # 점수 증가 아이템 </code></pre>
