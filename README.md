# AdvBarStory

- 2023-02-13 Init Set, Town, Stage1 제작
- 2023-02-14 PlayerMove 제작, Portal 제작, 카메라 무브
- 2023-02-15 TitleScene 제작, Game Opening 제작

issue : 대화 스크립트 관리를 어떻게 관리 할 것인가?

solution : CSV or JSON을 활용할 수 있을것으로 보임. 우선은 CSV를 통해 관리를 하도록 함

- 2023-02-16 UI 및 인벤토리 제작

issue : 스크립터블 오브젝트를 생성 후 이를 리스트로 관리하려고 시도

  이 아이템의 amount 변수를 게임 동작하며 수정 시 게임 종료 후에도 원본의 데이터가 수정된 채로 남아있는 문제

  solution : item에서 amount를 제거, 아이템의 amount를 List<int> itemAmount를 새롭게 생성해 관리.

  haveItems의 index와 itemAmount의 index를 동일하게 1 : 1 매칭시켜서 관리하며, 이는 item Slot에도 정보를 저장해 둠

- 2023-02-17 Stage1 Portal 세팅, 아이템 tag에 따른 인벤토리 목록별 출력 구현
- 2023-02-19 Stage1 및 Battle Field Set
- 2023-02-20 Battle Create 중
  
  issue : OK 및 Back, Cancel 버튼의 구현에 대해 설계를 어떻게 할 것인가
  
  플레이어의 턴마다의 동작, 상정의 아이템 구입 등 OK 및 Back, Cancel 버튼이 주로 사용된다.
  
  그러나 이것은 각각의 상황에 따라 동작이 다르다.
  
  이에 대한 구현을 어떤 방식으로 설계해야 하는가?
  
  solution : delegate를 통한 해결을 생각중에 있음
  
  클릭시 메서드를 연결시키며, cancel 혹은 back 버튼을 클릭 시 동작 후 연결을 해제하는 방법을 구상 중.

- 2023-02-21 Simple Battle Create. 매우 간단한 로직의 전투 구현

  3종류의 몬스터를 2~4의 랜덤한 숫자로 생성. 및 턴 회복속도에 따른 순차적 동작을 확인

- 2023-02-22 Build 과정에서 오류 발생

issue : Script updater for Library\Bee\artifacts\1900b0aP.dag\Assembly-CSharp.dll failed to produce updates.txt file 라는 에러 발생

summary : editor 에러로 추정. 확인 결과 Animations라는 이름의 namespace를 찾지 못해 발생하는 에러

AnimatorController 클래스를 사용하기 위해 using Animations를 하였으나, 이를 찾이 못해 발생한 에러.

solution : Library 폴더를 삭제 후 editor 재실행, 경로에 특수문자가 존재시 이를 제거.

이것이 전부 동작하지 않아, AnimationController 대신 RuntimeAnimationController로 수정. 성공

- 2023-02-23 Inventory 구조 수정 작업.

아이템을 카테고리 별로 분류 -> 카테고리별 리스트를 만들어 Inventory가 관리하도록 변경
  
- 2023-02-24 Recipe UI & Recipe 조합 설계
- 2023-02-26 Recipe를 활용한 Food 생성 기능 구현
- 2023-02-27 Battle System UI 개선, 시스템 일부 개선
  issue : Player의 Attack이 중복 적용되던 문제
  
  summary : PlayerManager에 존재하는 PlayerAction event의 reset을 해주지 않았던 것으로 추정.
  
  그 결과 Attack을 실행할 때 마다 PlayerAction event에 중복적으로 Attack이 연결되었을 것임
  
  PlayerManager.ActionReset()이 필요할 것으로 보임
  
  Solution : PlayerManager.ActionReset() -> PlayerAction = default로 변경을 적용하니 정상적으로 동작함을 확인.

- 2023-02-28 플레이어 스킬 구현

issue : 플레이어의 스킬이 연속 선택된 적에게 동작하지 않는 현상 발견

summary : 로그 분석 결과 행동 도중 character마다 들고 있던 onTileData가 소실되는 문제를 확인

마찬가지로 Tile이 들고 있는 onTileObject 역시 소실됨

onTileData는 Tile과 충돌하는 오브젝트가 있을 시 등록 되므로, 몬스터와 플레이어가 배틀 필드에 세팅 시, 이들을 등록하도록 설계함

solution : 확인 결과 skill을 사용 할 경우 발생하는 것이 로그로 발견됨.

이유는 skill의 effect object가 타일과 충돌하며, 일정 시간 후 사라지면서 onTileData를 지워 버린 것

skill의 effect object에 tag를 Effect로 전부 통일. BattleTile은 tag가 Effect일 시 충돌을 무시하도록 코드를 수정

- 2023-03-01 Popup UI 구현, 장비 장착 기능 구현

issue : Equip을 장착 시 아이템의 재고가 0이 되어도 표시되는 버그, 아이템을 해제시 장비가 복사되는 버그가 발생

summary : Equip의 해제 과정에서 플레이어의 현재 아이템 장착 여부를 확인하지만, 이 부분이 잘못 되었을 것으로 예상. 이로 인해 복사버그 발생

재고가 0이 되어도 사라지지 않는 현상, UseItem에서 처리를 못하고 있을 것으로 예상.

solution : Log 검사 결과 장비 복사 버그의 경우 플레이어의 현재 장비 슬롯이 null인가 확인하는 과정이 있음

하지만 이보다 먼저 Equip 슬롯에 장착시켜 버려, 장착 과정에서 오류가 발생함

왜냐하면 슬롯이 비었을 경우 EquipEquipment 함수만 호출하나, 그것이 아닐 시 EquipDismount를 하여, 그 장비의 갯수를 증가시킴

원래는 null 일시 장비 재고 감소 -> 장착의 과정이나 슬롯 갱신 -> Dismount로 재고 증가 -> 장착 -> 재고 감소의 과정이 된 것

이로인해 아이템 복사 버그와 내 예상과 달리 inventory에서 재고가 0이 되지 않고 있었음

해당 로직의 서순을 수정해 해결함