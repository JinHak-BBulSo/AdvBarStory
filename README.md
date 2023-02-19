# AdvBarStory

- 2023-02-13 Init Set, Town, Stage1 제작
- 2023-02-14 PlayerMove 제작, Portal 제작, 카메라 무브
- 2023-02-15 TitleScene 제작, Game Opening 제작

issue : 대화 스크립트 관리를 어떻게 관리 할 것인가?


solution : CSV를 통해 관리


- 2023-02-16 UI 및 인벤토리 제작

issue : 스크립터블 오브젝트를 생성 후 이를 리스트로 관리하려고 시도

이 아이템의 amount 변수를 게임 동작하며 수정 시 게임 종료 후에도 원본의 데이터가 수정된 채로 남아있는 문제

solution : item에서 amount를 제거, 아이템의 amount를 List<int> itemAmount를 새롭게 생성해 관리.

haveItems의 index와 itemAmount의 index를 동일하게 1 : 1 매칭시켜서 관리하며, 이는 item Slot에도 정보를 저장해 둠

- 2023-02-17 Stage1 Portal 세팅, 아이템 tag에 따른 인벤토리 목록별 출력 구현

- 2023-02-19 Stage1 및 Battle Field Set