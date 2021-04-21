# Welcome to the 'simsimtalk' 

### This is C# toy project.<br>
* coded in 2017.05
* Window 
* Visual Studio 2015 
* MS-SQL
* Server-Client

### 네트워크 통신방식<br>
1. 소켓 통신: Server와 Client가 특정 포트를 통해 연결을 성립하고 있는 실시간 양방향 통신<br>
(예) Android, iOS
<br><br>
2. HTTP 통신: Client가 요청을 보내는 경우에만 Server가 응답하는 단방향 통신<br>
(예) 스트리밍 서비스, 온라인 게임
<br><br>

### 전송 계층의 프로토콜(Transport Layer)<br>
- TCP(Transmission Control Protocol)
- UDP(User Datagram Protocol)

1. TCP: 인터넷상에서 데이터를 메시지 형태로 보내기 위해 IP와 함께 사용하는 프로토콜<br>
        >> 연결형 서비스, 높은 신뢰성, 상대적으로 느린 속도, 수신 여부 확인, 전송 순서 보장<br>
           ==> 연속성보다 신뢰성 있는 전송<br>
        >> if TCP Server, 서버-클라이언트(1:1)<br>
2. UDP: 데이터를 데이터그램 단위로 처리하는 프로토콜<br>
        >> 비연결형 서비스, 낮은 신뢰성, 상대적으로 빠른 속도, 수신 여부 비확인, 전송 순서 비보장<br> 
           ==> 신뢰성 보다 연속성이 있는 전송<br>
        >> if UDP Server, 서버-클라이언트(1:1, 1:N, N:M)<br>
